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
            UpdateTableAsync();
        }

        private async void UpdateTableAsync()
        {
            dataGridView1.DataSource = await brandsTechnicsLogic.GetBrandsTechnicAsync();
            dataGridView1.Columns[nameof(BrandTechnicDTO.Id)].Visible = false;
            dataGridView1.Columns[nameof(BrandTechnicDTO.NameBrandTechnic)].HeaderText = "Название";
            dataGridView1.Columns[nameof(BrandTechnicDTO.NameBrandTechnic)].Width = dataGridView1.Width;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            BrandAndTypeEdit brandAndTypeEdit = Program.ServiceProvider.GetRequiredService<BrandAndTypeEdit>();
            brandAndTypeEdit.nameTable = NameTableToEditEnum.BrandTechnic;
            brandAndTypeEdit.InitializeElementsFormAsync();
            if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
                UpdateTableAsync();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                BrandAndTypeEdit brandAndTypeEdit = Program.ServiceProvider.GetRequiredService<BrandAndTypeEdit>();
                brandAndTypeEdit.nameTable = NameTableToEditEnum.BrandTechnic;
                brandAndTypeEdit.id = IdBrand;
                brandAndTypeEdit.InitializeElementsFormAsync();
                if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
                    UpdateTableAsync();
            }
        }

        private async void ButtonRemove_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var typesBrandsDTO = await typesBrandsLogic.GetTypeBrandAsync(IdBrand);
                foreach (var typesBrand in typesBrandsDTO)
                {
                    await typesBrandsLogic.RemoveTypeBrandAsync(typesBrand);
                }
                var brandTechnicDTO = new BrandTechnicEditDTO() { Id = IdBrand };
                await brandsTechnicsLogic.RemoveBrandTechnicAsync(brandTechnicDTO);
                UpdateTableAsync();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
