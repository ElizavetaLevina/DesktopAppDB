using WinFormsApp1.Enum;

namespace WinFormsApp1
{
    public partial class Warning : Form
    {
        public int id;
        public Warning()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public string ButtonNoText
        {
            get { return buttonExit.Text; }
            set { buttonExit.Text = value; }
        }

        public string ButtonYesText
        {
            get { return buttonYes.Text; }
            set { buttonYes.Text = value; }
        }

        public bool ButtonVisible
        {
            get {  return buttonYes.Visible; }
            set {  buttonYes.Visible = value; }
        }

        public bool VisibleChangePrice
        {
            get { return linkLabelChangeMaxPrice.Visible; }
            set { linkLabelChangeMaxPrice.Visible = value; }
        }

        private void Warning_Activated(object sender, EventArgs e)
        {
            if (buttonYes.Visible)
                buttonYes.Focus();
        }


        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LinkLabelChangeMaxPrice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FeaturesOrder featuresOrder = new(id, StatusOrderEnum.InRepair, true)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            featuresOrder.ShowDialog();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
