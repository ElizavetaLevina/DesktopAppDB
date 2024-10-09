using WinFormsApp1.DTO;
using WinFormsApp1.Helpers;
using WinFormsApp1.Enum;
using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class CompletedOrder : Form
    {
        public string FoundProblem1
        {
            get { return textBoxFoundProblem1.Text; }
            set { textBoxFoundProblem1.Text = value; }
        }
        public string FoundProblem2
        {
            get { return textBoxFoundProblem2.Text; }
            set { textBoxFoundProblem2.Text = value; }
        }
        public string FoundProblem3
        {
            get { return textBoxFoundProblem3.Text; }
            set { textBoxFoundProblem3.Text = value; }
        }
        public string PriceProblem1
        {
            get { return textBoxPrice1.Text; }
            set { textBoxPrice1.Text = value; }
        }
        public string PriceProblem2
        {
            get { return textBoxPrice2.Text; }
            set { textBoxPrice2.Text = value; }
        }
        public string PriceProblem3
        {
            get { return textBoxPrice3.Text; }
            set { textBoxPrice3.Text = value; }
        }
        DateTime dateCreate;
        public int idOrder;
        private int numberProblem = 1;
        public int countProblem = 0;
        IMalfunctionsLogic malfunctionsLogic;
        IOrdersLogic ordersLogic;
        IWarehousesLogic warehousesLogic;
        IMalfunctionsOrdersLogic malfunctionsOrdersLogic;
        //bool loading = true;
        OrderEditDTO orderDTO;
        List<MalfunctionEditDTO> malfunctionsDTO;
        public CompletedOrder(IMalfunctionsLogic _malfunctionsLogic, IOrdersLogic _ordersLogic, IWarehousesLogic _warehousesLogic,
            IMalfunctionsOrdersLogic _malfunctionsOrdersLogic)
        {
            malfunctionsLogic = _malfunctionsLogic;
            ordersLogic = _ordersLogic;
            warehousesLogic = _warehousesLogic;
            malfunctionsOrdersLogic = _malfunctionsOrdersLogic;
            InitializeComponent();
        }

        public async void InitializeElementsFormAsync()
        {
            orderDTO = await ordersLogic.GetOrderAsync(idOrder);
            malfunctionsDTO = await malfunctionsLogic.GetMalfunctionsAsync();
            labelPriceDetails.Text = String.Format("{0} руб.", await warehousesLogic.GetPriceDetailsInOrderAsync(idOrder));
            labelCountDetails.Text = String.Format("{0} шт.", await warehousesLogic.GetCountDetailsInOrderAsync(idOrder));
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

        private void TextBoxKeyDown(Keys keyCode, TextBox nextTextBox)
        {
            if (keyCode == Keys.Enter)
            {
                SelectingElementsListBoxAsync();
                if (listBox1.Visible)
                    listBox1.Visible = false;
                nextTextBox.Focus();
            }
            else if (keyCode == Keys.Down)
            {
                listBox1.Focus();
                try
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count)
                        listBox1.SelectedIndex += 1;
                }
                catch { }
            }
            else if (keyCode == Keys.Up)
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

        private async void SelectingElementsListBoxAsync()
        {
            if (listBox1.SelectedIndex >= 0)
            {
                switch (numberProblem)
                {
                    case 1:
                        FoundProblem1 = listBox1.Items[listBox1.SelectedIndex].ToString();
                        PriceProblem1 = await malfunctionsLogic.GetPriceMalfunctionByNameAsync(FoundProblem1);
                        textBoxPrice1.Focus();
                        break;
                    case 2:
                        FoundProblem2 = listBox1.Items[listBox1.SelectedIndex].ToString();
                        PriceProblem2 = await malfunctionsLogic.GetPriceMalfunctionByNameAsync(FoundProblem2);
                        textBoxPrice2.Focus();
                        break;
                    case 3:
                        FoundProblem3 = listBox1.Items[listBox1.SelectedIndex].ToString();
                        PriceProblem3 = await malfunctionsLogic.GetPriceMalfunctionByNameAsync(FoundProblem3);
                        textBoxPrice3.Focus();
                        break;
                }
                listBox1.Visible = false;
            }
        }

        private void ClickOnFoundProblem(int number, TextBox textBox)
        {
            if (numberProblem == number && listBox1.Visible)
            {
                listBox1.Visible = false; return;
            }
            numberProblem = number;
            listBox1.DataSource = FoundProblemTextChangeHelper.GetItemsListBox(textBox.Text, malfunctionsDTO);
            listBox1.Location = new Point(listBox1.Location.X, textBox.Location.Y + textBox.Height);
            listBox1.Visible = true;
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

        private async void ButtonSave_ClickAsync(object sender, EventArgs e)
        {
            List<string> foundProblem = [];
            List<int> priceProblem = [];

            Warning warning = new();

            if (orderDTO.AdditionalMasterId != null && 
                (string.IsNullOrEmpty(textBoxMain.Text) || string.IsNullOrEmpty(textBoxAdditional.Text)))
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
                    if (string.IsNullOrEmpty(PriceProblem1))
                    {
                        warning.ShowDialog();
                        return;
                    }
                    foundProblem = FoundProblemTextChangeHelper.GetFoundProblem(countProblem: countProblem,
                        textBoxProblem1: FoundProblem1);
                    priceProblem = FoundProblemTextChangeHelper.GetPriceProblem(countProblem: countProblem,
                        textBoxPrice1: PriceProblem1);
                    break;
                case 2:
                    if (string.IsNullOrEmpty(PriceProblem1) || string.IsNullOrEmpty(PriceProblem2))
                    {
                        warning.ShowDialog();
                        return;
                    }
                    foundProblem = FoundProblemTextChangeHelper.GetFoundProblem(countProblem: countProblem,
                        textBoxProblem1: FoundProblem1, textBoxProblem2: FoundProblem2);
                    priceProblem = FoundProblemTextChangeHelper.GetPriceProblem(countProblem: countProblem,
                        textBoxPrice1: PriceProblem1, textBoxPrice2: PriceProblem2);
                    break;
                case 3:
                    if (string.IsNullOrEmpty(PriceProblem1) || string.IsNullOrEmpty(PriceProblem2) || 
                        string.IsNullOrEmpty(PriceProblem3))
                    {
                        warning.ShowDialog();
                        return;
                    }
                    foundProblem = FoundProblemTextChangeHelper.GetFoundProblem(countProblem: countProblem,
                        textBoxProblem1: FoundProblem1, textBoxProblem2: FoundProblem2,
                        textBoxProblem3: FoundProblem3);
                    priceProblem = FoundProblemTextChangeHelper.GetPriceProblem(countProblem: countProblem,
                        textBoxPrice1: PriceProblem1, textBoxPrice2: PriceProblem2, textBoxPrice3: PriceProblem3);
                    break;
            }

            if (orderDTO.PriceAgreed && (priceProblem.Sum() + await warehousesLogic.GetPriceDetailsInOrderAsync(idOrder)) > 
                orderDTO.MaxPrice)
            {
                warning.LabelText = String.Format("Цена ремонта выше согласованной! \nСогласованная цена: {0} руб.", 
                    orderDTO.MaxPrice);
                warning.VisibleChangePrice = true;
                warning.id = idOrder;
                if (warning.ShowDialog() == DialogResult.OK)
                    orderDTO = await ordersLogic.GetOrderAsync(idOrder);
                return;
            }

            for (int i = 0; i < countProblem; i++)
            {
                var malfunctionDTO = await malfunctionsLogic.GetMalfunctionByNameAsync(foundProblem[i]);
                malfunctionDTO.Name = foundProblem[i];
                malfunctionDTO.Price = priceProblem[i];
                var idMalfunction = await malfunctionsLogic.SaveMalfunctionAsync(malfunctionDTO);
                var malfunctionOrderDTO = new MalfunctionOrderEditDTO()
                {
                    MalfunctionId = idMalfunction,
                    OrderId = idOrder,
                    Price = priceProblem[i]
                };
                await malfunctionsOrdersLogic.SaveMalfunctionOrderAsync(malfunctionOrderDTO);
            }

            orderDTO.StatusOrder = StatusOrderEnum.Completed;
            orderDTO.DateCompleted = dateTimePicker1.Value.ToUniversalTime();
            if (orderDTO.AdditionalMasterId != null)
            {
                orderDTO.PercentWorkMainMaster = Convert.ToInt32(textBoxMain.Text);
                orderDTO.PercentWorkAdditionalMaster = Convert.ToInt32(textBoxAdditional.Text);
            }
            else orderDTO.PercentWorkMainMaster = 100;
            await ordersLogic.SaveOrderAsync(orderDTO);
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
            listBox1.DataSource = FoundProblemTextChangeHelper.GetItemsListBox(FoundProblem1, malfunctionsDTO);

            if (listBox1.Items.Count > 0)
                listBox1.Visible = true;
            else listBox1.Visible = false;
                

            if (string.IsNullOrEmpty(FoundProblem1))
            {
                countProblem = 0;
                textBoxFoundProblem2.Enabled = false;
                textBoxFoundProblem3.Enabled = false;
                textBoxPrice2.Enabled = false;
                textBoxPrice3.Enabled = false;
                PriceProblem1 = string.Empty;
            }
            else
            {
                countProblem = 1;
                textBoxFoundProblem2.Enabled = true;
                textBoxPrice2.Enabled = true;
                if (!string.IsNullOrEmpty(FoundProblem2))
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
            listBox1.DataSource = FoundProblemTextChangeHelper.GetItemsListBox(FoundProblem2, malfunctionsDTO);

            if (listBox1.Items.Count > 0)
                listBox1.Visible = true;
            else listBox1.Visible = false;

            if (string.IsNullOrEmpty(FoundProblem2))
            {
                countProblem = 1;
                textBoxFoundProblem3.Enabled = false;
                textBoxPrice3.Enabled = false;
                PriceProblem2 = string.Empty;
            }
            else
            {
                countProblem = 2;
                textBoxFoundProblem3.Enabled = true;
                textBoxPrice3.Enabled = true;
                if (!string.IsNullOrEmpty(FoundProblem3))
                    countProblem = 3;
            }
        }

        private void TextBoxFoundProblem3_TextChanged(object sender, EventArgs e)
        {
            numberProblem = 3;
            listBox1.Location = new Point(listBox1.Location.X, textBoxFoundProblem3.Location.Y +
                textBoxFoundProblem3.Height);
            listBox1.DataSource = FoundProblemTextChangeHelper.GetItemsListBox(FoundProblem3, malfunctionsDTO);

            if (listBox1.Items.Count > 0)
                listBox1.Visible = true;
            else listBox1.Visible = false;

            if (string.IsNullOrEmpty(FoundProblem3))
            {
                countProblem = 2;
                PriceProblem3 = string.Empty;
            }
            else
                countProblem = 3;
        }

        private void TextBoxFoundProblem1_Click(object sender, EventArgs e)
        {
            ClickOnFoundProblem(1, textBoxFoundProblem1);
        }

        private void TextBoxFoundProblem2_Click(object sender, EventArgs e)
        {
            ClickOnFoundProblem(2, textBoxFoundProblem2);
        }

        private void TextBoxFoundProblem3_Click(object sender, EventArgs e)
        {
            ClickOnFoundProblem(3, textBoxFoundProblem3);
        }

        private void TextBoxFoundProblem1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (KeyPressHelper.CheckKeyTab(e.KeyCode, listBox1.Visible))
                listBox1.Visible = false;
        }

        private void TextBoxFoundProblem2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (KeyPressHelper.CheckKeyTab(e.KeyCode, listBox1.Visible))
                listBox1.Visible = false;
        }

        private void TextBoxFoundProblem3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (KeyPressHelper.CheckKeyTab(e.KeyCode, listBox1.Visible))
                listBox1.Visible = false;
        }

        private void TextBoxPrice1_KeyPress(object sender, KeyPressEventArgs e)
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
            TextBoxKeyDown(e.KeyCode, nextTextBox: textBoxPrice1);
        }

        private void TextBoxFoundProblem2_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxKeyDown(e.KeyCode, nextTextBox: textBoxPrice2);
        }

        private void TextBoxFoundProblem3_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxKeyDown(e.KeyCode, nextTextBox: textBoxPrice3);
        }

        private void ListBox1_Click(object sender, EventArgs e)
        {
            SelectingElementsListBoxAsync();
        }

        private void ListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectingElementsListBoxAsync();
            }
            else if (e.KeyCode == Keys.Up && listBox1.SelectedIndex == 0)
            {
                switch (numberProblem)
                {
                    case 1:
                        textBoxFoundProblem1.Focus();
                        break;
                    case 2:
                        textBoxFoundProblem2.Focus();
                        break;
                    case 3:
                        textBoxFoundProblem3.Focus();
                        break;
                }
            }
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

        private async void LinkLabelPropertiesOrder_LinkClickedAsync(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PropertiesOrder propertiesOrder = Program.ServiceProvider.GetRequiredService<PropertiesOrder>();
            propertiesOrder.InitializeElementsFormAsync(idOrder, StatusOrderEnum.InRepair, true);
            if (propertiesOrder.ShowDialog() == DialogResult.OK)
            {
                orderDTO = await ordersLogic.GetOrderAsync(idOrder);
                if (orderDTO.AdditionalMasterId != null)
                {
                    panelMasters.Visible = true;
                    labelMainMaster.Text = orderDTO.MainMaster?.NameMaster;
                    labelAdditionalMaster.Text = orderDTO.AdditionalMaster?.NameMaster;
                }
                else panelMasters.Visible = false;
            }
        }

        private void CompletedOrder_Activated(object sender, EventArgs e)
        {
            textBoxFoundProblem1.Focus();
        }
    }
}
