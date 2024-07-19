using WinFormsApp1.DTO;
using WinFormsApp1.Repository;
using WinFormsApp1.Enum;

namespace WinFormsApp1
{
    public partial class CalculatingEmployeeSalaries : Form
    {
        List<OrderEditDTO> orderDTO;
        OrderRepository orderRepository = new();
        MasterRepository masterRepository = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();
        public CalculatingEmployeeSalaries()
        {
            InitializeComponent();
            InitializeElementsForm();            
        }

        private void InitializeElementsForm()
        {
            UpdateTable();
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            List<string> calculationBy = ["дате выполнения", "дате выдачи"];
            comboBoxCalculationByDate.DataSource = calculationBy;

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
            int[] percent = [60, 40];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }


            orderDTO = orderRepository.GetOrdersForSalaries();
            var masterDTO = masterRepository.GetMasters();
            var malfunctionOrderDTO = malfunctionOrderRepository.GetMalfunctionOrders();
            var radioButton = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            dataGridView1.Rows.Clear();

            for (int i = 0; i < masterDTO.Count; i++)
            {
                int salary = 0;
                for (int j = 0; j < orderDTO.Count; j++)
                {
                    if (orderDTO[j].ReturnUnderGuarantee)
                    {
                        int? monthReturn = orderDTO[j].DateCreation?.Month;
                        int? yearReturn = orderDTO[j].DateCreation?.Year;
                        int? monthCompleted = orderDTO[j].DateCompleted?.Month;
                        int? yearCompleted = orderDTO[j].DateCompleted?.Year;
                        if(comboBoxCalculationByDate.SelectedIndex == 0)
                        {
                            if (orderDTO[j].DateCompletedReturn != null)
                            {
                                monthCompleted = orderDTO[j].DateCompletedReturn?.Month;
                                yearCompleted = orderDTO[j].DateCompletedReturn?.Year;
                            }
                        }
                        else
                        {
                            if (!orderDTO[j].Issue) 
                            {
                                monthCompleted = 0;
                                yearCompleted = 0;
                            }

                            if (orderDTO[j].DateIssueReturn == null)
                            {
                                monthCompleted = orderDTO[j].DateIssue?.Month;
                                yearCompleted = orderDTO[j].DateIssue?.Year;
                            }
                            else
                            {
                                monthCompleted = orderDTO[j].DateIssueReturn?.Month;
                                yearCompleted = orderDTO[j].DateIssueReturn?.Year;
                            }
                        }
                        

                        if (monthCompleted == NumberSelectedMonth() && yearCompleted == Convert.ToInt32(comboBoxYears.Text)
                            && (monthReturn != NumberSelectedMonth() || yearReturn != Convert.ToInt32(comboBoxYears.Text)))
                        {
                            for(int k = 0; k < malfunctionOrderDTO.Count; k++)
                            {
                                if (malfunctionOrderDTO[k].OrderId == orderDTO[j].Id)
                                {
                                    salary += malfunctionOrderDTO[k].Price;
                                }
                            }

                            
                        }
                        else if (monthReturn == NumberSelectedMonth() && yearReturn == Convert.ToInt32(comboBoxYears.Text) &&
                            (monthCompleted != NumberSelectedMonth() || yearCompleted != Convert.ToInt32(comboBoxYears.Text)))
                        {
                            if (orderDTO[j].InProgress)
                            {
                                for (int k = 0; k < malfunctionOrderDTO.Count; k++)
                                {
                                    if (malfunctionOrderDTO[k].OrderId == orderDTO[j].Id)
                                    {
                                        salary -= malfunctionOrderDTO[k].Price;
                                    }
                                }
                            }
                        }
                    }
                    else if (!orderDTO[j].InProgress)
                    {
                        int? monthCompleted = orderDTO[j].DateCompleted?.Month;
                        int? yearCompleted = orderDTO[j].DateCompleted?.Year;

                        if (comboBoxCalculationByDate.SelectedIndex == 1)
                        {
                            if (!orderDTO[j].Issue)
                            {
                                monthCompleted = 0;
                                yearCompleted = 0;
                            } else
                            {
                                monthCompleted = orderDTO[j].DateIssue?.Month;
                                yearCompleted = orderDTO[j].DateIssue?.Year;
                            }
                        }
                        
                        
                        if (monthCompleted == NumberSelectedMonth() && yearCompleted == Convert.ToInt32(comboBoxYears.Text))
                        {
                            if (masterDTO[i].TypeSalary == TypeSalaryEnum.percentOrganization.ToString())
                            {
                                for (int k = 0; k < malfunctionOrderDTO.Count; k++)
                                {
                                    if (malfunctionOrderDTO[k].OrderId == orderDTO[j].Id)
                                    {
                                        salary += malfunctionOrderDTO[k].Price;
                                    }
                                }
                            }
                            else
                            {
                                if (orderDTO[j].MainMasterId == masterDTO[i].Id)
                                {
                                   if (masterDTO[i].TypeSalary == TypeSalaryEnum.percentMaster.ToString())
                                    {
                                        for (int k = 0; k < malfunctionOrderDTO.Count; k++)
                                        {
                                            if (malfunctionOrderDTO[k].OrderId == orderDTO[j].Id)
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
            }
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
