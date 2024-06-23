using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class CompletedOrder : Form
    {
        readonly DateTime dateCreate;
        readonly int idOrder;
        public List<string>? problem = [];
        public List<int>? price = [];
        public List<string>? nameProblem = [];
        private int numberProblem = 1;
        public int countProblem = 0;
        MalfunctionRepository malfunctionRepository = new();
        WarehouseRepository warehouseRepository = new();
        OrderRepository orderRepository = new();
        OrderEditDTO orderDTO;
        MalfunctionEditDTO malfunctionDTO;
        public CompletedOrder(int id)
        {
            InitializeComponent();
            idOrder = id;
            int summDetails = 0;
            orderDTO = orderRepository.GetOrderById(idOrder);

            var malfunctionList = malfunctionRepository.GetMalfunctions();
            foreach(var malfunction in malfunctionList)
            {
                nameProblem.Add(malfunction.Name);
            }

            var detailsList = warehouseRepository.GetDetailsInOrder(idOrder);
            if (detailsList.Count > 0)
            {
                List<string> detailsListName = [];
                List<int> detailsListSale = [];

                foreach (var detail in detailsList)
                {
                    detailsListName.Add(detail.NameDetail);
                    detailsListSale.Add(detail.PriceSale);
                    summDetails += detail.PriceSale;

                }

                labelPriceDetails.Text = String.Format("{0} руб.", summDetails);
                labelCountDetails.Text = String.Format("{0} шт.", detailsListName.Count);
            }

            dateCreate = orderDTO.DateCreation.Value;
            labelDurationRepair.Text = String.Format("{0} дн.", (int)(DateTime.Now - dateCreate).TotalDays);
            labelIdOrder.Text = orderDTO.NumberOrder.ToString();
            labelNameDevice.Text = String.Format("{0} {1} {2}", orderDTO.TypeTechnic?.NameTypeTechnic,
                orderDTO.BrandTechnic?.NameBrandTechnic, orderDTO.ModelTechnic);
        }

        private void LinkLabelDateNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;    
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            price?.Clear();
            problem?.Clear();
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            int? sumPrice = price?.Sum();
            if (orderDTO.PriceAgreed && sumPrice > orderDTO.MaxPrice)
            {
                warning.LabelText = String.Format("Цена ремонта выше согласованной! \nСогласованная цена: {0} руб.", orderDTO.MaxPrice);
                warning.VisibleChangePrice = true;
                warning.id = idOrder;
                warning.ShowDialog();
                return;
            }
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
                    if (textBoxPrice1.Text.Length == 0 || textBoxPrice2.Text.Length == 0)
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

            /*Task task;
            for(int i = 0; i < countProblem; i++)
            {
                malfunctionDTO = malfunctionRepository.GetMalfunctionByName(problem[i]);
                malfunctionDTO.Price = price[i];
                task = Task.Run(async () =>
                {
                    await malfunctionRepository.SaveMalfunctionAsync(malfunctionDTO);
                });
                task.Wait();
            }

            

            orderDTO.InProgress = false;
            orderDTO.DateCompleted = dateTimePicker1.Value;
            if (orderDTO.ReturnUnderGuarantee)
            {
                int countDayInRepair = (orderDTO.DateCompletedReturn.Value - orderDTO.DateReturn.Value).Days;
                DateTime? dateEndGuarantee = orderDTO.DateEndGuarantee.Value.AddDays(countDayInRepair);
                orderDTO.DateEndGuarantee = dateEndGuarantee;
            }
            task = Task.Run(async () =>
            {
                await orderRepository.SaveOrderAsync(orderDTO);
            });
            task.Wait();*/
            DialogResult = DialogResult.OK;
            Close();
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
            foreach(var problem in nameProblem)
            {
                if (problem.StartsWith(textBoxFoundProblem1.Text))
                {
                    listBox1.Visible = true;
                    listBox1.Items.Add(problem);
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
            foreach (var problem in nameProblem)
            {
                if (problem.StartsWith(textBoxFoundProblem2.Text) && textBoxFoundProblem2.Text.Length > 0)
                {
                    listBox1.Visible = true;
                    listBox1.Items.Add(problem);
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
                    countProblem = 3;
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
            foreach (var problem in nameProblem)
            {
                if (problem.StartsWith(textBoxFoundProblem3.Text) && textBoxFoundProblem3.Text.Length > 0)
                {
                    listBox1.Visible = true;
                    listBox1.Items.Add(problem);
                }
            }
            if (textBoxFoundProblem3.Text == "")
            {
                countProblem = 2;
                textBoxPrice3.Text = "";
            }
            else
                countProblem = 3;
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
        
        private void ListBox1_Click(object sender, EventArgs e)
        {
            try
            {
                MalfunctionEditDTO malfunctionDTO;
                int id = listBox1.SelectedIndex;
                if (id >= 0)
                {
                    switch (numberProblem)
                    {
                        case 1:
                            
                            textBoxFoundProblem1.Text = listBox1.Items[id].ToString();
                            listBox1.Visible = false;
                            malfunctionDTO = malfunctionRepository.GetMalfunctionByName(textBoxFoundProblem1.Text);
                            textBoxPrice1.Text = malfunctionDTO.Price.ToString();
                            textBoxPrice1.Focus();
                            break;
                        case 2:
                            textBoxFoundProblem2.Text = listBox1.Items[id].ToString();
                            listBox1.Visible = false;
                            malfunctionDTO = malfunctionRepository.GetMalfunctionByName(textBoxFoundProblem2.Text);
                            textBoxPrice2.Text = malfunctionDTO.Price.ToString();
                            textBoxPrice2.Focus();
                            break;
                        case 3:
                            textBoxFoundProblem3.Text = listBox1.Items[id].ToString();
                            listBox1.Visible = false;
                            malfunctionDTO = malfunctionRepository.GetMalfunctionByName(textBoxFoundProblem3.Text);
                            textBoxPrice3.Text = malfunctionDTO.Price.ToString();
                            textBoxPrice3.Focus();
                            break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public DateTime DateComplete
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }
        public bool EnabledPrice
        {
            get { return textBoxPrice1.Enabled; }
            set { textBoxPrice1.Enabled = value; }
        }
    }
}
