namespace WinFormsApp1
{
    partial class TypesTechnic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypesTechnic));
            dataGridView1 = new DataGridView();
            btnAddDevice = new Button();
            btnChangeDevice = new Button();
            btnDeleteDevice = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
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
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(404, 486);
            dataGridView1.TabIndex = 0;
            // 
            // btnAddDevice
            // 
            btnAddDevice.Location = new Point(430, 12);
            btnAddDevice.Name = "btnAddDevice";
            btnAddDevice.Size = new Size(249, 43);
            btnAddDevice.TabIndex = 1;
            btnAddDevice.Text = "Добавить тип устройства";
            btnAddDevice.UseVisualStyleBackColor = true;
            btnAddDevice.Click += BtnAddDevice_Click;
            // 
            // btnChangeDevice
            // 
            btnChangeDevice.Location = new Point(430, 75);
            btnChangeDevice.Name = "btnChangeDevice";
            btnChangeDevice.Size = new Size(249, 43);
            btnChangeDevice.TabIndex = 2;
            btnChangeDevice.Text = "Изменить тип устройства";
            btnChangeDevice.UseVisualStyleBackColor = true;
            btnChangeDevice.Click += BtnChangeDevice_Click;
            // 
            // btnDeleteDevice
            // 
            btnDeleteDevice.Location = new Point(430, 139);
            btnDeleteDevice.Name = "btnDeleteDevice";
            btnDeleteDevice.Size = new Size(249, 43);
            btnDeleteDevice.TabIndex = 3;
            btnDeleteDevice.Text = "Удалить тип устройства";
            btnDeleteDevice.UseVisualStyleBackColor = true;
            btnDeleteDevice.Click += BtnDeleteDevice_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(430, 455);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(249, 43);
            btnExit.TabIndex = 4;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // AddDevice
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 510);
            Controls.Add(btnExit);
            Controls.Add(btnDeleteDevice);
            Controls.Add(btnChangeDevice);
            Controls.Add(btnAddDevice);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AddDevice";
            Text = "Типы устройств";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAddDevice;
        private Button btnChangeDevice;
        private Button btnDeleteDevice;
        private Button btnExit;
    }
}