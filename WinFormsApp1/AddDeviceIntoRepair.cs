using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Reports;
using WinFormsApp1.Repository;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class AddDeviceIntoRepair : Form
    {
        int numberPage = 1;
        bool loading = true;
        readonly List<string> oldClients = [];
        readonly List<string> oldClientsType = [];
        readonly List<string> diagnosisList = [];
        readonly List<string> equipmentList = [];
        List<DiagnosisEditDTO> diagnosesDTO;
        List<EquipmentEditDTO> equipmentsDTO;
        NameTableToEditEnum nameTextBox;
        OrderRepository orderRepository = new();
        ClientRepository clientRepository = new();
        DiagnosisRepository diagnosisRepository = new();
        EquipmentRepository equipmentRepository = new();
        MasterRepository masterRepository = new();
        TypeBrandRepository typeBrandRepository = new();
        TypeTechnicRepository typeTechnicRepository = new();
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
            textBoxNumberOrder.Text = IdKeyOrder().ToString();

            var clientsDTO = clientRepository.GetClients();
            foreach (var client in clientsDTO)
            {
                oldClients.Add(client.IdClient);
                oldClientsType.Add(client.TypeClient);
            }

            diagnosesDTO = diagnosisRepository.GetDiagnoses();
            foreach (var diagnosis in diagnosesDTO)
            {
                diagnosisList.Add(diagnosis.Name);
            }

            equipmentsDTO = equipmentRepository.GetEquipments();
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
                    numberPage = 1;
                    break;
                case 3:
                    panel3.Visible = false;
                    panel2.Visible = true;
                    numberPage = 2;
                    break;
                case 4:
                    panel4.Visible = false;
                    panel3.Visible = true;
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
                    numberPage = 2;
                    break;
                case 2:
                    panel2.Visible = false;
                    panel3.Visible = true;
                    numberPage = 3;
                    break;
                case 3:
                    panel3.Visible = false;
                    panel4.Visible = true;
                    numberPage = 4;
                    buttonFurther.Text = "Готово";
                    break;
                case 4:
                    if (!CheckComboBox())
                        return;
                    if (!CheckIdClient())
                        return;
                    var mainMasterId = ((MasterDTO)comboBoxMainMaster.SelectedItem).Id;
                    var additionalMasterId = ((MasterDTO)comboBoxAdditionalMaster.SelectedItem).Id;
                    DateTime? dateStartWork = null;
                    int? maxPrice = null;
                    Task? task;
                    if (comboBoxMainMaster.Text != "-")
                        dateStartWork = dateTimePicker1.Value;

                    if (checkBox1.Checked)
                        maxPrice = Convert.ToInt32(textBoxMaxPrice.Text);

                    var clientDTO = clientRepository.GetClientByIdClient(textBoxNameClient.Text);
                    int idClient = clientDTO.Id;
                    if (idClient == 0)
                    {
                        clientDTO.IdClient = textBoxNameClient.Text;
                        clientDTO.NameAndAddressClient = textBoxNameAddress.Text;
                        clientDTO.NumberSecondPhone = textBoxSecondPhone.Text;

                        task = Task.Run(async () =>
                        {
                            idClient = await clientRepository.SaveClientAsync(clientDTO);
                        });
                        task.Wait();
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

                    var orderDTO = new OrderEditDTO()
                    {
                        Id = 0,
                        NumberOrder = Convert.ToInt32(textBoxNumberOrder.Text),
                        ClientId = idClient,
                        MainMasterId = mainMasterId,
                        AdditionalMasterId = additionalMasterId,
                        DateCreation = dateTimePicker1.Value,
                        DateStartWork = dateStartWork,
                        TypeTechnicId = ((TypeTechnicDTO)comboBoxDevice.SelectedItem).Id,
                        BrandTechnicId = ((TypeBrandComboBoxDTO)comboBoxBrand.SelectedItem).IdBrand,
                        ModelTechnic = textBoxModel.Text,
                        FactoryNumber = textBoxFactoryNumber.Text,
                        EquipmentId = idEquipment,
                        DiagnosisId = idDiagnosis,
                        Note = textBoxNote.Text,
                        InProgress = true,
                        ColorRow = FindColor()
                    };

                    int idOrder = 0;
                    task = Task.Run(async () =>
                    {
                        idOrder = await orderRepository.SaveOrderAsync(orderDTO);
                    });
                    task.Wait();

                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Распечатать квитанцию?",
                        ButtonNoText = "Нет",
                        ButtonVisible = true
                    };

                    if (warning.ShowDialog() == DialogResult.OK)
                    {
                        GettingReport gettingReport = new();
                        gettingReport.Report(idOrder);
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                    break;
            }
            Steps();
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

        private void ShowWarningForm(string text = "Вы не заполнили обязательные поля!")
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

        private void UpdateComboBox(ElementOfRepairEnum elementOfRepair)
        {
            var mastersDTO = masterRepository.GetMastersForOutput();
            mastersDTO.Insert(0, new MasterDTO() { Id = null, NameMaster = "-" });
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

        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(MousePosition);
        }

        private int IdKeyOrder()
        {
            return orderRepository.GetLastNumberOrder();
        }

        private void ListBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idClient = listBoxClient.SelectedIndex;
            if (idClient >= 0)
            {
                textBoxNameClient.Text = listBoxClient.Items[idClient].ToString();

                listBoxClient.Items.Clear();
                listBoxClient.Visible = false;

                labelTypeClient.Text = "Старый клиент";

                textBoxNameClient.Focus();
                textBoxNameClient.SelectionStart = textBoxNameClient.TextLength;
            }
        }

        private void TextBoxNameClient_TextChanged(object sender, EventArgs e)
        {
            listBoxClient.Items.Clear();
            listBoxClient.Visible = false;

            foreach (var client in oldClients)
            {
                if (client.StartsWith(textBoxNameClient.Text) && textBoxNameClient.Text.Length > 0 && !loading)
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

        private void TextBoxSecondPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void AddDeviceForRepair_Activated(object sender, EventArgs e)
        {
            buttonNumber.Focus();
            loading = false;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBoxMaxPrice.Enabled = true;
            else textBoxMaxPrice.Enabled = false;
        }

        private void ComboBoxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox(ElementOfRepairEnum.BrandDeviceElement);
        }

        private void TextBoxEquipment_TextChanged(object sender, EventArgs e)
        {
            listBoxEquipmentDiagnosis.Items.Clear();
            listBoxEquipmentDiagnosis.Visible = false;
            listBoxEquipmentDiagnosis.Location = new Point(listBoxEquipmentDiagnosis.Location.X, textBoxEquipment.Location.Y + textBoxEquipment.Height);
            nameTextBox = NameTableToEditEnum.Equipment;

            equipmentsDTO = equipmentRepository.GetEquipmentsByName(textBoxEquipment.Text);
            foreach (var equipment in equipmentsDTO)
            {
                if (!loading)
                {
                    listBoxEquipmentDiagnosis.Visible = true;
                    listBoxEquipmentDiagnosis.Items.Add(equipment.Name);
                }
            }
        }

        private void TextBoxDiagnosis_TextChanged(object sender, EventArgs e)
        {
            listBoxEquipmentDiagnosis.Items.Clear();
            listBoxEquipmentDiagnosis.Visible = false;
            listBoxEquipmentDiagnosis.Location = new Point(listBoxEquipmentDiagnosis.Location.X, textBoxDiagnosis.Location.Y + textBoxDiagnosis.Height);
            nameTextBox = NameTableToEditEnum.Diagnosis;

            diagnosesDTO = diagnosisRepository.GetDiagnosesByName(textBoxDiagnosis.Text);
            foreach (var diagnosis in diagnosesDTO)
            {
                if (!loading)
                {
                    listBoxEquipmentDiagnosis.Visible = true;
                    listBoxEquipmentDiagnosis.Items.Add(diagnosis.Name);
                }
            }
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEquipmentDiagnosis.SelectedIndex >= 0)
            {
                switch (nameTextBox)
                {
                    case NameTableToEditEnum.Equipment:
                        textBoxEquipment.Text = listBoxEquipmentDiagnosis.Items[listBoxEquipmentDiagnosis.SelectedIndex].ToString();
                        break;
                    case NameTableToEditEnum.Diagnosis:
                        textBoxDiagnosis.Text = listBoxEquipmentDiagnosis.Items[listBoxEquipmentDiagnosis.SelectedIndex].ToString();
                        break;
                }

                listBoxEquipmentDiagnosis.Items.Clear();
                listBoxEquipmentDiagnosis.Visible = false;
            }
        }

        private void TextBoxEquipment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBoxEquipmentDiagnosis.Visible = false;
            }
        }

        private void TextBoxDiagnosis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBoxEquipmentDiagnosis.Visible = false;
            }
        }

        private void TextBoxEquipment_Click(object sender, EventArgs e)
        {
            if (listBoxEquipmentDiagnosis.Visible)
                listBoxEquipmentDiagnosis.Visible = false;
            else
            {
                listBoxEquipmentDiagnosis.Items.Clear();
                listBoxEquipmentDiagnosis.Location = new Point(listBoxEquipmentDiagnosis.Location.X, textBoxEquipment.Location.Y + textBoxEquipment.Height);
                nameTextBox = NameTableToEditEnum.Equipment;

                equipmentsDTO = equipmentRepository.GetEquipmentsByName(textBoxEquipment.Text);
                foreach (var equipment in equipmentsDTO)
                {
                    listBoxEquipmentDiagnosis.Items.Add(equipment.Name);
                }

                if (listBoxEquipmentDiagnosis.Items.Count > 0)
                    listBoxEquipmentDiagnosis.Visible = true;
            }
        }

        private void TextBoxDiagnosis_Click(object sender, EventArgs e)
        {
            if (listBoxEquipmentDiagnosis.Visible)
                listBoxEquipmentDiagnosis.Visible = false;
            else
            {
                listBoxEquipmentDiagnosis.Items.Clear();
                listBoxEquipmentDiagnosis.Location = new Point(listBoxEquipmentDiagnosis.Location.X, textBoxDiagnosis.Location.Y + textBoxDiagnosis.Height);
                nameTextBox = NameTableToEditEnum.Diagnosis;

                diagnosesDTO = diagnosisRepository.GetDiagnosesByName(textBoxDiagnosis.Text);
                foreach (var diagnosis in diagnosesDTO)
                {
                    if (!loading)
                    {
                        listBoxEquipmentDiagnosis.Items.Add(diagnosis.Name);
                    }
                }

                if (listBoxEquipmentDiagnosis.Items.Count > 0)
                    listBoxEquipmentDiagnosis.Visible = true;
            }
        }

        private void FirstId_Click(object sender, EventArgs e)
        {
            textBoxNumberOrder.Text = "1";
        }

        private void LastId_Click(object sender, EventArgs e)
        {
            textBoxNumberOrder.Text = IdKeyOrder().ToString();
        }

        private void ComboBoxMaster1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainMaster.Text != "-")
                comboBoxAdditionalMaster.Enabled = true;
            else
                comboBoxAdditionalMaster.Enabled = false;
        }

        private void ComboBoxMaster2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainMaster.Text == comboBoxAdditionalMaster.Text)
                comboBoxAdditionalMaster.SelectedIndex = 0;
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
