using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class AddDevice : Form
    {
        private int idKey;
        public AddDevice()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void BtnAddDevice_Click(object sender, EventArgs e)
        {
            EnterBrandForm enterBrandForm = new("type", true, 0)
            {
                StartPosition = FormStartPosition.CenterParent,
                Text = "Добавить тип устройства",
                LabelSecondName = "Фирма-производитель",
                LabelNameInList = "Фирмы-производители для "
            };
            enterBrandForm.ShowDialog();
            if (enterBrandForm.Add)
            {
                CRUD.AddAsyncTypeTechnic(idKey, enterBrandForm.NameTextBox);

                if (enterBrandForm.idList != null)
                {
                    for (int i = 0; i < enterBrandForm.idList.Count; i++)
                    {
                        CRUD.AddAsyncTypeBrand(enterBrandForm.idList[i], idKey);
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
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                string name = dataGridView1.Rows[numberRow].Cells[1].Value.ToString();
                EnterBrandForm enterBrandForm = new("type", false, id)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Изменение типа устройства",
                    BtnText = "Изменить",
                    NameTextBox = name,
                    LabelSecondName = "Фирма-производитель",
                    LabelNameInList = "Фирмы-производители " + name
                };
                enterBrandForm.ShowDialog();

                if (enterBrandForm.Add)
                {
                    CRUD.ChangeTypeTechnic(id, enterBrandForm.NameTextBox);
                    Context context = new();
                    if (enterBrandForm.idList != null)
                    {
                        for (int i = 0; i < enterBrandForm.idList.Count; i++)
                        {
                            if(!context.TypeBrands.Any(a => a.TypeTechnicsId == id &&
                            a.BrandTechnicsId == enterBrandForm.idList[i]))
                            {
                                CRUD.AddAsyncTypeBrand(enterBrandForm.idList[i], id);
                            }                            
                        }
                    }
                    if (enterBrandForm.idRemoveList != null)
                    {
                        for (int i = 0; i < enterBrandForm.idRemoveList.Count; i++)
                        {
                            CRUD.RemoveTypeBrand(enterBrandForm.idRemoveList[i], id);
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
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                CRUD.RemoveTypeTechnic(id);
                Context context = new();
                var list = context.TypeBrands.Where(i => i.TypeTechnicsId == id).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    CRUD.RemoveTypeBrand(list[i].BrandTechnicsId, id);
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
            using Context context = new();
            dataGridView1.DataSource = context.TypeTechnices.ToList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Тип устройства";
            dataGridView1.Columns[1].Width = 340;
            if (context.TypeTechnices.Any())
            {
                idKey = context.TypeTechnices.OrderBy(i => i.Id).Last().Id;
                idKey++;
            }
            else { idKey = 1; }
        }
    }
}
