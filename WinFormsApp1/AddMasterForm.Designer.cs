namespace WinFormsApp1
{
    partial class AddMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMasterForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxName = new TextBox();
            textBoxAddress = new TextBox();
            textBoxNumberPhone = new TextBox();
            radioButtonRate = new RadioButton();
            radioButtonProfitMaster = new RadioButton();
            radioButtonProfitOrganization = new RadioButton();
            textBoxRate = new TextBox();
            labelRate = new Label();
            trackBarPercent = new TrackBar();
            labelPercent = new Label();
            buttonAdd = new Button();
            buttonExit = new Button();
            labelSymbolPercent = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarPercent).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 38);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 0;
            label1.Text = "ФИО мастера";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 81);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 1;
            label2.Text = "Адрес";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 121);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 2;
            label3.Text = "Телефон";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 204);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 3;
            label4.Text = "Зарплата";
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(0, 176);
            label5.Name = "label5";
            label5.Size = new Size(646, 2);
            label5.TabIndex = 4;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(168, 35);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(304, 31);
            textBoxName.TabIndex = 6;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(168, 78);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(465, 31);
            textBoxAddress.TabIndex = 7;
            // 
            // textBoxNumberPhone
            // 
            textBoxNumberPhone.Location = new Point(168, 118);
            textBoxNumberPhone.Name = "textBoxNumberPhone";
            textBoxNumberPhone.Size = new Size(192, 31);
            textBoxNumberPhone.TabIndex = 8;
            // 
            // radioButtonRate
            // 
            radioButtonRate.AutoSize = true;
            radioButtonRate.Checked = true;
            radioButtonRate.Location = new Point(168, 202);
            radioButtonRate.Name = "radioButtonRate";
            radioButtonRate.Size = new Size(92, 29);
            radioButtonRate.TabIndex = 9;
            radioButtonRate.TabStop = true;
            radioButtonRate.Text = "Ставка";
            radioButtonRate.UseVisualStyleBackColor = true;
            radioButtonRate.Click += RadioButtonRate_Click;
            // 
            // radioButtonProfitMaster
            // 
            radioButtonProfitMaster.AutoSize = true;
            radioButtonProfitMaster.Location = new Point(168, 237);
            radioButtonProfitMaster.Name = "radioButtonProfitMaster";
            radioButtonProfitMaster.Size = new Size(271, 29);
            radioButtonProfitMaster.TabIndex = 10;
            radioButtonProfitMaster.TabStop = true;
            radioButtonProfitMaster.Text = "Процент с прибыли мастера";
            radioButtonProfitMaster.UseVisualStyleBackColor = true;
            radioButtonProfitMaster.Click += RadioButtonProfitMaster_Click;
            // 
            // radioButtonProfitOrganization
            // 
            radioButtonProfitOrganization.AutoSize = true;
            radioButtonProfitOrganization.Location = new Point(168, 272);
            radioButtonProfitOrganization.Name = "radioButtonProfitOrganization";
            radioButtonProfitOrganization.Size = new Size(311, 29);
            radioButtonProfitOrganization.TabIndex = 11;
            radioButtonProfitOrganization.TabStop = true;
            radioButtonProfitOrganization.Text = "Процент с прибыли организации";
            radioButtonProfitOrganization.UseVisualStyleBackColor = true;
            radioButtonProfitOrganization.Click += RadioButtonProfitOrganization_Click;
            // 
            // textBoxRate
            // 
            textBoxRate.Location = new Point(360, 201);
            textBoxRate.Name = "textBoxRate";
            textBoxRate.Size = new Size(150, 31);
            textBoxRate.TabIndex = 12;
            textBoxRate.KeyPress += TextBoxRate_KeyPress;
            // 
            // labelRate
            // 
            labelRate.AutoSize = true;
            labelRate.Location = new Point(516, 204);
            labelRate.Name = "labelRate";
            labelRate.Size = new Size(46, 25);
            labelRate.TabIndex = 13;
            labelRate.Text = "руб.";
            // 
            // trackBarPercent
            // 
            trackBarPercent.Enabled = false;
            trackBarPercent.Location = new Point(100, 308);
            trackBarPercent.Maximum = 100;
            trackBarPercent.Name = "trackBarPercent";
            trackBarPercent.Size = new Size(429, 69);
            trackBarPercent.TabIndex = 14;
            trackBarPercent.Scroll += TrackBarPercent_Scroll;
            // 
            // labelPercent
            // 
            labelPercent.Enabled = false;
            labelPercent.Location = new Point(269, 352);
            labelPercent.Name = "labelPercent";
            labelPercent.Size = new Size(44, 25);
            labelPercent.TabIndex = 15;
            labelPercent.Text = "0";
            labelPercent.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(212, 397);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(210, 43);
            buttonAdd.TabIndex = 17;
            buttonAdd.Text = "Добавить мастера";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(428, 397);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(210, 43);
            buttonExit.TabIndex = 18;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // labelSymbolPercent
            // 
            labelSymbolPercent.AutoSize = true;
            labelSymbolPercent.Enabled = false;
            labelSymbolPercent.Location = new Point(306, 352);
            labelSymbolPercent.Name = "labelSymbolPercent";
            labelSymbolPercent.Size = new Size(27, 25);
            labelSymbolPercent.TabIndex = 19;
            labelSymbolPercent.Text = "%";
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Location = new Point(0, 388);
            label6.Name = "label6";
            label6.Size = new Size(646, 2);
            label6.TabIndex = 5;
            // 
            // AddMasterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 448);
            Controls.Add(labelSymbolPercent);
            Controls.Add(buttonExit);
            Controls.Add(buttonAdd);
            Controls.Add(labelPercent);
            Controls.Add(trackBarPercent);
            Controls.Add(labelRate);
            Controls.Add(textBoxRate);
            Controls.Add(radioButtonProfitOrganization);
            Controls.Add(radioButtonProfitMaster);
            Controls.Add(radioButtonRate);
            Controls.Add(textBoxNumberPhone);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddMasterForm";
            Text = "Добавление нового мастера";
            Activated += AddMasterForm_Activated;
            ((System.ComponentModel.ISupportInitialize)trackBarPercent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxName;
        private TextBox textBoxAddress;
        private TextBox textBoxNumberPhone;
        private RadioButton radioButtonRate;
        private RadioButton radioButtonProfitMaster;
        private RadioButton radioButtonProfitOrganization;
        private TextBox textBoxRate;
        private Label labelRate;
        private TrackBar trackBarPercent;
        private Label labelPercent;
        private Button buttonAdd;
        private Button buttonExit;
        private Label labelSymbolPercent;
        private Label label6;
    }
}