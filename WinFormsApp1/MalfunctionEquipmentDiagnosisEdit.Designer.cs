namespace WinFormsApp1
{
    partial class MalfunctionEquipmentDiagnosisEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MalfunctionEquipmentDiagnosisEdit));
            label1 = new Label();
            labelPrice = new Label();
            textBoxName = new TextBox();
            textBoxPrice = new TextBox();
            labelRub = new Label();
            label4 = new Label();
            buttonSave = new Button();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 68);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 0;
            label1.Text = " Название";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(125, 126);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(53, 25);
            labelPrice.TabIndex = 1;
            labelPrice.Text = "Цена";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(184, 65);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(306, 31);
            textBoxName.TabIndex = 2;
            textBoxName.KeyDown += TextBoxName_KeyDown;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(184, 123);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(149, 31);
            textBoxPrice.TabIndex = 3;
            textBoxPrice.KeyDown += TextBoxPrice_KeyDown;
            textBoxPrice.KeyPress += TextBoxPrice_KeyPress;
            // 
            // labelRub
            // 
            labelRub.AutoSize = true;
            labelRub.Location = new Point(339, 126);
            labelRub.Name = "labelRub";
            labelRub.Size = new Size(46, 25);
            labelRub.TabIndex = 4;
            labelRub.Text = "руб.";
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(-2, 197);
            label4.Name = "label4";
            label4.Size = new Size(651, 2);
            label4.TabIndex = 5;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(238, 213);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(191, 43);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(440, 213);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(191, 43);
            buttonExit.TabIndex = 7;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // MalfunctionEquipmentDiagnosisEdit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 268);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(label4);
            Controls.Add(labelRub);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxName);
            Controls.Add(labelPrice);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MalfunctionEquipmentDiagnosisEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить неисправность";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelPrice;
        private TextBox textBoxName;
        private TextBox textBoxPrice;
        private Label labelRub;
        private Label label4;
        private Button buttonSave;
        private Button buttonExit;
    }
}