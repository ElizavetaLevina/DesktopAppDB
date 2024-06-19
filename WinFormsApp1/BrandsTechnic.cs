using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class BrandsTechnic : Form
    {
        BrandTechnicRepository brandTechnicRepository = new();
        TypeBrandRepository typeBrandRepository = new();
        public BrandsTechnic()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void BtnAddBrand_Click(object sender, EventArgs e)
        {
            BrandAndTypeEdit enterBrandForm = new("brand")
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelSecondName = "Тип устройства",
                LabelNameInList = "Типы устройств для "
            };
            
            if (enterBrandForm.ShowDialog() == DialogResult.OK)
            {
                int brandTechnicId = 0;
                var task = Task.Run(async () =>
                {
                    var brandTechnicDTO = new BrandTechnicEditDTO() { Id = 0, Name = enterBrandForm.NameTextBox };
                    brandTechnicId = await brandTechnicRepository.SaveBrandTechnicAsync(brandTechnicDTO);
                }); 
                task.Wait();

                if (enterBrandForm.idList != null)
                {
                    foreach(var typeId in enterBrandForm.idList)
                    {
                        task = Task.Run(async () =>
                        {
                            var typeBrandDTO = new TypeBrandEditDTO()
                            {
                                BrandTechnicsId = brandTechnicId,
                                TypeTechnicsId = typeId
                            };
                            await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                        });
                        task.Wait();
                    }
                }
                UpdateTable();
            }
        }

        private void BtnChangeBrand_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int brandTechnicId = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                string? name = dataGridView1.Rows[numberRow].Cells["NameBrandTechnic"].Value.ToString();
                List <TypeBrandDTO> list = typeBrandRepository.GetTypeBrand();
                BrandAndTypeEdit enterBrandForm = new("brand", false, brandTechnicId)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Изменение названия фирмы",
                    BtnText = "Сохранить",
                    NameTextBox = name,
                    LabelSecondName = "Тип устройства",
                    LabelNameInList = String.Format("Типы устройств для {0}", name)
                };

                if (enterBrandForm.ShowDialog() == DialogResult.OK)
                {
                    var task = Task.Run(async () =>
                    {
                        var brandTechnicDTO = new BrandTechnicEditDTO() { Id = brandTechnicId, Name = enterBrandForm.NameTextBox };
                        await brandTechnicRepository.SaveBrandTechnicAsync(brandTechnicDTO);
                    });
                    task.Wait();

                    if (enterBrandForm.idList != null)
                    {
                        foreach(var typeId in enterBrandForm.idList)
                        {
                            if (!list.Any(a => a.TypeTechnicsId == brandTechnicId && a.BrandTechnicsId == typeId))
                            {
                                Task.Run(async () =>
                                {
                                    var typeBrandDTO = new TypeBrandEditDTO()
                                    {
                                        BrandTechnicsId = brandTechnicId,
                                        TypeTechnicsId = typeId
                                    };
                                    await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                                });
                            }
                        }
                    }

                    if(enterBrandForm.idRemoveList != null)
                    {
                        foreach(var typeId in enterBrandForm.idRemoveList)
                        {
                            var typeBrandDTO = new TypeBrandEditDTO()
                            {
                                BrandTechnicsId = brandTechnicId,
                                TypeTechnicsId = typeId
                            };
                            typeBrandRepository.RemoveTypeBrand(typeBrandDTO);
                        }
                    }
                    UpdateTable();
                }
            }
        }

        private void BtnDeleteBrand_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var brandTechnicDTO = new BrandTechnicEditDTO() { Id = id };
                brandTechnicRepository.RemoveBrandTechnic(brandTechnicDTO);
                UpdateTable();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateTable()
        {
            List<BrandTechnicDTO> list = brandTechnicRepository.GetBrandsTechnic();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["NameBrandTechnic"].HeaderText = "Название";
            dataGridView1.Columns["NameBrandTechnic"].Width = dataGridView1.Width;
        }
    }
}
