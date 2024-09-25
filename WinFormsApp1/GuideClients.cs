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
            InitializeElementsForm();
        }

        private void InitializeElementsForm() 
        {
            clients = clientsLogic.GetClientsForTable();
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

        private void TextBoxEnterName_TextChanged(object sender, EventArgs e)
        {
            clients = clientsLogic.GetClientsByIdClient(textBoxEnterName.Text);
            UpdateTable();
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            clients = clientsLogic.GetClientsForTable();
            UpdateTable();
        }

        private void ButtonWhite_Click(object sender, EventArgs e)
        {
            clients = clientsLogic.GetClientsByType(TypeClientEnum.white);
            UpdateTable();
        }

        private void ButtonNormal_Click(object sender, EventArgs e)
        {
            clients = clientsLogic.GetClientsByType(TypeClientEnum.normal);
            UpdateTable();
        }

        private void ButtonBlack_Click(object sender, EventArgs e)
        {
            clients = clientsLogic.GetClientsByType(TypeClientEnum.black);
            UpdateTable();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
