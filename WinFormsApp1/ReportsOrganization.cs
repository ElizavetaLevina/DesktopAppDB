using System.Windows.Forms.DataVisualization.Charting;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class ReportsOrganization : Form
    {
        IMastersLogic mastersLogic;
        IOrdersLogic ordersLogic;
        List<OrderEditDTO> ordersDTO;
        int[] pointsArray;
        bool loadingForm = true;
        MonthEnum[] valuesAsArray = (MonthEnum[])System.Enum.GetValues(typeof(MonthEnum));
        public ReportsOrganization(IMastersLogic _mastersLogic, IOrdersLogic _ordersLogic)
        {
            mastersLogic = _mastersLogic;
            ordersLogic = _ordersLogic;
            InitializeComponent();
            InitializeComboBox();
            InitializeChart();
            loadingForm = false;
        }

        private void InitializeComboBox()
        {
            List<int> years = [];
            int startYear = 2023;
            int endYear = DateTime.Now.Year + 1;

            for (int i = 0; i <= endYear - startYear; i++)
            {
                years.Add(startYear + i);
            }

            comboBoxMaster.ValueMember = nameof(MasterDTO.Id);
            comboBoxMaster.DisplayMember = nameof(MasterDTO.NameMaster);
            comboBoxMaster.DataSource = mastersLogic.GetMastersForOutput();

            comboBoxYear.DataSource = years;
            comboBoxYear.SelectedItem = DateTime.Now.Year;
        }

        private void InitializeChart()
        {
            var interval = 0.1666666667;
            var startPosition = interval * 6;

            ordersDTO = ordersLogic.GetOrdersForChart(year: Convert.ToInt32(comboBoxYear.SelectedValue));
            pointsArray = ArrayForChartHepler.GetArrayCountOrders(ordersDTO);

            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.Interval = interval;

            for (int i = 0; i < valuesAsArray.Length; i++)
            {
                Series series = chart1.Series.Add(valuesAsArray[i].ToString());
                series.Points.AddXY(valuesAsArray[i].ToString(), pointsArray[i]);
                series.ChartType = SeriesChartType.Bar;
                series.Points[0].Label = pointsArray[i].ToString();
                series.LabelBackColor = Color.White;
                series.LabelBorderColor = Color.Black;
                series.CustomProperties = "PointWidth=2";

                var valueLabel = valuesAsArray[i].ToString();

                CustomLabel label = new((startPosition - interval * i), (startPosition - interval * (i + 1)), valueLabel, 0, LabelMarkStyle.None);
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
            }
        }

        private void UpdateChart(int[] pointsArray)
        {
            if (loadingForm)
                return;

            for (int i = 0; i < valuesAsArray.Length; i++)
            {
                chart1.Series[i].Points.Clear();
                chart1.Series[i].Points.AddXY(valuesAsArray[i].ToString(), pointsArray[i]);
                chart1.Series[i].ChartType = SeriesChartType.Bar;
                chart1.Series[i].Points[0].Label = pointsArray[i].ToString();
                chart1.Series[i].CustomProperties = "PointWidth=2";
            }
        }

        private void SelectedRadioButtonPanel2(bool master = false, int? masterId = null) 
        {
            var selectedRadioButtonPanel2 = panel2.Controls.OfType<RadioButton>().First(r => r.Checked);

            if (selectedRadioButtonPanel2 == radioButtonCountOrders)
                pointsArray = ArrayForChartHepler.GetArrayCountOrders(ordersDTO);
            else if (selectedRadioButtonPanel2 == radioButtonExpensesForDetails)
                pointsArray = ArrayForChartHepler.GetArrayExpensesForDetails(ordersDTO);
            else
                pointsArray = ArrayForChartHepler.GetArrayTotalProfit(ordersDTO, master: master, masterId: masterId);

            UpdateChart(pointsArray);
        }


        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingForm)
                return;

            var selectedRadioButtonPanel1 = panel1.Controls.OfType<RadioButton>().First(r => r.Checked);
            var selectedRadioButtonPanel2 = panel2.Controls.OfType<RadioButton>().First(r => r.Checked);
            bool master = false;
            int? masterId = null;

            if (selectedRadioButtonPanel1 == radioButtonOrganization)
                ordersDTO = ordersLogic.GetOrdersForChart(year: Convert.ToInt32(comboBoxYear.SelectedValue));
            else
            {
                master = true;
                masterId = ((MasterDTO)comboBoxMaster.SelectedItem).Id;
                ordersDTO = ordersLogic.GetOrdersForChart(year: Convert.ToInt32(comboBoxYear.SelectedValue), master: true,
                masterId: masterId);
            }

            SelectedRadioButtonPanel2(master: master, masterId: masterId);
        }

        private void RadioButtonOrganization_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonOrganization.Checked)
                return;

            comboBoxMaster.Enabled = false;
            ordersDTO = ordersLogic.GetOrdersForChart(year: Convert.ToInt32(comboBoxYear.SelectedValue));
            SelectedRadioButtonPanel2();
        }

        private void RadioButtonMaster_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonMaster.Checked)
                return;

            comboBoxMaster.Enabled = true;
            ordersDTO = ordersLogic.GetOrdersForChart(year: Convert.ToInt32(comboBoxYear.SelectedValue), master: true,
                masterId: ((MasterDTO)comboBoxMaster.SelectedItem).Id);
            SelectedRadioButtonPanel2(master: true, masterId: ((MasterDTO)comboBoxMaster.SelectedItem).Id);
        }

        private void ComboBoxMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingForm)
                return;

            ordersDTO = ordersLogic.GetOrdersForChart(year: Convert.ToInt32(comboBoxYear.SelectedValue), master: true,
                masterId: ((MasterDTO)comboBoxMaster.SelectedItem).Id);

            SelectedRadioButtonPanel2(master: true, masterId: ((MasterDTO)comboBoxMaster.SelectedItem).Id);
        }

        private void RadioButtonCountOrders_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonCountOrders.Checked)
                return;

            pointsArray = ArrayForChartHepler.GetArrayCountOrders(ordersDTO);
            UpdateChart(pointsArray);
        }

        private void RadioButtonExpensesForDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonExpensesForDetails.Checked)
                return;

            pointsArray = ArrayForChartHepler.GetArrayExpensesForDetails(ordersDTO);
            UpdateChart(pointsArray);
        }

        private void RadioButtonProfit_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonProfit.Checked)
                return;

            var selectedRadioButtonPanel1 = panel1.Controls.OfType<RadioButton>().First(r => r.Checked);

            if (selectedRadioButtonPanel1 == radioButtonOrganization)
                pointsArray = ArrayForChartHepler.GetArrayTotalProfit(ordersDTO);
            else pointsArray = ArrayForChartHepler.GetArrayTotalProfit(ordersDTO, master: true, 
                    masterId: ((MasterDTO)comboBoxMaster.SelectedItem).Id);

            UpdateChart(pointsArray);
        }
    }
}
