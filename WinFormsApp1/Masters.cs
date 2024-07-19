using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class Masters : Form
    {
        MasterRepository masterRepository = new();
        public Masters()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void BtnAddMaster_Click(object sender, EventArgs e)
        {
            MasterEdit addMasterForm = new(true)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMasterForm.ShowDialog();
            UpdateTable();
        }

        private void BtnChangeMaster_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);

                MasterEdit addMasterForm = new(false, id)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Изменение информации о мастере"
                };
                addMasterForm.ShowDialog();
                UpdateTable();
            }
        }

        private void BtnDeleteMaster_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var masterDTO = new MasterEditDTO() { Id = id };
                masterRepository.RemoveMaster(masterDTO);
                UpdateTable();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateTable()
        {
            dataGridView1.DataSource = masterRepository.GetMastersForOutput();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["NameMaster"].HeaderText = "ФИО";
            dataGridView1.Columns["NumberPhone"].HeaderText = "Телефон";

            int[] percent = [0, 40, 60];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }
        }
    }
}
