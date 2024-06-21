namespace WinFormsApp1
{
    public partial class Organization : Form
    {
        public Organization()
        {
            InitializeComponent();
            textBoxName.Text = Properties.Settings.Default.NameOrg;
            textBoxAddress.Text = Properties.Settings.Default.AddressOrg;
            textBoxPhone.Text = Properties.Settings.Default.PhoneOrg;
            textBoxMail.Text = Properties.Settings.Default.MailOrg;
            textBoxFax.Text = Properties.Settings.Default.FaxOrg;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NameOrg = textBoxName.Text;
            Properties.Settings.Default.AddressOrg = textBoxAddress.Text;
            Properties.Settings.Default.PhoneOrg = textBoxPhone.Text;
            Properties.Settings.Default.MailOrg = textBoxMail.Text;
            Properties.Settings.Default.FaxOrg = textBoxFax.Text;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
