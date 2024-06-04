using System.Data;
using WinFormsApp1.Model;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class FeaturesOrder : Form
    {
        public int idOrder;
        public string statusOrder;
        public bool pressBtnSave = false;
        public bool show = true;
        public FeaturesOrder(int id, string status)
        {
            InitializeComponent();
            idOrder = id;
            statusOrder = status;
            this.Text = "Свойства устройства (заказ №" + id + ")";
            Context context = new();
            var list = context.Orders.Where(i => i.Id == id).ToList();

            //IdOrder
            textBoxIdOrder.Text = list[0].Id.ToString();

            //StatusOrder
            if (list[0].InProgress)
                textBoxStatus.Text = "Находится в ремонте";
            else
                textBoxStatus.Text = "Отремонтирован";

            //NameMaster
            UpdateComboBox(0);
            var listMaster = context.Masters.Where(i => i.Id == list[0].MasterId).ToList();
            if (listMaster.Count > 0 && listMaster[0].NameMaster != null)
                comboBoxMaster.SelectedIndex = comboBoxMaster.FindStringExact(listMaster[0].NameMaster);

            //DateCreation
            dateCreation.Value = DateTime.Parse(list[0].DateCreation);

            //Device
            UpdateComboBox(1);
            var listDevice = context.TypeTechnices.Where(i => i.Id == list[0].TypeTechnicId).ToList();
            comboBoxDevice.SelectedIndex = comboBoxDevice.FindStringExact(listDevice[0].NameTypeTechnic);

            //Brand
            UpdateComboBox(2);
            var listBrand = context.BrandTechnices.Where(i => i.Id == list[0].BrandTechnicId).ToList();
            comboBoxBrand.SelectedIndex = comboBoxBrand.FindStringExact(listBrand[0].NameBrandTechnic);

            //Model
            textBoxModel.Text = list[0].ModelTechnic;

            //FactoryNumber
            textBoxFactoryNumber.Text = list[0].FactoryNumber;

            //PriceAgreed
            checkBoxPriceAgreed.Checked = list[0].PriceAgreed;
            textBoxMaxPrice.Text = list[0].MaxPrice.ToString();
            show = !list[0].PriceAgreed;

            //Equipment
            textBoxEquipment.Text = list[0].Equipment;

            //Diagnosis
            textBoxDiagnosis.Text = list[0].Diagnosis;

            //Note
            textBoxNote.Text = list[0].Note;

            //NameClient
            var listClient = context.Clients.Where(i => i.Id == list[0].ClientId).ToList();
            textBoxClientName.Text = listClient[0].NameClient;

            //Address
            textBoxAddress.Text = listClient[0].Address;

            //HomePhone
            textBoxHomePhone.Text = listClient[0].NumberPhoneHome;

            //WorkPhone
            textBoxWorkPhone.Text = listClient[0].NumberPhoneWork;

            //TypeClient
            switch (listClient[0].TypeClient)
            {
                case "normal":
                    textBoxTypeClient.Text = "Обычный клиент"; break;
                case "white":
                    textBoxTypeClient.Text = "В белом списке"; break;
                case "black":
                    textBoxTypeClient.Text = "В черном списке"; break;
            }

            switch (status)
            {
                case "Completed":
                    OrderComplete();
                    break;
                case "GuaranteeIssue":
                    OrderIssue();
                    break;
                case "Archive":
                    OrderIssue();
                    break;
            }
        }

        private void UpdateComboBox(int idBox)
        {
            switch (idBox)
            {
                case 0:
                    comboBoxMaster.DataSource = null;
                    comboBoxMaster.Items.Clear();
                    using (Context context = new())
                    {
                        comboBoxMaster.ValueMember = "Id";
                        comboBoxMaster.DisplayMember = "NameMaster";
                        var list = context.Masters.ToList();
                        list.Insert(0, new Master() { Id = -1, NameMaster = "-" });
                        comboBoxMaster.DataSource = list;
                    }
                    break;
                case 1:
                    comboBoxDevice.DataSource = null;
                    comboBoxDevice.Items.Clear();
                    using (Context context = new())
                    {
                        comboBoxDevice.ValueMember = "Id";
                        comboBoxDevice.DisplayMember = "NameTypeTechnic";
                        comboBoxDevice.DataSource = context.TypeTechnices.ToList();
                    }
                    break;
                case 2:
                    comboBoxBrand.DataSource = null;
                    comboBoxBrand.Items.Clear();
                    using (Context context = new())
                    {
                        comboBoxBrand.ValueMember = "Id";
                        comboBoxBrand.DisplayMember = "NameBrandTechnic";
                        comboBoxBrand.DataSource = context.BrandTechnices.ToList();
                    }
                    break;
            }
        }

        public void OrderComplete()
        {
            Context context = new();
            int summDetails = 0;
            int sumPrice = 0;

            List<TextBox> problem = [textBoxProblem1, textBoxProblem2, textBoxProblem3,
                textBoxProblem4, textBoxProblem5];
            List<TextBox> price = [textBoxPrice1, textBoxPrice2, textBoxPrice3, textBoxPrice4,
                textBoxPrice5];
            List<Label> lProblem = [labelProblem1, labelProblem2, labelProblem3, labelProblem4,
                labelProblem5];
            List<Label> lPrice = [labelPrice1, labelPrice2, labelPrice3, labelPrice4,
                labelPrice5];
            List<Label> lRub = [labelRub1, labelRub2, labelRub3, labelRub4, labelRub5];
            

            var listDetails = context.Details.Where(i => i.Id == idOrder).Select(a => new
            {
                a.IdWarehouse
            }).ToList();

            if (listDetails[0].IdWarehouse != null)
            {
                var listWarehouse = context.Warehouse.ToList();
                List<string> listNameS = [];
                List<int> listPriceSaleS = [];

                for (int i = 0; i < listDetails[0].IdWarehouse.Count; i++)
                {
                    for (int j = 0; j < listWarehouse.Count; j++)
                    {
                        if (listDetails[0].IdWarehouse[i] == listWarehouse[j].Id)
                        {
                            listNameS.Add(listWarehouse[j].NameDetail);
                            listPriceSaleS.Add(listWarehouse[j].PriceSale);
                        }
                    }
                }
                for (int i = 0; i < listNameS.Count; i++)
                {
                    listBox1.Items.Add((i + 1) + ". " + listNameS[i] + " (" + listPriceSaleS[i]
                        + " руб.)");
                    summDetails += listPriceSaleS[i];
                }
                textBoxPriceDetails.Text = summDetails.ToString() + " руб.";
                textBoxCountDetails.Text = listPriceSaleS.Count.ToString() + " шт.";
            }            
            

            var list = context.MalfunctionOrders.Where(i => i.OrderId == idOrder).
                Select(a => new {a.Malfunction, a.Price}).ToList();
            for(int i = 0; i < list.Count;i++)
            {
                problem[i].Enabled = true;
                price[i].Enabled = true;
                problem[i].Text = list[i].Malfunction.Name;
                price[i].Text = list[i].Price.ToString();
                lProblem[i].ForeColor = Color.Black;
                lPrice[i].ForeColor = Color.Black;
                lRub[i].ForeColor = Color.Black;
                sumPrice += list[i].Price;
            }
            textBoxSumPrice.Text = sumPrice.ToString();
        }

        public void OrderIssue()
        {
            OrderComplete();
            Context context = new();
            var list = context.Orders.Where(i => i.Id == idOrder).ToList();

            label20.ForeColor = Color.Black;
            label21.ForeColor = Color.FromArgb(105, 101, 148);
            label22.ForeColor = Color.FromArgb(105, 101, 148);
            label23.ForeColor = Color.FromArgb(105, 101, 148);
            label24.ForeColor = Color.FromArgb(105, 101, 148);

            dateTimePicker1.Enabled = true;
            textBoxAvailabilityGuarantee.Enabled = true;
            textBoxGuaranteePeriod.Enabled = true;
            textBoxEndGuarantee.Enabled = true;
            textBoxGuaranteeLeft.Enabled = true;

            dateTimePicker1.Value = DateTime.Parse(list[0].DateIssue);

            if (list[0].Guarantee > 0)
            {
                if (DateTime.Now < DateTime.Parse(list[0].DateEndGuarantee))
                    textBoxAvailabilityGuarantee.Text = "Присутствует";
                else
                    textBoxAvailabilityGuarantee.Text = "Закончилась";
            }
            else
                textBoxAvailabilityGuarantee.Text = "Отсутствует";

            textBoxGuaranteePeriod.Text = list[0].Guarantee.ToString() + " мес.";
            textBoxEndGuarantee.Text = list[0].DateEndGuarantee;

            if (((int)(DateTime.Parse(list[0].DateEndGuarantee) - DateTime.Now).TotalDays) > 0)
                textBoxGuaranteeLeft.Text = ((int)(DateTime.Parse(list[0].DateEndGuarantee) - DateTime.Now).TotalDays).ToString() + " дн.";
            else
                textBoxGuaranteeLeft.Text = "Закончилась";

        }

        private void LinkLabelMaster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddMaster addMaster = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMaster.ShowDialog();
            UpdateComboBox(0);
        }

        private void LinkLabelDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddDevice addDevice = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addDevice.ShowDialog();
            UpdateComboBox(1);
        }

        private void LinkLabelBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddBrand addBrand = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addBrand.ShowDialog();
            UpdateComboBox(2);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Context context = new();
            int id = Convert.ToInt32(textBoxIdOrder.Text);
            var list = context.Orders.Where(a => a.Id == id).ToList();
            string foundProblem = "";
            int priceRepair = 0;
            string dateIssue = "";
            string dateEndGuarantee = "";
            int? nameMaster = null;
            string? dateStartWork = list[0].DateStartWork;
            Color color = Color.Black;
            int? maxPrice = null;

            if (checkBoxPriceAgreed.Checked && textBoxMaxPrice.TextLength == 0)
            {
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Не заполнена максимальная цена!"
                };
                warning.ShowDialog();
                return;
            }
            else if (checkBoxPriceAgreed.Checked)
                maxPrice = Convert.ToInt32(textBoxMaxPrice.Text);

            if (comboBoxMaster.Text != "-")
            {
                nameMaster = context.Masters.Where(a => a.NameMaster == comboBoxMaster.Text).ToList()[0].Id;
                if (list[0].DateStartWork == null)
                    dateStartWork = DateTime.Now.ToShortDateString();
            }

            switch (statusOrder)
            {
                case "Accepted":
                    var countDay = 0;
                    if (comboBoxMaster.Text != "-")
                        countDay = (DateTime.Now - DateTime.Parse(dateStartWork)).Days;
                    else
                    {
                        dateStartWork = null;
                        countDay = (DateTime.Now - dateCreation.Value).Days;
                    }

                    if (countDay < Convert.ToInt32(Properties.Settings.Default.FirstLevelText))
                        color = Properties.Settings.Default.FirstLevelColor;
                    else if (countDay > Convert.ToInt32(Properties.Settings.Default.SecondLevelText))
                        color = Properties.Settings.Default.ThirdLevelColor;
                    else
                        color = Properties.Settings.Default.SecondLevelColor;
                    break;
                case "InRepair":
                    if (comboBoxMaster.Text != "-")
                        countDay = (DateTime.Now - DateTime.Parse(dateStartWork)).Days;
                    else
                    {
                        dateStartWork = null;
                        countDay = (DateTime.Now - dateCreation.Value).Days;
                    }
                    if (countDay < Convert.ToInt32(Properties.Settings.Default.FirstLevelText))
                        color = Properties.Settings.Default.FirstLevelColor;
                    else if (countDay > Convert.ToInt32(Properties.Settings.Default.SecondLevelText))
                        color = Properties.Settings.Default.ThirdLevelColor;
                    else
                        color = Properties.Settings.Default.SecondLevelColor;
                    break;
                case "Completed":
                    countDay = (DateTime.Now - DateTime.Parse(list[0].DateCompleted)).Days;
                    if (countDay < Convert.ToInt32(Properties.Settings.Default.FirstLevelText))
                        color = Properties.Settings.Default.FirstLevelColor;
                    else if (countDay > Convert.ToInt32(Properties.Settings.Default.SecondLevelText))
                        color = Properties.Settings.Default.ThirdLevelColor;
                    else
                        color = Properties.Settings.Default.SecondLevelColor;
                    foundProblem = textBoxProblem1.Text;
                    priceRepair = Convert.ToInt32(textBoxPrice1.Text);
                    break;
                case "GuaranteeIssue":
                    foundProblem = textBoxProblem1.Text;
                    priceRepair = Convert.ToInt32(textBoxPrice1.Text);
                    dateIssue = dateTimePicker1.Value.ToString();
                    dateEndGuarantee = (dateTimePicker1.Value.AddMonths(list[0].Guarantee)).ToString();
                    break;
                case "Archive":
                    foundProblem = textBoxProblem1.Text;
                    priceRepair = Convert.ToInt32(textBoxPrice1.Text);
                    dateIssue = dateTimePicker1.Value.ToString();
                    dateEndGuarantee = (dateTimePicker1.Value.AddMonths(list[0].Guarantee)).ToString();
                    break;
            }

            CRUD.ChangeOrder(id,
                list[0].ClientId,
                nameMaster,
                dateCreation.Text,
                dateStartWork,
                list[0].DateCompleted,
                dateIssue,
                context.TypeTechnices.Where(a => a.NameTypeTechnic == comboBoxDevice.Text).ToList()[0].Id,
                context.BrandTechnices.Where(a => a.NameBrandTechnic == comboBoxBrand.Text).ToList()[0].Id,
                textBoxModel.Text,
                textBoxFactoryNumber.Text,
                textBoxEquipment.Text,
                textBoxDiagnosis.Text,
                textBoxNote.Text,
                list[0].InProgress,
                list[0].Guarantee,
                textBoxEndGuarantee.Text,
                list[0].Deleted,
                list[0].ReturnUnderGuarantee,
                list[0].DateReturn,
                list[0].DateCompletedReturn,
                list[0].DateIssueReturn,
                list[0].Issue,
                /*list[0].PriceRepair,
                list[0].FoundProblem,*/
                ColorTranslator.ToHtml(color),
                textBoxDateLastCall.Text,
                checkBoxPriceAgreed.Checked,
                maxPrice);
            pressBtnSave = true;
            this.Close();
        }

        private void TextBoxPriceRepair_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Context context = new();
            var list = context.Orders.Where(i => i.Id == idOrder).Select(a => new
            {
                a.DateCompleted,
                a.Guarantee,
                a.DateIssue
            }).ToList();

            if (dateTimePicker1.Value < DateTime.Parse(list[0].DateCompleted))
                dateTimePicker1.Value = DateTime.Parse(list[0].DateCompleted);

            textBoxEndGuarantee.Text = (dateTimePicker1.Value.AddMonths(list[0].Guarantee)).ToShortDateString();
            if (((int)(DateTime.Parse(textBoxEndGuarantee.Text) - DateTime.Now).TotalDays) > 0)
                textBoxGuaranteeLeft.Text = ((int)(DateTime.Parse(textBoxEndGuarantee.Text) - DateTime.Now).TotalDays).ToString() + " дн.";
            else
                textBoxGuaranteeLeft.Text = "Закончилась";

            if (list[0].Guarantee > 0)
            {
                if (DateTime.Now < DateTime.Parse(textBoxEndGuarantee.Text))
                    textBoxAvailabilityGuarantee.Text = "Присутствует";
                else
                    textBoxAvailabilityGuarantee.Text = "Закончилась";
            }
        }

        private void FeaturesOrder_Activated(object sender, EventArgs e)
        {
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxDateLastCall.Text = DateTime.Now.ToShortDateString();
        }

        private void TextBoxDateLastCall_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void FeaturesOrder_Load(object sender, EventArgs e)
        {
            timer1.Interval = 200;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (show)
            {
                Context context = new();
                var list = context.Orders.Where(i => i.Id == idOrder).ToList();
                if (!list[0].PriceAgreed)
                {
                    show = false;
                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Цена не согласована!"
                    };
                    warning.ShowDialog();
                }
            }
        }

        private void TextBoxMaxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

        private void CheckBoxPriceAgreed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPriceAgreed.Checked)
                textBoxMaxPrice.Enabled = true;
            else
                textBoxMaxPrice.Enabled = false;
        }
    }
}
