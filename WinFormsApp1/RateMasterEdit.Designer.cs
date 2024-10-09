namespace WinFormsApp1
{
    partial class RateMasterEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateMasterEdit));
            dataGridView1 = new DataGridView();
            label1 = new Label();
            comboBoxMonth = new ComboBox();
            label2 = new Label();
            comboBoxYear = new ComboBox();
            labelPercent = new Label();
            textBoxPercent = new TextBox();
            buttonSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dataGridView1.Location = new Point(12, 74);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(776, 350);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 1;
            label1.Text = "Месяц";
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMonth.FormattingEnabled = true;
            comboBoxMonth.Location = new Point(83, 21);
            comboBoxMonth.Name = "comboBoxMonth";
            comboBoxMonth.Size = new Size(182, 33);
            comboBoxMonth.TabIndex = 2;
            comboBoxMonth.SelectedIndexChanged += ComboBoxMonth_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(304, 24);
            label2.Name = "label2";
            label2.Size = new Size(41, 25);
            label2.TabIndex = 3;
            label2.Text = "Год";
            // 
            // comboBoxYear
            // 
            comboBoxYear.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(351, 21);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(107, 33);
            comboBoxYear.TabIndex = 4;
            comboBoxYear.SelectedIndexChanged += ComboBoxYear_SelectedIndexChanged;
            // 
            // labelPercent
            // 
            labelPercent.AutoSize = true;
            labelPercent.Location = new Point(492, 24);
            labelPercent.Name = "labelPercent";
            labelPercent.Size = new Size(84, 25);
            labelPercent.TabIndex = 5;
            labelPercent.Text = "Процент";
            // 
            // textBoxPercent
            // 
            textBoxPercent.Location = new Point(582, 21);
            textBoxPercent.MaxLength = 3;
            textBoxPercent.Name = "textBoxPercent";
            textBoxPercent.Size = new Size(62, 31);
            textBoxPercent.TabIndex = 6;
            textBoxPercent.KeyPress += TextBoxPercent_KeyPress;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(676, 16);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 41);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_ClickAsync;
            // 
            // RateMasterEdit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 433);
            Controls.Add(buttonSave);
            Controls.Add(textBoxPercent);
            Controls.Add(labelPercent);
            Controls.Add(comboBoxYear);
            Controls.Add(label2);
            Controls.Add(comboBoxMonth);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RateMasterEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Процент прибыли мастера";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private ComboBox comboBoxMonth;
        private Label label2;
        private ComboBox comboBoxYear;
        private Label labelPercent;
        private TextBox textBoxPercent;
        private Button buttonSave;
    }
}