using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class BrandsTechnic : Form
    {
        public int IdBrand { get { return Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
            Cells[nameof(BrandTechnicDTO.Id)].Value); } }
        BrandsTechnicsLogic brandsTechnicsLogic = new();
        TypesBrandsLogic typesBrandsLogic = new();

        public BrandsTechnic()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void UpdateTable()
        {
            dataGridView1.DataSource = brandsTechnicsLogic.GetBrandsTechnic();
            dataGridView1.Columns[nameof(BrandTechnicDTO.Id)].Visible = false;
            dataGridView1.Columns[nameof(BrandTechnicDTO.NameBrandTechnic)].HeaderText = "Название";
            dataGridView1.Columns[nameof(BrandTechnicDTO.NameBrandTechnic)].Width = dataGridView1.Width;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            BrandAndTypeEdit brandAndTypeEdit = new(NameTableToEditEnum.BrandTechnic)
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
                BrandAndTypeEdit brandAndTypeEdit = new(NameTableToEditEnum.BrandTechnic, IdBrand)
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
                var brandTechnicDTO = new BrandTechnicEditDTO() { Id = IdBrand };
                typesBrandsLogic.RemoveTypeBrand(idBrand: IdBrand);
                brandsTechnicsLogic.RemoveBrandTechnic(brandTechnicDTO);
                UpdateTable();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
