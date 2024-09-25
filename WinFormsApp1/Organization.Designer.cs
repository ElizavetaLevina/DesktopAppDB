namespace WinFormsApp1
{
    partial class Organization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Organization));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxName = new TextBox();
            textBoxAddress = new TextBox();
            textBoxPhone = new TextBox();
            textBoxMail = new TextBox();
            textBoxFax = new TextBox();
            label6 = new Label();
            buttonSave = new Button();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(50, 44);
            label1.Name = "label1";
            label1.Size = new Size(182, 38);
            label1.TabIndex = 0;
            label1.Text = "Название";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(50, 111);
            label2.Name = "label2";
            label2.Size = new Size(182, 38);
            label2.TabIndex = 1;
            label2.Text = "Адрес";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new Point(50, 176);
            label3.Name = "label3";
            label3.Size = new Size(182, 38);
            label3.TabIndex = 2;
            label3.Text = "Контактный телефон";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Location = new Point(50, 242);
            label4.Name = "label4";
            label4.Size = new Size(182, 38);
            label4.TabIndex = 3;
            label4.Text = "Электронная почта";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new Point(50, 309);
            label5.Name = "label5";
            label5.Size = new Size(182, 38);
            label5.TabIndex = 4;
            label5.Text = "Факс";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(238, 48);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(271, 31);
            textBoxName.TabIndex = 5;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(238, 115);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(550, 31);
            textBoxAddress.TabIndex = 6;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(238, 180);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(271, 31);
            textBoxPhone.TabIndex = 7;
            // 
            // textBoxMail
            // 
            textBoxMail.Location = new Point(238, 246);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(271, 31);
            textBoxMail.TabIndex = 8;
            // 
            // textBoxFax
            // 
            textBoxFax.Location = new Point(238, 313);
            textBoxFax.Name = "textBoxFax";
            textBoxFax.Size = new Size(271, 31);
            textBoxFax.TabIndex = 9;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Location = new Point(-2, 377);
            label6.Name = "label6";
            label6.Size = new Size(809, 2);
            label6.TabIndex = 10;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(468, 392);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(148, 43);
            buttonSave.TabIndex = 11;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(636, 392);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(148, 43);
            buttonExit.TabIndex = 12;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // Organization
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(label6);
            Controls.Add(textBoxFax);
            Controls.Add(textBoxMail);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Organization";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Сведения об организации";
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
        private TextBox textBoxPhone;
        private TextBox textBoxMail;
        private TextBox textBoxFax;
        private Label label6;
        private Button buttonSave;
        private Button buttonExit;
    }
}