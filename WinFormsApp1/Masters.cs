using WinFormsApp1.DTO;
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class Masters : Form
    {
        MastersLogic mastersLogic = new();
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
                MasterEdit addMasterForm = new(false, IdMaster)
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
                var masterDTO = mastersLogic.GetMaster(IdMaster);
                mastersLogic.RemoveMaster(masterDTO);
                UpdateTable();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateTable()
        {
            dataGridView1.DataSource = mastersLogic.GetMastersForOutput();
            dataGridView1.Columns[nameof(MasterDTO.Id)].Visible = false;
            dataGridView1.Columns[nameof(MasterDTO.NameMaster)].HeaderText = "ФИО";
            dataGridView1.Columns[nameof(MasterDTO.NumberPhone)].HeaderText = "Телефон";

            int[] percent = [0, 40, 60];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }
        }

        public int IdMaster
        {
            get { return Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
                Cells[nameof(MasterDTO.Id)].Value); }
        }
    }
}
