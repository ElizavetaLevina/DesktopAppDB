using Microsoft.VisualBasic.Logging;
using WinFormsApp1.DTO;
using WinFormsApp1.Repository;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class FeaturesOrder : Form
    {
        public int idOrder;
        public string statusOrder;
        public bool show = true;
        public bool logIn;
        OrderEditDTO orderDTO;
        OrderRepository orderRepository = new();
        MasterRepository masterRepository = new();
        TypeTechnicRepository typeTechnicRepository = new();
        TypeBrandRepository typeBrandRepository = new();
        WarehouseRepository warehouseRepository = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();
        ClientRepository clientRepository = new();
        EquipmentRepository equipmentRepository = new();
        DiagnosisRepository diagnosisRepository = new();
        List<DiagnosisEditDTO> diagnosesDTO;
        List<EquipmentEditDTO> equipmentsDTO;
        public FeaturesOrder(int id, string status, bool _logIn)
        {
            InitializeComponent();
            logIn = _logIn;
            idOrder = id;
            statusOrder = status;
            Text = String.Format("Свойства устройства (заказ № {0} )", id);
            orderDTO = orderRepository.GetOrder(idOrder);
            textBoxIdOrder.Text = idOrder.ToString();

            if (orderDTO.InProgress)
                textBoxStatus.Text = "Находится в ремонте";
            else
                textBoxStatus.Text = "Отремонтирован";

            textBoxEquipment.Text = equipmentRepository.GetEquipment(orderDTO.EquipmentId).Name;
            textBoxDiagnosis.Text = diagnosisRepository.GetDiagnosis(orderDTO.DiagnosisId).Name;

            listBoxEquipment.Visible = false;
            listBoxDiagnosis.Visible = false;

            UpdateComboBox(0);

            var mastersDTO = masterRepository.GetMasters();

            if (mastersDTO.Count > 0 && orderDTO.MasterId != null)
                comboBoxMaster.SelectedIndex = comboBoxMaster.FindStringExact(orderDTO.Master?.NameMaster);

            dateCreation.Value = orderDTO.DateCreation.Value;

            UpdateComboBox(1);
            comboBoxDevice.SelectedIndex = comboBoxDevice.FindStringExact(orderDTO.TypeTechnic?.Name);

            UpdateComboBox(2);
            comboBoxBrand.SelectedIndex = comboBoxBrand.FindStringExact(orderDTO.BrandTechnic?.Name);

            textBoxModel.Text = orderDTO.ModelTechnic;

            textBoxFactoryNumber.Text = orderDTO.FactoryNumber;

            checkBoxPriceAgreed.Checked = orderDTO.PriceAgreed;
            textBoxMaxPrice.Text = orderDTO.MaxPrice.ToString();

            UpdateData();

            var clientDTO = clientRepository.GetClient(orderDTO.ClientId);

            switch (clientDTO.TypeClient)
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
                    comboBoxMaster.ValueMember = nameof(MasterDTO.Id);
                    comboBoxMaster.DisplayMember = nameof(MasterDTO.NameMaster);
                    var mastersDTO = masterRepository.GetMasters();
                    mastersDTO.Insert(0, new MasterDTO() { Id = null, NameMaster = "-" });
                    comboBoxMaster.DataSource = mastersDTO;
                    break;
                case 1:
                    comboBoxDevice.DataSource = null;
                    comboBoxDevice.Items.Clear();
                    comboBoxDevice.ValueMember = nameof(TypeTechnicDTO.Id);
                    comboBoxDevice.DisplayMember = nameof(TypeTechnicDTO.NameTypeTechnic);
                    comboBoxDevice.DataSource = typeTechnicRepository.GetTypesTechnic();
                    break;
                case 2:
                    comboBoxBrand.DataSource = null;
                    comboBoxBrand.Items.Clear();
                    comboBoxBrand.ValueMember = nameof(TypeBrandComboBoxDTO.IdBrand);
                    comboBoxBrand.DisplayMember = nameof(TypeBrandComboBoxDTO.NameBrandTechnic);
                    comboBoxBrand.DataSource = typeBrandRepository.GetTypeBrandByNameType(comboBoxDevice.Text);
                    break;
            }
        }

        public void OrderComplete()
        {
            int summDetails = 0;
            int sumPrice = 0;

            var detailsDTO = warehouseRepository.GetDetailsInOrder(idOrder);

            List<TextBox> problem = [textBoxProblem1, textBoxProblem2, textBoxProblem3];
            List<TextBox> price = [textBoxPrice1, textBoxPrice2, textBoxPrice3];
            List<Label> lProblem = [labelProblem1, labelProblem2, labelProblem3];
            List<Label> lPrice = [labelPrice1, labelPrice2, labelPrice3];
            List<Label> lRub = [labelRub1, labelRub2, labelRub3];

            for (int i = 0; i < detailsDTO.Count; i++)
            {
                listBox1.Items.Add(String.Format("{0}. {1} ({2} руб.)", i + 1, detailsDTO[i].NameDetail, detailsDTO[i].PriceSale));
                summDetails += detailsDTO[i].PriceSale;
            }
            textBoxPriceDetails.Text = String.Format("{0} руб.", summDetails);
            textBoxCountDetails.Text = String.Format("{0} шт.", detailsDTO.Count);

            var malfunctionOrderDTO = malfunctionOrderRepository.GetMalfunctionOrdersByIdOrder(idOrder);

            for (int i = 0; i < malfunctionOrderDTO.Count; i++)
            {
                problem[i].Enabled = true;
                price[i].Enabled = true;
                problem[i].Text = malfunctionOrderDTO[i].Malfunction?.Name;
                price[i].Text = malfunctionOrderDTO[i].Price.ToString();
                lProblem[i].ForeColor = Color.Black;
                lPrice[i].ForeColor = Color.Black;
                lRub[i].ForeColor = Color.Black;
                sumPrice += malfunctionOrderDTO[i].Price;
            }
            textBoxSumPrice.Text = sumPrice.ToString();
        }

        public void OrderIssue()
        {
            OrderComplete();

            label20.ForeColor = Color.Black;
            label21.ForeColor = Color.FromArgb(105, 101, 148);
            label22.ForeColor = Color.FromArgb(105, 101, 148);
            label23.ForeColor = Color.FromArgb(105, 101, 148);
            label24.ForeColor = Color.FromArgb(105, 101, 148);

            
            textBoxAvailabilityGuarantee.Enabled = true;
            textBoxGuaranteePeriod.Enabled = true;
            textBoxEndGuarantee.Enabled = true;
            textBoxGuaranteeLeft.Enabled = true;

            dateIssue.Value = orderDTO.DateIssue.Value;

            if (orderDTO.Guarantee > 0)
            {
                if (DateTime.Now < orderDTO.DateEndGuarantee.Value)
                    textBoxAvailabilityGuarantee.Text = "Присутствует";
                else
                    textBoxAvailabilityGuarantee.Text = "Закончилась";
            }
            else
                textBoxAvailabilityGuarantee.Text = "Отсутствует";

            textBoxGuaranteePeriod.Text = String.Format("{0} мес.", orderDTO.Guarantee);
            textBoxEndGuarantee.Text = orderDTO.DateEndGuarantee.ToString();

            if (((int)(orderDTO.DateEndGuarantee.Value - DateTime.Now).TotalDays) > 0)
                textBoxGuaranteeLeft.Text = String.Format("{0} дн.",
                    (int)(orderDTO.DateEndGuarantee.Value - DateTime.Now).TotalDays);
            else
                textBoxGuaranteeLeft.Text = "Закончилась";
        }

        private void LogInToTheSystem()
        {
            if (logIn)
            {
                Warning warning = new Warning()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Выйти из системы?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };
                if(warning.ShowDialog() == DialogResult.OK)
                    logIn = false;
            }
            else
            {
                LogInSystem logInSystem = new(true)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                if (logInSystem.ShowDialog() == DialogResult.OK)
                    logIn = true;
            }
            UpdateData();
        }

        private void UpdateData()
        {
            if (logIn)
            {
                dateCreation.Enabled = true;
                if (statusOrder == "GuaranteeIssue" || statusOrder == "Archive")
                    dateIssue.Enabled = true;
                linkLabelLogIn.Text = Properties.Settings.Default.Login;
                textBoxMaxPrice.Enabled = true;
                checkBoxPriceAgreed.Enabled = true;
            }
            else
            {
                dateCreation.Enabled = false;
                if (statusOrder == "GuaranteeIssue" || statusOrder == "Archive")
                    dateIssue.Enabled = false;
                linkLabelLogIn.Text = "Войти (Ctrl+D)";
                textBoxMaxPrice.Enabled = false;
                checkBoxPriceAgreed.Enabled = false;
            }
        }

        private void LinkLabelMaster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Masters addMaster = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMaster.ShowDialog();
            UpdateComboBox(0);
        }

        private void LinkLabelDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TypesTechnic addDevice = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addDevice.ShowDialog();
            UpdateComboBox(1);
        }

        private void LinkLabelBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BrandsTechnic addBrand = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addBrand.ShowDialog();
            UpdateComboBox(2);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string foundProblem = "";
            int priceRepair = 0;
            DateTime? dateIssue = null;
            DateTime? dateEndGuarantee = null;
            int? masterId = null;
            DateTime? dateStartWork = orderDTO.DateStartWork;
            Color color = Color.Black;
            int? maxPrice = null;
            Task task;

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
                masterId = ((MasterDTO)comboBoxMaster.SelectedItem).Id;
                if (orderDTO.DateStartWork == null)
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
                    countDay = (DateTime.Now - orderDTO.DateCompleted.Value).Days;
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
                    dateIssue = this.dateIssue.Value;
                    dateEndGuarantee = this.dateIssue.Value.AddMonths(orderDTO.Guarantee);
                    break;
                case "Archive":
                    foundProblem = textBoxProblem1.Text;
                    priceRepair = Convert.ToInt32(textBoxPrice1.Text);
                    dateIssue = this.dateIssue.Value;
                    dateEndGuarantee = this.dateIssue.Value.AddMonths(orderDTO.Guarantee);
                    break;
            }

            var equipmentDTO = equipmentRepository.GetEquipmentByName(textBoxEquipment.Text);
            int? idEquipment = equipmentDTO.Id;
            if (idEquipment == 0)
            {
                if (textBoxEquipment.Text != "")
                {
                    task = Task.Run(async () =>
                    {
                        idEquipment = await equipmentRepository.SaveEquipmentAsync(equipmentDTO);
                    });
                    task.Wait();
                }
                else idEquipment = null;
            }

            var diagnosisDTO = diagnosisRepository.GetDiagnosisByName(textBoxDiagnosis.Text);
            int? idDiagnosis = diagnosisDTO.Id;
            if (idDiagnosis == 0)
            {
                if (textBoxDiagnosis.Text != "")
                {
                    task = Task.Run(async () =>
                    {
                        idDiagnosis = await diagnosisRepository.SaveDiagnosisAsync(diagnosisDTO);
                    });
                    task.Wait();
                }
                else idDiagnosis = null;
            }

            orderDTO.MasterId = masterId;
            orderDTO.DateCreation = dateCreation.Value;
            orderDTO.DateStartWork = dateStartWork;
            orderDTO.DateIssue = dateIssue;
            orderDTO.TypeTechnicId = ((TypeTechnicDTO)comboBoxDevice.SelectedItem).Id;
            orderDTO.BrandTechnicId = ((TypeBrandComboBoxDTO)comboBoxBrand.SelectedItem).IdBrand;
            orderDTO.ModelTechnic = textBoxModel.Text;
            orderDTO.FactoryNumber = textBoxFactoryNumber.Text;
            orderDTO.EquipmentId = idEquipment;
            orderDTO.DiagnosisId = idDiagnosis;
            orderDTO.Note = textBoxNote.Text;
            orderDTO.DateEndGuarantee = dateEndGuarantee;
            orderDTO.ColorRow = ColorTranslator.ToHtml(color);
            orderDTO.DateLastCall = textBoxDateLastCall.Text;
            orderDTO.PriceAgreed = checkBoxPriceAgreed.Checked;
            orderDTO.MaxPrice = maxPrice;

            task = Task.Run(async () =>
            {
                await orderRepository.SaveOrderAsync(orderDTO);
            });
            task.Wait();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void TextBoxPriceRepair_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

        private void DateIssue_ValueChanged(object sender, EventArgs e)
        {
            if (dateIssue.Value < orderDTO.DateCompleted.Value)
                dateIssue.Value = orderDTO.DateCompleted.Value;

            textBoxEndGuarantee.Text = (dateIssue.Value.AddMonths(orderDTO.Guarantee)).ToShortDateString();
            if (((int)(DateTime.Parse(textBoxEndGuarantee.Text) - DateTime.Now).TotalDays) > 0)
                textBoxGuaranteeLeft.Text = String.Format("{0} дн.", (int)(DateTime.Parse(textBoxEndGuarantee.Text) - DateTime.Now).TotalDays);
            else
                textBoxGuaranteeLeft.Text = "Закончилась";

            if (orderDTO.Guarantee > 0)
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
                if (!orderDTO.PriceAgreed)
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
                LogInToTheSystem();
                e.SuppressKeyPress = true;
            }
        }

        private void TextBoxEquipment_Click(object sender, EventArgs e)
        {
            if (listBoxEquipment.Visible)
                listBoxEquipment.Visible = false;
            else
                listBoxEquipment.Visible = true;
        }

        private void TextBoxDiagnosis_Click(object sender, EventArgs e)
        {
            if (listBoxDiagnosis.Visible)
                listBoxDiagnosis.Visible = false;
            else
                listBoxDiagnosis.Visible = true;
        }

        private void TextBoxEquipment_TextChanged(object sender, EventArgs e)
        {
            listBoxEquipment.Items.Clear();
            listBoxEquipment.Visible = false;
            equipmentsDTO = equipmentRepository.GetEquipmentsByName(textBoxEquipment.Text);

            foreach (var equipment in equipmentsDTO)
            {
                listBoxEquipment.Visible = true;
                listBoxEquipment.Items.Add(equipment.Name);
            }
        }

        private void TextBoxDiagnosis_TextChanged(object sender, EventArgs e)
        {
            listBoxDiagnosis.Items.Clear();
            listBoxDiagnosis.Visible = false;
            diagnosesDTO = diagnosisRepository.GetDiagnosesByName(textBoxDiagnosis.Text);

            foreach (var diagnosis in diagnosesDTO)
            {
                listBoxDiagnosis.Visible = true;
                listBoxDiagnosis.Items.Add(diagnosis.Name);
            }
        }

        private void ListBoxEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEquipment.SelectedIndex >= 0)
            {
                textBoxEquipment.Text = listBoxEquipment.Items[listBoxEquipment.SelectedIndex].ToString();
                listBoxEquipment.Visible = false;
            }
        }

        private void ListBoxDiagnosis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDiagnosis.SelectedIndex >= 0)
            {
                textBoxDiagnosis.Text = listBoxDiagnosis.Items[listBoxDiagnosis.SelectedIndex].ToString();
                listBoxDiagnosis.Visible = false;
            }
        }

        private void TextBoxEquipment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listBoxEquipment.Visible)
            {
                listBoxEquipment.Visible = false;
            }
        }

        private void TextBoxDiagnosis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listBoxDiagnosis.Visible)
            {
                listBoxDiagnosis.Visible = false;
            }
        }

        private void LinkLabelLogIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogInToTheSystem();
        }
    }
}
