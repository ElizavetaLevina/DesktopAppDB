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
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        public string ButtonNoText
        {
            get { return this.buttonExit.Text; }
            set { this.buttonExit.Text = value; }
        }

        public string ButtonYesText
        {
            get { return this.buttonYes.Text; }
            set { this.buttonYes.Text = value; }
        }

        public bool ButtonVisible
        {
            get {  return this.buttonYes.Visible; }
            set {  this.buttonYes.Visible = value; }
        }

        public bool VisibleChangePrice
        {
            get { return this.linkLabelChangeMaxPrice.Visible; }
            set { linkLabelChangeMaxPrice.Visible = value; }
        }

        private void Warning_Activated(object sender, EventArgs e)
        {
            if (buttonYes.Visible)
                buttonYes.Focus();
        }


        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LinkLabelChangeMaxPrice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FeaturesOrder featuresOrder = new(id, "InRepair", true)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            featuresOrder.ShowDialog();
            this.Close();
        }
    }
}
