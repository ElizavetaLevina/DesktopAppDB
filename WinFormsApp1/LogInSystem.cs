namespace WinFormsApp1
{
    public partial class LogInSystem : Form
    {
        private readonly bool logIn;
        public LogInSystem(bool _logIn)
        {
            InitializeComponent();
            logIn = _logIn;
            textBoxLogin.Text = Properties.Settings.Default.Login;
            if (!logIn)
            {
                this.Text = "Изменение логина/пароля";
                textBoxPassword.Text = Properties.Settings.Default.Password;
                buttonLogIn.Text = "Сохранить";
                checkBoxShowPassword.Checked = true;
            }
        }

        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            if (logIn)
            {
                if (textBoxLogin.Text == Properties.Settings.Default.Login &&
                    textBoxPassword.Text == Properties.Settings.Default.Password)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
                if (textBoxLogin.Text != "" && textBoxPassword.Text != "")
                {
                    Properties.Settings.Default.Login = textBoxLogin.Text;
                    Properties.Settings.Default.Password = textBoxPassword.Text;
                    Properties.Settings.Default.Save();
                    this.Close();
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (logIn)
                {
                    if (textBoxLogin.Text == Properties.Settings.Default.Login &&
                    textBoxPassword.Text == Properties.Settings.Default.Password)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
                    if (textBoxLogin.Text != "" && textBoxPassword.Text != "")
                    {
                        Properties.Settings.Default.Login = textBoxLogin.Text;
                        Properties.Settings.Default.Password = textBoxPassword.Text;
                        Properties.Settings.Default.Save();
                        this.Close();
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
    }
}
