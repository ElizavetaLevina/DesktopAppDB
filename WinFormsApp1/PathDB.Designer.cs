namespace WinFormsApp1
{
    partial class PathDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathDB));
            label1 = new Label();
            label2 = new Label();
            buttonExit = new Button();
            openFileDialog1 = new OpenFileDialog();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBoxHost = new TextBox();
            textBoxPort = new TextBox();
            textBoxDatabase = new TextBox();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            textBoxSearchPath = new TextBox();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 23);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 2;
            label1.Text = "Host:";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(-5, 180);
            label2.Name = "label2";
            label2.Size = new Size(624, 2);
            label2.TabIndex = 3;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(432, 187);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(171, 43);
            buttonExit.TabIndex = 7;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "computerservice";
            openFileDialog1.Filter = "Data base files(*.db)|*.db|All files(*.*)|*.*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 71);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 5;
            label3.Text = "Port:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 118);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 6;
            label4.Text = "Database:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(311, 20);
            label5.Name = "label5";
            label5.Size = new Size(95, 25);
            label5.TabIndex = 7;
            label5.Text = "Username:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(316, 71);
            label6.Name = "label6";
            label6.Size = new Size(91, 25);
            label6.TabIndex = 8;
            label6.Text = "Password:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(304, 118);
            label7.Name = "label7";
            label7.Size = new Size(102, 25);
            label7.TabIndex = 9;
            label7.Text = "SearchPath:";
            // 
            // textBoxHost
            // 
            textBoxHost.Location = new Point(112, 20);
            textBoxHost.Name = "textBoxHost";
            textBoxHost.Size = new Size(150, 31);
            textBoxHost.TabIndex = 0;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(112, 68);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(150, 31);
            textBoxPort.TabIndex = 1;
            // 
            // textBoxDatabase
            // 
            textBoxDatabase.Location = new Point(112, 115);
            textBoxDatabase.Name = "textBoxDatabase";
            textBoxDatabase.Size = new Size(150, 31);
            textBoxDatabase.TabIndex = 2;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(412, 17);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(150, 31);
            textBoxUsername.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(412, 68);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(150, 31);
            textBoxPassword.TabIndex = 4;
            // 
            // textBoxSearchPath
            // 
            textBoxSearchPath.Location = new Point(412, 115);
            textBoxSearchPath.Name = "textBoxSearchPath";
            textBoxSearchPath.Size = new Size(150, 31);
            textBoxSearchPath.TabIndex = 5;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(245, 187);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(171, 43);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // PathDB
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 236);
            Controls.Add(buttonSave);
            Controls.Add(textBoxSearchPath);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxDatabase);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxHost);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(buttonExit);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PathDB";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Путь базы данных";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Button buttonExit;
        private OpenFileDialog openFileDialog1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBoxHost;
        private TextBox textBoxPort;
        private TextBox textBoxDatabase;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private TextBox textBoxSearchPath;
        private Button buttonSave;
    }
}