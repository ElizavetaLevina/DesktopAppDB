using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class GuideClients : Form
    {
        ClientRepository clientRepository = new();
        List<ClientDTO> clients;
        public GuideClients()
        {
            InitializeComponent();
        }

        private void UpdateTable()
        {
            dataGridView1.DataSource = clients;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["IdClient"].HeaderText = "ID клиента";
            dataGridView1.Columns["NameAndAddressClient"].HeaderText = "ФИО, адрес";
            dataGridView1.Columns["NumberSecondPhone"].HeaderText = "Дополнительный телефон";

            int[] percent = [0, 35, 35, 30];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }

        }

        private void GuideClients_Activated(object sender, EventArgs e)
        {
            buttonAll.Focus();
            clients = clientRepository.GetClientsForTable();
            UpdateTable();
        }

        private void TextBoxEnterName_TextChanged(object sender, EventArgs e)
        {
            clients = clientRepository.GetClientsByIdClient(textBoxEnterName.Text);
            UpdateTable();
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            clients = clientRepository.GetClientsForTable();
            UpdateTable();
        }

        private void ButtonWhite_Click(object sender, EventArgs e)
        {
            clients = clientRepository.GetClientsByType(TypeClientEnum.white);
            UpdateTable();
        }

        private void ButtonNormal_Click(object sender, EventArgs e)
        {
            clients = clientRepository.GetClientsByType(TypeClientEnum.normal);
            UpdateTable();
        }

        private void ButtonBlack_Click(object sender, EventArgs e)
        {
            clients = clientRepository.GetClientsByType(TypeClientEnum.black);
            UpdateTable();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
