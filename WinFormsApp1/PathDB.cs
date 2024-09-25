namespace WinFormsApp1
{
    public partial class PathDB : Form
    {
        public PathDB()
        {
            InitializeComponent();
            InitializeTextBoxes();
        }

        public void InitializeTextBoxes()
        {
            Host = string.IsNullOrEmpty(Properties.Settings.Default.Host) ? "localhost" : Properties.Settings.Default.Host;
            Port = string.IsNullOrEmpty(Properties.Settings.Default.Port) ? "5432" : Properties.Settings.Default.Port;
            Database = string.IsNullOrEmpty(Properties.Settings.Default.Database) ? "postgres" : Properties.Settings.Default.Database;
            Username = string.IsNullOrEmpty(Properties.Settings.Default.Username) ? "postgres" : Properties.Settings.Default.Username;
            Password = string.IsNullOrEmpty(Properties.Settings.Default.Password) ? "123" : Properties.Settings.Default.Password;
            SearchPath = string.IsNullOrEmpty(Properties.Settings.Default.SearchPath) ? "public" : Properties.Settings.Default.SearchPath;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Host) || string.IsNullOrEmpty(Port) || string.IsNullOrEmpty(Database) || string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(SearchPath))
            {
                Warning warning = new();
                warning.ShowDialog();
                return;
            }

            Properties.Settings.Default.Host = Host;
            Properties.Settings.Default.Port = Port;
            Properties.Settings.Default.Database = Database;
            Properties.Settings.Default.Username = Username;
            Properties.Settings.Default.Password = Password;
            Properties.Settings.Default.SearchPath = SearchPath;
            Properties.Settings.Default.Save();
            Close();
        }

        public string Host
        {
            get { return textBoxHost.Text; }
            set { textBoxHost.Text = value; }
        }

        public string Port
        {
            get { return textBoxPort.Text; }
            set { textBoxPort.Text = value; }
        }

        public string Database
        {
            get { return textBoxDatabase.Text; }
            set { textBoxDatabase.Text = value; }
        }

        public string Username
        {
            get { return textBoxUsername.Text; }
            set { textBoxUsername.Text = value; }
        }

        public string Password
        {
            get { return textBoxPassword.Text; }
            set { textBoxPassword.Text = value; }
        }

        public string SearchPath
        {
            get { return textBoxSearchPath.Text; }
            set { textBoxSearchPath.Text = value; }
        }
    }
}
