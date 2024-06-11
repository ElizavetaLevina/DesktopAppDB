using System.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class GuideClients : Form
    {
        public GuideClients()
        {
            InitializeComponent();
        }

        private void UpdateTable()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "ID клиента";
            dataGridView1.Columns[2].HeaderText = "ФИО";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].HeaderText = "Дополнительный телефон";

            int[] percent = [0, 30, 20, 30, 20];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }

        }

        private void GuideClients_Activated(object sender, EventArgs e)
        {
            buttonAll.Focus();
            using Context context = new();
            var list = context.Clients.ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void TextBoxEnterName_TextChanged(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.Where(i => i.NameClient.IndexOf(textBoxEnterName.Text) > -1).ToList();
            dataGridView1.DataSource = list;
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void ButtonWhite_Click(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.Where(i => i.TypeClient == "white").ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void ButtonNormal_Click(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.Where(i => i.TypeClient == "normal").ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void ButtonBlack_Click(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.Where(i => i.TypeClient == "black").ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
