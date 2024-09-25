namespace WinFormsApp1
{
    partial class DetailsInWarehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsInWarehouse));
            dataGridView1 = new DataGridView();
            buttonAddDetails = new Button();
            buttonDeleteDetail = new Button();
            label1 = new Label();
            buttonExit = new Button();
            buttonAdd = new Button();
            textBoxDevice = new TextBox();
            buttonChangeDetail = new Button();
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
            dataGridView1.Location = new Point(12, 29);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(776, 338);
            dataGridView1.TabIndex = 0;
            // 
            // buttonAddDetails
            // 
            buttonAddDetails.Location = new Point(12, 381);
            buttonAddDetails.Name = "buttonAddDetails";
            buttonAddDetails.Size = new Size(243, 43);
            buttonAddDetails.TabIndex = 1;
            buttonAddDetails.Text = "Добавить деталь на склад";
            buttonAddDetails.UseVisualStyleBackColor = true;
            buttonAddDetails.Click += ButtonAddDetails_Click;
            // 
            // buttonDeleteDetail
            // 
            buttonDeleteDetail.Location = new Point(280, 381);
            buttonDeleteDetail.Name = "buttonDeleteDetail";
            buttonDeleteDetail.Size = new Size(243, 43);
            buttonDeleteDetail.TabIndex = 2;
            buttonDeleteDetail.Text = "Удалить делать со склада";
            buttonDeleteDetail.UseVisualStyleBackColor = true;
            buttonDeleteDetail.Click += ButtonDeleteDetail_Click;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(-1, 436);
            label1.Name = "label1";
            label1.Size = new Size(801, 2);
            label1.TabIndex = 3;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(545, 451);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(243, 43);
            buttonExit.TabIndex = 6;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(280, 451);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(243, 43);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "Добавить деталь в заказ";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // textBoxDevice
            // 
            textBoxDevice.Location = new Point(12, 457);
            textBoxDevice.Name = "textBoxDevice";
            textBoxDevice.Size = new Size(243, 31);
            textBoxDevice.TabIndex = 4;
            textBoxDevice.Visible = false;
            textBoxDevice.TextChanged += TextBoxDevice_TextChanged;
            // 
            // buttonChangeDetail
            // 
            buttonChangeDetail.Location = new Point(545, 381);
            buttonChangeDetail.Name = "buttonChangeDetail";
            buttonChangeDetail.Size = new Size(243, 43);
            buttonChangeDetail.TabIndex = 3;
            buttonChangeDetail.Text = "Изменить данные";
            buttonChangeDetail.UseVisualStyleBackColor = true;
            buttonChangeDetail.Click += ButtonChangeDetail_Click;
            // 
            // DetailsInWarehouse
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 503);
            Controls.Add(buttonChangeDetail);
            Controls.Add(textBoxDevice);
            Controls.Add(buttonAdd);
            Controls.Add(buttonExit);
            Controls.Add(label1);
            Controls.Add(buttonDeleteDetail);
            Controls.Add(buttonAddDetails);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DetailsInWarehouse";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Склад";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonAddDetails;
        private Button buttonDeleteDetail;
        private Label label1;
        private Button buttonExit;
        private Button buttonAdd;
        private TextBox textBoxDevice;
        private Button buttonChangeDetail;
    }
}