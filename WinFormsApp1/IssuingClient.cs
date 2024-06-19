using System.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class IssuingClient : Form
    {
        public int idOrder;
        readonly DateTime dateСompletion;
        public IssuingClient(int id)
        {
            InitializeComponent();
            idOrder = id;
            int summDetails = 0;
            int sumPrice = 0;
            using Context context = new();
            /*var listDetails = context.Details.Where(i => i.Id == idOrder).Select(a => new
            { a.IdWarehouse }).ToList();*/
            var list = context.Orders.Where(i => i.Id == id).Select(a => new
            {
                a.Client.NameAndAddressClient,
                a.DateCreation,
                a.DateCompleted,
                a.Equipment,
                a.ReturnUnderGuarantee
            }).ToList();
            var listMalfunctionOrder = context.MalfunctionOrders.Where(i => i.OrderId == idOrder).ToList();

            dateСompletion = list[0].DateCompleted.Value;

            if (/*listDetails[0].IdWarehouse != null*/true)
            {
                var listWarehouse = context.Warehouse.ToList();
                List<string> listNameS = [];
                List<int> listPriceSaleS = [];

                /*for (int i = 0; i < listDetails[0].IdWarehouse.Count; i++)
                {
                    for (int j = 0; j < listWarehouse.Count; j++)
                    {
                        if (listDetails[0].IdWarehouse[i] == listWarehouse[j].Id)
                        {
                            listNameS.Add(listWarehouse[j].NameDetail);
                            listPriceSaleS.Add(listWarehouse[j].PriceSale);
                        }
                    }
                }*/
                for (int i = 0; i < listNameS.Count; i++)
                {
                    summDetails += listPriceSaleS[i];
                }
                labelPriceDetails.Text = String.Format("{0} руб.", summDetails);
                labelCountDetails.Text = String.Format("{0} шт.", listPriceSaleS.Count);
            }

            labelNameClient.Text = list[0].NameAndAddressClient;
            labelDateCreate.Text = list[0].DateCreation.ToString();
            labelEquipment.Text = list[0].Equipment?.Name;

            for(int i = 0; i < listMalfunctionOrder.Count; i++)
            {
                sumPrice += listMalfunctionOrder[i].Price;
            }
            labelPriceRepair.Text = sumPrice.ToString();
            labelTotalPrice.Text = String.Format("{0} руб.", summDetails + sumPrice);
            labelGuaranteePeriod.Text = DateTime.Now.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LinkLabelDateNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void TextBoxGuarantee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateIssue = dateTimePicker1.Value;
            if ((int)(dateIssue - dateСompletion).TotalDays < 0)
            {
                dateIssue = dateСompletion;
                dateTimePicker1.Value = dateСompletion;
            }
            if (Convert.ToInt32(textBoxGuarantee.Text) > 0)
                labelGuaranteePeriod.Text = dateIssue.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
        }

        private void TextBoxGuarantee_TextChanged(object sender, EventArgs e)
        {
            DateTime dateIssue = dateTimePicker1.Value;
            if (Convert.ToInt32(textBoxGuarantee.Text.Length) > 0)
            {
                labelIsGuarantee.Text = "Гарантия до";
                labelGuaranteePeriod.Text = dateIssue.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
            } else
            {
                labelIsGuarantee.Text = "Без гарантии";
                labelGuaranteePeriod.Text = "";
            }
        }

        private void ButtonIssueDevice_Click(object sender, EventArgs e)
        {
            if (textBoxGuarantee.Text.Length > 0)
            {
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Распечатать квитанцию?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };

                if (warning.ShowDialog() == DialogResult.OK)
                {
                    Form1 form = new();
                    form.ReportIssuing(idOrder);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
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
            get
            {
                return this.dateTimePicker1.Value;
            }
            set
            {
                this.dateTimePicker1.Value = value;
            }
        }

        public int GuaranteePeriod
        {
            get
            {
                return Convert.ToInt32(this.textBoxGuarantee.Text);
            }
            set
            {
                this.textBoxGuarantee.Text = value.ToString();
            }
        }

        public DateTime DateEndGuarantee
        {
            get
            {
                return DateTime.Parse(this.labelGuaranteePeriod.Text);
            }
            set
            {
                this.labelGuaranteePeriod.Text = value.ToString();
            }
        }
    }
}
