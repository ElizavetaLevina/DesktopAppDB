namespace WinFormsApp1
{
    partial class DetailEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailEdit));
            labelName = new Label();
            labelPricePurchase = new Label();
            label3 = new Label();
            textBoxNameDetail = new TextBox();
            textBoxPricePurchase = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            linkLabel1 = new LinkLabel();
            label4 = new Label();
            buttonSave = new Button();
            buttonExit = new Button();
            label5 = new Label();
            label6 = new Label();
            textBoxPriceSale = new TextBox();
            labelPriceSale = new Label();
            listBoxDetails = new ListBox();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(58, 46);
            labelName.Name = "labelName";
            labelName.Size = new Size(149, 25);
            labelName.TabIndex = 0;
            labelName.Text = "Название детали";
            // 
            // labelPricePurchase
            // 
            labelPricePurchase.AutoSize = true;
            labelPricePurchase.Location = new Point(81, 124);
            labelPricePurchase.Name = "labelPricePurchase";
            labelPricePurchase.Size = new Size(126, 25);
            labelPricePurchase.TabIndex = 1;
            labelPricePurchase.Text = "Цена покупки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 272);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 2;
            label3.Text = "Дата покупки";
            // 
            // textBoxNameDetail
            // 
            textBoxNameDetail.Location = new Point(213, 43);
            textBoxNameDetail.Name = "textBoxNameDetail";
            textBoxNameDetail.Size = new Size(466, 31);
            textBoxNameDetail.TabIndex = 3;
            textBoxNameDetail.TextChanged += TextBoxNameDetail_TextChanged;
            textBoxNameDetail.KeyPress += TextBoxNameDetail_KeyPress;
            // 
            // textBoxPricePurchase
            // 
            textBoxPricePurchase.Location = new Point(213, 121);
            textBoxPricePurchase.MaxLength = 6;
            textBoxPricePurchase.Name = "textBoxPricePurchase";
            textBoxPricePurchase.Size = new Size(172, 31);
            textBoxPricePurchase.TabIndex = 4;
            textBoxPricePurchase.KeyPress += TextBoxPricePurchase_KeyPress;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(213, 267);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(172, 31);
            dateTimePicker1.TabIndex = 6;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabel1.Location = new Point(391, 272);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(161, 25);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Сегодняшняя дата";
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(-6, 341);
            label4.Name = "label4";
            label4.Size = new Size(700, 2);
            label4.TabIndex = 7;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(332, 350);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(170, 43);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(508, 350);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(170, 43);
            buttonExit.TabIndex = 9;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(387, 124);
            label5.Name = "label5";
            label5.Size = new Size(46, 25);
            label5.TabIndex = 10;
            label5.Text = "руб.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(387, 201);
            label6.Name = "label6";
            label6.Size = new Size(46, 25);
            label6.TabIndex = 14;
            label6.Text = "руб.";
            // 
            // textBoxPriceSale
            // 
            textBoxPriceSale.Location = new Point(213, 198);
            textBoxPriceSale.MaxLength = 6;
            textBoxPriceSale.Name = "textBoxPriceSale";
            textBoxPriceSale.Size = new Size(172, 31);
            textBoxPriceSale.TabIndex = 5;
            textBoxPriceSale.KeyPress += TextBoxPriceSale_KeyPress;
            // 
            // labelPriceSale
            // 
            labelPriceSale.AutoSize = true;
            labelPriceSale.Location = new Point(75, 201);
            labelPriceSale.Name = "labelPriceSale";
            labelPriceSale.Size = new Size(132, 25);
            labelPriceSale.TabIndex = 12;
            labelPriceSale.Text = "Цена продажи";
            // 
            // listBoxDetails
            // 
            listBoxDetails.FormattingEnabled = true;
            listBoxDetails.ItemHeight = 25;
            listBoxDetails.Location = new Point(213, 73);
            listBoxDetails.Name = "listBoxDetails";
            listBoxDetails.Size = new Size(466, 129);
            listBoxDetails.TabIndex = 15;
            listBoxDetails.SelectedIndexChanged += ListBoxDetails_SelectedIndexChanged;
            // 
            // DetailEdit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 406);
            Controls.Add(listBoxDetails);
            Controls.Add(label6);
            Controls.Add(textBoxPriceSale);
            Controls.Add(labelPriceSale);
            Controls.Add(label5);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(label4);
            Controls.Add(linkLabel1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBoxPricePurchase);
            Controls.Add(textBoxNameDetail);
            Controls.Add(label3);
            Controls.Add(labelPricePurchase);
            Controls.Add(labelName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DetailEdit";
            Text = "Добавление детали на склад";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelPricePurchase;
        private Label label3;
        private TextBox textBoxNameDetail;
        private TextBox textBoxPricePurchase;
        private DateTimePicker dateTimePicker1;
        private LinkLabel linkLabel1;
        private Label label4;
        private Button buttonSave;
        private Button buttonExit;
        private Label label5;
        private Label label6;
        private TextBox textBoxPriceSale;
        private Label labelPriceSale;
        private ListBox listBoxDetails;
    }
}