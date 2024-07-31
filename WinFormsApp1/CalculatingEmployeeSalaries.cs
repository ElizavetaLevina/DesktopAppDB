using WinFormsApp1.DTO;
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
        public CalculatingEmployeeSalaries()
        {
            InitializeComponent();
            InitializeComboBoxes();
            InitializeTable();
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
            dataGridView1.Rows.Clear();
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

            var mastersDTO = masterRepository.GetMasters();

            foreach (var master in mastersDTO)
            {
                dataGridView1.Rows.Add(master.NameMaster, CalculationSalaryHelper.SalaryCalculation(master, ordersDTO), string.Empty);
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

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //TODO разобраться когда вызывается
            if (e.ColumnIndex == 2)
            {
                var nameMaster = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                var masterDTO = masterRepository.GetMasterByName(nameMaster);
                var year = comboBoxYears.SelectedValue;
                NoteSalaryMasterEditDTO noteSalaryMasterDTO = new()
                {
                    MasterId = masterDTO.Id,
                    Note = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value,
                    Date = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, NumberSelectedMonth(), comboBoxYears.SelectedValue))
                };
                Task.Run(async () =>
                {
                    await noteSalaryMasterRepository.SaveNoteSalaryMasterAsync(noteSalaryMasterDTO);
                });
            }
        }
    }
}
