namespace WinFormsApp1
{
    partial class EnterBrandForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterBrandForm));
            btnAdd = new Button();
            btnExit = new Button();
            label1 = new Label();
            nameTextBox = new TextBox();
            label4 = new Label();
            labelSecondName = new Label();
            linkLabelAdd = new LinkLabel();
            comboBoxSecondName = new ComboBox();
            linkLabelDelete = new LinkLabel();
            listBox1 = new ListBox();
            labelNameInList = new Label();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(63, 394);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(161, 43);
            btnAdd.TabIndex = 2;
            btnAdd.Tag = "Yes";
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(295, 394);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(161, 43);
            btnExit.TabIndex = 3;
            btnExit.Tag = "No";
            btnExit.Text = "Отмена";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // label1
            // 
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(210, 31);
            label1.TabIndex = 4;
            label1.Text = "Название";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nameTextBox
            // 
            nameTextBox.ForeColor = Color.Black;
            nameTextBox.HideSelection = false;
            nameTextBox.Location = new Point(228, 28);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(228, 31);
            nameTextBox.TabIndex = 0;
            nameTextBox.TextChanged += NameTextBox_TextChanged;
            nameTextBox.KeyPress += NameTextBox_KeyPress;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(-1, 381);
            label4.Name = "label4";
            label4.Size = new Size(507, 2);
            label4.TabIndex = 7;
            // 
            // labelSecondName
            // 
            labelSecondName.Location = new Point(12, 80);
            labelSecondName.Name = "labelSecondName";
            labelSecondName.Size = new Size(210, 31);
            labelSecondName.TabIndex = 8;
            labelSecondName.Text = "Фирма-производитель";
            labelSecondName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // linkLabelAdd
            // 
            linkLabelAdd.AutoSize = true;
            linkLabelAdd.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabelAdd.Location = new Point(228, 122);
            linkLabelAdd.Name = "linkLabelAdd";
            linkLabelAdd.Size = new Size(90, 25);
            linkLabelAdd.TabIndex = 10;
            linkLabelAdd.TabStop = true;
            linkLabelAdd.Text = "Добавить";
            linkLabelAdd.LinkClicked += LinkLabelAdd_LinkClicked;
            // 
            // comboBoxSecondName
            // 
            comboBoxSecondName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSecondName.FormattingEnabled = true;
            comboBoxSecondName.Location = new Point(228, 80);
            comboBoxSecondName.Name = "comboBoxSecondName";
            comboBoxSecondName.Size = new Size(228, 33);
            comboBoxSecondName.TabIndex = 11;
            // 
            // linkLabelDelete
            // 
            linkLabelDelete.AutoSize = true;
            linkLabelDelete.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabelDelete.Location = new Point(380, 122);
            linkLabelDelete.Name = "linkLabelDelete";
            linkLabelDelete.Size = new Size(76, 25);
            linkLabelDelete.TabIndex = 12;
            linkLabelDelete.TabStop = true;
            linkLabelDelete.Text = "Удалить";
            linkLabelDelete.LinkClicked += LinkLabelDelete_LinkClicked;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(228, 164);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(228, 204);
            listBox1.TabIndex = 13;
            // 
            // labelNameInList
            // 
            labelNameInList.Location = new Point(12, 164);
            labelNameInList.Name = "labelNameInList";
            labelNameInList.Size = new Size(210, 204);
            labelNameInList.TabIndex = 14;
            labelNameInList.Text = "Фирмы-производители для Сотовый телефон";
            labelNameInList.TextAlign = ContentAlignment.TopRight;
            // 
            // EnterBrandForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 449);
            Controls.Add(labelNameInList);
            Controls.Add(listBox1);
            Controls.Add(linkLabelDelete);
            Controls.Add(comboBoxSecondName);
            Controls.Add(linkLabelAdd);
            Controls.Add(labelSecondName);
            Controls.Add(label4);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnAdd);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EnterBrandForm";
            Text = "Добавление новой фирмы";
            Activated += EnterBrandForm_Activated;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnExit;
        private Label label1;
        private TextBox nameTextBox;
        private Label label4;
        private Label labelSecondName;
        private LinkLabel linkLabelAdd;
        private ComboBox comboBoxSecondName;
        private LinkLabel linkLabelDelete;
        private ListBox listBox1;
        private Label labelNameInList;
    }
}