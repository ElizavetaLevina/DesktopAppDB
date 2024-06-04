namespace WinFormsApp1
{
    partial class FeaturesClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeaturesClient));
            label1 = new Label();
            textBoxName = new TextBox();
            textBoxAddress = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBoxHomePhone = new TextBox();
            textBoxWorkPhone = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            buttonSave = new Button();
            buttonExit = new Button();
            label7 = new Label();
            radioButtonNormal = new RadioButton();
            radioButtonWhite = new RadioButton();
            radioButtonBlack = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 44);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 0;
            label1.Text = "ФИО клиента";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(201, 41);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(394, 31);
            textBoxName.TabIndex = 1;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(201, 93);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(522, 31);
            textBoxAddress.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 96);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 3;
            label2.Text = "Адрес";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 133);
            label3.Name = "label3";
            label3.Size = new Size(124, 25);
            label3.TabIndex = 4;
            label3.Text = "Дом. телефон";
            // 
            // textBoxHomePhone
            // 
            textBoxHomePhone.Location = new Point(201, 130);
            textBoxHomePhone.Name = "textBoxHomePhone";
            textBoxHomePhone.Size = new Size(150, 31);
            textBoxHomePhone.TabIndex = 5;
            // 
            // textBoxWorkPhone
            // 
            textBoxWorkPhone.Location = new Point(510, 130);
            textBoxWorkPhone.Name = "textBoxWorkPhone";
            textBoxWorkPhone.Size = new Size(213, 31);
            textBoxWorkPhone.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 133);
            label4.Name = "label4";
            label4.Size = new Size(117, 25);
            label4.TabIndex = 7;
            label4.Text = "Раб. телефон";
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(-2, 294);
            label5.Name = "label5";
            label5.Size = new Size(784, 2);
            label5.TabIndex = 8;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Location = new Point(-2, 295);
            label6.Name = "label6";
            label6.Size = new Size(784, 2);
            label6.TabIndex = 9;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(286, 304);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(241, 43);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(533, 304);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(241, 43);
            buttonExit.TabIndex = 11;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(53, 192);
            label7.Name = "label7";
            label7.Size = new Size(109, 25);
            label7.TabIndex = 12;
            label7.Text = "Тип клиента";
            // 
            // radioButtonNormal
            // 
            radioButtonNormal.AutoSize = true;
            radioButtonNormal.Location = new Point(201, 190);
            radioButtonNormal.Name = "radioButtonNormal";
            radioButtonNormal.Size = new Size(167, 29);
            radioButtonNormal.TabIndex = 13;
            radioButtonNormal.TabStop = true;
            radioButtonNormal.Text = "Простой клиент";
            radioButtonNormal.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhite
            // 
            radioButtonWhite.AutoSize = true;
            radioButtonWhite.Location = new Point(201, 225);
            radioButtonWhite.Name = "radioButtonWhite";
            radioButtonWhite.Size = new Size(163, 29);
            radioButtonWhite.TabIndex = 14;
            radioButtonWhite.TabStop = true;
            radioButtonWhite.Text = "В белом списке";
            radioButtonWhite.UseVisualStyleBackColor = true;
            // 
            // radioButtonBlack
            // 
            radioButtonBlack.AutoSize = true;
            radioButtonBlack.Location = new Point(201, 260);
            radioButtonBlack.Name = "radioButtonBlack";
            radioButtonBlack.Size = new Size(175, 29);
            radioButtonBlack.TabIndex = 15;
            radioButtonBlack.TabStop = true;
            radioButtonBlack.Text = "В черном списке";
            radioButtonBlack.UseVisualStyleBackColor = true;
            // 
            // FeaturesClient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 354);
            Controls.Add(radioButtonBlack);
            Controls.Add(radioButtonWhite);
            Controls.Add(radioButtonNormal);
            Controls.Add(label7);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxWorkPhone);
            Controls.Add(textBoxHomePhone);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FeaturesClient";
            Text = "Изменение данных клиента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxName;
        private TextBox textBoxAddress;
        private Label label2;
        private Label label3;
        private TextBox textBoxHomePhone;
        private TextBox textBoxWorkPhone;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button buttonSave;
        private Button buttonExit;
        private Label label7;
        private RadioButton radioButtonNormal;
        private RadioButton radioButtonWhite;
        private RadioButton radioButtonBlack;
    }
}