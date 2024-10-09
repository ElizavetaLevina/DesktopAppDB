using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class PropertiesClient : Form
    {
        IClientsLogic clientsLogic;
        ClientEditDTO clientDTO;
        public string idClient;
        public PropertiesClient(IClientsLogic _clientsLogic)
        {
            clientsLogic = _clientsLogic;
            InitializeComponent();
        }

        public async void InitializeElementsFormsAsync()
        {
            clientDTO = await clientsLogic.GetClientAsync(idClient);
            textBoxID.Text = clientDTO.IdClient;
            textBoxNameAddress.Text = clientDTO.NameAndAddressClient;
            textBoxSecondPhone.Text = clientDTO.NumberSecondPhone;

            switch (clientDTO.TypeClient)
            {
                case TypeClientEnum.normal:
                    radioButtonNormal.Checked = true; break;
                case TypeClientEnum.white:
                    radioButtonWhite.Checked = true; break;
                case TypeClientEnum.black:
                    radioButtonBlack.Checked = true; break;
            }
        }

        private async void ButtonSave_ClickAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxID.Text))
            {
                clientDTO.IdClient = textBoxID.Text;
                clientDTO.NameAndAddressClient = textBoxNameAddress.Text;
                clientDTO.NumberSecondPhone = textBoxSecondPhone.Text;
                clientDTO.TypeClient = TypeClient();
                await clientsLogic.SaveClientAsync(clientDTO);

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public TypeClientEnum TypeClient()
        {
            var typeClient = TypeClientEnum.normal;

            if (radioButtonWhite.Checked)
                typeClient = TypeClientEnum.white;
            else if (radioButtonBlack.Checked)
                typeClient = TypeClientEnum.black;

            return typeClient;
        }
    }
}
