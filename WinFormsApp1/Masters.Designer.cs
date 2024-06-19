namespace WinFormsApp1
{
    partial class Masters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Masters));
            dataGridView1 = new DataGridView();
            btnAddMaster = new Button();
            btnChangeMaster = new Button();
            btnDeleteMaster = new Button();
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
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(506, 486);
            dataGridView1.TabIndex = 0;
            // 
            // btnAddMaster
            // 
            btnAddMaster.Location = new Point(529, 12);
            btnAddMaster.Name = "btnAddMaster";
            btnAddMaster.Size = new Size(249, 43);
            btnAddMaster.TabIndex = 1;
            btnAddMaster.Text = "Добавить мастера";
            btnAddMaster.UseVisualStyleBackColor = true;
            btnAddMaster.Click += BtnAddMaster_Click;
            // 
            // btnChangeMaster
            // 
            btnChangeMaster.Location = new Point(529, 75);
            btnChangeMaster.Name = "btnChangeMaster";
            btnChangeMaster.Size = new Size(249, 43);
            btnChangeMaster.TabIndex = 2;
            btnChangeMaster.Text = "Изменить данные";
            btnChangeMaster.UseVisualStyleBackColor = true;
            btnChangeMaster.Click += BtnChangeMaster_Click;
            // 
            // btnDeleteMaster
            // 
            btnDeleteMaster.Location = new Point(529, 139);
            btnDeleteMaster.Name = "btnDeleteMaster";
            btnDeleteMaster.Size = new Size(249, 43);
            btnDeleteMaster.TabIndex = 3;
            btnDeleteMaster.Text = "Удалить мастера";
            btnDeleteMaster.UseVisualStyleBackColor = true;
            btnDeleteMaster.Click += BtnDeleteMaster_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(529, 455);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(249, 43);
            btnExit.TabIndex = 4;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // AddMaster
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 510);
            Controls.Add(btnExit);
            Controls.Add(btnDeleteMaster);
            Controls.Add(btnChangeMaster);
            Controls.Add(btnAddMaster);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AddMaster";
            Text = "Мастера";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAddMaster;
        private Button btnChangeMaster;
        private Button btnDeleteMaster;
        private Button btnExit;
    }
}