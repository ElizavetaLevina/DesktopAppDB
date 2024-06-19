using System.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class CompletedOrder : Form
    {
        readonly DateTime dateCreate;
        readonly int id;
        public List<string>? problem = [];
        public List<int>? price = [];
        public List<string>? nameProblem = [];
        private int numberProblem = 1;
        public int countProblem = 0;
        public CompletedOrder(int _id)
        {
            InitializeComponent();
            id = _id;
            int summDetails = 0;
            using Context context = new();
            /*var listIdWarehouse = context.Details.Where(i => i.Id == id).Select(a => new
            {
                a.IdWarehouse
            }).ToList();*/

            var listProblem = context.Malfunctions.ToList();
            for (int i = 0; i < listProblem.Count; i++)
            {
                nameProblem.Add(listProblem[i].Name);
            }

            if (/*listIdWarehouse[0].IdWarehouse != null*/true)
            {
                var listWarehouse = context.Warehouse.ToList();
                List<string> listNameS = [];
                List<int> listPriceSaleS = [];

               /* for (int i = 0; i < listIdWarehouse[0].IdWarehouse?.Count; i++)
                {
                    for (int j = 0; j < listWarehouse.Count; j++)
                    {
                        if (listIdWarehouse[0].IdWarehouse?[i] == listWarehouse[j].Id)
                        {
                            listNameS.Add(listWarehouse[j].NameDetail);
                            listPriceSaleS.Add(listWarehouse[j].PriceSale);
                        }
                    }
                }*/
                for (int i = 0; i < listPriceSaleS.Count; i++)
                {
                    summDetails += listPriceSaleS[i];
                }

                labelPriceDetails.Text = String.Format("{0} руб.", summDetails);
                labelCountDetails.Text = String.Format("{0} шт.", listPriceSaleS.Count);
            }
            var list = context.Orders.Where(i => i.Id == id)
                .Select(a => new
                {
                    a.Id,
                    a.DateCreation, 
                    a.TypeTechnic,
                    a.BrandTechnic, 
                    a.ModelTechnic
                })
                .ToList();
            dateCreate = list[0].DateCreation.Value;
            labelDurationRepair.Text = String.Format("{0} дн.", (int)(DateTime.Now - dateCreate).TotalDays);
            labelIdOrder.Text = list[0].Id.ToString();
            labelNameDevice.Text = String.Format("{0} {1} {2}", list[0].TypeTechnic?.NameTypeTechnic,
                list[0].BrandTechnic?.NameBrandTechnic, list[0].ModelTechnic);
        }

        private void LinkLabelDateNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;    
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Context context = new();
            var list = context.Orders.Where(i => i.Id == id).ToList();
            price?.Clear();
            problem?.Clear();
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            switch (countProblem)
            {
                case 0:
                    warning.ShowDialog();
                    return;
                case 1:
                    if (textBoxPrice1.Text.Length == 0)
                    {
                        warning.ShowDialog();
                        return;
                    }
                    problem?.Add(textBoxFoundProblem1.Text);
                    price?.Add(Convert.ToInt32(textBoxPrice1.Text));
                    break;
                case 2:
                    if (textBoxPrice2.Text.Length == 0 || textBoxPrice1.Text.Length == 0)
                    {
                        warning.ShowDialog();
                        return;
                    }
                    problem?.Add(textBoxFoundProblem1.Text);
                    price?.Add(Convert.ToInt32(textBoxPrice1.Text));
                    problem?.Add(textBoxFoundProblem2.Text);
                    price?.Add(Convert.ToInt32(textBoxPrice2.Text));
                    break;
                case 3:
                    if (textBoxPrice3.Text.Length == 0 || textBoxPrice2.Text.Length == 0 ||
                        textBoxPrice1.Text.Length == 0)
                    {
                        warning.ShowDialog();
                        return;
                    }
                    problem?.Add(textBoxFoundProblem1.Text);
                    price?.Add(Convert.ToInt32(textBoxPrice1.Text));
                    problem?.Add(textBoxFoundProblem2.Text);
                    price?.Add(Convert.ToInt32(textBoxPrice2.Text));
                    problem?.Add(textBoxFoundProblem3.Text);
                    price?.Add(Convert.ToInt32(textBoxPrice3.Text));
                    break;
            }
            int? sumPrice = price?.Sum();

            if (list[0].PriceAgreed && sumPrice > list[0].MaxPrice)
            {
                warning.LabelText = String.Format("Цена ремонта выше согласованной! \nСогласованная цена: {0} руб.", list[0].MaxPrice);
                warning.VisibleChangePrice = true;
                warning.id = id;
                warning.ShowDialog();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateComplete = dateTimePicker1.Value;
            if ((int)(dateComplete - dateCreate).TotalDays < 0)
            {
                dateComplete = dateCreate;
                dateTimePicker1.Value = dateCreate;
            }
            labelDurationRepair.Text = String.Format("{0} дн.", ((int)(dateComplete - dateCreate).TotalDays));
        }

        private void TextBoxFoundProblem1_TextChanged(object sender, EventArgs e)
        {
            numberProblem = 1;
            listBox1.Location = new Point(listBox1.Location.X, textBoxFoundProblem1.Location.Y +
                textBoxFoundProblem1.Height);
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            listBox1.Visible = false;
            for (int i = 0; i < nameProblem?.Count; i++)
            {
                if (nameProblem[i].StartsWith(textBoxFoundProblem1.Text))
                {
                    listBox1.Visible = true;
                    listBox1.Items.Add(nameProblem[i]);
                }
            }
            if (textBoxFoundProblem1.Text == "")
            {
                countProblem = 0;
                textBoxFoundProblem2.Enabled = false;
                textBoxFoundProblem3.Enabled = false;
                textBoxPrice2.Enabled = false;
                textBoxPrice3.Enabled = false;
                textBoxPrice1.Text = "";
            }
            else
            {
                countProblem = 1;
                textBoxFoundProblem2.Enabled = true;
                textBoxPrice2.Enabled = true;
                if (textBoxFoundProblem2.Text != "")
                {
                    textBoxFoundProblem3.Enabled = true;
                    textBoxPrice3.Enabled = true;
                }
            }
        }

        private void TextBoxFoundProblem2_TextChanged(object sender, EventArgs e)
        {
            numberProblem = 2;
            listBox1.Location = new Point(listBox1.Location.X, textBoxFoundProblem2.Location.Y +
                textBoxFoundProblem2.Height);
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            listBox1.Visible = false;
            for (int i = 0; i < nameProblem?.Count; i++)
            {
                if (nameProblem[i].StartsWith(textBoxFoundProblem2.Text) && textBoxFoundProblem2.Text.Length > 0)
                {
                    listBox1.Visible = true;
                    listBox1.Items.Add(nameProblem[i]);
                }
            }
            if (textBoxFoundProblem2.Text == "")
            {
                countProblem = 1;
                textBoxFoundProblem3.Enabled = false;
                textBoxPrice3.Enabled = false;
                textBoxPrice2.Text = "";
            }
            else
            {
                countProblem = 2;
                textBoxFoundProblem3.Enabled = true;
                textBoxPrice3.Enabled = true;
                if (textBoxFoundProblem3.Text != "")
                {
                    countProblem = 3;
                }
            }
        }

        private void TextBoxFoundProblem3_TextChanged(object sender, EventArgs e)
        {
            numberProblem = 3;
            listBox1.Location = new Point(listBox1.Location.X, textBoxFoundProblem3.Location.Y +
                textBoxFoundProblem3.Height);
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            listBox1.Visible = false;
            for (int i = 0; i < nameProblem?.Count; i++)
            {
                if (nameProblem[i].StartsWith(textBoxFoundProblem3.Text) && textBoxFoundProblem3.Text.Length > 0)
                {
                    listBox1.Visible = true;
                    listBox1.Items.Add(nameProblem[i]);
                }
            }
            if (textBoxFoundProblem3.Text == "")
            {
                countProblem = 2;
                textBoxPrice3.Text = "";
            }
            else
            {
                countProblem = 3;
            }
        }

        private void TextBoxFoundProblem1_Click(object sender, EventArgs e)
        {
            numberProblem = 1;
            if (textBoxFoundProblem1.Text == "")
                listBox1.DataSource = nameProblem;

            listBox1.Location = new Point(listBox1.Location.X, textBoxFoundProblem1.Location.Y +
                textBoxFoundProblem1.Height);
            listBox1.Visible = true;
        }
        private void TextBoxFoundProblem2_Click(object sender, EventArgs e)
        {
            numberProblem = 2;
            if (textBoxFoundProblem2.Text == "")
                listBox1.DataSource = nameProblem;
            listBox1.Location = new Point(listBox1.Location.X, textBoxFoundProblem2.Location.Y +
                textBoxFoundProblem2.Height);
            listBox1.Visible = true;
        }

        private void TextBoxFoundProblem3_Click(object sender, EventArgs e)
        {
            numberProblem = 3;
            if (textBoxFoundProblem3.Text == "")
                listBox1.DataSource = nameProblem;
            listBox1.Location = new Point(listBox1.Location.X, textBoxFoundProblem3.Location.Y +
                textBoxFoundProblem3.Height);
            listBox1.Visible = true;
        }

        private void TextBoxPriceRepair_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void TextBoxPrice2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void TextBoxPrice3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void TextBoxPrice4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void TextBoxPrice5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void TextBoxFoundProblem1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Visible = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count)
                        listBox1.SelectedIndex += 1;
                }
                catch { }
            }
            else if (e.KeyCode == Keys.Up)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex > 1)
                        listBox1.SelectedIndex -= 1;
                }
                catch { }
            }
        }

        private void TextBoxFoundProblem2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Visible = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count)
                        listBox1.SelectedIndex += 1;
                }
                catch { }
            }
            else if (e.KeyCode == Keys.Up)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex > 1)
                        listBox1.SelectedIndex -= 1;
                }
                catch { }
            }
        }

        private void TextBoxFoundProblem3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Visible = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count)
                        listBox1.SelectedIndex += 1;
                }
                catch { }
            }
            else if (e.KeyCode == Keys.Up)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex > 1)
                        listBox1.SelectedIndex -= 1;
                }
                catch { }
            }
        }

        private void TextBoxFoundProblem4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Visible = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count)
                        listBox1.SelectedIndex += 1;
                }
                catch { }
            }
            else if (e.KeyCode == Keys.Up)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex > 1)
                        listBox1.SelectedIndex -= 1;
                }
                catch { }
            }
        }

        private void TextBoxFoundProblem5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Visible = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count)
                        listBox1.SelectedIndex += 1;
                }
                catch { }
            }
            else if (e.KeyCode == Keys.Up)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex > 1)
                        listBox1.SelectedIndex -= 1;
                }
                catch { }
            }
        }
        
        private void ListBox1_Click(object sender, EventArgs e)
        {
            try
            {
                using Context context = new();
                List<Malfunction> list;
                int id = listBox1.SelectedIndex;
                if (id >= 0)
                {
                    switch (numberProblem)
                    {
                        case 1:
                            
                            textBoxFoundProblem1.Text = listBox1.Items[id].ToString();
                            listBox1.Visible = false;
                            list = context.Malfunctions.Where(i => i.Name == textBoxFoundProblem1.Text).ToList();
                            textBoxPrice1.Text = list[0].Price.ToString();
                            textBoxPrice1.Focus();
                            break;
                        case 2:
                            textBoxFoundProblem2.Text = listBox1.Items[id].ToString();
                            listBox1.Visible = false;
                            list = context.Malfunctions.Where(i => i.Name == textBoxFoundProblem2.Text).ToList();
                            textBoxPrice2.Text = list[0].Price.ToString();
                            textBoxPrice2.Focus();
                            break;
                        case 3:
                            textBoxFoundProblem3.Text = listBox1.Items[id].ToString();
                            listBox1.Visible = false;
                            list = context.Malfunctions.Where(i => i.Name == textBoxFoundProblem3.Text).ToList();
                            textBoxPrice3.Text = list[0].Price.ToString();
                            textBoxPrice3.Focus();
                            break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public DateTime DateComplete
        {
            get { return this.dateTimePicker1.Value; }
            set { this.dateTimePicker1.Value = value; }
        }
        public bool EnabledPrice
        {
            get { return textBoxPrice1.Enabled; }
            set { textBoxPrice1.Enabled = value; }
        }
    }
}
