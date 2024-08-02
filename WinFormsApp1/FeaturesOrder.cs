using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Repository;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class FeaturesOrder : Form
    {
        public int idOrder;
        readonly string withoutMaster = "-";
        StatusOrderEnum statusOrder;
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
        List<MasterDTO> mastersDTO;
        public FeaturesOrder(int id, StatusOrderEnum status, bool _logIn)
        {
            InitializeComponent();
            logIn = _logIn;
            idOrder = id;
            statusOrder = status;
            orderDTO = orderRepository.GetOrder(idOrder);
            InitializeElementsForm();
        }

        private void InitializeElementsForm()
        {
            textBoxIdOrder.Text = orderDTO.NumberOrder.ToString();
            Text = String.Format("Свойства устройства (заказ № {0} )", orderDTO.NumberOrder);

            if (orderDTO.StatusOrder == StatusOrderEnum.InRepair)
                textBoxStatus.Text = "Находится в ремонте";
            else
                textBoxStatus.Text = "Отремонтирован";

            textBoxEquipment.Text = equipmentRepository.GetEquipment(orderDTO.EquipmentId).Name;
            textBoxDiagnosis.Text = diagnosisRepository.GetDiagnosis(orderDTO.DiagnosisId).Name;

            listBoxEquipment.Visible = false;
            listBoxDiagnosis.Visible = false;

            UpdateComboBox(ElementOfRepairEnum.MainMasterElement);
            UpdateComboBox(ElementOfRepairEnum.AdditionalMasterElement);

            if (mastersDTO.Count > 0 && orderDTO.MainMasterId != null)
                comboBoxMainMaster.SelectedIndex = comboBoxMainMaster.FindStringExact(orderDTO.MainMaster?.NameMaster);
            if (mastersDTO.Count > 0 && orderDTO.AdditionalMasterId != null)
                comboBoxAdditionalMaster.SelectedIndex = comboBoxAdditionalMaster.FindStringExact(orderDTO.AdditionalMaster?.NameMaster);

            dateCreation.Value = orderDTO.DateCreation.Value;

            UpdateComboBox(ElementOfRepairEnum.TypeDeviceElement);
            comboBoxDevice.SelectedIndex = comboBoxDevice.FindStringExact(orderDTO.TypeTechnic?.Name);

            UpdateComboBox(ElementOfRepairEnum.BrandDeviceElement);
            comboBoxBrand.SelectedIndex = comboBoxBrand.FindStringExact(orderDTO.BrandTechnic?.Name);

            textBoxModel.Text = orderDTO.ModelTechnic;

            textBoxFactoryNumber.Text = orderDTO.FactoryNumber;

            checkBoxPriceAgreed.Checked = orderDTO.PriceAgreed;
            textBoxMaxPrice.Text = orderDTO.MaxPrice.ToString();

            UpdateData();

            var clientDTO = clientRepository.GetClient(orderDTO.ClientId);

            switch (clientDTO.TypeClient)
            {
                case TypeClientEnum.normal:
                    textBoxTypeClient.Text = "Обычный клиент"; break;
                case TypeClientEnum.white:
                    textBoxTypeClient.Text = "В белом списке"; break;
                case TypeClientEnum.black:
                    textBoxTypeClient.Text = "В черном списке"; break;
            }

            switch (statusOrder)
            {
                case StatusOrderEnum.InRepair:
                    textBoxStored.Text = (DateTime.Now - orderDTO.DateCreation).Value.Days.ToString();
                    break;
                case StatusOrderEnum.Completed:
                    labelStatus.Text = "Отремонтирован:";
                    textBoxStored.Text = (DateTime.Now - orderDTO.DateCompleted).Value.Days.ToString();
                    OrderComplete();
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    textBoxStored.Visible = false;
                    labelStatus.Visible = false;
                    labelDay.Visible = false;
                    OrderIssue();
                    break;
                case StatusOrderEnum.Archive:
                    textBoxStored.Visible = false;
                    labelStatus.Visible = false;
                    labelDay.Visible = false;
                    OrderIssue();
                    break;
            }
        }

        private void UpdateComboBox(ElementOfRepairEnum elementOfRepair)
        {
            mastersDTO = masterRepository.GetMastersForOutput();
            mastersDTO.Insert(0, new MasterDTO() { Id = null, NameMaster = withoutMaster });
            switch (elementOfRepair)
            {
                case ElementOfRepairEnum.MainMasterElement:
                    comboBoxMainMaster.DataSource = null;
                    comboBoxMainMaster.Items.Clear();
                    comboBoxMainMaster.ValueMember = nameof(MasterDTO.Id);
                    comboBoxMainMaster.DisplayMember = nameof(MasterDTO.NameMaster);
                    comboBoxMainMaster.DataSource = mastersDTO;
                    break;
                case ElementOfRepairEnum.AdditionalMasterElement:
                    comboBoxAdditionalMaster.DataSource = null;
                    comboBoxAdditionalMaster.Items.Clear();
                    comboBoxAdditionalMaster.ValueMember = nameof(MasterDTO.Id);
                    comboBoxAdditionalMaster.DisplayMember = nameof(MasterDTO.NameMaster);
                    comboBoxAdditionalMaster.DataSource = mastersDTO;
                    break;
                case ElementOfRepairEnum.TypeDeviceElement:
                    comboBoxDevice.DataSource = null;
                    comboBoxDevice.Items.Clear();
                    comboBoxDevice.ValueMember = nameof(TypeTechnicDTO.Id);
                    comboBoxDevice.DisplayMember = nameof(TypeTechnicDTO.NameTypeTechnic);
                    comboBoxDevice.DataSource = typeTechnicRepository.GetTypesTechnic();
                    break;
                case ElementOfRepairEnum.BrandDeviceElement:
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
            var detailsDTO = warehouseRepository.GetDetailsInOrder(idOrder);

            List<TextBox> problem = [textBoxProblem1, textBoxProblem2, textBoxProblem3];
            List<TextBox> price = [textBoxPrice1, textBoxPrice2, textBoxPrice3];
            List<Label> lProblem = [labelProblem1, labelProblem2, labelProblem3];
            List<Label> lPrice = [labelPrice1, labelPrice2, labelPrice3];
            List<Label> lRub = [labelRub1, labelRub2, labelRub3];

            for (int i = 0; i < detailsDTO.Count; i++)
            {
                listBox1.Items.Add(String.Format("{0}. {1} ({2} руб.)", i + 1, detailsDTO[i].NameDetail, detailsDTO[i].PriceSale));
            }
            textBoxPriceDetails.Text = String.Format("{0} руб.", detailsDTO.Sum(i => i.PriceSale));
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
            }
            textBoxSumPrice.Text = malfunctionOrderDTO.Sum(i => i.Price).ToString();
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
            textBoxEndGuarantee.Text = orderDTO.DateEndGuarantee.Value.ToShortDateString();

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
                if (warning.ShowDialog() == DialogResult.OK)
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
                if (statusOrder == StatusOrderEnum.GuaranteeIssue || statusOrder == StatusOrderEnum.Archive)
                    dateIssue.Enabled = true;
                linkLabelLogIn.Text = Properties.Settings.Default.Login;
                if (checkBoxPriceAgreed.Checked)
                    textBoxMaxPrice.Enabled = true;
                checkBoxPriceAgreed.Enabled = true;
            }
            else
            {
                dateCreation.Enabled = false;
                if (statusOrder == StatusOrderEnum.GuaranteeIssue || statusOrder == StatusOrderEnum.Archive)
                    dateIssue.Enabled = false;
                linkLabelLogIn.Text = "Войти (Ctrl+D)";
                textBoxMaxPrice.Enabled = false;
                checkBoxPriceAgreed.Enabled = false;
            }
        }

        private void FeaturesOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                LogInToTheSystem();
                e.SuppressKeyPress = true;
            }
        }

        private void FillingListBox(ListBox listBox, bool equipment = false, bool diagnosis = false, bool click = false)
        {
            if (click)
            {
                if (listBox.Visible)
                {
                    listBox.Visible = false;
                    return;
                }
            }

            listBox.Items.Clear();

            if (equipment)
            {
                equipmentsDTO = equipmentRepository.GetEquipmentsByName(textBoxEquipment.Text);
                foreach (var item in equipmentsDTO)
                {
                    listBox.Items.Add(item.Name);
                }
            }
            else if (diagnosis)
            {
                diagnosesDTO = diagnosisRepository.GetDiagnosesByName(textBoxDiagnosis.Text);
                foreach (var item in diagnosesDTO)
                {
                    listBox.Items.Add(item.Name);
                }
            }
            if (listBox.Items.Count > 0)
                listBox.Visible = true;
            else
                listBox.Visible = false;
        }

        private void TextBoxKeyDown(Keys keyCode, TextBox textBox, ListBox listBox)
        {
            if (keyCode == Keys.Enter)
            {
                if (listBox.Visible)
                    listBox.Visible = false;
                textBox.Focus();
            }
            else if (keyCode == Keys.Down)
            {
                listBox.Focus();
                try
                {
                    if (listBox.SelectedIndex < listBox1.Items.Count)
                        listBox.SelectedIndex += 1;
                }
                catch { }
            }
            else if (keyCode == Keys.Up)
            {
                listBox.Focus();
                try
                {
                    if (listBox.SelectedIndex > 1)
                        listBox.SelectedIndex -= 1;
                }
                catch { }
            }
        }

        private void SelectingElementsListBox(ListBox listBox, TextBox textBoxCurrent, TextBox textBoxNext)
        {
            if (listBox.SelectedIndex >= 0)
            {
                textBoxCurrent.Text = listBox.Items[listBox.SelectedIndex].ToString();
                listBox.Visible = false;
                textBoxNext.Focus();
            }
        }

        private void LinkLabelMaster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Masters addMaster = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMaster.ShowDialog();
            UpdateComboBox(ElementOfRepairEnum.MainMasterElement);
            UpdateComboBox(ElementOfRepairEnum.AdditionalMasterElement);
        }

        private void LinkLabelDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TypesTechnic addDevice = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addDevice.ShowDialog();
            UpdateComboBox(ElementOfRepairEnum.TypeDeviceElement);
        }

        private void LinkLabelBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BrandsTechnic addBrand = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addBrand.ShowDialog();
            UpdateComboBox(ElementOfRepairEnum.BrandDeviceElement);
        }

        private void TextBoxPriceRepair_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxDateLastCall.Text = DateTime.Now.ToShortDateString();
        }

        private void TextBoxDateLastCall_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
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
            e.Handled = !KeyPressHelper.CheckKeyPress(true, textBoxMaxPrice.Text, e.KeyChar);
        }

        private void CheckBoxPriceAgreed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPriceAgreed.Checked)
                textBoxMaxPrice.Enabled = true;
            else
                textBoxMaxPrice.Enabled = false;
        }

        private void CheckBoxPriceAgreed_KeyDown(object sender, KeyEventArgs e)
        {
            checkBoxPriceAgreed.Checked = !checkBoxPriceAgreed.Checked;
        }

        private void TextBoxEquipment_Click(object sender, EventArgs e)
        {
            FillingListBox(listBoxEquipment, equipment: true, click: true);
        }

        private void TextBoxDiagnosis_Click(object sender, EventArgs e)
        {
            FillingListBox(listBoxDiagnosis, diagnosis: true, click: true);
        }

        private void TextBoxEquipment_TextChanged(object sender, EventArgs e)
        {
            FillingListBox(listBoxEquipment, equipment: true);
        }

        private void TextBoxDiagnosis_TextChanged(object sender, EventArgs e)
        {
            FillingListBox(listBoxDiagnosis, diagnosis: true);
        }

        private void TextBoxEquipment_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxKeyDown(e.KeyCode, textBoxDiagnosis, listBoxEquipment);
        }

        private void TextBoxDiagnosis_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxKeyDown(e.KeyCode, textBoxNote, listBoxDiagnosis);
        }

        private void TextBoxEquipment_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (KeyPressHelper.CheckKeyTab(e.KeyCode, listBoxEquipment.Visible))
                listBoxEquipment.Visible = false;
        }

        private void TextBoxDiagnosis_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (KeyPressHelper.CheckKeyTab(e.KeyCode, listBoxDiagnosis.Visible))
                listBoxDiagnosis.Visible = false;
        }

        private void ListBoxEquipment_Click(object sender, EventArgs e)
        {
            SelectingElementsListBox(listBoxEquipment, textBoxEquipment, textBoxDiagnosis);
        }

        private void ListBoxEquipment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectingElementsListBox(listBoxEquipment, textBoxEquipment, textBoxDiagnosis);
            else if (e.KeyCode == Keys.Up && listBoxEquipment.SelectedIndex == 0)
                textBoxEquipment.Focus();
        }

        private void ListBoxDiagnosis_Click(object sender, EventArgs e)
        {
            SelectingElementsListBox(listBoxDiagnosis, textBoxDiagnosis, textBoxNote);
        }

        private void ListBoxDiagnosis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectingElementsListBox(listBoxDiagnosis, textBoxDiagnosis, textBoxNote);
            else if (e.KeyCode == Keys.Up && listBoxEquipment.SelectedIndex == 0)
                textBoxDiagnosis.Focus();
        }

        private void LinkLabelLogIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogInToTheSystem();
        }

        private void ComboBoxMainMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainMaster.Text != withoutMaster)
                comboBoxAdditionalMaster.Enabled = true;
            else
                comboBoxAdditionalMaster.Enabled = false;

            if (comboBoxMainMaster.Text == comboBoxAdditionalMaster.Text)
                comboBoxMainMaster.SelectedIndex = 0;
        }

        private void ComboBoxAdditionalMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainMaster.Text == comboBoxAdditionalMaster.Text)
                comboBoxAdditionalMaster.SelectedIndex = 0;
        }

        private void ComboBoxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox(ElementOfRepairEnum.BrandDeviceElement);
        }

        private void DateIssue_ValueChanged(object sender, EventArgs e)
        {
            if (dateIssue.Value < orderDTO.DateCompleted.Value)
                dateIssue.Value = orderDTO.DateCompleted.Value;

            textBoxEndGuarantee.Text = dateIssue.Value.AddMonths(orderDTO.Guarantee).ToShortDateString();
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

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string foundProblem = string.Empty;
            int priceRepair = 0;
            DateTime? dateIssue = null;
            DateTime? dateEndGuarantee = null;
            var mainMasterId = ((MasterDTO)comboBoxMainMaster.SelectedItem).Id;
            var additionalMasterId = ((MasterDTO)comboBoxAdditionalMaster.SelectedItem).Id;
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

            if (comboBoxMainMaster.Text != withoutMaster)
            {
                if (orderDTO.DateStartWork == null)
                    dateStartWork = DateTime.Now;
            }

            switch (statusOrder)
            {
                case StatusOrderEnum.InRepair:
                    int countDay = 0;
                    if (comboBoxMainMaster.Text != withoutMaster)
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
                case StatusOrderEnum.Completed:
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
                case StatusOrderEnum.GuaranteeIssue:
                    foundProblem = textBoxProblem1.Text;
                    priceRepair = Convert.ToInt32(textBoxPrice1.Text);
                    dateIssue = dateIssue.Value;
                    dateEndGuarantee = dateIssue.Value.AddMonths(orderDTO.Guarantee);
                    break;
                case StatusOrderEnum.Archive:
                    foundProblem = textBoxProblem1.Text;
                    priceRepair = Convert.ToInt32(textBoxPrice1.Text);
                    dateIssue = dateIssue.Value;
                    dateEndGuarantee = dateIssue.Value.AddMonths(orderDTO.Guarantee);
                    break;
            }

            var equipmentDTO = equipmentRepository.GetEquipmentByName(textBoxEquipment.Text);
            int? idEquipment = equipmentDTO.Id;
            if (idEquipment == 0)
            {
                if (!string.IsNullOrEmpty(textBoxEquipment.Text))
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
                if (!string.IsNullOrEmpty(textBoxDiagnosis.Text))
                {
                    task = Task.Run(async () =>
                    {
                        idDiagnosis = await diagnosisRepository.SaveDiagnosisAsync(diagnosisDTO);
                    });
                    task.Wait();
                }
                else idDiagnosis = null;
            }

            orderDTO.MainMasterId = mainMasterId;
            orderDTO.AdditionalMasterId = additionalMasterId;
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
    }
}
