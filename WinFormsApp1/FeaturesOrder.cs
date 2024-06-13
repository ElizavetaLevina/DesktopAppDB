using System.Data;
using WinFormsApp1.Model;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class FeaturesOrder : Form
    {
        public int idOrder;
        public string statusOrder;
        public bool show = true;
        public bool logIn;
        public FeaturesOrder(int id, string status, bool _logIn)
        {
            InitializeComponent();
            logIn = _logIn;

            idOrder = id;
            statusOrder = status;
            this.Text = String.Format("Свойства устройства (заказ № {0} )", id);
            Context context = new();
            var list = context.Orders.Where(i => i.Id == id).ToList();


            textBoxIdOrder.Text = list[0].Id.ToString();

            if (list[0].InProgress)
                textBoxStatus.Text = "Находится в ремонте";
            else
                textBoxStatus.Text = "Отремонтирован";

            UpdateComboBox(0);
            var listMaster = context.Masters.Where(i => i.Id == list[0].MasterId).ToList();
            if (listMaster.Count > 0 && listMaster[0].NameMaster != null)
                comboBoxMaster.SelectedIndex = comboBoxMaster.FindStringExact(listMaster[0].NameMaster);

            dateCreation.Value = list[0].DateCreation.Value;

            UpdateComboBox(1);
            var listDevice = context.TypeTechnices.Where(i => i.Id == list[0].TypeTechnicId).ToList();
            comboBoxDevice.SelectedIndex = comboBoxDevice.FindStringExact(listDevice[0].NameTypeTechnic);

            UpdateComboBox(2);
            var listBrand = context.BrandTechnices.Where(i => i.Id == list[0].BrandTechnicId).ToList();
            comboBoxBrand.SelectedIndex = comboBoxBrand.FindStringExact(listBrand[0].NameBrandTechnic);

            textBoxModel.Text = list[0].ModelTechnic;

            textBoxFactoryNumber.Text = list[0].FactoryNumber;

            checkBoxPriceAgreed.Checked = list[0].PriceAgreed;
            textBoxMaxPrice.Text = list[0].MaxPrice.ToString();

            if (!logIn)
            {
                textBoxMaxPrice.Enabled = false;
                checkBoxPriceAgreed.Enabled = false;
            }
            show = !list[0].PriceAgreed;

            textBoxEquipment.Text = list[0].Equipment?.Name;

            textBoxDiagnosis.Text = list[0].Diagnosis?.Name;

            textBoxNote.Text = list[0].Note;

            var listClient = context.Clients.Where(i => i.Id == list[0].ClientId).ToList();
            textBoxIdClient.Text = listClient[0].IdClient;

            textBoxNameAddress.Text = String.Format("{0}, {1}", listClient[0].NameClient, listClient[0].Address);

            textBoxSecondPhone.Text = listClient[0].NumberSecondPhone;

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

            List<TextBox> problem = [textBoxProblem1, textBoxProblem2, textBoxProblem3];
            List<TextBox> price = [textBoxPrice1, textBoxPrice2, textBoxPrice3];
            List<Label> lProblem = [labelProblem1, labelProblem2, labelProblem3];
            List<Label> lPrice = [labelPrice1, labelPrice2, labelPrice3];
            List<Label> lRub = [labelRub1, labelRub2, labelRub3];


            var listDetails = context.Details.Where(i => i.Id == idOrder).Select(a => new
            {
                a.IdWarehouse
            }).ToList();

            if (listDetails[0].IdWarehouse != null)
            {
                var listWarehouse = context.Warehouse.ToList();
                List<string> listNameS = [];
                List<int> listPriceSaleS = [];

                for (int i = 0; i < listDetails[0].IdWarehouse?.Count; i++)
                {
                    for (int j = 0; j < listWarehouse.Count; j++)
                    {
                        if (listDetails[0].IdWarehouse?[i] == listWarehouse[j].Id)
                        {
                            listNameS.Add(listWarehouse[j].NameDetail);
                            listPriceSaleS.Add(listWarehouse[j].PriceSale);
                        }
                    }
                }
                for (int i = 0; i < listNameS.Count; i++)
                {
                    listBox1.Items.Add(String.Format("{0}. {1} ({2} руб.)", i + 1, listNameS[i], listPriceSaleS[i]));
                    summDetails += listPriceSaleS[i];
                }
                textBoxPriceDetails.Text = String.Format("{0} руб.", summDetails);
                textBoxCountDetails.Text = String.Format("{0} шт.", listPriceSaleS.Count);
            }


            var list = context.MalfunctionOrders.Where(i => i.OrderId == idOrder).
                Select(a => new { a.Malfunction, a.Price }).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                problem[i].Enabled = true;
                price[i].Enabled = true;
                problem[i].Text = list[i].Malfunction?.Name;
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

            if (logIn) dateTimePicker1.Enabled = true;
            else dateTimePicker1.Enabled = false;
            textBoxAvailabilityGuarantee.Enabled = true;
            textBoxGuaranteePeriod.Enabled = true;
            textBoxEndGuarantee.Enabled = true;
            textBoxGuaranteeLeft.Enabled = true;

            dateTimePicker1.Value = list[0].DateIssue.Value;

            if (list[0].Guarantee > 0)
            {
                if (DateTime.Now < list[0].DateEndGuarantee.Value)
                    textBoxAvailabilityGuarantee.Text = "Присутствует";
                else
                    textBoxAvailabilityGuarantee.Text = "Закончилась";
            }
            else
                textBoxAvailabilityGuarantee.Text = "Отсутствует";

            textBoxGuaranteePeriod.Text = String.Format("{0} мес.", list[0].Guarantee);
            textBoxEndGuarantee.Text = list[0].DateEndGuarantee.ToString();

            if (((int)(list[0].DateEndGuarantee.Value - DateTime.Now).TotalDays) > 0)
                textBoxGuaranteeLeft.Text = String.Format("{0} дн.", 
                    (int)(list[0].DateEndGuarantee.Value - DateTime.Now).TotalDays);
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Context context = new();
            int id = Convert.ToInt32(textBoxIdOrder.Text);
            var list = context.Orders.Where(a => a.Id == id).ToList();
            string foundProblem = "";
            int priceRepair = 0;
            DateTime? dateIssue = null;
            DateTime? dateEndGuarantee = null;
            int? nameMaster = null;
            DateTime? dateStartWork = list[0].DateStartWork;
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
                    dateStartWork = DateTime.Now;
            }

            switch (statusOrder)
            {
                case "InRepair":
                    int countDay = 0;
                    if (comboBoxMaster.Text != "-")
                        countDay = (DateTime.Now - dateStartWork.Value).Days;
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
                    countDay = (DateTime.Now - list[0].DateCompleted.Value).Days;
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
                    dateIssue = dateTimePicker1.Value;
                    dateEndGuarantee = dateTimePicker1.Value.AddMonths(list[0].Guarantee);
                    break;
                case "Archive":
                    foundProblem = textBoxProblem1.Text;
                    priceRepair = Convert.ToInt32(textBoxPrice1.Text);
                    dateIssue = dateTimePicker1.Value;
                    dateEndGuarantee = dateTimePicker1.Value.AddMonths(list[0].Guarantee);
                    break;
            }

            CRUD.ChangeOrder(id,
                list[0].ClientId,
                nameMaster,
                dateCreation.Value,
                dateStartWork,
                list[0].DateCompleted,
                dateIssue,
                context.TypeTechnices.Where(a => a.NameTypeTechnic == comboBoxDevice.Text).ToList()[0].Id,
                context.BrandTechnices.Where(a => a.NameBrandTechnic == comboBoxBrand.Text).ToList()[0].Id,
                textBoxModel.Text,
                textBoxFactoryNumber.Text,
                context.Equipment.Where(a => a.Name == textBoxEquipment.Text).ToList()[0].Id/*list[0].EquipmentId*/,
                context.Diagnosis.Where(a => a.Name == textBoxDiagnosis.Text).ToList()[0].Id/*list[0].DiagnosisId*/,
                textBoxNote.Text,
                list[0].InProgress,
                list[0].Guarantee,
                DateTime.Parse(textBoxEndGuarantee.Text),
                list[0].Deleted,
                list[0].ReturnUnderGuarantee,
                list[0].DateReturn,
                list[0].DateCompletedReturn,
                list[0].DateIssueReturn,
                list[0].Issue,
                ColorTranslator.ToHtml(color),
                textBoxDateLastCall.Text,
                checkBoxPriceAgreed.Checked,
                maxPrice);
            this.DialogResult = DialogResult.OK;
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

            if (dateTimePicker1.Value < list[0].DateCompleted.Value)
                dateTimePicker1.Value = list[0].DateCompleted.Value;

            textBoxEndGuarantee.Text = (dateTimePicker1.Value.AddMonths(list[0].Guarantee)).ToShortDateString();
            if (((int)(DateTime.Parse(textBoxEndGuarantee.Text) - DateTime.Now).TotalDays) > 0)
                textBoxGuaranteeLeft.Text = String.Format("{0} дн.", (int)(DateTime.Parse(textBoxEndGuarantee.Text) - DateTime.Now).TotalDays);
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

        private void FeaturesOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                if (!logIn)
                {
                    LogInSystem logInSystem = new(true)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (logInSystem.ShowDialog() == DialogResult.OK)
                    {
                        logIn = true;
                        textBoxMaxPrice.Enabled = true;
                        checkBoxPriceAgreed.Enabled = true;
                        if(statusOrder == "GuaranteeIssue" || statusOrder == "Archive")
                            dateTimePicker1.Enabled = true;
                    }
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}
