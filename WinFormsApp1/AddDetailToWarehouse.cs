using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class AddDetailToWarehouse : Form
    {
        readonly List<string> nameDetails = [];
        public bool changeDetail = false;
        bool loading = true;
        readonly int id;
        public AddDetailToWarehouse(bool _changeDetail, int _id)
        {
            InitializeComponent();
            changeDetail = _changeDetail;
            id = _id;
            Context context = new();
            var list = context.Warehouse.Select(a => new { a.NameDetail }).ToList();
            listBoxDetails.Visible = false;
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (!nameDetails.Contains(list[i].NameDetail))
                        nameDetails.Add(list[i].NameDetail);
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
                if (changeDetail)
                {
                    CRUD.ChangeWarehouse(id, textBoxNameDetail.Text,
                        Convert.ToInt32(textBoxPricePurchase.Text),
                        Convert.ToInt32(textBoxPriceSale.Text), dateTimePicker1.Value, true, null);
                }
                else
                {
                    CRUD.AddAsyncWarehouse(IdDetail(), textBoxNameDetail.Text,
                        Convert.ToInt32(textBoxPricePurchase.Text),
                        Convert.ToInt32(textBoxPriceSale.Text), dateTimePicker1.Value, true, null);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void TextBoxNameDetail_TextChanged(object sender, EventArgs e)
        {
            listBoxDetails.Items.Clear();
            listBoxDetails.Visible = false;

            for (int i = 0; i < nameDetails.Count; i++)
            {
                if (nameDetails[i].StartsWith(textBoxNameDetail.Text) &&
                    textBoxNameDetail.Text.Length > 0 && !loading)
                {
                    listBoxDetails.Visible = true;
                    listBoxDetails.Items.Add(nameDetails[i]);
                }
            }
        }

        private void TextBoxPriceDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

        private static int IdDetail()
        {
            int id;
            using (Context context = new())
            {
                if (context.Warehouse.Any())
                {
                    id = context.Warehouse.OrderBy(i => i.Id).Last().Id;
                    id++;
                }
                else { id = 1; }
            }
            return id;
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
            if(e.KeyChar == 13 && listBoxDetails.Visible)
                listBoxDetails.Visible = false;
        }

        public string NameDetail
        {
            get { return this.textBoxNameDetail.Text; }
            set { this.textBoxNameDetail.Text = value; }
        }

        public int PricePurchase
        {
            get { return Convert.ToInt32(this.textBoxPricePurchase.Text); }
            set { this.textBoxPricePurchase.Text = value.ToString(); }
        }

        public int PriceSale
        {
            get { return Convert.ToInt32(this.textBoxPriceSale.Text); }
            set { this.textBoxPriceSale.Text = value.ToString(); }
        }

        public DateTime DatePurchase
        {
            get { return this.dateTimePicker1.Value; }
            set { this.dateTimePicker1.Value = value; }
        }
    }
}
