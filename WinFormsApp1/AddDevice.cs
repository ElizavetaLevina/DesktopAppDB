using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class AddDevice : Form
    {
        TypeTechnicRepository typeTechnicRepository = new();
        TypeBrandRepository typeBrandRepository = new();
        public AddDevice()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void BtnAddDevice_Click(object sender, EventArgs e)
        {
            EnterBrandForm enterBrandForm = new("type")
            {
                StartPosition = FormStartPosition.CenterParent,
                Text = "Добавить тип устройства",
                LabelSecondName = "Фирма-производитель",
                LabelNameInList = "Фирмы-производители для "
            };

            if (enterBrandForm.ShowDialog() == DialogResult.OK)
            {
                int typeTechnicId = 0;
                var task = Task.Run(async () =>
                {
                    var typeTechnicDTO = new TypeTechnicEditDTO() { Id = 0, Name = enterBrandForm.NameTextBox };
                    typeTechnicId = await typeTechnicRepository.SaveTypeTechnicAsync(typeTechnicDTO);
                });
                task.Wait();

                if (enterBrandForm.idList != null)
                {
                    foreach (var brandId in enterBrandForm.idList)
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
                int typeTechnicId = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                string? name = dataGridView1.Rows[numberRow].Cells["NameTypeTechnic"].Value.ToString();
                List<TypeBrandDTO> list = typeBrandRepository.GetTypeBrand();
                EnterBrandForm enterBrandForm = new("type", false, typeTechnicId)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Изменение типа устройства",
                    BtnText = "Сохранить",
                    NameTextBox = name,
                    LabelSecondName = "Фирма-производитель",
                    LabelNameInList = String.Format("Фирмы-производители {0}", name)
                };

                if (enterBrandForm.ShowDialog() == DialogResult.OK)
                {
                    var task = Task.Run(async () =>
                    {
                        var typeTechnicDTO = new TypeTechnicEditDTO() { Id = typeTechnicId, Name = enterBrandForm.NameTextBox };
                        await typeTechnicRepository.SaveTypeTechnicAsync(typeTechnicDTO);
                    });
                    task.Wait();

                    if (enterBrandForm.idList != null)
                    {
                        for (int i = 0; i < enterBrandForm.idList.Count; i++)
                        {
                            if (!list.Any(a => a.TypeTechnicsId == typeTechnicId && a.BrandTechnicsId == enterBrandForm.idList[i]))
                            {
                                task = Task.Run(async () =>
                                {
                                    var typeBrandDTO = new TypeBrandEditDTO()
                                    {
                                        BrandTechnicsId = enterBrandForm.idList[i],
                                        TypeTechnicsId = typeTechnicId
                                    };
                                    await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                                });
                                task.Wait();
                            }
                        }
                    }
                    if (enterBrandForm.idRemoveList != null)
                    {
                        for (int i = 0; i < enterBrandForm.idRemoveList.Count; i++)
                        {
                            var typeBrandDTO = new TypeBrandEditDTO()
                            {
                                BrandTechnicsId = enterBrandForm.idRemoveList[i],
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
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var typeTechnicDTO = new TypeTechnicEditDTO() { Id = id };
                typeTechnicRepository.RemoveTypeTechnic(typeTechnicDTO);
                List<TypeBrandDTO> list = typeBrandRepository.GetTypeBrand();
                for (int i = 0; i < list.Count; i++)
                {
                    var typeBrandDTO = new TypeBrandEditDTO()
                    {
                        BrandTechnicsId = list[i].BrandTechnicsId,
                        TypeTechnicsId = id
                    };
                    typeBrandRepository.RemoveTypeBrand(typeBrandDTO);
                }
                UpdateTable();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateTable()
        {
            List<TypeTechnicDTO> list= typeTechnicRepository.GetTypeTechnics();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["NameTypeTechnic"].HeaderText = "Тип устройства";
            dataGridView1.Columns["NameTypeTechnic"].Width = dataGridView1.Width;
        }
    }
}
