using WinFormsApp1.DTO;
using WinFormsApp1.Helpers;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class CompletedOrder : Form
    {
        readonly DateTime dateCreate;
        readonly int idOrder;
        public List<string>? problem = [];
        public List<int>? price = [];
        int sumDetails = 0;
        public List<string> nameProblem = [];
        private int numberProblem = 1;
        public int countProblem = 0;
        MalfunctionRepository malfunctionRepository = new();
        WarehouseRepository warehouseRepository = new();
        OrderRepository orderRepository = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();
        OrderEditDTO orderDTO;
        MalfunctionEditDTO malfunctionDTO;
        public CompletedOrder(int id)
        {
            InitializeComponent();
            idOrder = id;
            orderDTO = orderRepository.GetOrder(idOrder);

            var malfunctionList = malfunctionRepository.GetMalfunctions();
            foreach (var malfunction in malfunctionList)
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
                    sumDetails += detail.PriceSale;

                }

                labelPriceDetails.Text = String.Format("{0} руб.", sumDetails);
                labelCountDetails.Text = String.Format("{0} шт.", detailsListName.Count);
            }

            dateCreate = orderDTO.DateCreation.Value;
            labelDurationRepair.Text = String.Format("{0} дн.", (int)(DateTime.Now - dateCreate).TotalDays);
            labelIdOrder.Text = orderDTO.NumberOrder.ToString();
            labelNameDevice.Text = String.Format("{0} {1} {2}", orderDTO.TypeTechnic?.Name,
                orderDTO.BrandTechnic?.Name, orderDTO.ModelTechnic);

            if (orderDTO.AdditionalMasterId != null)
            {
                panelMasters.Visible = true;
                labelMainMaster.Text = orderDTO.MainMaster?.NameMaster;
                labelAdditionalMaster.Text = orderDTO.AdditionalMaster?.NameMaster;
            }
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

            if (orderDTO.AdditionalMasterId != null && (string.IsNullOrEmpty(textBoxMain.Text) || string.IsNullOrEmpty(textBoxAdditional.Text)))
            {
                warning.ShowDialog();
                return;
            }

            switch (countProblem)
            {
                case 0:
                    warning.ShowDialog();
                    return;
                case 1:
                    if (string.IsNullOrEmpty(textBoxPrice1.Text))
                    {
                        warning.ShowDialog();
                        return;
                    }
                    problem?.Add(textBoxFoundProblem1.Text);
                    price?.Add(Convert.ToInt32(textBoxPrice1.Text));
                    break;
                case 2:
                    if (string.IsNullOrEmpty(textBoxPrice1.Text) || string.IsNullOrEmpty(textBoxPrice2.Text))
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
                    if (string.IsNullOrEmpty(textBoxPrice1.Text) || string.IsNullOrEmpty(textBoxPrice2.Text) || string.IsNullOrEmpty(textBoxPrice3.Text))
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
            int? sumPrice = price?.Sum() + sumDetails;
            if (orderDTO.PriceAgreed && sumPrice > orderDTO.MaxPrice)
            {
                warning.LabelText = String.Format("Цена ремонта выше согласованной! \nСогласованная цена: {0} руб.", orderDTO.MaxPrice);
                warning.VisibleChangePrice = true;
                warning.id = idOrder;
                if (warning.ShowDialog() == DialogResult.OK)
                    orderDTO = orderRepository.GetOrder(idOrder);
                return;
            }

            Task task;
            int idMalfunction = 0;
            for (int i = 0; i < countProblem; i++)
            {
                malfunctionDTO = malfunctionRepository.GetMalfunctionByName(problem[i]);
                malfunctionDTO.Price = price[i];
                task = Task.Run(async () =>
                {
                    idMalfunction = await malfunctionRepository.SaveMalfunctionAsync(malfunctionDTO);
                });
                task.Wait();

                var malfunctionOrderDTO = new MalfunctionOrderEditDTO()
                {
                    MalfunctionId = idMalfunction,
                    OrderId = idOrder,
                    Price = price[i]
                };
                task = Task.Run(async () =>
                {
                    await malfunctionOrderRepository.SaveMalfunctionOrderAsync(malfunctionOrderDTO);
                });
                task.Wait();
            }

            orderDTO.InProgress = false;
            orderDTO.DateCompleted = dateTimePicker1.Value;
            if (orderDTO.AdditionalMasterId != null)
            {
                orderDTO.PercentWorkMainMaster = Convert.ToInt32(textBoxMain.Text);
                orderDTO.PercentWorkAdditionalMaster = Convert.ToInt32(textBoxAdditional.Text);
            }
            else orderDTO.PercentWorkMainMaster = 100;
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
            task.Wait();
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
            foreach (var problem in nameProblem)
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
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void TextBoxPrice2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void TextBoxPrice3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
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



        private void TextBoxMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(true, textBoxMain.Text, e.KeyChar);
        }

        private void TextBoxAdditional_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(true, textBoxAdditional.Text, e.KeyChar);
        }

        private void TextBoxMain_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxMain.Text))
                textBoxAdditional.Text = (100 - Convert.ToInt32(textBoxMain.Text)).ToString();
            else textBoxAdditional.Text = string.Empty;
        }

        private void TextBoxAdditional_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxAdditional.Text))
                textBoxMain.Text = (100 - Convert.ToInt32(textBoxAdditional.Text)).ToString();
            else textBoxMain.Text = string.Empty;
        }

        private void LinkLabelFeaturesOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FeaturesOrder featuresOrder = new(idOrder, Enum.StatusOrderEnum.InRepair, true)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (featuresOrder.ShowDialog() == DialogResult.OK)
            {
                orderDTO = orderRepository.GetOrder(idOrder);
                if (orderDTO.AdditionalMasterId != null)
                {
                    panelMasters.Visible = true;
                    labelMainMaster.Text = orderDTO.MainMaster?.NameMaster;
                    labelAdditionalMaster.Text = orderDTO.AdditionalMaster?.NameMaster;
                }
                else panelMasters.Visible = false;
            }
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
