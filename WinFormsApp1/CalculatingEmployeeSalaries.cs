using System.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class CalculatingEmployeeSalaries : Form
    {
        public CalculatingEmployeeSalaries()
        {
            InitializeComponent();
            UpdateComboBox();
            UpdateTable();
            comboBox1.SelectedIndex = 0;
            int[] percent = [60, 40];
            for(int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }
        }

        private void UpdateComboBox()
        {
            Context context = new();
            var list = context.Orders.Where(i => !i.InProgress).Select(i => new { i.DateCompleted }).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (comboBoxYears.Items.IndexOf(list[i].DateCompleted.Value.Year) < 0)
                {
                    comboBoxYears.Items.Add(list[i].DateCompleted.Value.Year);
                }
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

            switch (checkedButton.Text)
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
            Context context = new();
            var list = context.Orders.Where(i => !i.Deleted && (!i.InProgress ||
            i.ReturnUnderGuarantee)).ToList();
            var listMasters = context.Masters.ToList();
            var listPriceRepair = context.MalfunctionOrders.ToList();

            /*int countOrders = 0;
            int profit = 0;
            int countCompletedOrders = 0;*/

            dataGridView1.Rows.Clear();

            for (int i = 0; i < listMasters.Count; i++)
            {
                int salary = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j].ReturnUnderGuarantee)
                    {
                        int monthReturn = list[j].DateCreation.Value.Month;
                        int yearReturn = list[j].DateCreation.Value.Year;
                        int monthCompleted = list[j].DateCompleted.Value.Month;
                        int yearCompleted = list[j].DateCompleted.Value.Year;
                        if(comboBox1.SelectedIndex == 0)
                        {
                            if (list[j].DateCompletedReturn != null)
                            {
                                monthCompleted = list[j].DateCompletedReturn.Value.Month;
                                yearCompleted = list[j].DateCompletedReturn.Value.Year;
                            }
                        }
                        else
                        {
                            if (!list[j].Issue) 
                            {
                                monthCompleted = 0;
                                yearCompleted = 0;
                            }

                            if (list[j].DateIssueReturn == null)
                            {
                                monthCompleted = list[j].DateIssue.Value.Month;
                                yearCompleted = list[j].DateIssue.Value.Year;
                            }
                            else
                            {
                                monthCompleted = list[j].DateIssueReturn.Value.Month;
                                yearCompleted = list[j].DateIssueReturn.Value.Year;
                            }
                        }
                        

                        if (monthCompleted == CheckMonth() && yearCompleted == Convert.ToInt32(comboBoxYears.Text)
                            && (monthReturn != CheckMonth() || yearReturn != Convert.ToInt32(comboBoxYears.Text)))
                        {
                            for(int k = 0; k < listPriceRepair.Count; k++)
                            {
                                if (listPriceRepair[k].OrderId == list[j].Id)
                                {
                                    salary += listPriceRepair[k].Price;
                                }
                            }

                            
                        }
                        else if (monthReturn == CheckMonth() && yearReturn == Convert.ToInt32(comboBoxYears.Text) &&
                            (monthCompleted != CheckMonth() || yearCompleted != Convert.ToInt32(comboBoxYears.Text)))
                        {
                            if (list[j].InProgress)
                            {
                                for (int k = 0; k < listPriceRepair.Count; k++)
                                {
                                    if (listPriceRepair[k].OrderId == list[j].Id)
                                    {
                                        salary -= listPriceRepair[k].Price;
                                    }
                                }
                            }
                        }
                    }
                    else if (!list[j].InProgress)
                    {
                        int monthCompleted = list[j].DateCompleted.Value.Month;
                        int yearCompleted = list[j].DateCompleted.Value.Year;

                        if (comboBox1.SelectedIndex == 1)
                        {
                            if (!list[j].Issue)
                            {
                                monthCompleted = 0;
                                yearCompleted = 0;
                            } else
                            {
                                monthCompleted = list[j].DateIssue.Value.Month;
                                yearCompleted = list[j].DateIssue.Value.Year;
                            }
                        }
                        
                        
                        if (monthCompleted == CheckMonth() && yearCompleted == Convert.ToInt32(comboBoxYears.Text))
                        {
                            if (listMasters[i].TypeSalary == "percentOrganization")
                            {
                                for (int k = 0; k < listPriceRepair.Count; k++)
                                {
                                    if (listPriceRepair[k].OrderId == list[j].Id)
                                    {
                                        salary += listPriceRepair[k].Price;
                                    }
                                }
                            }
                            else
                            {
                                if (list[j].MasterId == listMasters[i].Id)
                                {
                                   if (listMasters[i].TypeSalary == "percentMaster")
                                    {
                                        for (int k = 0; k < listPriceRepair.Count; k++)
                                        {
                                            if (listPriceRepair[k].OrderId == list[j].Id)
                                            {
                                                salary += listPriceRepair[k].Price;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                if (listMasters[i].TypeSalary == "rate")
                    dataGridView1.Rows.Add(listMasters[i].NameMaster, listMasters[i].Rate);
                else
                    dataGridView1.Rows.Add(listMasters[i].NameMaster, listMasters[i].Rate / 100.0 * salary);
                salary = 0;
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
