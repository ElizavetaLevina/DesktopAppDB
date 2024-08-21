using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class CalculatingEmployeeSalaries : Form
    {
        List<OrderEditDTO> ordersDTO;
        MastersLogic mastersLogic = new();
        NotesSalaryMastersLogic notesSalaryMastersLogic = new();
        RateMastersLogic rateMastersLogic = new();
        OrdersLogic ordersLogic = new();
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

        private void SalaryCalculation()
        {
            var selectedDate = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, NumberSelectedMonth(),
                    comboBoxYears.SelectedValue));
            var selectedComboBoxItem = (SalaryCalculationByEnum)comboBoxCalculationByDate.SelectedItem;
            DateTime? dateCompleted = selectedComboBoxItem == SalaryCalculationByEnum.выполнения ? selectedDate : null;
            DateTime? dateIssue = selectedComboBoxItem == SalaryCalculationByEnum.выдачи ? selectedDate : null;
            var date = (DateTime)(dateCompleted != null ? dateCompleted : dateIssue);
            var mastersDTO = mastersLogic.GetMasters();
            var noteMastersDTO = notesSalaryMastersLogic.GetNoteSalaryMasters(date);
            List <NoteSalaryMasterEditDTO>  dataSource = new();

            ordersDTO = ordersLogic.GetOrdersForSalaries(dateCompleted: dateCompleted, dateIssue: dateIssue);

            foreach (var master in mastersDTO)
            {
                var rateMastersDTO = rateMastersLogic.GetRateMasterByDate(master.Id, date);
                var noteMaster = noteMastersDTO.FirstOrDefault(i => i.MasterId == master.Id) ?? 
                    new NoteSalaryMasterEditDTO() { MasterId = master.Id, Date = date};
                noteMaster.NameMaster = master.NameMaster;
                noteMaster.Salary = CalculationSalaryHelper.SalaryCalculation(master, ordersDTO, rateMastersDTO);

                dataSource.Add(noteMaster);
            }
            dataGridView1.DataSource = dataSource;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                SalaryCalculation();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                SalaryCalculation();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                SalaryCalculation();
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                SalaryCalculation();
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                SalaryCalculation();
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                SalaryCalculation();
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
                SalaryCalculation();
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
                SalaryCalculation();
        }

        private void RadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
                SalaryCalculation();
        }

        private void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
                SalaryCalculation();
        }

        private void RadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked)
                SalaryCalculation();
        }

        private void RadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton12.Checked)
                SalaryCalculation();
        }

        private void ComboBoxCalculationByDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
                SalaryCalculation();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var noteSalaryMasters = dataGridView1.DataSource as List<NoteSalaryMasterEditDTO>;
            foreach (var item in noteSalaryMasters)
            {
                notesSalaryMastersLogic.SaveNoteSalaryMasterAsync(item);
            }            
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
