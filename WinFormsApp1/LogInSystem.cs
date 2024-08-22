﻿namespace WinFormsApp1
{
    public partial class LogInSystem : Form
    {
        private readonly bool logIn;
        public LogInSystem(bool _logIn)
        {
            InitializeComponent();
            logIn = _logIn;
            InitializeElementsForm();
        }

        private void InitializeElementsForm()
        {
            textBoxLogin.Text = Properties.Settings.Default.Login;
            if (!logIn)
            {
                Text = "Изменение логина/пароля";
                Password = Properties.Settings.Default.Password;
                buttonLogIn.Text = "Сохранить";
                checkBoxShowPassword.Checked = true;
            }
        }

        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            if (logIn)
            {
                if (Login == Properties.Settings.Default.Login &&
                    Password == Properties.Settings.Default.Password)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Неправильный логин или пароль!"
                    };
                    warning.ShowDialog();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
                {
                    Properties.Settings.Default.Login = textBoxLogin.Text;
                    Properties.Settings.Default.Password = textBoxPassword.Text;
                    Properties.Settings.Default.Save();
                    Close();
                }
                else
                {
                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    warning.ShowDialog();
                }
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (logIn)
                {
                    if (Login == Properties.Settings.Default.Login && 
                        Password == Properties.Settings.Default.Password)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        Warning warning = new()
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            LabelText = "Неправильный логин или пароль!"
                        };
                        warning.ShowDialog();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
                    {
                        Properties.Settings.Default.Login = textBoxLogin.Text;
                        Properties.Settings.Default.Password = textBoxPassword.Text;
                        Properties.Settings.Default.Save();
                        Close();
                    }
                    else
                    {
                        Warning warning = new()
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        warning.ShowDialog();
                    }
                }
            }
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked) textBoxPassword.UseSystemPasswordChar = false;
            else textBoxPassword.UseSystemPasswordChar = true;
        }

        private void CheckBoxShowPassword_KeyDown(object sender, KeyEventArgs e)
        {
            checkBoxShowPassword.Checked = !checkBoxShowPassword.Checked;
        }

        private void LogInSystem_Activated(object sender, EventArgs e)
        {
            if (logIn)
                textBoxPassword.Focus();
        }

        public string Login
        {
            get { return textBoxLogin.Text; }
            set { textBoxLogin.Text = value; }
        }

        public string Password
        {
            get { return textBoxPassword.Text; }
            set { textBoxPassword.Text = value; }
        }
    }
}
