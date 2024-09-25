using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class BrandsTechnic : Form
    {
        public int IdBrand { get { return Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
            Cells[nameof(BrandTechnicDTO.Id)].Value); } }
        IBrandsTechnicsLogic brandsTechnicsLogic;
        ITypesBrandsLogic typesBrandsLogic;

        public BrandsTechnic(IBrandsTechnicsLogic _brandsTechnicsLogic, ITypesBrandsLogic _typesBrandsLogic)
        {
            brandsTechnicsLogic = _brandsTechnicsLogic;
            typesBrandsLogic = _typesBrandsLogic;
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
            BrandAndTypeEdit brandAndTypeEdit = Program.ServiceProvider.GetRequiredService<BrandAndTypeEdit>();
            brandAndTypeEdit.nameTable = NameTableToEditEnum.BrandTechnic;
            brandAndTypeEdit.InitializeElementsForm();
            if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
                UpdateTable();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                BrandAndTypeEdit brandAndTypeEdit = Program.ServiceProvider.GetRequiredService<BrandAndTypeEdit>();
                brandAndTypeEdit.nameTable = NameTableToEditEnum.BrandTechnic;
                brandAndTypeEdit.id = IdBrand;
                brandAndTypeEdit.InitializeElementsForm();
                if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
                    UpdateTable();
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var typesBrandsDTO = typesBrandsLogic.GetTypeBrand(IdBrand);
                foreach (var typesBrand in typesBrandsDTO)
                {
                    typesBrandsLogic.RemoveTypeBrand(typesBrand);
                }
                var brandTechnicDTO = new BrandTechnicEditDTO() { Id = IdBrand };
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
