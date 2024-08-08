﻿using WinFormsApp1.DTO;
using WinFormsApp1.Repository;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class CalculatingEmployeeSalaries : Form
    {
        List<OrderEditDTO> ordersDTO;
        OrderRepository orderRepository = new();
        MasterRepository masterRepository = new();
        NoteSalaryMasterRepository noteSalaryMasterRepository = new();
        RateMasterRepository rateMasterRepository = new();
        bool loading = true;
        public CalculatingEmployeeSalaries()
        {
            InitializeComponent();
            InitializeComboBoxes();
            InitializeTable();
            loading = false;
        }

        private void InitializeComboBoxes()
        {
            comboBoxCalculationByDate.DataSource = System.Enum.GetValues(typeof(SalaryCalculationByEnum));

            List<int> years = [];
            int startYear = 2023;
            int endYear = DateTime.Now.Year + 1;

            for (int i = 0; i <= endYear - startYear; i++)
            {
                years.Add(startYear + i);
            }
            comboBoxYears.DataSource = years;
            comboBoxYears.SelectedItem = DateTime.Now.Year;
        }

        private void InitializeTable()
        {
            int[] percent = [30, 20, 50];
            bool[] readOnly = [true, true, false];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
                dataGridView1.Columns[i].ReadOnly = readOnly[i];
            }

            switch ((MonthEnum)DateTime.Now.Month)
            {
                case MonthEnum.Январь:
                    radioButton1.Checked = true; break;
                case MonthEnum.Февраль:
                    radioButton2.Checked = true; break;
                case MonthEnum.Март:
                    radioButton3.Checked = true; break;
                case MonthEnum.Апрель:
                    radioButton4.Checked = true; break;
                case MonthEnum.Май:
                    radioButton5.Checked = true; break;
                case MonthEnum.Июнь:
                    radioButton6.Checked = true; break;
                case MonthEnum.Июль:
                    radioButton7.Checked = true; break;
                case MonthEnum.Август:
                    radioButton8.Checked = true; break;
                case MonthEnum.Сентябрь:
                    radioButton9.Checked = true; break;
                case MonthEnum.Октябрь:
                    radioButton10.Checked = true; break;
                case MonthEnum.Ноябрь:
                    radioButton11.Checked = true; break;
                case MonthEnum.Декабрь:
                    radioButton12.Checked = true; break;
            }
        }

        private int NumberSelectedMonth()
        {
            var selectedRadioButton = panel1.Controls.OfType<RadioButton>().First(r => r.Checked);
            var selectedMonthEnum = (MonthEnum)System.Enum.Parse(typeof(MonthEnum), selectedRadioButton.Text);

            return (int)selectedMonthEnum;
        }

        private void UpdateTable()
        {
            //dataGridView1.Rows.Clear();
            
            SalaryCalculation();
        }

        private void SalaryCalculation()
        {
            DateTime? dateCompleted = null;
            DateTime? dateIssue = null;

            if ((SalaryCalculationByEnum)comboBoxCalculationByDate.SelectedItem == SalaryCalculationByEnum.выполнения)
                dateCompleted = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, NumberSelectedMonth(), comboBoxYears.SelectedValue));
            else
                dateIssue = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, NumberSelectedMonth(), comboBoxYears.SelectedValue));

            ordersDTO = orderRepository.GetOrdersForSalaries(dateCompleted: dateCompleted, dateIssue: dateIssue);

            DateTime date = (DateTime)(dateCompleted != null ? dateCompleted : dateIssue);


            var mastersDTO = masterRepository.GetMasters();
            var noteMastersDTO = noteSalaryMasterRepository.GetNoteSalaryMasters(date);


            //dataGridView1.DataSource = noteMastersDTO;
            List <NoteSalaryMasterEditDTO>  dataSource = new();

            foreach (var master in mastersDTO)
            {
                var rateMastersDTO = rateMasterRepository.GetRateMasterByDate(master.Id, date);
                var noteMaster = noteMastersDTO.FirstOrDefault(i => i.MasterId == master.Id) ?? 
                    new NoteSalaryMasterEditDTO() { MasterId = master.Id, Date = date};
                noteMaster.NameMaster = master.NameMaster;
                noteMaster.Salary = CalculationSalaryHelper.SalaryCalculation(master, ordersDTO, rateMastersDTO);
                /*dataGridView1.Rows.Add(master.NameMaster,
                    CalculationSalaryHelper.SalaryCalculation(master, ordersDTO, rateMastersDTO),
                    noteMastersDTO.FirstOrDefault(i => i.MasterId == master.Id)?.Note);*/

                dataSource.Add(noteMaster);
            }
            dataGridView1.DataSource = dataSource;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                UpdateTable();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                UpdateTable();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                UpdateTable();
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                UpdateTable();
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                UpdateTable();
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                UpdateTable();
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
                UpdateTable();
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
                UpdateTable();
        }

        private void RadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
                UpdateTable();
        }

        private void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
                UpdateTable();
        }

        private void RadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked)
                UpdateTable();
        }

        private void RadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton12.Checked)
                UpdateTable();
        }

        private void ComboBoxCalculationByDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
                UpdateTable();
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var dataSource = dataGridView1.DataSource as List<NoteSalaryMasterEditDTO>;

            foreach (var item in dataSource)
            {
                Task.Run(async () =>
                {
                    await noteSalaryMasterRepository.SaveNoteSalaryMasterAsync(item);
                });
            }
            /*for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var nameMaster = dataGridView1.Rows[i].Cells[0].Value.ToString();
                var masterDTO = masterRepository.GetMasterByName(nameMaster);
                var year = comboBoxYears.SelectedValue;
                NoteSalaryMasterEditDTO noteSalaryMasterDTO = new()
                {
                    MasterId = masterDTO.Id,
                    Note = (string)dataGridView1.Rows[i].Cells[2].Value,
                    Date = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, NumberSelectedMonth(), comboBoxYears.SelectedValue))
                };

                Task.Run(async () =>
                {
                    await noteSalaryMasterRepository.SaveNoteSalaryMasterAsync(noteSalaryMasterDTO);
                });
            }*/

            
        }
    }
}
