namespace WinFormsApp1
{
    partial class ReportsOrganization
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsOrganization));
            label1 = new Label();
            label4 = new Label();
            comboBoxYear = new ComboBox();
            panel1 = new Panel();
            comboBoxMaster = new ComboBox();
            radioButtonMaster = new RadioButton();
            radioButtonOrganization = new RadioButton();
            panel2 = new Panel();
            radioButtonProfit = new RadioButton();
            radioButtonExpensesForDetails = new RadioButton();
            radioButtonCountOrders = new RadioButton();
            label2 = new Label();
            buttonExit = new Button();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(26, 28);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 0;
            label1.Text = "Параметры:";
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(-2, 63);
            label4.Name = "label4";
            label4.Size = new Size(259, 2);
            label4.TabIndex = 3;
            // 
            // comboBoxYear
            // 
            comboBoxYear.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(26, 91);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(187, 33);
            comboBoxYear.TabIndex = 0;
            comboBoxYear.SelectedIndexChanged += ComboBoxYear_SelectedIndexChangedAsync;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBoxMaster);
            panel1.Controls.Add(radioButtonMaster);
            panel1.Controls.Add(radioButtonOrganization);
            panel1.Location = new Point(-2, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(252, 138);
            panel1.TabIndex = 6;
            // 
            // comboBoxMaster
            // 
            comboBoxMaster.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaster.Enabled = false;
            comboBoxMaster.FormattingEnabled = true;
            comboBoxMaster.Location = new Point(29, 88);
            comboBoxMaster.Name = "comboBoxMaster";
            comboBoxMaster.Size = new Size(186, 33);
            comboBoxMaster.TabIndex = 3;
            comboBoxMaster.SelectedIndexChanged += ComboBoxMaster_SelectedIndexChangedAsync;
            // 
            // radioButtonMaster
            // 
            radioButtonMaster.AutoSize = true;
            radioButtonMaster.Location = new Point(29, 53);
            radioButtonMaster.Name = "radioButtonMaster";
            radioButtonMaster.Size = new Size(213, 29);
            radioButtonMaster.TabIndex = 2;
            radioButtonMaster.Text = "Отдельно по мастеру";
            radioButtonMaster.UseVisualStyleBackColor = true;
            radioButtonMaster.CheckedChanged += RadioButtonMaster_CheckedChangedAsync;
            // 
            // radioButtonOrganization
            // 
            radioButtonOrganization.AutoSize = true;
            radioButtonOrganization.Checked = true;
            radioButtonOrganization.Location = new Point(29, 14);
            radioButtonOrganization.Name = "radioButtonOrganization";
            radioButtonOrganization.Size = new Size(218, 29);
            radioButtonOrganization.TabIndex = 1;
            radioButtonOrganization.TabStop = true;
            radioButtonOrganization.Text = "Организация в целом";
            radioButtonOrganization.UseVisualStyleBackColor = true;
            radioButtonOrganization.CheckedChanged += RadioButtonOrganization_CheckedChangedAsync;
            // 
            // panel2
            // 
            panel2.Controls.Add(radioButtonProfit);
            panel2.Controls.Add(radioButtonExpensesForDetails);
            panel2.Controls.Add(radioButtonCountOrders);
            panel2.Location = new Point(-2, 289);
            panel2.Name = "panel2";
            panel2.Size = new Size(252, 150);
            panel2.TabIndex = 7;
            // 
            // radioButtonProfit
            // 
            radioButtonProfit.AutoSize = true;
            radioButtonProfit.Location = new Point(29, 106);
            radioButtonProfit.Name = "radioButtonProfit";
            radioButtonProfit.Size = new Size(112, 29);
            radioButtonProfit.TabIndex = 6;
            radioButtonProfit.Text = "Прибыль";
            radioButtonProfit.UseVisualStyleBackColor = true;
            radioButtonProfit.CheckedChanged += RadioButtonProfit_CheckedChanged;
            // 
            // radioButtonExpensesForDetails
            // 
            radioButtonExpensesForDetails.AutoSize = true;
            radioButtonExpensesForDetails.Location = new Point(29, 61);
            radioButtonExpensesForDetails.Name = "radioButtonExpensesForDetails";
            radioButtonExpensesForDetails.Size = new Size(186, 29);
            radioButtonExpensesForDetails.TabIndex = 5;
            radioButtonExpensesForDetails.Text = "Затраты на детали";
            radioButtonExpensesForDetails.UseVisualStyleBackColor = true;
            radioButtonExpensesForDetails.CheckedChanged += RadioButtonExpensesForDetails_CheckedChanged;
            // 
            // radioButtonCountOrders
            // 
            radioButtonCountOrders.AutoSize = true;
            radioButtonCountOrders.Checked = true;
            radioButtonCountOrders.Location = new Point(29, 15);
            radioButtonCountOrders.Name = "radioButtonCountOrders";
            radioButtonCountOrders.Size = new Size(212, 29);
            radioButtonCountOrders.TabIndex = 4;
            radioButtonCountOrders.TabStop = true;
            radioButtonCountOrders.Text = "Выполненные заказы";
            radioButtonCountOrders.UseVisualStyleBackColor = true;
            radioButtonCountOrders.CheckedChanged += RadioButtonCountOrders_CheckedChanged;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(0, 523);
            label2.Name = "label2";
            label2.Size = new Size(1100, 2);
            label2.TabIndex = 8;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(921, 536);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(166, 43);
            buttonExit.TabIndex = 9;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(257, -1);
            label3.Name = "label3";
            label3.Size = new Size(2, 527);
            label3.TabIndex = 10;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(-2, 288);
            label5.Name = "label5";
            label5.Size = new Size(259, 2);
            label5.TabIndex = 11;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Location = new Point(-2, 146);
            label6.Name = "label6";
            label6.Size = new Size(259, 2);
            label6.TabIndex = 12;
            // 
            // chart1
            // 
            customLabel1.ForeColor = Color.Black;
            customLabel1.Text = "Июнь";
            customLabel1.ToPosition = 0.1666666667D;
            customLabel2.ForeColor = Color.Black;
            customLabel2.Text = "Июль";
            customLabel2.ToPosition = -0.1666666667D;
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.CustomLabels.Add(customLabel2);
            chartArea1.AxisX.Interval = 0.1666666667D;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Location = new Point(287, 27);
            chart1.Name = "chart1";
            chart1.Size = new Size(787, 470);
            chart1.TabIndex = 15;
            chart1.Text = "chart1";
            // 
            // ReportsOrganization
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 591);
            Controls.Add(chart1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(buttonExit);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(comboBoxYear);
            Controls.Add(label4);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReportsOrganization";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Отчет по работе за год";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private ComboBox comboBoxYear;
        private Panel panel1;
        private ComboBox comboBoxMaster;
        private RadioButton radioButtonMaster;
        private RadioButton radioButtonOrganization;
        private Panel panel2;
        private RadioButton radioButtonProfit;
        private RadioButton radioButtonExpensesForDetails;
        private RadioButton radioButtonCountOrders;
        private Label label2;
        private Button buttonExit;
        private Label label3;
        private Label label5;
        private Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}