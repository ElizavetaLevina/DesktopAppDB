namespace WinFormsApp1
{
    partial class AddBrand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBrand));
            dataGridView1 = new DataGridView();
            btnAddBrand = new Button();
            btnChangeBrand = new Button();
            btnExit = new Button();
            btnDeleteBrand = new Button();
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
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(404, 486);
            dataGridView1.TabIndex = 0;
            // 
            // btnAddBrand
            // 
            btnAddBrand.Location = new Point(430, 15);
            btnAddBrand.Name = "btnAddBrand";
            btnAddBrand.Size = new Size(249, 43);
            btnAddBrand.TabIndex = 1;
            btnAddBrand.Text = "Добавить фирму";
            btnAddBrand.UseVisualStyleBackColor = true;
            btnAddBrand.Click += BtnAddBrand_Click;
            // 
            // btnChangeBrand
            // 
            btnChangeBrand.Location = new Point(430, 75);
            btnChangeBrand.Name = "btnChangeBrand";
            btnChangeBrand.Size = new Size(249, 43);
            btnChangeBrand.TabIndex = 2;
            btnChangeBrand.Text = "Изменить название фирмы";
            btnChangeBrand.UseVisualStyleBackColor = true;
            btnChangeBrand.Click += BtnChangeBrand_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(430, 455);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(249, 43);
            btnExit.TabIndex = 3;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // btnDeleteBrand
            // 
            btnDeleteBrand.BackColor = SystemColors.Control;
            btnDeleteBrand.Location = new Point(430, 139);
            btnDeleteBrand.Name = "btnDeleteBrand";
            btnDeleteBrand.Size = new Size(249, 43);
            btnDeleteBrand.TabIndex = 4;
            btnDeleteBrand.Text = "Удалить фирму";
            btnDeleteBrand.UseVisualStyleBackColor = false;
            btnDeleteBrand.Click += BtnDeleteBrand_Click;
            // 
            // AddBrand
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 510);
            Controls.Add(btnDeleteBrand);
            Controls.Add(btnExit);
            Controls.Add(btnChangeBrand);
            Controls.Add(btnAddBrand);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AddBrand";
            Text = "Фирмы-производители устройств";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAddBrand;
        private Button btnChangeBrand;
        private Button btnExit;
        private Button btnDeleteBrand;
    }
}