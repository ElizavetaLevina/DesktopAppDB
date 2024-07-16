using System.Data;
using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

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
            UpdateComboBox();
            UpdateTable();
            comboBoxCalculationByDate.SelectedIndex = 0;
            int[] percent = [60, 40];
            for(int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }
        }

        private void UpdateComboBox()
        {
            orderDTO = orderRepository.GetOrdersForComboBoxSalaries();
            foreach(var order in orderDTO)
            {
                if(comboBoxYears.Items.IndexOf(order.DateCompleted?.Year) < 0)
                    comboBoxYears.Items.Add(order.DateCompleted?.Year);
            }

            if (comboBoxYears.Items.IndexOf(DateTime.Now.Year) < 0)
                comboBoxYears.Items.Add(DateTime.Now.Year);

            comboBoxYears.SelectedIndex = 0;
        }

        private int CheckMonth()
        {
            int numberMonth = 0;

            var checkedButton = panel1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            switch (checkedButton?.Text)
            {
                case "Январь":
                    numberMonth = 1;
                    break;
                case "Февраль":
                    numberMonth = 2;
                    break;
                case "Март":
                    numberMonth = 3;
                    break;
                case "Апрель":
                    numberMonth = 4;
                    break;
                case "Май":
                    numberMonth = 5;
                    break;
                case "Июнь":
                    numberMonth = 6;
                    break;
                case "Июль":
                    numberMonth = 7;
                    break;
                case "Август":
                    numberMonth = 8;
                    break;
                case "Сентябрь":
                    numberMonth = 9;
                    break;
                case "Октябрь":
                    numberMonth = 10;
                    break;
                case "Ноябрь":
                    numberMonth = 11;
                    break;
                case "Декабрь":
                    numberMonth = 12;
                    break;
            }
            return numberMonth;
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
            orderDTO = orderRepository.GetOrdersForSalaries();
            var masterDTO = masterRepository.GetMasters();
            var malfunctionOrderDTO = malfunctionOrderRepository.GetMalfunctionOrders();

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
                        

                        if (monthCompleted == CheckMonth() && yearCompleted == Convert.ToInt32(comboBoxYears.Text)
                            && (monthReturn != CheckMonth() || yearReturn != Convert.ToInt32(comboBoxYears.Text)))
                        {
                            for(int k = 0; k < malfunctionOrderDTO.Count; k++)
                            {
                                if (malfunctionOrderDTO[k].OrderId == orderDTO[j].Id)
                                {
                                    salary += malfunctionOrderDTO[k].Price;
                                }
                            }

                            
                        }
                        else if (monthReturn == CheckMonth() && yearReturn == Convert.ToInt32(comboBoxYears.Text) &&
                            (monthCompleted != CheckMonth() || yearCompleted != Convert.ToInt32(comboBoxYears.Text)))
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
                        
                        
                        if (monthCompleted == CheckMonth() && yearCompleted == Convert.ToInt32(comboBoxYears.Text))
                        {
                            if (masterDTO[i].TypeSalary == "percentOrganization")
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
                                   if (masterDTO[i].TypeSalary == "percentMaster")
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
                if (masterDTO[i].TypeSalary == "rate")
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
