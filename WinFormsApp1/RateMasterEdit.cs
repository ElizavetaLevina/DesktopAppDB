using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic.Interfaces;


namespace WinFormsApp1
{
    public partial class RateMasterEdit : Form
    {
        IRateMastersLogic rateMastersLogic;
        public int masterId;
        RateMasterEditDTO rateMasterDTO;
        DateTime date;
        public RateMasterEdit(IRateMastersLogic _rateMastersLogic)
        {
            rateMastersLogic = _rateMastersLogic;
            InitializeComponent();
        }

        public void InitializeElementsForm()
        {
            UpdateTableAsync();
            comboBoxMonth.DataSource = System.Enum.GetValues(typeof(MonthEnum));
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1;

            List<int> years = [];
            int startYear = 2023;
            int endYear = DateTime.Now.Year + 1;

            for (int i = 0; i <= endYear - startYear; i++)
            {
                years.Add(startYear + i);
            }
            comboBoxYear.DataSource = years;
            comboBoxYear.SelectedItem = DateTime.Now.Year;

            UpdatePercentAsync();
        }

        private async void UpdateTableAsync()
        {
            dataGridView1.DataSource = await rateMastersLogic.GetRateMasterByIdMasterAsync(masterId);
            dataGridView1.Columns[nameof(RateMasterDTO.Id)].Visible = false;
        }

        private async void UpdatePercentAsync()
        {
            date = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, comboBoxMonth.SelectedIndex + 1, comboBoxYear.SelectedValue));
            rateMasterDTO = await rateMastersLogic.GetRateMasterByDateAsync(masterId, date);
            if (rateMasterDTO.Id != 0)
                textBoxPercent.Text = rateMasterDTO.PercentProfit.ToString();
            else
                textBoxPercent.Text = string.Empty;
        }

        private void TextBoxPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Helpers.KeyPressHelper.CheckKeyPress(true, textBoxPercent.Text, e.KeyChar);
        }

        private async void ButtonSave_ClickAsync(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(textBoxPercent.Text) || Convert.ToInt32(textBoxPercent.Text) > 100))
            {
                labelPercent.ForeColor = Color.Red;
                Warning warning = new()
                {
                    LabelText = "Некорректно введены данные"
                };
                warning.ShowDialog();
                return;
            }
            labelPercent.ForeColor = Color.Black;

            //var date = DateTime.Parse(string.Format("{0}.{1}.{2}", 1, comboBoxMonth.SelectedIndex + 1, comboBoxYear.SelectedValue));
            //var rateMasterDTO = rateMastersLogic.GetRateMasterByDate(masterId, date);

            rateMasterDTO.MasterId = masterId;
            rateMasterDTO.PercentProfit = Convert.ToInt32(textBoxPercent.Text);
            rateMasterDTO.DateStart = date.ToUniversalTime();
            rateMasterDTO.DateEnd = date.ToUniversalTime();

            await rateMastersLogic.SaveRateMasterAsync(rateMasterDTO);

            UpdateTableAsync();
        }

        private void ComboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePercentAsync();
        }

        private void ComboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePercentAsync();
        }
    }
}
