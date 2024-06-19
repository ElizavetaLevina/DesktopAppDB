using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class FeaturesClient : Form
    {
        ClientRepository clientRepository = new();
        ClientEditDTO client;
        public int clientId;
        public FeaturesClient(int id = 0)
        {
            InitializeComponent();
            clientId = id;
            client = clientRepository.GetClient(id);
            textBoxID.Text = client.IdClient;
            textBoxNameAddress.Text = client.NameAndAddressClient;
            textBoxSecondPhone.Text = client.NumberSecondPhone;

            switch (client.TypeClient)
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
            if (textBoxID.Text != "")
            {
                client.IdClient = textBoxID.Text;
                client.NameAndAddressClient = textBoxNameAddress.Text;
                client.NumberSecondPhone = textBoxSecondPhone.Text;
                client.TypeClient = TypeClient();

                Task.Run(async () =>
                {
                    await clientRepository.SaveClientAsync(client);
                });

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string TypeClient()
        {
            string typeClient = "normal";

            if (radioButtonWhite.Checked)
                typeClient = "white";
            else if (radioButtonBlack.Checked)
                typeClient = "black";

            return typeClient;
        }
    }
}
