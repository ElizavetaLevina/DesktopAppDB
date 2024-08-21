using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class TypesTechnic : Form
    {
        public int IdType { get { return Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
            Cells[nameof(TypeTechnicDTO.Id)].Value); } }
        TypesTechnicsLogic typesTechnicsLogic = new();
        TypesBrandsLogic typesBrandsLogic = new();

        public TypesTechnic()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void UpdateTable()
        {
            dataGridView1.DataSource = typesTechnicsLogic.GetTypesTechnic();
            dataGridView1.Columns[nameof(TypeTechnicDTO.Id)].Visible = false;
            dataGridView1.Columns[nameof(TypeTechnicDTO.NameTypeTechnic)].HeaderText = "Тип устройства";
            dataGridView1.Columns[nameof(TypeTechnicDTO.NameTypeTechnic)].Width = dataGridView1.Width;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            BrandAndTypeEdit brandAndTypeEdit = new(NameTableToEditEnum.TypeTechnic)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
                UpdateTable();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                BrandAndTypeEdit brandAndTypeEdit = new(NameTableToEditEnum.TypeTechnic, IdType)
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
                    UpdateTable();
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var typesBrandsDTO = typesBrandsLogic.GetTypeBrand(IdType);
                foreach (var typesBrand in typesBrandsDTO)
                {
                    typesBrandsLogic.RemoveTypeBrand(typesBrand);
                }
                var typeTechnicDTO = new TypeTechnicEditDTO() { Id = IdType };
                typesTechnicsLogic.RemoveTypeTechnic(typeTechnicDTO);
                UpdateTable();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
