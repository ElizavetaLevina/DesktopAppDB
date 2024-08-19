using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class IssuingClient : Form
    {
        public int idOrder;
        readonly DateTime dateСompleted;
        OrderEditDTO orderDTO;
        OrderRepository orderRepository = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();
        WarehouseRepository warehouseRepository = new();
        public IssuingClient(int id)
        {
            InitializeComponent();
            idOrder = id;
            int summDetails = 0;
            int sumPrice = 0;
            orderDTO = orderRepository.GetOrder(idOrder);
            var malfunctionOrderDTO = malfunctionOrderRepository.GetMalfunctionOrdersByIdOrder(idOrder);
            var detailsDTO = warehouseRepository.GetDetailsInOrder(idOrder);

            foreach(var detail in detailsDTO)
            {
                summDetails += detail.PriceSale;
            }

            labelPriceDetails.Text = String.Format("{0} руб.", summDetails);
            labelCountDetails.Text = String.Format("{0} шт.", detailsDTO.Count);

            foreach(var malfunction in malfunctionOrderDTO)
            {
                sumPrice += malfunction.Price;
            }

            labelPriceRepair.Text = sumPrice.ToString();
            labelTotalPrice.Text = String.Format("{0} руб.", summDetails + sumPrice);
            labelGuaranteePeriod.Text = DateTime.Now.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
            labelNameClient.Text = orderDTO.Client?.NameAndAddressClient;
            labelDateCreate.Text = orderDTO.DateCreation.Value.ToShortDateString();
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


                var task = Task.Run(async () =>
                {
                    await orderRepository.SaveOrderAsync(orderDTO);
                });
                task.Wait();


                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Распечатать квитанцию?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };

                if (warning.ShowDialog() == DialogResult.OK)
                {
                    /*IssuingReport issuingReport = new();
                    issuingReport.Report(idOrder);*/
                }
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
