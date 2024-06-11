using System.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class FeaturesClient : Form
    {
        public FeaturesClient(int id)
        {
            InitializeComponent();
            Context context = new();
            var list = context.Clients.Where(i => i.Id == id).ToList();

            textBoxID.Text = list[0].IdClient;
            textBoxNameAddress.Text = String.Format("{0}, {1}", list[0].NameClient, list[0].Address);
            textBoxSecondPhone.Text = list[0].NumberSecondPhone;

            switch (list[0].TypeClient)
            {
                case "normal":
                    radioButtonNormal.Checked = true; break;
                case "white":
                    radioButtonWhite.Checked = true; break;
                case "black":
                    radioButtonBlack.Checked = true; break;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string IdClient
        {
            get { return this.textBoxID.Text; }
            set { this.textBoxID.Text = value; }
        }

        public string NameAdressClient
        {
            get { return this.textBoxNameAddress.Text; }
            set { this.textBoxNameAddress.Text = value; }
        }

        public string SecondPhone
        {
            get { return this.textBoxSecondPhone.Text; }
            set { this.textBoxSecondPhone.Text = value; }
        }

        public bool NormalType
        {
            get { return radioButtonNormal.Checked; }
            set { radioButtonNormal.Checked = value; }
        }

        public bool WhiteType
        {
            get { return radioButtonWhite.Checked; }
            set { radioButtonWhite.Checked = value; }
        }

        public bool BlackType
        {
            get { return radioButtonBlack.Checked; }
            set { radioButtonBlack.Checked = value; }
        }
    }
}
