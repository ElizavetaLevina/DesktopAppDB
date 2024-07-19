using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class FeaturesClient : Form
    {
        ClientRepository clientRepository = new();
        ClientEditDTO clientDTO;
        public int clientId;
        public FeaturesClient(int id = 0)
        {
            InitializeComponent();
            clientId = id;
            clientDTO = clientRepository.GetClient(id);
            textBoxID.Text = clientDTO.IdClient;
            textBoxNameAddress.Text = clientDTO.NameAndAddressClient;
            textBoxSecondPhone.Text = clientDTO.NumberSecondPhone;

            var typeClient = (TypeClientEnum)System.Enum.Parse(typeof(TypeClientEnum), clientDTO.TypeClient);

            switch (typeClient)
            {
                case TypeClientEnum.normal:
                    radioButtonNormal.Checked = true; break;
                case TypeClientEnum.white:
                    radioButtonWhite.Checked = true; break;
                case TypeClientEnum.black:
                    radioButtonBlack.Checked = true; break;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxID.Text))
            {
                clientDTO.IdClient = textBoxID.Text;
                clientDTO.NameAndAddressClient = textBoxNameAddress.Text;
                clientDTO.NumberSecondPhone = textBoxSecondPhone.Text;
                clientDTO.TypeClient = TypeClient();

                Task.Run(async () =>
                {
                    await clientRepository.SaveClientAsync(clientDTO);
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
            string typeClient = TypeClientEnum.normal.ToString();

            if (radioButtonWhite.Checked)
                typeClient = TypeClientEnum.white.ToString();
            else if (radioButtonBlack.Checked)
                typeClient = TypeClientEnum.black.ToString();

            return typeClient;
        }
    }
}
