using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class IssuingClient : Form
    {
        public int idOrder;
        OrdersLogic ordersLogic = new();
        MalfunctionsOrdersLogic malfunctionsOrdersLogic = new();
        WarehousesLogic warehousesLogic = new();
        OrderEditDTO orderDTO;
        ReportsLogic reportsLogic = new();
        public IssuingClient(int id)
        {
            InitializeComponent();
            idOrder = id;
            InitializeElementsForm();
        }

        private void InitializeElementsForm()
        {
            orderDTO = ordersLogic.GetOrder(idOrder);
            var malfunctionOrderDTO = malfunctionsOrdersLogic.GetMalfunctionOrdersByIdOrder(idOrder);
            var detailsDTO = warehousesLogic.GetDetailsInOrder(idOrder);

            labelPriceDetails.Text = String.Format("{0} руб.", detailsDTO.Sum(i => i.PriceSale));
            labelCountDetails.Text = String.Format("{0} шт.", detailsDTO.Count);
            labelPriceRepair.Text = malfunctionOrderDTO.Sum(i => i.Price).ToString();
            labelTotalPrice.Text = String.Format("{0} руб.", detailsDTO.Sum(i => i.PriceSale) +
                malfunctionOrderDTO.Sum(i => i.Price));
            labelGuaranteePeriod.Text = DateTime.Now.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
            labelNameClient.Text = orderDTO.Client?.IdClient;
            labelDateCreate.Text = orderDTO.DateCreation?.ToShortDateString();
            labelEquipment.Text = orderDTO.Equipment?.Name;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LinkLabelDateNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void TextBoxGuarantee_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if ((int)(dateTimePicker1.Value - orderDTO.DateCompleted.Value).TotalDays < 0)
                dateTimePicker1.Value = orderDTO.DateCompleted.Value;
            if (Convert.ToInt32(textBoxGuarantee.Text) > 0)
                labelGuaranteePeriod.Text = dateTimePicker1.Value.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
        }

        private void TextBoxGuarantee_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxGuarantee.Text.Length) > 0)
            {
                labelIsGuarantee.Text = "Гарантия до";
                labelGuaranteePeriod.Text = dateTimePicker1.Value.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
            } else
            {
                labelIsGuarantee.Text = "Без гарантии";
                labelGuaranteePeriod.Text = string.Empty;
            }
        }

        private void ButtonIssueDevice_Click(object sender, EventArgs e)
        {
            if (textBoxGuarantee.Text.Length > 0)
            {
                if (orderDTO.ReturnUnderGuarantee)
                    orderDTO.DateIssueReturn = orderDTO.DateIssue;

                orderDTO.DateIssue = DateIssue;
                orderDTO.Guarantee = GuaranteePeriod;
                orderDTO.DateEndGuarantee = DateEndGuarantee;
                if (orderDTO.Guarantee > 0 && orderDTO.DateEndGuarantee > DateTime.Now)
                    orderDTO.StatusOrder = StatusOrderEnum.GuaranteeIssue;
                else
                    orderDTO.StatusOrder = StatusOrderEnum.Archive;

                ordersLogic.SaveOrder(orderDTO);

                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Распечатать квитанцию?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };
                if (warning.ShowDialog() == DialogResult.OK)
                    reportsLogic.IssuingDeviceReport(idOrder);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Не введена гарантия!"
                };
                warning.ShowDialog();
            }
        }

        public DateTime DateIssue
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        public int GuaranteePeriod
        {
            get { return Convert.ToInt32(textBoxGuarantee.Text); }
            set { textBoxGuarantee.Text = value.ToString(); }
        }

        public DateTime DateEndGuarantee
        {
            get { return DateTime.Parse(labelGuaranteePeriod.Text); }
            set { labelGuaranteePeriod.Text = value.ToString(); }
        }
    }
}
