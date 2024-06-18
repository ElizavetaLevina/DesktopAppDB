using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class AddDetailToWarehouse : Form
    {
        readonly List<string> nameDetails = [];
        public bool changeDetail = false;
        bool loading = true;
        readonly int id;
        WarehouseRepository warehouseRepository = new();
        public AddDetailToWarehouse(bool _changeDetail, int _id = 0)
        {
            InitializeComponent();
            changeDetail = _changeDetail;
            id = _id;
            var list = warehouseRepository.GetWarehouses();
            listBoxDetails.Visible = false;
            if (list.Count > 0)
            {
                foreach(var item in list)
                {
                    if (!nameDetails.Contains(item.NameDetail))
                        nameDetails.Add(item.NameDetail);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxNameDetail.Text == "" || textBoxPricePurchase.Text == "" ||
                textBoxPriceSale.Text == "")
            {
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                warning.ShowDialog();

                if (textBoxNameDetail.Text == "")
                    labelName.ForeColor = Color.Red;
                else
                    labelName.ForeColor = Color.Black;

                if (textBoxPricePurchase.Text == "")
                    labelPricePurchase.ForeColor = Color.Red;
                else
                    labelPricePurchase.ForeColor = Color.Black;

                if (textBoxPriceSale.Text == "")
                    labelPriceSale.ForeColor = Color.Red;
                else
                    labelPriceSale.ForeColor = Color.Black;
            }
            else
            {
                var warehouseDTO = new WarehouseEditDTO()
                {
                    Id = id,
                    NameDetail = textBoxNameDetail.Text,
                    PricePurchase = Convert.ToInt32(textBoxPricePurchase.Text),
                    PriceSale = Convert.ToInt32(textBoxPriceSale.Text),
                    DatePurchase = dateTimePicker1.Value,
                    Availability = true,
                    IdOrder = null
                };
                var task = Task.Run(async () =>
                {
                    await warehouseRepository.SaveWarehouseAsync(warehouseDTO);
                });
                task.Wait();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void TextBoxNameDetail_TextChanged(object sender, EventArgs e)
        {
            listBoxDetails.Items.Clear();
            listBoxDetails.Visible = false;

            foreach(var name in nameDetails)
            {
                if (name.StartsWith(textBoxNameDetail.Text) &&
                    textBoxNameDetail.Text.Length > 0 && !loading)
                {
                    listBoxDetails.Visible = true;
                    listBoxDetails.Items.Add(name);
                }
            }
        }

        private void TextBoxPriceDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

        private void TextBoxPriceSale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

        private void ListBoxDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = listBoxDetails.SelectedIndex;
            if (id >= 0)
            {
                textBoxNameDetail.Text = listBoxDetails.Items[id].ToString();

                listBoxDetails.Items.Clear();
                listBoxDetails.Visible = false;

                textBoxNameDetail.Focus();
                textBoxNameDetail.SelectionStart = textBoxNameDetail.TextLength;
            }
        }

        private void AddDetailToWarehouse_Activated(object sender, EventArgs e)
        {
            loading = false;
        }

        private void TextBoxNameDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && listBoxDetails.Visible)
                listBoxDetails.Visible = false;
        }

        public string NameDetail
        {
            get { return textBoxNameDetail.Text; }
            set { textBoxNameDetail.Text = value; }
        }

        public int PricePurchase
        {
            get { return Convert.ToInt32(textBoxPricePurchase.Text); }
            set { textBoxPricePurchase.Text = value.ToString(); }
        }

        public int PriceSale
        {
            get { return Convert.ToInt32(textBoxPriceSale.Text); }
            set { textBoxPriceSale.Text = value.ToString(); }
        }

        public DateTime DatePurchase
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }
    }
}
