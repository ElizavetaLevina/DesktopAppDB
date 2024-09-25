using System.Windows.Forms;
using WinFormsApp1.DTO;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic.Interfaces;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WinFormsApp1
{
    public partial class DetailEdit : Form
    {
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
        readonly List<string> nameDetails = [];
        public bool changeDetail = false;
        public int idDetail = 0;
        WarehouseEditDTO warehouseDTO = new();
        IWarehousesLogic warehousesLogic;
        public DetailEdit(IWarehousesLogic _warehousesLogic)
        {
            warehousesLogic = _warehousesLogic;
            InitializeComponent();
        }

        public void InitializeElementsForm()
        {
            var list = warehousesLogic.GetWarehouses();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (!nameDetails.Contains(item.NameDetail))
                        nameDetails.Add(item.NameDetail);
                }
            }
            if (changeDetail)
            {
                warehouseDTO = warehousesLogic.GetWarehouse(id: idDetail);
                Text = "Изменение данных";
                NameDetail = warehouseDTO.NameDetail;
                PricePurchase = warehouseDTO.PricePurchase;
                PriceSale = warehouseDTO.PriceSale;
                DatePurchase = warehouseDTO.DatePurchase;
            }
            listBoxDetails.Visible = false;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNameDetail.Text) || string.IsNullOrEmpty(textBoxPricePurchase.Text) ||
                string.IsNullOrEmpty(textBoxPriceSale.Text))
            {
                Warning warning = new();
                warning.ShowDialog();

                if (string.IsNullOrEmpty(textBoxNameDetail.Text))
                    labelName.ForeColor = Color.Red;
                else
                    labelName.ForeColor = Color.Black;

                if (string.IsNullOrEmpty(textBoxPricePurchase.Text))
                    labelPricePurchase.ForeColor = Color.Red;
                else
                    labelPricePurchase.ForeColor = Color.Black;

                if (string.IsNullOrEmpty(textBoxPriceSale.Text))
                    labelPriceSale.ForeColor = Color.Red;
                else
                    labelPriceSale.ForeColor = Color.Black;
            }
            else
            {
                warehouseDTO.NameDetail = NameDetail;
                warehouseDTO.PricePurchase = PricePurchase;
                warehouseDTO.PriceSale = PriceSale;
                warehouseDTO.DatePurchase = DatePurchase.ToUniversalTime();
                warehouseDTO.Availability = true;
                warehouseDTO.IdOrder = null;

                warehousesLogic.SaveDetail(warehouseDTO);
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

            foreach (var name in nameDetails)
            {
                if (name.ToLower().StartsWith(NameDetail.ToLower()) && NameDetail.Length > 0)
                {
                    listBoxDetails.Visible = true;
                    listBoxDetails.Items.Add(name);
                }
            }
        }

        private void TextBoxPricePurchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(true, textBoxPricePurchase.Text, e.KeyChar);
        }

        private void TextBoxPriceSale_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(true, textBoxPriceSale.Text, e.KeyChar);
        }

        private void TextBoxNameDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && listBoxDetails.Visible)
                listBoxDetails.Visible = false;
        }

        private void TextBoxNameDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBoxDetails.Visible)
                    listBoxDetails.Visible = false;
                textBoxNameDetail.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                listBoxDetails.Focus();
                try
                {
                    if (listBoxDetails.SelectedIndex < listBoxDetails.Items.Count)
                        listBoxDetails.SelectedIndex += 1;
                }
                catch { }
            }
            else if (e.KeyCode == Keys.Up)
            {
                listBoxDetails.Focus();
                try
                {
                    if (listBoxDetails.SelectedIndex > 1)
                        listBoxDetails.SelectedIndex -= 1;
                }
                catch { }
            }
        }

        private void ListBoxDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listBoxDetails.SelectedIndex >= 0)
            {
                textBoxNameDetail.Text = listBoxDetails.Items[listBoxDetails.SelectedIndex].ToString();
                listBoxDetails.Visible = false;
                textBoxNameDetail.SelectionStart = textBoxNameDetail.Text.Length;
            }
        }
    }
}
