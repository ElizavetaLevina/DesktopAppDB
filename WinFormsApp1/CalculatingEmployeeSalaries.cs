using WinFormsApp1.DTO;
using WinFormsApp1.Repository;
using WinFormsApp1.Enum;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class CalculatingEmployeeSalaries : Form
    {
        List<OrderEditDTO> ordersDTO;
        OrderRepository orderRepository = new();
        MasterRepository masterRepository = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();
        public CalculatingEmployeeSalaries()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            comboBoxCalculationByDate.DataSource = System.Enum.GetValues(typeof(SalaryCalculationByEnum));

            List<int> years = new();
            int startYear = 2023;
            int endYear = DateTime.Now.Year + 1;

            for (int i = 0; i <= endYear - startYear; i++)
            {
                years.Add(startYear + i);
            }
            comboBoxYears.DataSource = years;
            comboBoxYears.SelectedItem = DateTime.Now.Year;
        }

        private int NumberSelectedMonth()
        {
            var selectedRadioButton = panel1.Controls.OfType<RadioButton>().First(r => r.Checked);
            var selectedMonthEnum = (MonthEnum)System.Enum.Parse(typeof(MonthEnum), selectedRadioButton.Text);

            return (int)selectedMonthEnum;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();

        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void RadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            int[] percent = [30, 20, 50];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }



            SalaryCalculation();



            ordersDTO = orderRepository.GetOrdersForSalaries();
            var masterDTO = masterRepository.GetMasters();
            var malfunctionOrderDTO = malfunctionOrderRepository.GetMalfunctionOrders();


            dataGridView1.Rows.Clear();




            /*for (int i = 0; i < masterDTO.Count; i++)
            {
                int salary = 0;
                for (int j = 0; j < ordersDTO.Count; j++)
                {
                    if (ordersDTO[j].ReturnUnderGuarantee)
                    {
                        int? monthReturn = ordersDTO[j].DateCreation?.Month;
                        int? yearReturn = ordersDTO[j].DateCreation?.Year;
                        int? monthCompleted = ordersDTO[j].DateCompleted?.Month;
                        int? yearCompleted = ordersDTO[j].DateCompleted?.Year;
                        if(comboBoxCalculationByDate.SelectedIndex == 0)
                        {
                            if (ordersDTO[j].DateCompletedReturn != null)
                            {
                                monthCompleted = ordersDTO[j].DateCompletedReturn?.Month;
                                yearCompleted = ordersDTO[j].DateCompletedReturn?.Year;
                            }
                        }
                        else
                        {
                            if (!ordersDTO[j].Issue) 
                            {
                                monthCompleted = 0;
                                yearCompleted = 0;
                            }

                            if (ordersDTO[j].DateIssueReturn == null)
                            {
                                monthCompleted = ordersDTO[j].DateIssue?.Month;
                                yearCompleted = ordersDTO[j].DateIssue?.Year;
                            }
                            else
                            {
                                monthCompleted = ordersDTO[j].DateIssueReturn?.Month;
                                yearCompleted = ordersDTO[j].DateIssueReturn?.Year;
                            }
                        }
                        

                        if (monthCompleted == NumberSelectedMonth() && yearCompleted == Convert.ToInt32(comboBoxYears.Text)
                            && (monthReturn != NumberSelectedMonth() || yearReturn != Convert.ToInt32(comboBoxYears.Text)))
                        {
                            for(int k = 0; k < malfunctionOrderDTO.Count; k++)
                            {
                                if (malfunctionOrderDTO[k].OrderId == ordersDTO[j].Id)
                                {
                                    salary += malfunctionOrderDTO[k].Price;
                                }
                            }

                            
                        }
                        else if (monthReturn == NumberSelectedMonth() && yearReturn == Convert.ToInt32(comboBoxYears.Text) &&
                            (monthCompleted != NumberSelectedMonth() || yearCompleted != Convert.ToInt32(comboBoxYears.Text)))
                        {
                            if (ordersDTO[j].InProgress)
                            {
                                for (int k = 0; k < malfunctionOrderDTO.Count; k++)
                                {
                                    if (malfunctionOrderDTO[k].OrderId == ordersDTO[j].Id)
                                    {
                                        salary -= malfunctionOrderDTO[k].Price;
                                    }
                                }
                            }
                        }
                    }
                    else if (!ordersDTO[j].InProgress)
                    {
                        int? monthCompleted = ordersDTO[j].DateCompleted?.Month;
                        int? yearCompleted = ordersDTO[j].DateCompleted?.Year;

                        if (comboBoxCalculationByDate.SelectedIndex == 1)
                        {
                            if (!ordersDTO[j].Issue)
                            {
                                monthCompleted = 0;
                                yearCompleted = 0;
                            } else
                            {
                                monthCompleted = ordersDTO[j].DateIssue?.Month;
                                yearCompleted = ordersDTO[j].DateIssue?.Year;
                            }
                        }
                        
                        
                        if (monthCompleted == NumberSelectedMonth() && yearCompleted == Convert.ToInt32(comboBoxYears.Text))
                        {
                            if (masterDTO[i].TypeSalary == TypeSalaryEnum.percentOrganization.ToString())
                            {
                                for (int k = 0; k < malfunctionOrderDTO.Count; k++)
                                {
                                    if (malfunctionOrderDTO[k].OrderId == ordersDTO[j].Id)
                                    {
                                        salary += malfunctionOrderDTO[k].Price;
                                    }
                                }
                            }
                            else
                            {
                                if (ordersDTO[j].MainMasterId == masterDTO[i].Id)
                                {
                                   if (masterDTO[i].TypeSalary == TypeSalaryEnum.percentMaster.ToString())
                                    {
                                        for (int k = 0; k < malfunctionOrderDTO.Count; k++)
                                        {
                                            if (malfunctionOrderDTO[k].OrderId == ordersDTO[j].Id)
                                            {
                                                salary += malfunctionOrderDTO[k].Price;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (masterDTO[i].TypeSalary == TypeSalaryEnum.rate.ToString())
                    dataGridView1.Rows.Add(masterDTO[i].NameMaster, masterDTO[i].Rate);
                else
                    dataGridView1.Rows.Add(masterDTO[i].NameMaster, masterDTO[i].Rate / 100.0 * salary);
            }*/
        }

        private void SalaryCalculation()
        {
            DateTime? dateCompleted = null;
            DateTime? dateIssue = null;

            if ((SalaryCalculationByEnum)comboBoxCalculationByDate.SelectedItem == SalaryCalculationByEnum.выполнения)
                dateCompleted = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, NumberSelectedMonth(), comboBoxYears.SelectedValue));
            else
                dateIssue = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, NumberSelectedMonth(), comboBoxYears.SelectedValue));

            // все завершённые заказы, с учётов вернувшихся по гараниии
            ordersDTO = orderRepository.GetOrdersForSalaries(dateCompleted: dateCompleted, dateIssue: dateIssue);
            // общая прибыль, расчитывается как сумма всех завершённых заказов за вычетом вернувшихся по гарантии
            var sumOrders = ordersDTO.Where(o => o.ReturnUnderGuarantee == false).Sum(o => o.MalfunctionOrders.Sum(m => m.Price));
            var mastersDTO = masterRepository.GetMasters();


        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBoxCalculationByDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
