using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class GuideClients : Form
    {
        IClientsLogic clientsLogic;
        List<ClientDTO> clients;
        public GuideClients(IClientsLogic _clientsLogic)
        {
            clientsLogic = _clientsLogic;
            InitializeComponent();
            InitializeElementsFormAsync();
        }

        private async void InitializeElementsFormAsync() 
        {
            clients = await clientsLogic.GetClientsForTableAsync();
            UpdateTable();
        }

        private void UpdateTable()
        {
            dataGridView1.DataSource = clients;
            dataGridView1.Columns[nameof(ClientDTO.Id)].Visible = false;
            dataGridView1.Columns[nameof(ClientDTO.IdClient)].HeaderText = "ID клиента";
            dataGridView1.Columns[nameof(ClientDTO.NameAndAddressClient)].HeaderText = "ФИО, адрес";
            dataGridView1.Columns[nameof(ClientDTO.NumberSecondPhone)].HeaderText = "Дополнительный телефон";

            int[] percent = [0, 35, 35, 30];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }
        }

        private async void TextBoxEnterName_TextChangedAsync(object sender, EventArgs e)
        {
            clients = await clientsLogic.GetClientsByIdClientAsync(textBoxEnterName.Text);
            UpdateTable();
        }

        private async void ButtonAll_ClickAsync(object sender, EventArgs e)
        {
            clients = await clientsLogic.GetClientsForTableAsync();
            UpdateTable();
        }

        private async void ButtonWhite_ClickAsync(object sender, EventArgs e)
        {
            clients = await clientsLogic.GetClientsByTypeAsync(TypeClientEnum.white);
            UpdateTable();
        }

        private async void ButtonNormal_ClickAsync(object sender, EventArgs e)
        {
            clients = await clientsLogic.GetClientsByTypeAsync(TypeClientEnum.normal);
            UpdateTable();
        }

        private async void ButtonBlack_ClickAsync(object sender, EventArgs e)
        {
            clients = await clientsLogic.GetClientsByTypeAsync(TypeClientEnum.black);
            UpdateTable();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
