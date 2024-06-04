namespace WinFormsApp1
{
    partial class CompletedOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompletedOrder));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            labelDurationRepair = new Label();
            labelCountDetails = new Label();
            labelPriceDetails = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            dateTimePicker1 = new DateTimePicker();
            linkLabelDateNow = new LinkLabel();
            textBoxPrice1 = new TextBox();
            label11 = new Label();
            textBoxFoundProblem1 = new TextBox();
            label12 = new Label();
            label13 = new Label();
            buttonSave = new Button();
            buttonExit = new Button();
            pictureBox1 = new PictureBox();
            label14 = new Label();
            textBoxFoundProblem2 = new TextBox();
            label15 = new Label();
            textBoxPrice2 = new TextBox();
            label16 = new Label();
            label17 = new Label();
            textBoxFoundProblem3 = new TextBox();
            label18 = new Label();
            textBoxPrice3 = new TextBox();
            label19 = new Label();
            label20 = new Label();
            textBoxFoundProblem4 = new TextBox();
            label21 = new Label();
            textBoxPrice4 = new TextBox();
            label22 = new Label();
            label23 = new Label();
            textBoxFoundProblem5 = new TextBox();
            label24 = new Label();
            textBoxPrice5 = new TextBox();
            label25 = new Label();
            label26 = new Label();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(270, 20);
            label1.Name = "label1";
            label1.Size = new Size(206, 25);
            label1.TabIndex = 0;
            label1.Text = "Информация к месту:";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(270, 51);
            label2.Name = "label2";
            label2.Size = new Size(290, 2);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 72);
            label3.Name = "label3";
            label3.Size = new Size(197, 25);
            label3.TabIndex = 2;
            label3.Text = "Длительность ремонта";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(322, 97);
            label4.Name = "label4";
            label4.Size = new Size(179, 25);
            label4.TabIndex = 3;
            label4.Text = "Кол-во исп. деталей:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(279, 122);
            label5.Name = "label5";
            label5.Size = new Size(222, 25);
            label5.TabIndex = 4;
            label5.Text = "Суммарная цена деталей:";
            // 
            // labelDurationRepair
            // 
            labelDurationRepair.AutoSize = true;
            labelDurationRepair.Location = new Point(507, 72);
            labelDurationRepair.Name = "labelDurationRepair";
            labelDurationRepair.Size = new Size(51, 25);
            labelDurationRepair.TabIndex = 5;
            labelDurationRepair.Text = "0 дн.";
            // 
            // labelCountDetails
            // 
            labelCountDetails.AutoSize = true;
            labelCountDetails.Location = new Point(507, 97);
            labelCountDetails.Name = "labelCountDetails";
            labelCountDetails.Size = new Size(52, 25);
            labelCountDetails.TabIndex = 6;
            labelCountDetails.Text = "0 шт.";
            // 
            // labelPriceDetails
            // 
            labelPriceDetails.AutoSize = true;
            labelPriceDetails.Location = new Point(507, 122);
            labelPriceDetails.Name = "labelPriceDetails";
            labelPriceDetails.Size = new Size(61, 25);
            labelPriceDetails.TabIndex = 7;
            labelPriceDetails.Text = "0 руб.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(271, 167);
            label6.Name = "label6";
            label6.Size = new Size(159, 25);
            label6.TabIndex = 8;
            label6.Text = "Отчет о ремонте";
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.Location = new Point(270, 200);
            label7.Name = "label7";
            label7.Size = new Size(290, 2);
            label7.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(294, 223);
            label8.Name = "label8";
            label8.Size = new Size(207, 25);
            label8.TabIndex = 10;
            label8.Text = "Дата исполнения заказа";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(841, 281);
            label9.Name = "label9";
            label9.Size = new Size(99, 25);
            label9.TabIndex = 11;
            label9.Text = "Стоимость";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(273, 281);
            label10.Name = "label10";
            label10.Size = new Size(228, 25);
            label10.TabIndex = 12;
            label10.Text = "Найденная неисправность";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(507, 221);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(150, 31);
            dateTimePicker1.TabIndex = 13;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // linkLabelDateNow
            // 
            linkLabelDateNow.AutoSize = true;
            linkLabelDateNow.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabelDateNow.Location = new Point(663, 223);
            linkLabelDateNow.Name = "linkLabelDateNow";
            linkLabelDateNow.Size = new Size(161, 25);
            linkLabelDateNow.TabIndex = 14;
            linkLabelDateNow.TabStop = true;
            linkLabelDateNow.Text = "Сегодняшняя дата";
            linkLabelDateNow.LinkClicked += LinkLabelDateNow_LinkClicked;
            // 
            // textBoxPrice1
            // 
            textBoxPrice1.Location = new Point(946, 278);
            textBoxPrice1.Name = "textBoxPrice1";
            textBoxPrice1.Size = new Size(150, 31);
            textBoxPrice1.TabIndex = 18;
            textBoxPrice1.KeyPress += TextBoxPriceRepair_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1102, 281);
            label11.Name = "label11";
            label11.Size = new Size(46, 25);
            label11.TabIndex = 16;
            label11.Text = "руб.";
            // 
            // textBoxFoundProblem1
            // 
            textBoxFoundProblem1.Location = new Point(507, 278);
            textBoxFoundProblem1.Name = "textBoxFoundProblem1";
            textBoxFoundProblem1.Size = new Size(317, 31);
            textBoxFoundProblem1.TabIndex = 17;
            textBoxFoundProblem1.Click += TextBoxFoundProblem1_Click;
            textBoxFoundProblem1.TextChanged += TextBoxFoundProblem1_TextChanged;
            textBoxFoundProblem1.KeyDown += TextBoxFoundProblem1_KeyDown;
            // 
            // label12
            // 
            label12.BorderStyle = BorderStyle.Fixed3D;
            label12.Location = new Point(-2, 556);
            label12.Name = "label12";
            label12.Size = new Size(1216, 2);
            label12.TabIndex = 18;
            // 
            // label13
            // 
            label13.BorderStyle = BorderStyle.Fixed3D;
            label13.Location = new Point(-2, 557);
            label13.Name = "label13";
            label13.Size = new Size(1216, 2);
            label13.TabIndex = 19;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(710, 567);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(241, 43);
            buttonSave.TabIndex = 27;
            buttonSave.Text = "Пометить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(957, 567);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(241, 43);
            buttonExit.TabIndex = 28;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.complite;
            pictureBox1.Location = new Point(12, 181);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 209);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // label14
            // 
            label14.BorderStyle = BorderStyle.Fixed3D;
            label14.Location = new Point(236, 1);
            label14.Name = "label14";
            label14.Size = new Size(2, 555);
            label14.TabIndex = 23;
            // 
            // textBoxFoundProblem2
            // 
            textBoxFoundProblem2.Enabled = false;
            textBoxFoundProblem2.Location = new Point(507, 332);
            textBoxFoundProblem2.Name = "textBoxFoundProblem2";
            textBoxFoundProblem2.Size = new Size(317, 31);
            textBoxFoundProblem2.TabIndex = 19;
            textBoxFoundProblem2.Click += TextBoxFoundProblem2_Click;
            textBoxFoundProblem2.TextChanged += TextBoxFoundProblem2_TextChanged;
            textBoxFoundProblem2.KeyDown += TextBoxFoundProblem2_KeyDown;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(1102, 335);
            label15.Name = "label15";
            label15.Size = new Size(46, 25);
            label15.TabIndex = 27;
            label15.Text = "руб.";
            // 
            // textBoxPrice2
            // 
            textBoxPrice2.Enabled = false;
            textBoxPrice2.Location = new Point(946, 332);
            textBoxPrice2.Name = "textBoxPrice2";
            textBoxPrice2.Size = new Size(150, 31);
            textBoxPrice2.TabIndex = 20;
            textBoxPrice2.KeyPress += TextBoxPrice2_KeyPress;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(273, 335);
            label16.Name = "label16";
            label16.Size = new Size(228, 25);
            label16.TabIndex = 25;
            label16.Text = "Найденная неисправность";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(841, 335);
            label17.Name = "label17";
            label17.Size = new Size(99, 25);
            label17.TabIndex = 24;
            label17.Text = "Стоимость";
            // 
            // textBoxFoundProblem3
            // 
            textBoxFoundProblem3.Enabled = false;
            textBoxFoundProblem3.Location = new Point(507, 386);
            textBoxFoundProblem3.Name = "textBoxFoundProblem3";
            textBoxFoundProblem3.Size = new Size(317, 31);
            textBoxFoundProblem3.TabIndex = 21;
            textBoxFoundProblem3.Click += TextBoxFoundProblem3_Click;
            textBoxFoundProblem3.TextChanged += TextBoxFoundProblem3_TextChanged;
            textBoxFoundProblem3.KeyDown += TextBoxFoundProblem3_KeyDown;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(1102, 389);
            label18.Name = "label18";
            label18.Size = new Size(46, 25);
            label18.TabIndex = 32;
            label18.Text = "руб.";
            // 
            // textBoxPrice3
            // 
            textBoxPrice3.Enabled = false;
            textBoxPrice3.Location = new Point(946, 386);
            textBoxPrice3.Name = "textBoxPrice3";
            textBoxPrice3.Size = new Size(150, 31);
            textBoxPrice3.TabIndex = 22;
            textBoxPrice3.KeyPress += TextBoxPrice3_KeyPress;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(273, 389);
            label19.Name = "label19";
            label19.Size = new Size(228, 25);
            label19.TabIndex = 30;
            label19.Text = "Найденная неисправность";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(841, 389);
            label20.Name = "label20";
            label20.Size = new Size(99, 25);
            label20.TabIndex = 29;
            label20.Text = "Стоимость";
            // 
            // textBoxFoundProblem4
            // 
            textBoxFoundProblem4.Enabled = false;
            textBoxFoundProblem4.Location = new Point(507, 440);
            textBoxFoundProblem4.Name = "textBoxFoundProblem4";
            textBoxFoundProblem4.Size = new Size(317, 31);
            textBoxFoundProblem4.TabIndex = 23;
            textBoxFoundProblem4.Click += TextBoxFoundProblem4_Click;
            textBoxFoundProblem4.TextChanged += TextBoxFoundProblem4_TextChanged;
            textBoxFoundProblem4.KeyDown += TextBoxFoundProblem4_KeyDown;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(1102, 443);
            label21.Name = "label21";
            label21.Size = new Size(46, 25);
            label21.TabIndex = 37;
            label21.Text = "руб.";
            // 
            // textBoxPrice4
            // 
            textBoxPrice4.Enabled = false;
            textBoxPrice4.Location = new Point(946, 440);
            textBoxPrice4.Name = "textBoxPrice4";
            textBoxPrice4.Size = new Size(150, 31);
            textBoxPrice4.TabIndex = 24;
            textBoxPrice4.KeyPress += TextBoxPrice4_KeyPress;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(273, 443);
            label22.Name = "label22";
            label22.Size = new Size(228, 25);
            label22.TabIndex = 35;
            label22.Text = "Найденная неисправность";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(841, 443);
            label23.Name = "label23";
            label23.Size = new Size(99, 25);
            label23.TabIndex = 34;
            label23.Text = "Стоимость";
            // 
            // textBoxFoundProblem5
            // 
            textBoxFoundProblem5.Enabled = false;
            textBoxFoundProblem5.Location = new Point(507, 494);
            textBoxFoundProblem5.Name = "textBoxFoundProblem5";
            textBoxFoundProblem5.Size = new Size(317, 31);
            textBoxFoundProblem5.TabIndex = 25;
            textBoxFoundProblem5.Click += TextBoxFoundProblem5_Click;
            textBoxFoundProblem5.TextChanged += TextBoxFoundProblem5_TextChanged;
            textBoxFoundProblem5.KeyDown += TextBoxFoundProblem5_KeyDown;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(1102, 497);
            label24.Name = "label24";
            label24.Size = new Size(46, 25);
            label24.TabIndex = 42;
            label24.Text = "руб.";
            // 
            // textBoxPrice5
            // 
            textBoxPrice5.Enabled = false;
            textBoxPrice5.Location = new Point(946, 494);
            textBoxPrice5.Name = "textBoxPrice5";
            textBoxPrice5.Size = new Size(150, 31);
            textBoxPrice5.TabIndex = 26;
            textBoxPrice5.KeyPress += TextBoxPrice5_KeyPress;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(273, 497);
            label25.Name = "label25";
            label25.Size = new Size(228, 25);
            label25.TabIndex = 40;
            label25.Text = "Найденная неисправность";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(841, 497);
            label26.Name = "label26";
            label26.Size = new Size(99, 25);
            label26.TabIndex = 39;
            label26.Text = "Стоимость";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(507, 73);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(317, 129);
            listBox1.TabIndex = 44;
            listBox1.Visible = false;
            listBox1.Click += ListBox1_Click;
            // 
            // CompletedOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 622);
            Controls.Add(listBox1);
            Controls.Add(textBoxFoundProblem5);
            Controls.Add(label24);
            Controls.Add(textBoxPrice5);
            Controls.Add(label25);
            Controls.Add(label26);
            Controls.Add(textBoxFoundProblem4);
            Controls.Add(label21);
            Controls.Add(textBoxPrice4);
            Controls.Add(label22);
            Controls.Add(label23);
            Controls.Add(textBoxFoundProblem3);
            Controls.Add(label18);
            Controls.Add(textBoxPrice3);
            Controls.Add(label19);
            Controls.Add(label20);
            Controls.Add(textBoxFoundProblem2);
            Controls.Add(label15);
            Controls.Add(textBoxPrice2);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(label14);
            Controls.Add(pictureBox1);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(textBoxFoundProblem1);
            Controls.Add(label11);
            Controls.Add(textBoxPrice1);
            Controls.Add(linkLabelDateNow);
            Controls.Add(dateTimePicker1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(labelPriceDetails);
            Controls.Add(labelCountDetails);
            Controls.Add(labelDurationRepair);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CompletedOrder";
            Text = "Пометка аппарата как отремонтированного";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label labelDurationRepair;
        private Label labelCountDetails;
        private Label labelPriceDetails;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private DateTimePicker dateTimePicker1;
        private LinkLabel linkLabelDateNow;
        private TextBox textBoxPrice1;
        private Label label11;
        private TextBox textBoxFoundProblem1;
        private Label label12;
        private Label label13;
        private Button buttonSave;
        private Button buttonExit;
        private PictureBox pictureBox1;
        private Label label14;
        private TextBox textBoxFoundProblem2;
        private Label label15;
        private TextBox textBoxPrice2;
        private Label label16;
        private Label label17;
        private TextBox textBoxFoundProblem3;
        private Label label18;
        private TextBox textBoxPrice3;
        private Label label19;
        private Label label20;
        private TextBox textBoxFoundProblem4;
        private Label label21;
        private TextBox textBoxPrice4;
        private Label label22;
        private Label label23;
        private TextBox textBoxFoundProblem5;
        private Label label24;
        private TextBox textBoxPrice5;
        private Label label25;
        private Label label26;
        private ListBox listBox1;
    }
}