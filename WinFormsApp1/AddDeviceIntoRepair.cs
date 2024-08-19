using System.Diagnostics;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class AddDeviceIntoRepair : Form
    {
        int numberPage = 1;
        bool loadingForm = true;
        readonly string withoutMaster = "-";
        readonly List<string> oldClients = [];
        readonly List<string> oldClientsType = [];
        readonly List<string> diagnosisList = [];
        readonly List<string> equipmentList = [];
        List<DiagnosisEditDTO> diagnosesDTO;
        List<EquipmentEditDTO> equipmentsDTO;
        NameTableToEditEnum nameTextBox;
        ReportsLogic reportsLogic = new();
        OrdersLogic ordersLogic = new();
        ClientsLogic clientsLogic = new();
        EquipmentsLogic equipmentsLogic = new();
        DiagnosesLogic diagnosesLogic = new();
        MastersLogic mastersLogic = new();
        TypesTechnicsLogic typesTechnicsLogic = new();
        TypesBrandsLogic typesBrandsLogic = new();
        public AddDeviceIntoRepair()
        {
            InitializeComponent();
            InitializeElementsForm();
        }

        private void InitializeElementsForm()
        {
            UpdateComboBox(ElementOfRepairEnum.MainMasterElement);
            UpdateComboBox(ElementOfRepairEnum.AdditionalMasterElement);
            UpdateComboBox(ElementOfRepairEnum.TypeDeviceElement);
            UpdateComboBox(ElementOfRepairEnum.BrandDeviceElement);

            NumberOrder = GetLastIdOrder();

            var clientsDTO = clientsLogic.GetClients();
            foreach (var client in clientsDTO)
            {
                oldClients.Add(client.IdClient);
                oldClientsType.Add(client.TypeClient.ToString());
            }

            diagnosesDTO = diagnosesLogic.GetDiagnoses();
            foreach (var diagnosis in diagnosesDTO)
            {
                diagnosisList.Add(diagnosis.Name);
            }

            equipmentsDTO = equipmentsLogic.GetEquipments();
            foreach (var equipment in equipmentsDTO)
            {
                equipmentList.Add(equipment.Name);
            }
            listBoxClient.Visible = false;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            switch (numberPage)
            {
                case 2:
                    panel2.Visible = false;
                    panel1.Visible = true;
                    dateTimePicker1.Focus();
                    numberPage = 1;
                    break;
                case 3:
                    panel3.Visible = false;
                    panel2.Visible = true;
                    comboBoxDevice.Focus();
                    numberPage = 2;
                    break;
                case 4:
                    panel4.Visible = false;
                    panel3.Visible = true;
                    textBoxNameClient.Focus();
                    numberPage = 3;
                    buttonFurther.Text = "Далее";
                    break;
            }
            Steps();
        }

        private void ButtonFurther_Click(object sender, EventArgs e)
        {
            switch (numberPage)
            {
                case 1:
                    panel1.Visible = false;
                    panel2.Visible = true;
                    comboBoxDevice.Focus();
                    numberPage = 2;
                    break;
                case 2:
                    panel2.Visible = false;
                    panel3.Visible = true;
                    textBoxNameClient.Focus();
                    numberPage = 3;
                    break;
                case 3:
                    panel3.Visible = false;
                    panel4.Visible = true;
                    textBoxEquipment.Focus();
                    numberPage = 4;
                    buttonFurther.Text = "Готово";
                    break;
                case 4:
                    SaveOrder();
                    break;
            }
            Steps();
        }

        private void SaveOrder()
        {
            if (!CheckComboBox())
                return;

            if (!CheckIdClient())
                return;

            var clientId = clientsLogic.SaveClient(ClientName, ClientNameAddress, ClientSecondPhone);

            var equipmentId = equipmentsLogic.SaveEquipment(Equipment);

            var diagnosisId = diagnosesLogic.SaveDiagnosis(Diagnosis);

            var orderDTO = new OrderEditDTO()
            {
                Id = 0,
                NumberOrder = NumberOrder,
                ClientId = clientId,
                MainMasterId = ((MasterDTO)comboBoxMainMaster.SelectedItem).Id,
                AdditionalMasterId = ((MasterDTO)comboBoxAdditionalMaster.SelectedItem).Id,
                DateCreation = dateTimePicker1.Value,
                DateStartWork = MainMasterName != withoutMaster ? dateTimePicker1.Value : null,
                TypeTechnicId = ((TypeTechnicDTO)comboBoxDevice.SelectedItem).Id,
                BrandTechnicId = ((TypeBrandComboBoxDTO)comboBoxBrand.SelectedItem).IdBrand,
                ModelTechnic = Model,
                FactoryNumber = FactoryNumber,
                EquipmentId = equipmentId,
                DiagnosisId = diagnosisId,
                Note = Note,
                StatusOrder = StatusOrderEnum.InRepair,
                ColorRow = FindColor(),
                PriceAgreed = checkBox1.Checked,
                MaxPrice = checkBox1.Checked ? Convert.ToInt32(textBoxMaxPrice.Text) : null
            };

            var idOrder = ordersLogic.SaveOrder(orderDTO);

            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelText = "Распечатать квитанцию?",
                ButtonNoText = "Нет",
                ButtonVisible = true
            };
            if (warning.ShowDialog() == DialogResult.OK)
                reportsLogic.GettingDeviceReport(idOrder);
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool CheckComboBox()
        {
            if (comboBoxDevice.Items.Count == 0 || comboBoxBrand.Items.Count == 0)
            {
                ShowWarningForm();

                if (comboBoxDevice.Items.Count == 0)
                    labelDevice.ForeColor = Color.Red;
                else
                    labelDevice.ForeColor = Color.Black;
                if (comboBoxBrand.Items.Count == 0)
                    labelBrand.ForeColor = Color.Red;
                else
                    labelBrand.ForeColor = Color.Black;

                return false;
            }
            else
                return true;
        }

        private bool CheckIdClient()
        {
            if (string.IsNullOrEmpty(textBoxNameClient.Text))
            {
                ShowWarningForm("Вы не заполнили Id заказчика!");
                labelNameClient.ForeColor = Color.Red;
                return false;
            }
            else
            {
                labelNameClient.ForeColor = Color.Black;
                return true;
            }
        }

        private static void ShowWarningForm(string text = "Вы не заполнили обязательные поля!")
        {
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelText = text
            };
            warning.ShowDialog();
        }

        private string FindColor()
        {
            string color;
            if ((DateTime.Now - dateTimePicker1.Value).Days < Convert.ToInt32
                        (Properties.Settings.Default.FirstLevelText))
            {
                color = ColorTranslator.ToHtml(Properties.Settings.Default.FirstLevelColor);
            }
            else if ((DateTime.Now - dateTimePicker1.Value).Days > Convert.ToInt32
                (Properties.Settings.Default.SecondLevelText))
            {
                color = ColorTranslator.ToHtml(Properties.Settings.Default.ThirdLevelColor);
            }
            else color = ColorTranslator.ToHtml(Properties.Settings.Default.SecondLevelColor);

            return color;
        }

        private void Steps()
        {
            switch (numberPage)
            {
                case 1:
                    labelStepName.Text = "Выбор мастера по ремонту и даты принятия (шаг 1 из 4)";
                    break;
                case 2:
                    labelStepName.Text = "Сведения об аппарате (шаг 2 из 4)";
                    break;
                case 3:
                    labelStepName.Text = "Сведения о заказчике (шаг 3 из 4)";
                    break;
                case 4:
                    labelStepName.Text = "Заметки (шаг 4 из 4)";
                    break;
            }
        }

        private void SelectingListBox(ListBox listBox, TextBox textBoxCurrent, TextBox textBoxNext, bool label = false)
        {
            if (listBox.SelectedIndex >= 0)
            {
                textBoxCurrent.Text = listBox.Items[listBox.SelectedIndex].ToString();

                listBox.Items.Clear();
                listBox.Visible = false;


                if (!label)
                    labelTypeClient.Text = "Старый клиент";

                textBoxNext.Focus();
            }

            /*if (listBoxClient.SelectedIndex >= 0)
            {
                textBoxNameClient.Text = listBoxClient.Items[listBoxClient.SelectedIndex].ToString();

                listBoxClient.Items.Clear();
                listBoxClient.Visible = false;

                labelTypeClient.Text = "Старый клиент";

                textBoxNameAddress.Focus();
            }*/
        }

        private void UpdateListBox(ListBox listBox, TextBox textBox, bool equipment = false, bool diagnosis = false, bool click = false)
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
            listBox.Location = new Point(listBox.Location.X, textBox.Location.Y + textBox.Height);
            

            if (equipment)
            {
                equipmentsDTO = equipmentsLogic.GetEquipmentsByName(textBox.Text);
                foreach (var item in equipmentsDTO)
                {
                    listBox.Items.Add(item.Name);
                }
                nameTextBox = NameTableToEditEnum.Equipment;
            }
            else if (diagnosis)
            {
                diagnosesDTO = diagnosesLogic.GetDiagnosesByName(textBox.Text);
                foreach (var item in diagnosesDTO)
                {
                    listBox.Items.Add(item.Name);
                }
                nameTextBox = NameTableToEditEnum.Diagnosis;
            }

            if (listBox.Items.Count > 0)
                listBox.Visible = true;
        }

        private void UpdateComboBox(ElementOfRepairEnum elementOfRepair)
        {
            var mastersDTO = mastersLogic.GetMastersForOutput();
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
                    comboBoxBrand.DataSource = typesBrandsLogic.GetTypeBrandByNameType(TypeDevice);
                    break;
            }
        }

        private static void PressKeys(ListBox listBox, TextBox textBoxNext, Keys keyCode)
        {
            if (keyCode == Keys.Down)
            {
                listBox.Focus();
                try
                {
                    if (listBox.SelectedIndex < listBox.Items.Count)
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
            else if (keyCode == Keys.Enter)
            {
                if (listBox.Visible)
                    listBox.Visible = false;

                textBoxNext.Focus();
            }
        }

        private void FirstId_Click(object sender, EventArgs e)
        {
            NumberOrder = 1;
        }

        private void LastId_Click(object sender, EventArgs e)
        {
            NumberOrder = GetLastIdOrder();
        }

        private void ComboBoxMainMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainMaster.Text != withoutMaster)
                comboBoxAdditionalMaster.Enabled = true;
            else
                comboBoxAdditionalMaster.Enabled = false;
        }

        private void ComboBoxAdditionalMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainMaster.Text == comboBoxAdditionalMaster.Text)
                comboBoxAdditionalMaster.SelectedIndex = 0;
        }

        private void LinkLabelDateCreation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void LinkLabelListMaster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Masters addMaster = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMaster.ShowDialog();
            UpdateComboBox(ElementOfRepairEnum.MainMasterElement);
            UpdateComboBox(ElementOfRepairEnum.AdditionalMasterElement);
        }

        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(MousePosition);
        }

        private int GetLastIdOrder()
        {
            return ordersLogic.GetLastIdOrder();
        }

        private void TextBoxNameClient_TextChanged(object sender, EventArgs e)
        {
            if (loadingForm)
                return;

            listBoxClient.Items.Clear();
            listBoxClient.Visible = false;

            foreach (var client in oldClients)
            {
                if (client.StartsWith(textBoxNameClient.Text) && textBoxNameClient.Text.Length > 0)
                {
                    listBoxClient.Visible = true;
                    listBoxClient.Items.Add(client);
                }
            }

            for (int i = 0; i < oldClients.Count; i++)
            {
                if (textBoxNameClient.Text == oldClients[i])
                {
                    labelTypeClient.Text = "Старый клиент";
                    if (oldClientsType[i] == TypeClientEnum.black.ToString())
                        labelBlackList.Visible = true;
                    else labelBlackList.Visible = false;
                    break;
                }
                else
                {
                    labelBlackList.Visible = false;
                    labelTypeClient.Text = "Новый клиент";
                }
            }
        }

        private void TextBoxNameClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void TextBoxNameClient_KeyDown(object sender, KeyEventArgs e)
        {
            PressKeys(listBoxClient, textBoxNameAddress, e.KeyCode);
        }

        private void TextBoxNameClient_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (KeyPressHelper.CheckKeyTab(e.KeyCode, listBoxClient.Visible))
                listBoxClient.Visible = false;
        }

        private void ListBoxClient_Click(object sender, EventArgs e)
        {
            SelectingListBox(listBox: listBoxClient, textBoxCurrent: textBoxNameClient, textBoxNext: textBoxNameAddress, label: true);
        }

        private void ListBoxClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectingListBox(listBox: listBoxClient, textBoxCurrent: textBoxNameClient, textBoxNext: textBoxNameAddress, label: true);
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (listBoxClient.SelectedIndex == 0)
                    textBoxNameClient.Focus();
            }
        }

        private void TextBoxSecondPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void LinkLabelDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TypesTechnic typeTechnic = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            typeTechnic.ShowDialog();
            UpdateComboBox(ElementOfRepairEnum.TypeDeviceElement);
        }

        private void LinkLabelBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BrandsTechnic brandTechnic = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            brandTechnic.ShowDialog();
            UpdateComboBox(ElementOfRepairEnum.BrandDeviceElement);
        }

        private void TextBoxNumberOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void ComboBoxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox(ElementOfRepairEnum.BrandDeviceElement);
        }

        private void TextBoxEquipment_TextChanged(object sender, EventArgs e)
        {
            if (loadingForm)
                return;

            UpdateListBox(listBoxEquipmentDiagnosis, textBoxEquipment, equipment: true);
        }

        private void TextBoxDiagnosis_TextChanged(object sender, EventArgs e)
        {
            if (loadingForm)
                return;

            UpdateListBox(listBoxEquipmentDiagnosis, textBoxDiagnosis, diagnosis: true);
        }

        private void TextBoxEquipment_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (KeyPressHelper.CheckKeyTab(e.KeyCode, listBoxEquipmentDiagnosis.Visible))
                listBoxEquipmentDiagnosis.Visible = false;
        }

        private void TextBoxDiagnosis_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (KeyPressHelper.CheckKeyTab(e.KeyCode, listBoxEquipmentDiagnosis.Visible))
                listBoxEquipmentDiagnosis.Visible = false;
        }

        private void ListBoxEquipmentDiagnosis_Click(object sender, EventArgs e)
        {
            if (nameTextBox == NameTableToEditEnum.Equipment)
                SelectingListBox(listBox: listBoxEquipmentDiagnosis, textBoxEquipment, textBoxDiagnosis);
            else if (nameTextBox == NameTableToEditEnum.Diagnosis)
                SelectingListBox(listBox: listBoxEquipmentDiagnosis, textBoxDiagnosis, textBoxNote);
        }

        private void ListBoxEquipmentDiagnosis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (nameTextBox == NameTableToEditEnum.Equipment)
                    SelectingListBox(listBox: listBoxEquipmentDiagnosis, textBoxEquipment, textBoxDiagnosis);
                else if (nameTextBox == NameTableToEditEnum.Diagnosis)
                    SelectingListBox(listBox: listBoxEquipmentDiagnosis, textBoxDiagnosis, textBoxNote);
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (listBoxEquipmentDiagnosis.SelectedIndex == 0)
                {
                    if (nameTextBox == NameTableToEditEnum.Equipment)
                        textBoxEquipment.Focus();
                    else if (nameTextBox == NameTableToEditEnum.Diagnosis)
                        textBoxDiagnosis.Focus();
                }
            }
        }

        private void TextBoxEquipment_KeyDown(object sender, KeyEventArgs e)
        {
            PressKeys(listBoxEquipmentDiagnosis, textBoxDiagnosis, e.KeyCode);
        }

        private void TextBoxDiagnosis_KeyDown(object sender, KeyEventArgs e)
        {
            PressKeys(listBoxEquipmentDiagnosis, textBoxNote, e.KeyCode);
        }

        private void TextBoxEquipment_Click(object sender, EventArgs e)
        {
            UpdateListBox(listBoxEquipmentDiagnosis, textBoxEquipment, equipment: true, click: true);
        }

        private void TextBoxDiagnosis_Click(object sender, EventArgs e)
        {
            UpdateListBox(listBoxEquipmentDiagnosis, textBoxDiagnosis, diagnosis: true, click: true);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBoxMaxPrice.Enabled = true;
            else textBoxMaxPrice.Enabled = false;
        }

        private void CheckBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                checkBox1.Checked = !checkBox1.Checked;
        }

        private void TextBoxMaxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(true, textBoxMaxPrice.Text, e.KeyChar);
        }

        private void AddDeviceForRepair_Activated(object sender, EventArgs e)
        {
            dateTimePicker1.Focus();
            loadingForm = false;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public int NumberOrder
        {
            get { return Convert.ToInt32(textBoxNumberOrder.Text); }
            set { textBoxNumberOrder.Text = value.ToString(); }
        }

        public string MainMasterName
        {
            get { return comboBoxMainMaster.Text; }
            set { comboBoxMainMaster.Text = value; }
        }

        public string AdditionalMasterName
        {
            get { return comboBoxAdditionalMaster.Text; }
            set { comboBoxAdditionalMaster.Text = value; }
        }

        public string TypeDevice
        {
            get { return comboBoxDevice.Text; }
            set { comboBoxDevice.Text = value; }
        }

        public string BrandDevice
        {
            get { return comboBoxBrand.Text; }
            set { comboBoxBrand.Text = value; }
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

        public string ClientName
        {
            get { return textBoxNameClient.Text; }
            set { textBoxNameClient.Text = value; }
        }

        public string ClientNameAddress
        {
            get { return textBoxNameAddress.Text; }
            set { textBoxNameAddress.Text = value; }
        }

        public string ClientSecondPhone
        {
            get { return textBoxSecondPhone.Text; }
            set { textBoxSecondPhone.Text = value; }
        }

        public string TypeClient
        {
            get { return labelTypeClient.Text; }
            set { labelTypeClient.Text = value; }
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

        public string Note
        {
            get { return textBoxNote.Text; }
            set { textBoxNote.Text = value; }
        }
    }
}
