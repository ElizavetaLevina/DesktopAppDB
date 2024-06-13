using WinFormsApp1.Model;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class AddDeviceForRepair : Form
    {
        int numberPage = 1;
        bool loading = true;
        readonly List<string> oldClients = [];
        readonly List<string> oldClientsType = [];
        readonly List<string> diagnosis = [];
        readonly List<string> equipment = [];
        private readonly List<Diagnosis> listDiagnosis;
        private readonly List<Equipment> listEquipment;
        string nameTextBox = "";
        public AddDeviceForRepair()
        {
            InitializeComponent();
            UpdateComboBox(0);
            UpdateComboBox(1);
            UpdateComboBox(2);
            textBoxIdOrder.Text = IdKeyOrder().ToString();
            Context context = new();
            var listClient = context.Clients.Select(a => new { a.IdClient, a.TypeClient }).ToList();
            if (listClient.Count > 0)
            {
                for (int i = 0; i < listClient.Count; i++)
                {
                    oldClients.Add(listClient[i].IdClient);
                    oldClientsType.Add(listClient[i].TypeClient);
                }
            }

            listDiagnosis = context.Diagnosis.ToList();
            for (int i = 0; i < listDiagnosis.Count; i++)
            {
                diagnosis.Add(listDiagnosis[i].Name);
            }

            listEquipment = context.Equipment.ToList();
            for (int i = 0; i < listEquipment.Count; i++)
            {
                equipment.Add(listEquipment[i].Name);
            }

            foundInTable.Click += FoundInTable_Click;
            lastId.Click += LastId_Click;
            checkId.Click += CheckId_Click;
            listBoxClient.Visible = false;
        }

        private void FoundInTable_Click(object? sender, EventArgs e)
        {
            Context context = new();
            var list = context.Orders.Select(a => new { a.Id }).OrderBy(a => a.Id).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if ((i + 1) != list[i].Id)
                {
                    textBoxIdOrder.Text = (i + 1).ToString();
                    break;
                }
            }
        }

        private void LastId_Click(object? sender, EventArgs e)
        {
            textBoxIdOrder.Text = IdKeyOrder().ToString();
        }

        private void CheckId_Click(object? sender, EventArgs e)
        {
            Context context = new();
            var list = context.Orders.Select(a => new { a.Id }).ToList();

            if (CheckIdOrder())
            {
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Проверка номера кватанции",
                    LabelText = "Квитанция с таким номером уже существует!"
                };
                warning.ShowDialog();
            }

        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            switch (numberPage)
            {
                case 2:
                    panel2.Visible = false;
                    panel1.Visible = true;
                    this.numberPage = 1;
                    break;
                case 3:
                    panel3.Visible = false;
                    panel2.Visible = true;
                    this.numberPage = 2;
                    break;
                case 4:
                    panel4.Visible = false;
                    panel3.Visible = true;
                    this.numberPage = 3;
                    buttonFurther.Text = "Далее";
                    break;

            }
            Steps();

        }

        private void ButtonFurther_Click(object sender, EventArgs e)
        {
            Context context = new();
            switch (numberPage)
            {
                case 1:
                    panel1.Visible = false;
                    panel2.Visible = true;
                    this.numberPage = 2;
                    break;
                case 2:
                    panel2.Visible = false;
                    panel3.Visible = true;
                    this.numberPage = 3;
                    break;
                case 3:
                    panel3.Visible = false;
                    panel4.Visible = true;
                    this.numberPage = 4;
                    buttonFurther.Text = "Готово";
                    break;
                case 4:
                    if (comboBoxDevice.Items.Count == 0 ||
                          comboBoxBrand.Items.Count == 0)
                    {
                        Warning warning = new()
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        warning.ShowDialog();

                        if (comboBoxDevice.Items.Count == 0)
                            labelDevice.ForeColor = Color.Red;
                        else
                            labelDevice.ForeColor = Color.Black;
                        if (comboBoxBrand.Items.Count == 0)
                            labelBrand.ForeColor = Color.Red;
                        else
                            labelBrand.ForeColor = Color.Black;
                    }
                    else if (textBoxNameClient.Text == "")
                    {
                        labelNameClient.ForeColor = Color.Red;
                        Warning warning = new()
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            LabelText = "Вы не заполнили ФИО заказчика!"
                        };
                        warning.ShowDialog();
                    }
                    else if (CheckIdOrder())
                    {
                        Warning warning = new()
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            Text = "Внимание",
                            LabelText = "Квитанция с таким номером уже существует!"
                        };
                        warning.ShowDialog();
                    }
                    else
                    {
                        int idClient = IdKeyClient();
                        int idOrder = Convert.ToInt32(textBoxIdOrder.Text);
                        int? nameMaster = null;
                        DateTime? dateStartWork = null;
                        string color = "";
                        int? maxPrice = null;
                        if (comboBoxMaster.Text != "-")
                        {
                            nameMaster = context.Masters.Where(a => a.NameMaster == comboBoxMaster.Text).ToList()[0].Id;
                            dateStartWork = dateTimePicker1.Value;
                        }

                        if (checkBox1.Checked)
                            maxPrice = Convert.ToInt32(textBoxMaxPrice.Text);

                        if (!CheckClient())
                        {
                            try
                            {
                                String[] splitted = textBoxNameAddress.Text.Split(",", 2);
                                CRUD.AddAsyncClient(idClient, textBoxNameClient.Text, splitted[0],
                                    splitted[splitted.Length - 1], textBoxSecondPhone.Text, "normal");
                            }
                            catch { }
                        }

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

                        int idDiagnosis = 1;
                        var listDiagnosis = context.Diagnosis.Where(i => i.Name.IndexOf(textBoxDiagnosis.Text) > -1).ToList();
                        if (listDiagnosis.Count == 0)
                        {
                            if (context.Diagnosis.Any())
                                idDiagnosis = context.Diagnosis.OrderBy(i => i.Id).Last().Id + 1;
                            CRUD.AddAsyncDiagnosis(idDiagnosis, textBoxDiagnosis.Text);
                        }
                        else
                            idDiagnosis = listDiagnosis[0].Id;

                        int idEquipment = 1;
                        var listEquipment = context.Equipment.Where(i => i.Name.IndexOf(textBoxEquipment.Text) > -1).ToList();
                        if (listEquipment.Count == 0)
                        {
                            if (context.Equipment.Any())
                                idEquipment = context.Equipment.OrderBy(i => i.Id).Last().Id + 1;
                            CRUD.AddAsyncEquipment(idEquipment, textBoxEquipment.Text);
                        }
                        else
                            idEquipment = listEquipment[0].Id;

                        CRUD.AddAsyncOrder(
                            idOrder,
                            context.Clients.Where(a => a.IdClient == textBoxNameClient.Text).ToList()[0].Id,
                            nameMaster,
                            dateTimePicker1.Value,
                            dateStartWork,
                            null,
                            null,
                            context.TypeTechnices.Where(a => a.NameTypeTechnic == comboBoxDevice.Text).ToList()[0].Id,
                            context.BrandTechnices.Where(a => a.NameBrandTechnic == comboBoxBrand.Text).ToList()[0].Id,
                            textBoxModel.Text,
                            textBoxFactoryNumber.Text,
                            idEquipment,
                            idDiagnosis,
                            textBoxNote.Text,
                            true,
                            0,
                            null,
                            false,
                            false,
                            null,
                            null,
                            null,
                            false,
                            color,
                            null,
                            checkBox1.Checked,
                            maxPrice);
                        CRUD.AddAsyncDetails(idOrder, null);
                        Warning warning = new()
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            LabelText = "Распечатать квитанцию?",
                            ButtonNoText = "Нет",
                            ButtonVisible = true
                        };

                        if (warning.ShowDialog() == DialogResult.OK)
                        {
                            Form1 form = new();
                            form.ReportGetting(idOrder);
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    break;
            }
            Steps();
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
            AddMaster addMaster = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMaster.ShowDialog();
            UpdateComboBox(0);
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
                        var list = context.TypeBrands.Where(i =>
                        i.BrandTechnic.NameBrandTechnic == comboBoxBrand.Text).ToList();
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
                        var list = context.TypeBrands.Where(i =>
                        i.TypeTechnic.NameTypeTechnic == comboBoxDevice.Text).Select(a => new
                        {
                            a.BrandTechnic.NameBrandTechnic
                        }).ToList();
                        comboBoxBrand.DisplayMember = "NameBrandTechnic";
                        comboBoxBrand.DataSource = list;
                    }
                    break;

            }
        }

        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(MousePosition);
        }

        private bool CheckIdOrder()
        {
            Context context = new();
            bool matching = false;
            var list = context.Orders.Select(a => new { a.Id }).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (Convert.ToInt32(textBoxIdOrder.Text) == list[i].Id)
                {
                    matching = true;
                    break;
                }
            }
            return matching;
        }

        private bool CheckClient()
        {
            Context context = new();
            bool matching = false;

            var list = context.Clients.Select(a => new { a.IdClient }).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (textBoxNameClient.Text == list[i].IdClient)
                {
                    matching = true;
                    break;
                }
            }
            return matching;
        }

        private static int IdKeyOrder()
        {
            int idKey;
            using (Context context = new())
            {
                if (context.Orders.Any())
                {
                    idKey = context.Orders.OrderBy(i => i.Id).Last().Id;
                    idKey++;
                }
                else { idKey = 1; }
            }
            return idKey;
        }

        private static int IdKeyClient()
        {
            int idKey;
            using (Context context = new())
            {
                if (context.Clients.Any())
                {
                    idKey = context.Clients.OrderBy(i => i.Id).Last().Id;
                    idKey++;
                }
                else { idKey = 1; }
            }
            return idKey;
        }

        private void ListBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = listBoxClient.SelectedIndex;
            if (id >= 0)
            {
                textBoxNameClient.Text = listBoxClient.Items[id].ToString();

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

            for (int i = 0; i < oldClients.Count; i++)
            {
                if (oldClients[i].StartsWith(textBoxNameClient.Text) && textBoxNameClient.Text.Length > 0 && !loading)
                {
                    listBoxClient.Visible = true;
                    listBoxClient.Items.Add(oldClients[i]);
                }
            }

            for (int i = 0; i < oldClients.Count; i++)
            {
                if (textBoxNameClient.Text == oldClients[i])
                {
                    labelTypeClient.Text = "Старый клиент";
                    if (oldClientsType[i] == "black")
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

        private void AddDeviceForRepair_Activated(object sender, EventArgs e)
        {
            buttonNumber.Focus();
            loading = false;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        private void TextBoxIdOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBoxMaxPrice.Enabled = true;
            else textBoxMaxPrice.Enabled = false;
        }

        private void ComboBoxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox(2);
        }

        private void TextBoxEquipment_TextChanged(object sender, EventArgs e)
        {
            listBoxEquipmentDiagnosis.Items.Clear();
            listBoxEquipmentDiagnosis.Visible = false;
            listBoxEquipmentDiagnosis.Location = new Point(listBoxEquipmentDiagnosis.Location.X, textBoxEquipment.Location.Y + textBoxEquipment.Height);
            nameTextBox = "equipment";

            for (int i = 0; i < equipment.Count; i++)
            {
                if (equipment[i].Contains(textBoxEquipment.Text, StringComparison.OrdinalIgnoreCase) && !loading)
                {
                    listBoxEquipmentDiagnosis.Visible = true;
                    listBoxEquipmentDiagnosis.Items.Add(equipment[i]);
                }
            }
        }

        private void TextBoxDiagnosis_TextChanged(object sender, EventArgs e)
        {
            listBoxEquipmentDiagnosis.Items.Clear();
            listBoxEquipmentDiagnosis.Visible = false;
            listBoxEquipmentDiagnosis.Location = new Point(listBoxEquipmentDiagnosis.Location.X, textBoxDiagnosis.Location.Y + textBoxDiagnosis.Height);
            nameTextBox = "diagnosis";

            for (int i = 0; i < diagnosis.Count; i++)
            {
                if (diagnosis[i].Contains(textBoxDiagnosis.Text, StringComparison.OrdinalIgnoreCase) && !loading)
                {
                    listBoxEquipmentDiagnosis.Visible = true;
                    listBoxEquipmentDiagnosis.Items.Add(diagnosis[i]);
                }
            }
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = listBoxEquipmentDiagnosis.SelectedIndex;
            if (id >= 0)
            {
                switch (nameTextBox)
                {
                    case "equipment":
                        textBoxEquipment.Text = listBoxEquipmentDiagnosis.Items[id].ToString();
                        break;
                    case "diagnosis":
                        textBoxDiagnosis.Text = listBoxEquipmentDiagnosis.Items[id].ToString();
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
            listBoxEquipmentDiagnosis.Items.Clear();
            listBoxEquipmentDiagnosis.Visible = true;
            listBoxEquipmentDiagnosis.Location = new Point(listBoxEquipmentDiagnosis.Location.X, textBoxEquipment.Location.Y + textBoxEquipment.Height);
            nameTextBox = "equipment";
            for (int i = 0; i < equipment.Count; i++)
            {
                if (textBoxEquipment.Text == "")
                    listBoxEquipmentDiagnosis.Items.Add(equipment[i]);
                else if(equipment[i].Contains(textBoxEquipment.Text, StringComparison.OrdinalIgnoreCase))
                    listBoxEquipmentDiagnosis.Items.Add(equipment[i]);
            }
        }

        private void TextBoxDiagnosis_Click(object sender, EventArgs e)
        {
            listBoxEquipmentDiagnosis.Items.Clear();
            listBoxEquipmentDiagnosis.Visible = true;
            listBoxEquipmentDiagnosis.Location = new Point(listBoxEquipmentDiagnosis.Location.X, textBoxDiagnosis.Location.Y + textBoxDiagnosis.Height);
            nameTextBox = "diagnosis";
            for (int i = 0; i < diagnosis.Count; i++)
            {
                if (textBoxDiagnosis.Text == "")
                    listBoxEquipmentDiagnosis.Items.Add(diagnosis[i]);
                else if (diagnosis[i].Contains(textBoxDiagnosis.Text, StringComparison.OrdinalIgnoreCase))
                    listBoxEquipmentDiagnosis.Items.Add(diagnosis[i]);
            }
        }

        public string MasterName
        {
            get { return this.comboBoxMaster.Text; }
            set { this.comboBoxMaster.Text = value; }
        }

        public string TypeDevice
        {
            get { return this.comboBoxDevice.Text; }
            set { this.comboBoxDevice.Text = value; }
        }

        public string BrandDevice
        {
            get { return this.comboBoxBrand.Text; }
            set { this.comboBoxBrand.Text = value; }
        }

        public string Model
        {
            get { return this.textBoxModel.Text; }
            set { this.textBoxModel.Text = value; }
        }

        public string FactoryNumber
        {
            get { return this.textBoxFactoryNumber.Text; }
            set { this.textBoxFactoryNumber.Text = value; }
        }

        public string ClientName
        {
            get { return this.textBoxNameClient.Text; }
            set { this.textBoxNameClient.Text = value; }
        }

        public string ClientNameAddress
        {
            get { return this.textBoxNameAddress.Text; }
            set { this.textBoxNameAddress.Text = value; }
        }

        public string ClientSecondPhone
        {
            get { return this.textBoxSecondPhone.Text; }
            set { this.textBoxSecondPhone.Text = value; }
        }

        public string TypeClient
        {
            get { return this.labelTypeClient.Text; }
            set { this.labelTypeClient.Text = value; }
        }

        public string Equipment
        {
            get { return this.textBoxEquipment.Text; }
            set { this.textBoxEquipment.Text = value; }
        }

        public string Diagnosis
        {
            get { return this.textBoxDiagnosis.Text; }
            set { this.textBoxDiagnosis.Text = value; }
        }

        public string Note
        {
            get { return this.textBoxNote.Text; }
            set { this.textBoxNote.Text = value; }
        }
    }
}
