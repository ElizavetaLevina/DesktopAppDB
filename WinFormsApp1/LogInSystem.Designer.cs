namespace WinFormsApp1
{
    partial class LogInSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInSystem));
            label1 = new Label();
            label2 = new Label();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            label3 = new Label();
            buttonLogIn = new Button();
            buttonExit = new Button();
            checkBoxShowPassword = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(118, 62);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 0;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(106, 118);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 1;
            label2.Text = "Пароль:";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(190, 59);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(193, 31);
            textBoxLogin.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(190, 115);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(193, 31);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.KeyDown += TextBoxPassword_KeyDown;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(-4, 208);
            label3.Name = "label3";
            label3.Size = new Size(555, 2);
            label3.TabIndex = 4;
            // 
            // buttonLogIn
            // 
            buttonLogIn.Location = new Point(204, 219);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(155, 43);
            buttonLogIn.TabIndex = 5;
            buttonLogIn.Text = "Войти";
            buttonLogIn.UseVisualStyleBackColor = true;
            buttonLogIn.Click += ButtonLogIn_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(373, 219);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(155, 43);
            buttonExit.TabIndex = 6;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // checkBoxShowPassword
            // 
            checkBoxShowPassword.AutoSize = true;
            checkBoxShowPassword.Location = new Point(190, 152);
            checkBoxShowPassword.Name = "checkBoxShowPassword";
            checkBoxShowPassword.Size = new Size(177, 29);
            checkBoxShowPassword.TabIndex = 7;
            checkBoxShowPassword.Text = "Показать пароль";
            checkBoxShowPassword.UseVisualStyleBackColor = true;
            checkBoxShowPassword.CheckedChanged += CheckBoxShowPassword_CheckedChanged;
            // 
            // LogInSystem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 271);
            Controls.Add(checkBoxShowPassword);
            Controls.Add(buttonExit);
            Controls.Add(buttonLogIn);
            Controls.Add(label3);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogInSystem";
            Text = "Вход в систему";
            Activated += LogInSystem_Activated;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Label label3;
        private Button buttonLogIn;
        private Button buttonExit;
        private CheckBox checkBoxShowPassword;
    }
}