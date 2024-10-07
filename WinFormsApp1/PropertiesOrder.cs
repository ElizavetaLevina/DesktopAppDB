using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic;
using WinFormsApp1.Logic.Interfaces;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class PropertiesOrder : Form
    {
        public int idOrder;
        readonly string withoutMaster = "-";
        public bool showFormForTimer = true;
        public bool logIn;
        StatusOrderEnum statusOrder;
        OrderEditDTO orderDTO;
        IOrdersLogic ordersLogic;
        IMastersLogic mastersLogic;
        ITypesTechnicsLogic typesTechnicsLogic;
        ITypesBrandsLogic typesBrandsLogic;
        IWarehousesLogic warehousesLogic;
        IMalfunctionsOrdersLogic malfunctionsOrdersLogic;
        IClientsLogic clientsLogic;
        IEquipmentsLogic equipmentsLogic;
        IDiagnosesLogic diagnosesLogic;
        List<DiagnosisEditDTO> diagnosesDTO;
        List<EquipmentEditDTO> equipmentsDTO;
        List<MasterDTO> mastersDTO;
        public PropertiesOrder(IOrdersLogic _ordersLogic, IMastersLogic _mastersLogic, ITypesTechnicsLogic _typesTechnicsLogic,
            ITypesBrandsLogic _typesBrandsLogic, IWarehousesLogic _warehousesLogic, IMalfunctionsOrdersLogic _malfunctionsOrdersLogic,
            IClientsLogic _clientsLogic, IEquipmentsLogic _equipmentsLogic, IDiagnosesLogic _diagnosesLogic)
        {
            ordersLogic = _ordersLogic;
            mastersLogic = _mastersLogic;
            typesTechnicsLogic = _typesTechnicsLogic;
            typesBrandsLogic = _typesBrandsLogic;
            warehousesLogic = _warehousesLogic;
            malfunctionsOrdersLogic = _malfunctionsOrdersLogic;
            clientsLogic = _clientsLogic;
            equipmentsLogic = _equipmentsLogic;
            diagnosesLogic = _diagnosesLogic;
            InitializeComponent();            
        }

        public void InitializeElementsForm(int id, StatusOrderEnum status, bool _logIn)
        {
            logIn = _logIn;
            idOrder = id;
            statusOrder = status;
            orderDTO = ordersLogic.GetOrder(idOrder);
            UpdateComboBox(ElementOfRepairEnum.MainMasterElement);
            UpdateComboBox(ElementOfRepairEnum.AdditionalMasterElement);
            UpdateComboBox(ElementOfRepairEnum.TypeDeviceElement);
            UpdateComboBox(ElementOfRepairEnum.BrandDeviceElement);

            textBoxIdOrder.Text = orderDTO.NumberOrder.ToString();
            Text = String.Format("Свойства устройства (заказ № {0} )", orderDTO.NumberOrder);

            if (orderDTO.StatusOrder == StatusOrderEnum.InRepair)
                textBoxStatus.Text = "Находится в ремонте";
            else
                textBoxStatus.Text = "Отремонтирован";

            Equipment = equipmentsLogic.GetEquipment(orderDTO.EquipmentId).Name;
            Diagnosis = diagnosesLogic.GetDiagnosis(orderDTO.DiagnosisId).Name;
            listBoxEquipment.Visible = false;
            listBoxDiagnosis.Visible = false;
            dateCreation.Value = orderDTO.DateCreation.Value;
            Model = orderDTO.ModelTechnic;
            FactoryNumber = orderDTO.FactoryNumber;
            PriceAgreed = orderDTO.PriceAgreed;
            MaxPrice = orderDTO.MaxPrice.ToString();
            if (mastersDTO.Count > 0 && orderDTO.MainMasterId != null)
                comboBoxMainMaster.SelectedIndex = comboBoxMainMaster.FindStringExact(orderDTO.MainMaster?.NameMaster);
            if (mastersDTO.Count > 0 && orderDTO.AdditionalMasterId != null)
                comboBoxAdditionalMaster.SelectedIndex = comboBoxAdditionalMaster.FindStringExact(
                    orderDTO.AdditionalMaster?.NameMaster);
            comboBoxDevice.SelectedIndex = comboBoxDevice.FindStringExact(orderDTO.TypeTechnic?.Name);
            comboBoxBrand.SelectedIndex = comboBoxBrand.FindStringExact(orderDTO.BrandTechnic?.Name);

            UpdateData();

            var clientDTO = clientsLogic.GetClient(orderDTO.Client.IdClient.ToString());
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
            mastersDTO = mastersLogic.GetMastersForOutput();
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
                    comboBoxDevice.DataSource = typesTechnicsLogic.GetTypesTechnic();
                    break;
                case ElementOfRepairEnum.BrandDeviceElement:
                    comboBoxBrand.DataSource = null;
                    comboBoxBrand.Items.Clear();
                    comboBoxBrand.ValueMember = nameof(TypeBrandComboBoxDTO.IdBrand);
                    comboBoxBrand.DisplayMember = nameof(TypeBrandComboBoxDTO.NameBrandTechnic);
                    comboBoxBrand.DataSource = typesBrandsLogic.GetTypeBrandByNameType(comboBoxDevice.Text);
                    break;
            }
        }

        public void OrderComplete()
        {
            var detailsDTO = warehousesLogic.GetDetailsInOrder(idOrder);

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

            var malfunctionOrderDTO = malfunctionsOrdersLogic.GetMalfunctionOrdersByIdOrder(idOrder);

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

            dateTimePickerIssue.Value = orderDTO.DateIssue.Value;

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
                Warning warning = new()
                {
                    LabelText = "Выйти из системы?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };
                if (warning.ShowDialog() == DialogResult.OK)
                    logIn = false;
            }
            else
            {
                LogInSystem logInSystem = new(true);
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
                    dateTimePickerIssue.Enabled = true;
                linkLabelLogIn.Text = Properties.Settings.Default.LoginInSystem;
                if (PriceAgreed)
                    textBoxMaxPrice.Enabled = true;
                checkBoxPriceAgreed.Enabled = true;
            }
            else
            {
                dateCreation.Enabled = false;
                if (statusOrder == StatusOrderEnum.GuaranteeIssue || statusOrder == StatusOrderEnum.Archive)
                    dateTimePickerIssue.Enabled = false;
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
                equipmentsDTO = equipmentsLogic.GetEquipmentsByName(textBoxEquipment.Text);
                foreach (var item in equipmentsDTO)
                {
                    listBox.Items.Add(item.Name);
                }
            }
            else if (diagnosis)
            {
                diagnosesDTO = diagnosesLogic.GetDiagnosesByName(textBoxDiagnosis.Text);
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
            Masters addMaster = Program.ServiceProvider.GetRequiredService<Masters>();
            addMaster.ShowDialog();
            UpdateComboBox(ElementOfRepairEnum.MainMasterElement);
            UpdateComboBox(ElementOfRepairEnum.AdditionalMasterElement);
        }

        private void LinkLabelDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TypesTechnic addDevice = Program.ServiceProvider.GetRequiredService<TypesTechnic>();
            addDevice.ShowDialog();
            UpdateComboBox(ElementOfRepairEnum.TypeDeviceElement);
        }

        private void LinkLabelBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BrandsTechnic addBrand = Program.ServiceProvider.GetRequiredService<BrandsTechnic>();
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
            if (showFormForTimer)
            {
                if (!orderDTO.PriceAgreed)
                {
                    showFormForTimer = false;
                    Warning warning = new()
                    {
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
            if (PriceAgreed)
                textBoxMaxPrice.Enabled = true;
            else
                textBoxMaxPrice.Enabled = false;
        }

        private void CheckBoxPriceAgreed_KeyDown(object sender, KeyEventArgs e)
        {
            PriceAgreed = !PriceAgreed;
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

        private void DateTimePickerIssue_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerIssue.Value < orderDTO.DateCompleted.Value)
                dateTimePickerIssue.Value = orderDTO.DateCompleted.Value;

            textBoxEndGuarantee.Text = dateTimePickerIssue.Value.AddMonths(orderDTO.Guarantee).ToShortDateString();
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

        private async void ButtonSave_ClickAsync(object sender, EventArgs e)
        {
            if (PriceAgreed && string.IsNullOrEmpty(MaxPrice))
            {
                Warning warning = new()
                {
                    LabelText = "Не заполнена максимальная цена!"
                };
                warning.ShowDialog();
                return;
            }

            var dateStartWork = orderDTO.DateStartWork;
            if (MainMaster != withoutMaster && orderDTO.DateStartWork == null)
                dateStartWork = DateTime.Now.ToUniversalTime();

            var equipmentDTO = equipmentsLogic.GetEquipmentByName(Equipment);
            int? idEquipment = equipmentDTO.Id;
            if (idEquipment == 0)
            {
                if (!string.IsNullOrEmpty(Equipment))
                    equipmentsLogic.SaveEquipment(equipmentDTO);
                else idEquipment = null;
            }

            var diagnosisDTO = diagnosesLogic.GetDiagnosisByName(Diagnosis);
            int? idDiagnosis = diagnosisDTO.Id;
            if (idDiagnosis == 0)
            {
                if (!string.IsNullOrEmpty(Diagnosis))
                    diagnosesLogic.SaveDiagnosis(diagnosisDTO);
                else idDiagnosis = null;
            }

            orderDTO.MainMasterId = ((MasterDTO)comboBoxMainMaster.SelectedItem).Id;
            orderDTO.AdditionalMasterId = ((MasterDTO)comboBoxAdditionalMaster.SelectedItem).Id;
            orderDTO.DateCreation = dateCreation.Value.ToUniversalTime();
            orderDTO.DateStartWork = dateStartWork;
            orderDTO.DateIssue = dateTimePickerIssue.Enabled ? dateTimePickerIssue.Value : orderDTO.DateIssue;
            orderDTO.TypeTechnicId = ((TypeTechnicDTO)comboBoxDevice.SelectedItem).Id;
            orderDTO.BrandTechnicId = ((TypeBrandComboBoxDTO)comboBoxBrand.SelectedItem).IdBrand;
            orderDTO.ModelTechnic = Model;
            orderDTO.FactoryNumber = FactoryNumber;
            orderDTO.EquipmentId = idEquipment;
            orderDTO.DiagnosisId = idDiagnosis;
            orderDTO.Note = textBoxNote.Text;
            orderDTO.DateEndGuarantee = orderDTO.DateIssue != null ? orderDTO.DateIssue?.AddMonths(orderDTO.Guarantee) : null;
            orderDTO.ColorRow = ColorTranslator.ToHtml(ColorsRowsHelper.ColorDefinition(orderDTO));
            orderDTO.DateLastCall = textBoxDateLastCall.Text;
            orderDTO.PriceAgreed = PriceAgreed;
            orderDTO.MaxPrice = PriceAgreed ? Convert.ToInt32(MaxPrice) : null;
            await ordersLogic.SaveOrderAsync(orderDTO);

            DialogResult = DialogResult.OK;
            Close();
        }

        public string MainMaster
        {
            get { return comboBoxMainMaster.Text; }
        }

        public string Model
        {
            get { return textBoxModel.Text; }
            set { textBoxModel.Text = value; }
        }

        public string FactoryNumber
        {
            get { return textBoxFactoryNumber.Text; }
            set { textBoxFactoryNumber.Text = value; }
        }

        public bool PriceAgreed
        {
            get { return checkBoxPriceAgreed.Checked; }
            set { checkBoxPriceAgreed.Checked = value; }
        }

        public string Equipment
        {
            get { return textBoxEquipment.Text; }
            set { textBoxEquipment.Text = value; }
        }

        public string Diagnosis
        {
            get { return textBoxDiagnosis.Text; }
            set { textBoxDiagnosis.Text = value; }
        }

        public string MaxPrice
        {
            get { return textBoxMaxPrice.Text; }
            set { textBoxMaxPrice.Text = value; }
        }
    }
}
