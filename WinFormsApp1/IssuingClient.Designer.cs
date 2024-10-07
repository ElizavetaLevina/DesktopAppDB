namespace WinFormsApp1
{
    partial class IssuingClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuingClient));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            labelGuaranteePeriod = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            labelTotalPrice = new Label();
            labelNameClient = new Label();
            labelDateCreate = new Label();
            labelEquipment = new Label();
            labelCountDetails = new Label();
            labelPriceDetails = new Label();
            labelPriceRepair = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBoxGuarantee = new TextBox();
            buttonIssueDevice = new Button();
            buttonExit = new Button();
            linkLabelDateNow = new LinkLabel();
            labelIsGuarantee = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.issue;
            pictureBox1.Location = new Point(12, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 281);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(236, 1);
            label1.Name = "label1";
            label1.Size = new Size(2, 381);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(270, 59);
            label2.Name = "label2";
            label2.Size = new Size(290, 2);
            label2.TabIndex = 2;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(266, 205);
            label3.Name = "label3";
            label3.Size = new Size(290, 2);
            label3.TabIndex = 3;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(0, 382);
            label4.Name = "label4";
            label4.Size = new Size(909, 2);
            label4.TabIndex = 4;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(0, 383);
            label5.Name = "label5";
            label5.Size = new Size(909, 2);
            label5.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(270, 28);
            label6.Name = "label6";
            label6.Size = new Size(231, 25);
            label6.TabIndex = 6;
            label6.Text = "Дата выдачи и гарантия:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(267, 172);
            label7.Name = "label7";
            label7.Size = new Size(206, 25);
            label7.TabIndex = 7;
            label7.Text = "Информация к месту:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(302, 83);
            label8.Name = "label8";
            label8.Size = new Size(199, 25);
            label8.TabIndex = 8;
            label8.Text = "Дата выдачи аппарата:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(274, 129);
            label9.Name = "label9";
            label9.Size = new Size(227, 25);
            label9.TabIndex = 11;
            label9.Text = "Гарантировать аппарат на";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(587, 129);
            label10.Name = "label10";
            label10.Size = new Size(46, 25);
            label10.TabIndex = 13;
            label10.Text = "мес.";
            // 
            // labelGuaranteePeriod
            // 
            labelGuaranteePeriod.AutoSize = true;
            labelGuaranteePeriod.Location = new Point(778, 129);
            labelGuaranteePeriod.Name = "labelGuaranteePeriod";
            labelGuaranteePeriod.Size = new Size(100, 25);
            labelGuaranteePeriod.TabIndex = 15;
            labelGuaranteePeriod.Text = "08.05.2024";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(401, 216);
            label11.Name = "label11";
            label11.Size = new Size(100, 25);
            label11.TabIndex = 16;
            label11.Text = "Id клиента:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(288, 241);
            label12.Name = "label12";
            label12.Size = new Size(213, 25);
            label12.TabIndex = 18;
            label12.Text = "Дата принятия аппарата:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(368, 266);
            label13.Name = "label13";
            label13.Size = new Size(133, 25);
            label13.TabIndex = 20;
            label13.Text = "Комплектация:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(269, 291);
            label14.Name = "label14";
            label14.Size = new Size(232, 25);
            label14.TabIndex = 22;
            label14.Text = "Кол-во деталей на ремонт:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(330, 316);
            label15.Name = "label15";
            label15.Size = new Size(171, 25);
            label15.TabIndex = 24;
            label15.Text = "Стоимость деталей:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(369, 341);
            label16.Name = "label16";
            label16.Size = new Size(132, 25);
            label16.TabIndex = 26;
            label16.Text = "Цена ремонта:";
            // 
            // label17
            // 
            label17.BorderStyle = BorderStyle.Fixed3D;
            label17.Location = new Point(744, 313);
            label17.Name = "label17";
            label17.Size = new Size(2, 60);
            label17.TabIndex = 18;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label18.Location = new Point(752, 316);
            label18.Name = "label18";
            label18.Size = new Size(68, 25);
            label18.TabIndex = 28;
            label18.Text = "Итого:";
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Location = new Point(752, 341);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(61, 25);
            labelTotalPrice.TabIndex = 29;
            labelTotalPrice.Text = "0 руб.";
            // 
            // labelNameClient
            // 
            labelNameClient.AutoSize = true;
            labelNameClient.Location = new Point(507, 216);
            labelNameClient.Name = "labelNameClient";
            labelNameClient.Size = new Size(62, 25);
            labelNameClient.TabIndex = 17;
            labelNameClient.Text = "78987";
            // 
            // labelDateCreate
            // 
            labelDateCreate.AutoSize = true;
            labelDateCreate.Location = new Point(507, 241);
            labelDateCreate.Name = "labelDateCreate";
            labelDateCreate.Size = new Size(100, 25);
            labelDateCreate.TabIndex = 19;
            labelDateCreate.Text = "04.04.2024";
            // 
            // labelEquipment
            // 
            labelEquipment.AutoSize = true;
            labelEquipment.Location = new Point(507, 266);
            labelEquipment.Name = "labelEquipment";
            labelEquipment.Size = new Size(19, 25);
            labelEquipment.TabIndex = 21;
            labelEquipment.Text = "-";
            // 
            // labelCountDetails
            // 
            labelCountDetails.AutoSize = true;
            labelCountDetails.Location = new Point(507, 291);
            labelCountDetails.Name = "labelCountDetails";
            labelCountDetails.Size = new Size(52, 25);
            labelCountDetails.TabIndex = 23;
            labelCountDetails.Text = "0 шт.";
            // 
            // labelPriceDetails
            // 
            labelPriceDetails.AutoSize = true;
            labelPriceDetails.Location = new Point(507, 316);
            labelPriceDetails.Name = "labelPriceDetails";
            labelPriceDetails.Size = new Size(61, 25);
            labelPriceDetails.TabIndex = 25;
            labelPriceDetails.Text = "0 руб.";
            // 
            // labelPriceRepair
            // 
            labelPriceRepair.AutoSize = true;
            labelPriceRepair.Location = new Point(508, 341);
            labelPriceRepair.Name = "labelPriceRepair";
            labelPriceRepair.Size = new Size(61, 25);
            labelPriceRepair.TabIndex = 27;
            labelPriceRepair.Text = "0 руб.";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(508, 78);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(164, 31);
            dateTimePicker1.TabIndex = 9;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // textBoxGuarantee
            // 
            textBoxGuarantee.Location = new Point(507, 126);
            textBoxGuarantee.Name = "textBoxGuarantee";
            textBoxGuarantee.Size = new Size(74, 31);
            textBoxGuarantee.TabIndex = 12;
            textBoxGuarantee.Text = "1";
            textBoxGuarantee.TextChanged += TextBoxGuarantee_TextChanged;
            textBoxGuarantee.KeyPress += TextBoxGuarantee_KeyPress;
            // 
            // buttonIssueDevice
            // 
            buttonIssueDevice.Location = new Point(392, 390);
            buttonIssueDevice.Name = "buttonIssueDevice";
            buttonIssueDevice.Size = new Size(241, 43);
            buttonIssueDevice.TabIndex = 30;
            buttonIssueDevice.Text = "Выдать аппарат";
            buttonIssueDevice.UseVisualStyleBackColor = true;
            buttonIssueDevice.Click += ButtonIssueDevice_ClickAsync;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(656, 390);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(241, 43);
            buttonExit.TabIndex = 31;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // linkLabelDateNow
            // 
            linkLabelDateNow.AutoSize = true;
            linkLabelDateNow.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabelDateNow.Location = new Point(688, 83);
            linkLabelDateNow.Name = "linkLabelDateNow";
            linkLabelDateNow.Size = new Size(161, 25);
            linkLabelDateNow.TabIndex = 10;
            linkLabelDateNow.TabStop = true;
            linkLabelDateNow.Text = "Сегодняшняя дата";
            linkLabelDateNow.LinkClicked += LinkLabelDateNow_LinkClicked;
            // 
            // labelIsGuarantee
            // 
            labelIsGuarantee.AutoSize = true;
            labelIsGuarantee.Location = new Point(668, 129);
            labelIsGuarantee.Name = "labelIsGuarantee";
            labelIsGuarantee.Size = new Size(111, 25);
            labelIsGuarantee.TabIndex = 14;
            labelIsGuarantee.Text = "Гарантия до";
            // 
            // IssuingClient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 440);
            Controls.Add(labelIsGuarantee);
            Controls.Add(linkLabelDateNow);
            Controls.Add(buttonExit);
            Controls.Add(buttonIssueDevice);
            Controls.Add(textBoxGuarantee);
            Controls.Add(dateTimePicker1);
            Controls.Add(labelPriceRepair);
            Controls.Add(labelPriceDetails);
            Controls.Add(labelCountDetails);
            Controls.Add(labelEquipment);
            Controls.Add(labelDateCreate);
            Controls.Add(labelNameClient);
            Controls.Add(labelTotalPrice);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(labelGuaranteePeriod);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "IssuingClient";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Выдача отремонтированного аппарата клиенту";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label labelGuaranteePeriod;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label labelTotalPrice;
        private Label labelNameClient;
        private Label labelDateCreate;
        private Label labelEquipment;
        private Label labelCountDetails;
        private Label labelPriceDetails;
        private Label labelPriceRepair;
        private DateTimePicker dateTimePicker1;
        private TextBox textBoxGuarantee;
        private Button buttonIssueDevice;
        private Button buttonExit;
        private LinkLabel linkLabelDateNow;
        private Label labelIsGuarantee;
    }
}