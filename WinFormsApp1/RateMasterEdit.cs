using WinFormsApp1.DTO;
using WinFormsApp1.Repository;
using WinFormsApp1.Enum;


namespace WinFormsApp1
{
    public partial class RateMasterEdit : Form
    {
        RateMasterRepository rateMasterRepository = new();
        int masterId;
        public RateMasterEdit(int id)
        {
            masterId = id;
            InitializeComponent();
            InitializeElementsForm();
        }

        private void InitializeElementsForm()
        {
            UpdateTable();
            comboBoxMonth.DataSource = System.Enum.GetValues(typeof(MonthEnum));
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1;

            List<int> years = new();
            int startYear = 2023;
            int endYear = DateTime.Now.Year + 1;

            for (int i = 0; i <= endYear - startYear; i++)
            {
                years.Add(startYear + i);
            }
            comboBoxYear.DataSource = years;
            comboBoxYear.SelectedItem = DateTime.Now.Year;

            UpdatePercent();
        }

        private void UpdateTable()
        {
            dataGridView1.DataSource = rateMasterRepository.GetRateMasterByIdMaster(masterId);
            dataGridView1.Columns[nameof(RateMasterDTO.Id)].Visible = false;
        }

        private void UpdatePercent()
        {
            var date = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, comboBoxMonth.SelectedIndex + 1, comboBoxYear.SelectedValue));
            var rateMasterDTO = rateMasterRepository.GetRateMaster(date);
            if (rateMasterDTO.Id != 0)
                textBoxPercent.Text = rateMasterDTO.PercentProfit.ToString();
            else
                textBoxPercent.Text = string.Empty;
        }

        private void TextBoxPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Helpers.KeyPressHelper.CheckKeyPress(true, textBoxPercent.Text, e.KeyChar);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(textBoxPercent.Text) || Convert.ToInt32(textBoxPercent.Text) > 100))
            {
                labelPercent.ForeColor = Color.Red;
                Warning warning = new()
                {
                    LabelText = "Некорректно введены данные",
                    StartPosition = FormStartPosition.CenterParent
                };
                warning.ShowDialog();
                return;
            }
            labelPercent.ForeColor = Color.Black;

            var date = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, comboBoxMonth.SelectedIndex + 1, comboBoxYear.SelectedValue));
            var rateMasterDTO = rateMasterRepository.GetRateMaster(date);

            rateMasterDTO.MasterId = masterId;
            rateMasterDTO.PercentProfit = Convert.ToInt32(textBoxPercent.Text);
            rateMasterDTO.DateStart = date;
            rateMasterDTO.DateEnd = date;

            var task = Task.Run(async () =>
            {
                await rateMasterRepository.SaveRateMasterAsync(rateMasterDTO);
            });
            task.Wait();

            UpdateTable();
        }

        private void ComboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePercent();
        }

        private void ComboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePercent();
        }
    }
}
