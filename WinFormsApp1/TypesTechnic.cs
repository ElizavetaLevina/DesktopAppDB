using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class TypesTechnic : Form
    {
        TypeTechnicRepository typeTechnicRepository = new();
        TypeBrandRepository typeBrandRepository = new();
        public TypesTechnic()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void BtnAddDevice_Click(object sender, EventArgs e)
        {
            BrandAndTypeEdit brandAndTypeEdit = new(NameTableToEditEnum.TypeTechnic)
            {
                StartPosition = FormStartPosition.CenterParent,
                Text = "Добавить тип устройства",
                LabelSecondName = "Фирма-производитель",
                LabelNameInList = "Фирмы-производители для "
            };

            if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
            {
                int typeTechnicId = 0;
                var task = Task.Run(async () =>
                {
                    var typeTechnicDTO = new TypeTechnicEditDTO() { Id = 0, Name = brandAndTypeEdit.NameTextBox };
                    typeTechnicId = await typeTechnicRepository.SaveTypeTechnicAsync(typeTechnicDTO);
                });
                task.Wait();

                if (brandAndTypeEdit.idList != null)
                {
                    foreach (var brandId in brandAndTypeEdit.idList)
                    {
                        var typeBrandDTO = new TypeBrandEditDTO()
                        {
                            BrandTechnicsId = brandId,
                            TypeTechnicsId = typeTechnicId
                        };
                        task = Task.Run(async () =>
                        {
                            await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                        });
                        task.Wait();
                    }
                }
                UpdateTable();
            }
        }

        private void BtnChangeDevice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int typeTechnicId = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[nameof(TypeTechnicDTO.Id)].Value);
                string? name = dataGridView1.Rows[numberRow].Cells[nameof(TypeTechnicDTO.NameTypeTechnic)].Value.ToString();
                List<TypeBrandDTO> list = typeBrandRepository.GetTypeBrand();
                BrandAndTypeEdit brandAndTypeEdit = new(NameTableToEditEnum.TypeTechnic, false, typeTechnicId)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Изменение типа устройства",
                    BtnText = "Сохранить",
                    NameTextBox = name,
                    LabelSecondName = "Фирма-производитель",
                    LabelNameInList = String.Format("Фирмы-производители {0}", name)
                };

                if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
                {
                    var task = Task.Run(async () =>
                    {
                        var typeTechnicDTO = new TypeTechnicEditDTO() { Id = typeTechnicId, Name = brandAndTypeEdit.NameTextBox };
                        await typeTechnicRepository.SaveTypeTechnicAsync(typeTechnicDTO);
                    });
                    task.Wait();

                    if (brandAndTypeEdit.idList != null)
                    {
                        foreach(var brandId in brandAndTypeEdit.idList)
                        {
                            if (!list.Any(a => a.BrandTechnicsId == brandId && a.TypeTechnicsId == typeTechnicId))
                            {
                                task = Task.Run(async () =>
                                {
                                    var typeBrandDTO = new TypeBrandEditDTO()
                                    {
                                        BrandTechnicsId = brandId,
                                        TypeTechnicsId = typeTechnicId
                                    };
                                    await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                                });
                                task.Wait();
                            }
                        }
                    }
                    if (brandAndTypeEdit.idRemoveList != null)
                    {
                        foreach(var brandId in brandAndTypeEdit.idRemoveList)
                        {
                            var typeBrandDTO = new TypeBrandEditDTO()
                            {
                                BrandTechnicsId = brandId,
                                TypeTechnicsId = typeTechnicId
                            };
                            typeBrandRepository.RemoveTypeBrand(typeBrandDTO);
                        }
                    }
                    UpdateTable();
                }
            }
        }

        private void BtnDeleteDevice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int typeTechnicId = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[nameof(TypeTechnicDTO.Id)].Value);
                var typeTechnicDTO = new TypeTechnicEditDTO() { Id = typeTechnicId };
                typeTechnicRepository.RemoveTypeTechnic(typeTechnicDTO);
                UpdateTable();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateTable()
        {
            List<TypeTechnicDTO> list= typeTechnicRepository.GetTypesTechnic();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[nameof(TypeTechnicDTO.Id)].Visible = false;
            dataGridView1.Columns[nameof(TypeTechnicDTO.NameTypeTechnic)].HeaderText = "Тип устройства";
            dataGridView1.Columns[nameof(TypeTechnicDTO.NameTypeTechnic)].Width = dataGridView1.Width;
        }
    }
}
