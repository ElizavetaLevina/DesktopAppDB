namespace WinFormsApp1
{
    partial class AddDetails
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDetails));
            dataGridView1 = new DataGridView();
            buttonAddDetail = new Button();
            buttonChangeDetail = new Button();
            buttonRemoveDetail = new Button();
            buttonExit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelCount = new Label();
            label4 = new Label();
            labelPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(224, 224, 224);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(742, 486);
            dataGridView1.TabIndex = 0;
            // 
            // buttonAddDetail
            // 
            buttonAddDetail.Location = new Point(771, 15);
            buttonAddDetail.Name = "buttonAddDetail";
            buttonAddDetail.Size = new Size(249, 43);
            buttonAddDetail.TabIndex = 1;
            buttonAddDetail.Text = "Добавить деталь";
            buttonAddDetail.UseVisualStyleBackColor = true;
            buttonAddDetail.Click += ButtonAddDetail_Click;
            // 
            // buttonChangeDetail
            // 
            buttonChangeDetail.Location = new Point(771, 75);
            buttonChangeDetail.Name = "buttonChangeDetail";
            buttonChangeDetail.Size = new Size(249, 43);
            buttonChangeDetail.TabIndex = 2;
            buttonChangeDetail.Text = "Изменить данные";
            buttonChangeDetail.UseVisualStyleBackColor = true;
            buttonChangeDetail.Click += ButtonChangeDetail_Click;
            // 
            // buttonRemoveDetail
            // 
            buttonRemoveDetail.Location = new Point(771, 139);
            buttonRemoveDetail.Name = "buttonRemoveDetail";
            buttonRemoveDetail.Size = new Size(249, 43);
            buttonRemoveDetail.TabIndex = 3;
            buttonRemoveDetail.Text = "Удалить деталь";
            buttonRemoveDetail.UseVisualStyleBackColor = true;
            buttonRemoveDetail.Click += ButtonRemoveDetail_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(771, 455);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(249, 43);
            buttonExit.TabIndex = 4;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(952, 209);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 5;
            label1.Text = "Итого:";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(771, 236);
            label2.Name = "label2";
            label2.Size = new Size(249, 2);
            label2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(57, 117, 68);
            label3.Location = new Point(845, 247);
            label3.Name = "label3";
            label3.Size = new Size(175, 25);
            label3.TabIndex = 7;
            label3.Text = "Количество деталей";
            // 
            // labelCount
            // 
            labelCount.ImageAlign = ContentAlignment.MiddleRight;
            labelCount.Location = new Point(815, 270);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(205, 31);
            labelCount.TabIndex = 8;
            labelCount.Text = "0 шт.";
            labelCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(57, 117, 68);
            label4.Location = new Point(802, 310);
            label4.Name = "label4";
            label4.Size = new Size(218, 25);
            label4.TabIndex = 9;
            label4.Text = "Суммарная цена деталей";
            // 
            // labelPrice
            // 
            labelPrice.Location = new Point(815, 335);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(205, 31);
            labelPrice.TabIndex = 10;
            labelPrice.Text = "0 руб.";
            labelPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AddDetails
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 510);
            Controls.Add(labelPrice);
            Controls.Add(label4);
            Controls.Add(labelCount);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonExit);
            Controls.Add(buttonRemoveDetail);
            Controls.Add(buttonChangeDetail);
            Controls.Add(buttonAddDetail);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AddDetails";
            Text = "Детали на ремонт аппарата";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonAddDetail;
        private Button buttonChangeDetail;
        private Button buttonRemoveDetail;
        private Button buttonExit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelCount;
        private Label label4;
        private Label labelPrice;
    }
}