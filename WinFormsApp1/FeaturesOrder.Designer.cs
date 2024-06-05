namespace WinFormsApp1
{
    partial class FeaturesOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeaturesOrder));
            tabControl1 = new TabControl();
            tabPageOrder = new TabPage();
            label28 = new Label();
            textBoxMaxPrice = new TextBox();
            label27 = new Label();
            textBoxNote = new TextBox();
            linkLabelBrand = new LinkLabel();
            linkLabelDevice = new LinkLabel();
            checkBoxPriceAgreed = new CheckBox();
            textBoxDiagnosis = new TextBox();
            textBoxEquipment = new TextBox();
            textBoxFactoryNumber = new TextBox();
            textBoxModel = new TextBox();
            comboBoxBrand = new ComboBox();
            comboBoxDevice = new ComboBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            dateCreation = new DateTimePicker();
            linkLabelMaster = new LinkLabel();
            comboBoxMaster = new ComboBox();
            label3 = new Label();
            textBoxStatus = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBoxIdOrder = new TextBox();
            tabPageClient = new TabPage();
            linkLabel1 = new LinkLabel();
            textBoxDateLastCall = new TextBox();
            label26 = new Label();
            label25 = new Label();
            textBoxTypeClient = new TextBox();
            textBoxAddress = new TextBox();
            label19 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            textBoxWorkPhone = new TextBox();
            textBoxHomePhone = new TextBox();
            textBoxClientName = new TextBox();
            tabPageDeviceRepair = new TabPage();
            label29 = new Label();
            textBoxSumPrice = new TextBox();
            label18 = new Label();
            labelRub3 = new Label();
            textBoxPrice3 = new TextBox();
            textBoxProblem3 = new TextBox();
            labelPrice3 = new Label();
            labelProblem3 = new Label();
            labelRub2 = new Label();
            textBoxPrice2 = new TextBox();
            textBoxProblem2 = new TextBox();
            labelPrice2 = new Label();
            labelProblem2 = new Label();
            labelRub1 = new Label();
            listBox1 = new ListBox();
            textBoxPrice1 = new TextBox();
            textBoxProblem1 = new TextBox();
            labelPrice1 = new Label();
            labelProblem1 = new Label();
            textBoxPriceDetails = new TextBox();
            textBoxCountDetails = new TextBox();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            tabPageGuarantee = new TabPage();
            textBoxGuaranteeLeft = new TextBox();
            textBoxEndGuarantee = new TextBox();
            textBoxGuaranteePeriod = new TextBox();
            textBoxAvailabilityGuarantee = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            label20 = new Label();
            buttonSave = new Button();
            buttonExit = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tabPageOrder.SuspendLayout();
            tabPageClient.SuspendLayout();
            tabPageDeviceRepair.SuspendLayout();
            tabPageGuarantee.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageOrder);
            tabControl1.Controls.Add(tabPageClient);
            tabControl1.Controls.Add(tabPageDeviceRepair);
            tabControl1.Controls.Add(tabPageGuarantee);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(789, 624);
            tabControl1.TabIndex = 0;
            // 
            // tabPageOrder
            // 
            tabPageOrder.Controls.Add(label28);
            tabPageOrder.Controls.Add(textBoxMaxPrice);
            tabPageOrder.Controls.Add(label27);
            tabPageOrder.Controls.Add(textBoxNote);
            tabPageOrder.Controls.Add(linkLabelBrand);
            tabPageOrder.Controls.Add(linkLabelDevice);
            tabPageOrder.Controls.Add(checkBoxPriceAgreed);
            tabPageOrder.Controls.Add(textBoxDiagnosis);
            tabPageOrder.Controls.Add(textBoxEquipment);
            tabPageOrder.Controls.Add(textBoxFactoryNumber);
            tabPageOrder.Controls.Add(textBoxModel);
            tabPageOrder.Controls.Add(comboBoxBrand);
            tabPageOrder.Controls.Add(comboBoxDevice);
            tabPageOrder.Controls.Add(label11);
            tabPageOrder.Controls.Add(label10);
            tabPageOrder.Controls.Add(label9);
            tabPageOrder.Controls.Add(label8);
            tabPageOrder.Controls.Add(label7);
            tabPageOrder.Controls.Add(label6);
            tabPageOrder.Controls.Add(label5);
            tabPageOrder.Controls.Add(label4);
            tabPageOrder.Controls.Add(dateCreation);
            tabPageOrder.Controls.Add(linkLabelMaster);
            tabPageOrder.Controls.Add(comboBoxMaster);
            tabPageOrder.Controls.Add(label3);
            tabPageOrder.Controls.Add(textBoxStatus);
            tabPageOrder.Controls.Add(label2);
            tabPageOrder.Controls.Add(label1);
            tabPageOrder.Controls.Add(textBoxIdOrder);
            tabPageOrder.Location = new Point(4, 34);
            tabPageOrder.Name = "tabPageOrder";
            tabPageOrder.Padding = new Padding(3);
            tabPageOrder.Size = new Size(781, 586);
            tabPageOrder.TabIndex = 0;
            tabPageOrder.Text = "Информация о заказе";
            tabPageOrder.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(664, 346);
            label28.Name = "label28";
            label28.Size = new Size(46, 25);
            label28.TabIndex = 30;
            label28.Text = "руб.";
            // 
            // textBoxMaxPrice
            // 
            textBoxMaxPrice.Enabled = false;
            textBoxMaxPrice.Location = new Point(536, 343);
            textBoxMaxPrice.Name = "textBoxMaxPrice";
            textBoxMaxPrice.Size = new Size(123, 31);
            textBoxMaxPrice.TabIndex = 29;
            textBoxMaxPrice.KeyPress += TextBoxMaxPrice_KeyPress;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(496, 346);
            label27.Name = "label27";
            label27.Size = new Size(33, 25);
            label27.TabIndex = 28;
            label27.Text = "до";
            // 
            // textBoxNote
            // 
            textBoxNote.Location = new Point(270, 487);
            textBoxNote.Multiline = true;
            textBoxNote.Name = "textBoxNote";
            textBoxNote.Size = new Size(463, 87);
            textBoxNote.TabIndex = 27;
            // 
            // linkLabelBrand
            // 
            linkLabelBrand.AutoSize = true;
            linkLabelBrand.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabelBrand.Location = new Point(552, 256);
            linkLabelBrand.Name = "linkLabelBrand";
            linkLabelBrand.Size = new Size(211, 25);
            linkLabelBrand.TabIndex = 26;
            linkLabelBrand.TabStop = true;
            linkLabelBrand.Text = "Список производителей";
            linkLabelBrand.LinkClicked += LinkLabelBrand_LinkClicked;
            // 
            // linkLabelDevice
            // 
            linkLabelDevice.AutoSize = true;
            linkLabelDevice.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabelDevice.Location = new Point(552, 208);
            linkLabelDevice.Name = "linkLabelDevice";
            linkLabelDevice.Size = new Size(124, 25);
            linkLabelDevice.TabIndex = 25;
            linkLabelDevice.TabStop = true;
            linkLabelDevice.Text = "Список типов";
            linkLabelDevice.LinkClicked += LinkLabelDevice_LinkClicked;
            // 
            // checkBoxPriceAgreed
            // 
            checkBoxPriceAgreed.AutoSize = true;
            checkBoxPriceAgreed.Location = new Point(496, 300);
            checkBoxPriceAgreed.Name = "checkBoxPriceAgreed";
            checkBoxPriceAgreed.Size = new Size(185, 29);
            checkBoxPriceAgreed.TabIndex = 24;
            checkBoxPriceAgreed.Text = "Цена согласована";
            checkBoxPriceAgreed.UseVisualStyleBackColor = true;
            checkBoxPriceAgreed.CheckedChanged += CheckBoxPriceAgreed_CheckedChanged;
            // 
            // textBoxDiagnosis
            // 
            textBoxDiagnosis.Location = new Point(270, 442);
            textBoxDiagnosis.Name = "textBoxDiagnosis";
            textBoxDiagnosis.Size = new Size(463, 31);
            textBoxDiagnosis.TabIndex = 21;
            // 
            // textBoxEquipment
            // 
            textBoxEquipment.Location = new Point(270, 399);
            textBoxEquipment.Name = "textBoxEquipment";
            textBoxEquipment.Size = new Size(463, 31);
            textBoxEquipment.TabIndex = 20;
            // 
            // textBoxFactoryNumber
            // 
            textBoxFactoryNumber.Location = new Point(270, 343);
            textBoxFactoryNumber.Name = "textBoxFactoryNumber";
            textBoxFactoryNumber.Size = new Size(171, 31);
            textBoxFactoryNumber.TabIndex = 19;
            // 
            // textBoxModel
            // 
            textBoxModel.Location = new Point(270, 301);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.Size = new Size(171, 31);
            textBoxModel.TabIndex = 18;
            // 
            // comboBoxBrand
            // 
            comboBoxBrand.BackColor = Color.FromArgb(224, 224, 224);
            comboBoxBrand.FormattingEnabled = true;
            comboBoxBrand.Location = new Point(270, 248);
            comboBoxBrand.Name = "comboBoxBrand";
            comboBoxBrand.Size = new Size(266, 33);
            comboBoxBrand.TabIndex = 17;
            // 
            // comboBoxDevice
            // 
            comboBoxDevice.BackColor = Color.FromArgb(224, 224, 224);
            comboBoxDevice.FormattingEnabled = true;
            comboBoxDevice.Location = new Point(270, 205);
            comboBoxDevice.Name = "comboBoxDevice";
            comboBoxDevice.Size = new Size(266, 33);
            comboBoxDevice.TabIndex = 16;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(139, 487);
            label11.Name = "label11";
            label11.Size = new Size(116, 25);
            label11.TabIndex = 15;
            label11.Text = "Примечание";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(23, 445);
            label10.Name = "label10";
            label10.Size = new Size(232, 25);
            label10.TabIndex = 14;
            label10.Text = "Предварительный диагноз";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(126, 402);
            label9.Name = "label9";
            label9.Size = new Size(129, 25);
            label9.TabIndex = 13;
            label9.Text = "Комплектация";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(96, 346);
            label8.Name = "label8";
            label8.Size = new Size(159, 25);
            label8.TabIndex = 12;
            label8.Text = "Заводской номер";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(179, 304);
            label7.Name = "label7";
            label7.Size = new Size(76, 25);
            label7.TabIndex = 11;
            label7.Text = "Модель";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(55, 251);
            label6.Name = "label6";
            label6.Size = new Size(200, 25);
            label6.TabIndex = 10;
            label6.Text = "Фирма-производитель";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(119, 208);
            label5.Name = "label5";
            label5.Size = new Size(136, 25);
            label5.TabIndex = 9;
            label5.Text = "Тип устройства";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 160);
            label4.Name = "label4";
            label4.Size = new Size(211, 25);
            label4.TabIndex = 8;
            label4.Text = "Дата принятия в ремонт";
            // 
            // dateCreation
            // 
            dateCreation.Format = DateTimePickerFormat.Short;
            dateCreation.Location = new Point(270, 155);
            dateCreation.Name = "dateCreation";
            dateCreation.Size = new Size(266, 31);
            dateCreation.TabIndex = 7;
            // 
            // linkLabelMaster
            // 
            linkLabelMaster.AutoSize = true;
            linkLabelMaster.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabelMaster.Location = new Point(496, 109);
            linkLabelMaster.Name = "linkLabelMaster";
            linkLabelMaster.Size = new Size(154, 25);
            linkLabelMaster.TabIndex = 6;
            linkLabelMaster.TabStop = true;
            linkLabelMaster.Text = "Список мастеров";
            linkLabelMaster.LinkClicked += LinkLabelMaster_LinkClicked;
            // 
            // comboBoxMaster
            // 
            comboBoxMaster.BackColor = Color.FromArgb(224, 224, 224);
            comboBoxMaster.FormattingEnabled = true;
            comboBoxMaster.Location = new Point(270, 104);
            comboBoxMaster.Name = "comboBoxMaster";
            comboBoxMaster.Size = new Size(210, 33);
            comboBoxMaster.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 107);
            label3.Name = "label3";
            label3.Size = new Size(72, 25);
            label3.TabIndex = 4;
            label3.Text = "Мастер";
            // 
            // textBoxStatus
            // 
            textBoxStatus.BackColor = SystemColors.ButtonFace;
            textBoxStatus.Location = new Point(270, 58);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.ReadOnly = true;
            textBoxStatus.Size = new Size(266, 31);
            textBoxStatus.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = Color.FromArgb(105, 101, 148);
            label2.Location = new Point(62, 61);
            label2.Name = "label2";
            label2.Size = new Size(193, 25);
            label2.TabIndex = 2;
            label2.Text = "Состояние устройства";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(105, 101, 148);
            label1.Location = new Point(95, 18);
            label1.Name = "label1";
            label1.Size = new Size(160, 25);
            label1.TabIndex = 1;
            label1.Text = "Номер квитанции";
            // 
            // textBoxIdOrder
            // 
            textBoxIdOrder.BackColor = SystemColors.ButtonFace;
            textBoxIdOrder.Location = new Point(270, 15);
            textBoxIdOrder.Name = "textBoxIdOrder";
            textBoxIdOrder.ReadOnly = true;
            textBoxIdOrder.Size = new Size(150, 31);
            textBoxIdOrder.TabIndex = 0;
            // 
            // tabPageClient
            // 
            tabPageClient.Controls.Add(linkLabel1);
            tabPageClient.Controls.Add(textBoxDateLastCall);
            tabPageClient.Controls.Add(label26);
            tabPageClient.Controls.Add(label25);
            tabPageClient.Controls.Add(textBoxTypeClient);
            tabPageClient.Controls.Add(textBoxAddress);
            tabPageClient.Controls.Add(label19);
            tabPageClient.Controls.Add(label14);
            tabPageClient.Controls.Add(label13);
            tabPageClient.Controls.Add(label12);
            tabPageClient.Controls.Add(textBoxWorkPhone);
            tabPageClient.Controls.Add(textBoxHomePhone);
            tabPageClient.Controls.Add(textBoxClientName);
            tabPageClient.Location = new Point(4, 34);
            tabPageClient.Name = "tabPageClient";
            tabPageClient.Padding = new Padding(3);
            tabPageClient.Size = new Size(781, 586);
            tabPageClient.TabIndex = 1;
            tabPageClient.Text = "Информация о клиенте";
            tabPageClient.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Red;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(133, 133, 133);
            linkLabel1.Location = new Point(507, 326);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(174, 25);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Сегодняшнее число";
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
            // 
            // textBoxDateLastCall
            // 
            textBoxDateLastCall.Location = new Point(248, 323);
            textBoxDateLastCall.Name = "textBoxDateLastCall";
            textBoxDateLastCall.Size = new Size(253, 31);
            textBoxDateLastCall.TabIndex = 12;
            textBoxDateLastCall.KeyPress += TextBoxDateLastCall_KeyPress;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(23, 326);
            label26.Name = "label26";
            label26.Size = new Size(210, 25);
            label26.TabIndex = 11;
            label26.Text = "Дата последнего звонка";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.ForeColor = Color.FromArgb(105, 101, 148);
            label25.Location = new Point(79, 257);
            label25.Name = "label25";
            label25.Size = new Size(154, 25);
            label25.TabIndex = 9;
            label25.Text = "Качество клиента";
            // 
            // textBoxTypeClient
            // 
            textBoxTypeClient.BackColor = SystemColors.ButtonFace;
            textBoxTypeClient.Location = new Point(248, 254);
            textBoxTypeClient.Name = "textBoxTypeClient";
            textBoxTypeClient.ReadOnly = true;
            textBoxTypeClient.Size = new Size(253, 31);
            textBoxTypeClient.TabIndex = 8;
            // 
            // textBoxAddress
            // 
            textBoxAddress.BackColor = SystemColors.ButtonFace;
            textBoxAddress.Location = new Point(248, 85);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.ReadOnly = true;
            textBoxAddress.Size = new Size(507, 31);
            textBoxAddress.TabIndex = 7;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.ForeColor = Color.FromArgb(105, 101, 148);
            label19.Location = new Point(171, 88);
            label19.Name = "label19";
            label19.Size = new Size(62, 25);
            label19.TabIndex = 6;
            label19.Text = "Адрес";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.FromArgb(105, 101, 148);
            label14.Location = new Point(116, 196);
            label14.Name = "label14";
            label14.Size = new Size(117, 25);
            label14.TabIndex = 5;
            label14.Text = "Раб. телефон";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.FromArgb(105, 101, 148);
            label13.Location = new Point(109, 157);
            label13.Name = "label13";
            label13.Size = new Size(124, 25);
            label13.TabIndex = 4;
            label13.Text = "Дом. телефон";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.FromArgb(105, 101, 148);
            label12.Location = new Point(95, 42);
            label12.Name = "label12";
            label12.Size = new Size(138, 25);
            label12.TabIndex = 3;
            label12.Text = "ФИО заказчика";
            // 
            // textBoxWorkPhone
            // 
            textBoxWorkPhone.BackColor = SystemColors.ButtonFace;
            textBoxWorkPhone.Location = new Point(248, 193);
            textBoxWorkPhone.Name = "textBoxWorkPhone";
            textBoxWorkPhone.ReadOnly = true;
            textBoxWorkPhone.Size = new Size(253, 31);
            textBoxWorkPhone.TabIndex = 2;
            // 
            // textBoxHomePhone
            // 
            textBoxHomePhone.BackColor = SystemColors.ButtonFace;
            textBoxHomePhone.Location = new Point(248, 151);
            textBoxHomePhone.Name = "textBoxHomePhone";
            textBoxHomePhone.ReadOnly = true;
            textBoxHomePhone.Size = new Size(253, 31);
            textBoxHomePhone.TabIndex = 1;
            // 
            // textBoxClientName
            // 
            textBoxClientName.BackColor = SystemColors.ButtonFace;
            textBoxClientName.Location = new Point(248, 39);
            textBoxClientName.Name = "textBoxClientName";
            textBoxClientName.ReadOnly = true;
            textBoxClientName.Size = new Size(253, 31);
            textBoxClientName.TabIndex = 0;
            // 
            // tabPageDeviceRepair
            // 
            tabPageDeviceRepair.Controls.Add(label29);
            tabPageDeviceRepair.Controls.Add(textBoxSumPrice);
            tabPageDeviceRepair.Controls.Add(label18);
            tabPageDeviceRepair.Controls.Add(labelRub3);
            tabPageDeviceRepair.Controls.Add(textBoxPrice3);
            tabPageDeviceRepair.Controls.Add(textBoxProblem3);
            tabPageDeviceRepair.Controls.Add(labelPrice3);
            tabPageDeviceRepair.Controls.Add(labelProblem3);
            tabPageDeviceRepair.Controls.Add(labelRub2);
            tabPageDeviceRepair.Controls.Add(textBoxPrice2);
            tabPageDeviceRepair.Controls.Add(textBoxProblem2);
            tabPageDeviceRepair.Controls.Add(labelPrice2);
            tabPageDeviceRepair.Controls.Add(labelProblem2);
            tabPageDeviceRepair.Controls.Add(labelRub1);
            tabPageDeviceRepair.Controls.Add(listBox1);
            tabPageDeviceRepair.Controls.Add(textBoxPrice1);
            tabPageDeviceRepair.Controls.Add(textBoxProblem1);
            tabPageDeviceRepair.Controls.Add(labelPrice1);
            tabPageDeviceRepair.Controls.Add(labelProblem1);
            tabPageDeviceRepair.Controls.Add(textBoxPriceDetails);
            tabPageDeviceRepair.Controls.Add(textBoxCountDetails);
            tabPageDeviceRepair.Controls.Add(label17);
            tabPageDeviceRepair.Controls.Add(label16);
            tabPageDeviceRepair.Controls.Add(label15);
            tabPageDeviceRepair.Location = new Point(4, 34);
            tabPageDeviceRepair.Name = "tabPageDeviceRepair";
            tabPageDeviceRepair.Padding = new Padding(3);
            tabPageDeviceRepair.Size = new Size(781, 586);
            tabPageDeviceRepair.TabIndex = 2;
            tabPageDeviceRepair.Text = "Ремонт аппарата";
            tabPageDeviceRepair.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.ForeColor = Color.FromArgb(105, 101, 148);
            label29.Location = new Point(698, 516);
            label29.Name = "label29";
            label29.Size = new Size(46, 25);
            label29.TabIndex = 35;
            label29.Text = "руб.";
            // 
            // textBoxSumPrice
            // 
            textBoxSumPrice.Location = new Point(584, 513);
            textBoxSumPrice.Name = "textBoxSumPrice";
            textBoxSumPrice.ReadOnly = true;
            textBoxSumPrice.Size = new Size(108, 31);
            textBoxSumPrice.TabIndex = 34;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = Color.FromArgb(105, 101, 148);
            label18.Location = new Point(513, 516);
            label18.Name = "label18";
            label18.Size = new Size(65, 25);
            label18.TabIndex = 33;
            label18.Text = "Итого:";
            // 
            // labelRub3
            // 
            labelRub3.AutoSize = true;
            labelRub3.ForeColor = Color.FromArgb(150, 150, 150);
            labelRub3.Location = new Point(698, 456);
            labelRub3.Name = "labelRub3";
            labelRub3.Size = new Size(46, 25);
            labelRub3.TabIndex = 22;
            labelRub3.Text = "руб.";
            // 
            // textBoxPrice3
            // 
            textBoxPrice3.Enabled = false;
            textBoxPrice3.Location = new Point(584, 453);
            textBoxPrice3.Name = "textBoxPrice3";
            textBoxPrice3.ReadOnly = true;
            textBoxPrice3.Size = new Size(108, 31);
            textBoxPrice3.TabIndex = 21;
            // 
            // textBoxProblem3
            // 
            textBoxProblem3.AllowDrop = true;
            textBoxProblem3.Enabled = false;
            textBoxProblem3.Location = new Point(270, 453);
            textBoxProblem3.Name = "textBoxProblem3";
            textBoxProblem3.ReadOnly = true;
            textBoxProblem3.Size = new Size(208, 31);
            textBoxProblem3.TabIndex = 20;
            // 
            // labelPrice3
            // 
            labelPrice3.AutoSize = true;
            labelPrice3.ForeColor = Color.FromArgb(150, 150, 150);
            labelPrice3.Location = new Point(525, 456);
            labelPrice3.Name = "labelPrice3";
            labelPrice3.Size = new Size(53, 25);
            labelPrice3.TabIndex = 19;
            labelPrice3.Text = "Цена";
            // 
            // labelProblem3
            // 
            labelProblem3.AutoSize = true;
            labelProblem3.ForeColor = Color.FromArgb(150, 150, 150);
            labelProblem3.Location = new Point(27, 456);
            labelProblem3.Name = "labelProblem3";
            labelProblem3.Size = new Size(228, 25);
            labelProblem3.TabIndex = 18;
            labelProblem3.Text = "Найденная неисправность";
            // 
            // labelRub2
            // 
            labelRub2.AutoSize = true;
            labelRub2.ForeColor = Color.FromArgb(150, 150, 150);
            labelRub2.Location = new Point(698, 409);
            labelRub2.Name = "labelRub2";
            labelRub2.Size = new Size(46, 25);
            labelRub2.TabIndex = 17;
            labelRub2.Text = "руб.";
            // 
            // textBoxPrice2
            // 
            textBoxPrice2.BackColor = SystemColors.Control;
            textBoxPrice2.Enabled = false;
            textBoxPrice2.Location = new Point(584, 406);
            textBoxPrice2.Name = "textBoxPrice2";
            textBoxPrice2.ReadOnly = true;
            textBoxPrice2.Size = new Size(108, 31);
            textBoxPrice2.TabIndex = 16;
            // 
            // textBoxProblem2
            // 
            textBoxProblem2.AllowDrop = true;
            textBoxProblem2.Enabled = false;
            textBoxProblem2.Location = new Point(270, 406);
            textBoxProblem2.Name = "textBoxProblem2";
            textBoxProblem2.ReadOnly = true;
            textBoxProblem2.Size = new Size(208, 31);
            textBoxProblem2.TabIndex = 15;
            // 
            // labelPrice2
            // 
            labelPrice2.AutoSize = true;
            labelPrice2.ForeColor = Color.FromArgb(150, 150, 150);
            labelPrice2.Location = new Point(525, 409);
            labelPrice2.Name = "labelPrice2";
            labelPrice2.Size = new Size(53, 25);
            labelPrice2.TabIndex = 14;
            labelPrice2.Text = "Цена";
            // 
            // labelProblem2
            // 
            labelProblem2.AutoSize = true;
            labelProblem2.ForeColor = Color.FromArgb(150, 150, 150);
            labelProblem2.Location = new Point(27, 409);
            labelProblem2.Name = "labelProblem2";
            labelProblem2.Size = new Size(228, 25);
            labelProblem2.TabIndex = 13;
            labelProblem2.Text = "Найденная неисправность";
            // 
            // labelRub1
            // 
            labelRub1.AutoSize = true;
            labelRub1.ForeColor = Color.FromArgb(150, 150, 150);
            labelRub1.Location = new Point(698, 362);
            labelRub1.Name = "labelRub1";
            labelRub1.Size = new Size(46, 25);
            labelRub1.TabIndex = 12;
            labelRub1.Text = "руб.";
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Control;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(270, 32);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(432, 204);
            listBox1.TabIndex = 11;
            // 
            // textBoxPrice1
            // 
            textBoxPrice1.BackColor = SystemColors.Control;
            textBoxPrice1.Enabled = false;
            textBoxPrice1.Location = new Point(584, 359);
            textBoxPrice1.Name = "textBoxPrice1";
            textBoxPrice1.ReadOnly = true;
            textBoxPrice1.Size = new Size(108, 31);
            textBoxPrice1.TabIndex = 9;
            textBoxPrice1.KeyPress += TextBoxPriceRepair_KeyPress;
            // 
            // textBoxProblem1
            // 
            textBoxProblem1.AllowDrop = true;
            textBoxProblem1.BackColor = SystemColors.Control;
            textBoxProblem1.Enabled = false;
            textBoxProblem1.Location = new Point(270, 359);
            textBoxProblem1.Name = "textBoxProblem1";
            textBoxProblem1.ReadOnly = true;
            textBoxProblem1.Size = new Size(208, 31);
            textBoxProblem1.TabIndex = 8;
            // 
            // labelPrice1
            // 
            labelPrice1.AutoSize = true;
            labelPrice1.ForeColor = Color.FromArgb(150, 150, 150);
            labelPrice1.Location = new Point(525, 362);
            labelPrice1.Name = "labelPrice1";
            labelPrice1.Size = new Size(53, 25);
            labelPrice1.TabIndex = 7;
            labelPrice1.Text = "Цена";
            // 
            // labelProblem1
            // 
            labelProblem1.AutoSize = true;
            labelProblem1.ForeColor = Color.FromArgb(150, 150, 150);
            labelProblem1.Location = new Point(27, 362);
            labelProblem1.Name = "labelProblem1";
            labelProblem1.Size = new Size(228, 25);
            labelProblem1.TabIndex = 6;
            labelProblem1.Text = "Найденная неисправность";
            // 
            // textBoxPriceDetails
            // 
            textBoxPriceDetails.Location = new Point(270, 291);
            textBoxPriceDetails.Name = "textBoxPriceDetails";
            textBoxPriceDetails.ReadOnly = true;
            textBoxPriceDetails.Size = new Size(150, 31);
            textBoxPriceDetails.TabIndex = 5;
            // 
            // textBoxCountDetails
            // 
            textBoxCountDetails.Location = new Point(270, 249);
            textBoxCountDetails.Name = "textBoxCountDetails";
            textBoxCountDetails.ReadOnly = true;
            textBoxCountDetails.Size = new Size(150, 31);
            textBoxCountDetails.TabIndex = 4;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.FromArgb(105, 101, 148);
            label17.Location = new Point(24, 294);
            label17.Name = "label17";
            label17.Size = new Size(231, 25);
            label17.TabIndex = 2;
            label17.Text = "Суммарная цена за детали";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.FromArgb(105, 101, 148);
            label16.Location = new Point(80, 252);
            label16.Name = "label16";
            label16.Size = new Size(175, 25);
            label16.TabIndex = 1;
            label16.Text = "Количество деталей";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.FromArgb(105, 101, 148);
            label15.Location = new Point(97, 35);
            label15.Name = "label15";
            label15.Size = new Size(158, 25);
            label15.TabIndex = 0;
            label15.Text = "Детали на ремонт";
            // 
            // tabPageGuarantee
            // 
            tabPageGuarantee.Controls.Add(textBoxGuaranteeLeft);
            tabPageGuarantee.Controls.Add(textBoxEndGuarantee);
            tabPageGuarantee.Controls.Add(textBoxGuaranteePeriod);
            tabPageGuarantee.Controls.Add(textBoxAvailabilityGuarantee);
            tabPageGuarantee.Controls.Add(dateTimePicker1);
            tabPageGuarantee.Controls.Add(label24);
            tabPageGuarantee.Controls.Add(label23);
            tabPageGuarantee.Controls.Add(label22);
            tabPageGuarantee.Controls.Add(label21);
            tabPageGuarantee.Controls.Add(label20);
            tabPageGuarantee.Location = new Point(4, 34);
            tabPageGuarantee.Name = "tabPageGuarantee";
            tabPageGuarantee.Padding = new Padding(3);
            tabPageGuarantee.Size = new Size(781, 586);
            tabPageGuarantee.TabIndex = 3;
            tabPageGuarantee.Text = "Гарантия на устройство";
            tabPageGuarantee.UseVisualStyleBackColor = true;
            // 
            // textBoxGuaranteeLeft
            // 
            textBoxGuaranteeLeft.Enabled = false;
            textBoxGuaranteeLeft.Location = new Point(270, 206);
            textBoxGuaranteeLeft.Name = "textBoxGuaranteeLeft";
            textBoxGuaranteeLeft.ReadOnly = true;
            textBoxGuaranteeLeft.Size = new Size(140, 31);
            textBoxGuaranteeLeft.TabIndex = 9;
            // 
            // textBoxEndGuarantee
            // 
            textBoxEndGuarantee.Enabled = false;
            textBoxEndGuarantee.Location = new Point(270, 164);
            textBoxEndGuarantee.Name = "textBoxEndGuarantee";
            textBoxEndGuarantee.ReadOnly = true;
            textBoxEndGuarantee.Size = new Size(180, 31);
            textBoxEndGuarantee.TabIndex = 8;
            // 
            // textBoxGuaranteePeriod
            // 
            textBoxGuaranteePeriod.Enabled = false;
            textBoxGuaranteePeriod.Location = new Point(270, 122);
            textBoxGuaranteePeriod.Name = "textBoxGuaranteePeriod";
            textBoxGuaranteePeriod.ReadOnly = true;
            textBoxGuaranteePeriod.Size = new Size(220, 31);
            textBoxGuaranteePeriod.TabIndex = 7;
            // 
            // textBoxAvailabilityGuarantee
            // 
            textBoxAvailabilityGuarantee.Enabled = false;
            textBoxAvailabilityGuarantee.ForeColor = Color.Black;
            textBoxAvailabilityGuarantee.Location = new Point(270, 80);
            textBoxAvailabilityGuarantee.Name = "textBoxAvailabilityGuarantee";
            textBoxAvailabilityGuarantee.ReadOnly = true;
            textBoxAvailabilityGuarantee.Size = new Size(260, 31);
            textBoxAvailabilityGuarantee.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(270, 30);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(153, 31);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.ForeColor = Color.FromArgb(150, 150, 150);
            label24.Location = new Point(48, 209);
            label24.Name = "label24";
            label24.Size = new Size(207, 25);
            label24.TabIndex = 4;
            label24.Text = "Осталось до окончания";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.ForeColor = Color.FromArgb(150, 150, 150);
            label23.Location = new Point(29, 167);
            label23.Name = "label23";
            label23.Size = new Size(226, 25);
            label23.TabIndex = 3;
            label23.Text = "Срок окончания гарантии";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.ForeColor = Color.FromArgb(150, 150, 150);
            label22.Location = new Point(36, 125);
            label22.Name = "label22";
            label22.Size = new Size(219, 25);
            label22.TabIndex = 2;
            label22.Text = "Срок гарантии в месяцах";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.ForeColor = Color.FromArgb(150, 150, 150);
            label21.Location = new Point(95, 83);
            label21.Name = "label21";
            label21.Size = new Size(160, 25);
            label21.TabIndex = 1;
            label21.Text = "Наличие гарантии";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = Color.FromArgb(150, 150, 150);
            label20.Location = new Point(60, 33);
            label20.Name = "label20";
            label20.Size = new Size(195, 25);
            label20.TabIndex = 0;
            label20.Text = "Дата выдачи аппарата";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(388, 647);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(194, 43);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(601, 647);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(194, 43);
            buttonExit.TabIndex = 27;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // timer1
            // 
            timer1.Tick += Timer1_Tick;
            // 
            // FeaturesOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 700);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FeaturesOrder";
            Text = "Свойства устройства";
            Activated += FeaturesOrder_Activated;
            Load += FeaturesOrder_Load;
            tabControl1.ResumeLayout(false);
            tabPageOrder.ResumeLayout(false);
            tabPageOrder.PerformLayout();
            tabPageClient.ResumeLayout(false);
            tabPageClient.PerformLayout();
            tabPageDeviceRepair.ResumeLayout(false);
            tabPageDeviceRepair.PerformLayout();
            tabPageGuarantee.ResumeLayout(false);
            tabPageGuarantee.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageOrder;
        private TabPage tabPageClient;
        private TabPage tabPageDeviceRepair;
        private TabPage tabPageGuarantee;
        private Label label1;
        private TextBox textBoxIdOrder;
        private Label label4;
        private DateTimePicker dateCreation;
        private LinkLabel linkLabelMaster;
        private ComboBox comboBoxMaster;
        private Label label3;
        private TextBox textBoxStatus;
        private Label label2;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private ComboBox comboBoxBrand;
        private ComboBox comboBoxDevice;
        private Label label11;
        private Label label10;
        private Label label9;
        private LinkLabel linkLabelDevice;
        private CheckBox checkBoxPriceAgreed;
        private TextBox textBoxDiagnosis;
        private TextBox textBoxEquipment;
        private TextBox textBoxFactoryNumber;
        private TextBox textBoxModel;
        private LinkLabel linkLabelBrand;
        private Button buttonSave;
        private Button buttonExit;
        private Label label14;
        private Label label13;
        private Label label12;
        private TextBox textBoxWorkPhone;
        private TextBox textBoxHomePhone;
        private TextBox textBoxClientName;
        private Label label17;
        private Label label16;
        private Label label15;
        private TextBox textBoxPrice1;
        private TextBox textBoxProblem1;
        private Label labelPrice1;
        private Label labelProblem1;
        private TextBox textBoxPriceDetails;
        private TextBox textBoxCountDetails;
        private TextBox textBoxNote;
        private Label label20;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label21;
        private DateTimePicker dateTimePicker1;
        private TextBox textBoxAvailabilityGuarantee;
        private TextBox textBoxGuaranteeLeft;
        private TextBox textBoxEndGuarantee;
        private TextBox textBoxGuaranteePeriod;
        private ListBox listBox1;
        private Label labelRub1;
        private TextBox textBoxAddress;
        private Label label19;
        private Label label25;
        private TextBox textBoxTypeClient;
        private TextBox textBoxDateLastCall;
        private Label label26;
        private LinkLabel linkLabel1;
        private System.Windows.Forms.Timer timer1;
        private Label label28;
        private TextBox textBoxMaxPrice;
        private Label label27;
        private Label labelRub3;
        private TextBox textBoxPrice3;
        private TextBox textBoxProblem3;
        private Label labelPrice3;
        private Label labelProblem3;
        private Label labelRub2;
        private TextBox textBoxPrice2;
        private TextBox textBoxProblem2;
        private Label labelPrice2;
        private Label labelProblem2;
        private Label label29;
        private TextBox textBoxSumPrice;
        private Label label18;
    }
}