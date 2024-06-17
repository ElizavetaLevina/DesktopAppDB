using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class AddBrand : Form
    {
        BrandTechnicRepository brandTechnicRepository = new();
        TypeBrandRepository typeBrandRepository = new();
        public AddBrand()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void BtnAddBrand_Click(object sender, EventArgs e)
        {
            EnterBrandForm enterBrandForm = new("brand", true, 0)
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelSecondName = "Тип устройства",
                LabelNameInList = "Типы устройств для "
            };
            
            if (enterBrandForm.ShowDialog() == DialogResult.OK)
            {
                Task.Run(async () =>
                {
                    var brandTechnicDTO = new BrandTechnicEditDTO() { Id = 0, Name = enterBrandForm.NameTextBox };
                    await brandTechnicRepository.SaveBrandTechnicAsync(brandTechnicDTO);
                });

                var list = brandTechnicRepository.GetBrandTechnics().OrderBy(i => i.Id).Last();

                if (enterBrandForm.idList != null)
                {
                    for (int i = 0; i < enterBrandForm.idList.Count; i++)
                    {
                        int brandId = list.Id + 1;
                        int typeId = enterBrandForm.idList[i];
                        Task.Run(async () =>
                        {
                            var typeBrandDTO = new TypeBrandEditDTO()
                            {
                                BrandTechnicsId = brandId,
                                TypeTechnicsId = typeId
                            };
                            await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                        });
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
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                string? name = dataGridView1.Rows[numberRow].Cells["NameBrandTechnic"].Value.ToString();
                List <TypeBrandDTO> list = typeBrandRepository.GetTypeBrand();
                EnterBrandForm enterBrandForm = new("brand", false, id)
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
                    Task.Run(async () =>
                    {
                        var brandTechnicDTO = new BrandTechnicEditDTO() { Id = id, Name = enterBrandForm.NameTextBox };
                        await brandTechnicRepository.SaveBrandTechnicAsync(brandTechnicDTO);
                    });

                    if (enterBrandForm.idList != null)
                    {
                        for (int i = 0; i < enterBrandForm.idList.Count; i++)
                        {
                            if(!list.Any(a => a.TypeTechnicsId == id && a.BrandTechnicsId == enterBrandForm.idList[i]))
                            {
                                int typeId = enterBrandForm.idList[i];
                                Task.Run(async () =>
                                {
                                    var typeBrandDTO = new TypeBrandEditDTO()
                                    {
                                        BrandTechnicsId = id,
                                        TypeTechnicsId = typeId
                                    };
                                    await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                                });
                            }
                        }
                    }
                    if(enterBrandForm.idRemoveList != null)
                    {
                        for (int i = 0; i < enterBrandForm.idRemoveList.Count; i++)
                        {
                            var typeBrandDTO = new TypeBrandEditDTO() 
                            { 
                                BrandTechnicsId = id, 
                                TypeTechnicsId = enterBrandForm.idRemoveList[i] 
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
                List<TypeBrandDTO> list = typeBrandRepository.GetTypeBrand();
                for(int i = 0; i < list.Count; i++)
                {
                    var typeBrandDTO = new TypeBrandEditDTO()
                    {
                        BrandTechnicsId = id,
                        TypeTechnicsId = list[i].TypeTechnicsId
                    };
                    typeBrandRepository.RemoveTypeBrand(typeBrandDTO);
                }
                UpdateTable();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTable()
        {
            List<BrandTechnicDTO> list = brandTechnicRepository.GetBrandTechnics();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["NameBrandTechnic"].HeaderText = "Название";
            dataGridView1.Columns["NameBrandTechnic"].Width = dataGridView1.Width;
        }
    }
}
