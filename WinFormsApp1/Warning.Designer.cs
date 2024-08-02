namespace WinFormsApp1
{
    partial class Warning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warning));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            buttonExit = new Button();
            buttonYes = new Button();
            label3 = new Label();
            label4 = new Label();
            linkLabelChangeMaxPrice = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(187, 29);
            label1.Name = "label1";
            label1.Size = new Size(414, 141);
            label1.TabIndex = 0;
            label1.Text = "Вы не заполнили обязательные поля!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.warning;
            pictureBox1.Location = new Point(21, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 137);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(172, 36);
            label2.Name = "label2";
            label2.Size = new Size(2, 150);
            label2.TabIndex = 4;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(420, 222);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(181, 43);
            buttonExit.TabIndex = 8;
            buttonExit.Text = "ОК";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // buttonYes
            // 
            buttonYes.Location = new Point(215, 222);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(181, 43);
            buttonYes.TabIndex = 7;
            buttonYes.Text = "Да";
            buttonYes.UseVisualStyleBackColor = true;
            buttonYes.Visible = false;
            buttonYes.Click += ButtonYes_Click;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(-5, 208);
            label3.Name = "label3";
            label3.Size = new Size(623, 2);
            label3.TabIndex = 8;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(-5, 209);
            label4.Name = "label4";
            label4.Size = new Size(623, 2);
            label4.TabIndex = 9;
            // 
            // linkLabelChangeMaxPrice
            // 
            linkLabelChangeMaxPrice.AutoSize = true;
            linkLabelChangeMaxPrice.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabelChangeMaxPrice.Location = new Point(263, 176);
            linkLabelChangeMaxPrice.Name = "linkLabelChangeMaxPrice";
            linkLabelChangeMaxPrice.Size = new Size(266, 25);
            linkLabelChangeMaxPrice.TabIndex = 6;
            linkLabelChangeMaxPrice.TabStop = true;
            linkLabelChangeMaxPrice.Text = "Изменить согласованную цену";
            linkLabelChangeMaxPrice.Visible = false;
            linkLabelChangeMaxPrice.LinkClicked += LinkLabelChangeMaxPrice_LinkClicked;
            // 
            // Warning
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 276);
            Controls.Add(linkLabelChangeMaxPrice);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(buttonYes);
            Controls.Add(buttonExit);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Warning";
            Text = "Внимание";
            Activated += Warning_Activated;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Button buttonExit;
        private Button buttonYes;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabelChangeMaxPrice;
    }
}