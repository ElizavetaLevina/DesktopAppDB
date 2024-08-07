﻿using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class BrandAndTypeEdit : Form
    {
        public bool newEntry = false;
        NameTableToEditEnum nameTable;
        public int id;
        public List<int>? idList = [];
        public List<int>? idRemoveList = [];
        BrandTechnicRepository brandTechnicRepository = new();
        TypeTechnicRepository typeTechnicRepository = new();
        TypeBrandRepository typeBrandRepository = new();
        public BrandAndTypeEdit(NameTableToEditEnum _nameTable, bool _newEntry = true, int _id = 0)
        {
            InitializeComponent();
            nameTable = _nameTable;
            newEntry = _newEntry;
            id = _id;
            UpdateComboBox(nameTable);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                label1.ForeColor = Color.Red;
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                warning.ShowDialog();
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BrandAndTypeEdit_Activated(object sender, EventArgs e)
        {
            nameTextBox.Focus();
            nameTextBox.SelectAll();
        }

        private void LinkLabelAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!listBox1.Items.Contains(comboBoxSecondName.Text))
                {
                    int id = 0;
                    listBox1.Items.Add(comboBoxSecondName.Text);

                    switch (nameTable)
                    {
                        case NameTableToEditEnum.TypeTechnic:
                            var brand = brandTechnicRepository.GetBrandTechnic(comboBoxSecondName.Text);
                            id = brand.Id;
                            break;
                        case NameTableToEditEnum.BrandTechnic:
                            var type = typeTechnicRepository.GetTypeTechnic(comboBoxSecondName.Text);
                            id = type.Id;
                            break;
                    }

                    idList?.Add(id);
                    if (idRemoveList.Contains(id))
                        idRemoveList.Remove(id);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LinkLabelDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int id = 0;
                listBox1.Items.Remove(comboBoxSecondName.Text);
                
                switch (nameTable)
                {
                    case NameTableToEditEnum.TypeTechnic:
                        var brand = brandTechnicRepository.GetBrandTechnic(comboBoxSecondName.Text);
                        id = brand.Id;
                        break;
                    case NameTableToEditEnum.BrandTechnic:
                        var listType = typeTechnicRepository.GetTypeTechnic(comboBoxSecondName.Text);
                        id = listType.Id;
                        break;
                }

                idList?.Remove(id);
                idRemoveList?.Add(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            switch (nameTable)
            {
                case NameTableToEditEnum.TypeTechnic:
                    labelNameInList.Text = String.Format("Фирмы-производители для {0}", nameTextBox.Text);
                    break;
                case NameTableToEditEnum.BrandTechnic:
                    labelNameInList.Text = String.Format("Типы устройств для {0}", nameTextBox.Text);
                    break;
            }
        }

        private void LinkLabelChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms.OfType<BrandAndTypeEdit>().Count() <= 2)
            {
                NameTableToEditEnum _nameTable = NameTableToEditEnum.TypeTechnic;
                string secondName = string.Empty;
                string nameInList = string.Empty;
                string textForm = string.Empty;
                switch (nameTable)
                {
                    case NameTableToEditEnum.TypeTechnic:
                        _nameTable = NameTableToEditEnum.BrandTechnic;
                        secondName = "Фирма-производитель";
                        nameInList = "Фирмы-производители для ";
                        textForm = "Добавление новой фирмы";
                        break;
                    case NameTableToEditEnum.BrandTechnic:
                        _nameTable = NameTableToEditEnum.TypeTechnic;
                        secondName = "Тип устройства";
                        nameInList = "Типы устройств для ";
                        textForm = "Добавление типа устройства";
                        break;
                }
                BrandAndTypeEdit brandAndTypeEdit = new(_nameTable)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelSecondName = secondName,
                    LabelNameInList = nameInList,
                    Text = textForm
                };

                if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
                {
                    switch (nameTable)
                    {
                        case NameTableToEditEnum.TypeTechnic:
                            var task = Task.Run(async () =>
                            {
                                var brandTechnicDTO = new BrandTechnicEditDTO() { Id = 0, Name = brandAndTypeEdit.NameTextBox };
                                await brandTechnicRepository.SaveBrandTechnicAsync(brandTechnicDTO);
                            });
                            task.Wait();

                            if (brandAndTypeEdit.idList != null)
                            {
                                for (int i = 0; i < brandAndTypeEdit.idList.Count; i++)
                                {
                                    if (!typeBrandRepository.GetTypeBrand(idBrand: id, idType: brandAndTypeEdit.idList[i]).Any())
                                    {
                                        int typeId = brandAndTypeEdit.idList[i];
                                        task = Task.Run(async () =>
                                        {
                                            var typeBrandDTO = new TypeBrandEditDTO()
                                            {
                                                BrandTechnicsId = id,
                                                TypeTechnicsId = typeId
                                            };
                                            await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                                        });
                                        task.Wait();
                                    }
                                }
                            }
                            if (brandAndTypeEdit.idRemoveList != null)
                            {
                                for (int i = 0; i < brandAndTypeEdit.idRemoveList.Count; i++)
                                {
                                    var typeBrandDTO = new TypeBrandEditDTO()
                                    {
                                        BrandTechnicsId = id,
                                        TypeTechnicsId = brandAndTypeEdit.idRemoveList[i]
                                    };
                                    typeBrandRepository.RemoveTypeBrand(typeBrandDTO);
                                }
                            }
                            break;
                        case NameTableToEditEnum.BrandTechnic:
                            task = Task.Run(async () =>
                            {
                                var typeTechnicDTO = new TypeTechnicEditDTO() { Id = 0, Name = brandAndTypeEdit.NameTextBox };
                                await typeTechnicRepository.SaveTypeTechnicAsync(typeTechnicDTO);
                            });
                            task.Wait();

                            if (brandAndTypeEdit.idList != null)
                            {
                                for (int i = 0; i < brandAndTypeEdit.idList.Count; i++)
                                {
                                    if (!typeBrandRepository.GetTypeBrand(idBrand: brandAndTypeEdit.idList[i], idType: id).Any())
                                    {
                                        int brandId = brandAndTypeEdit.idList[i];
                                        task = Task.Run(async () =>
                                        {
                                            var typeBrandDTO = new TypeBrandEditDTO()
                                            {
                                                BrandTechnicsId = brandId,
                                                TypeTechnicsId = id
                                            };
                                            await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                                        });
                                        task.Wait();
                                    }
                                }
                            }
                            if (brandAndTypeEdit.idRemoveList != null)
                            {
                                for (int i = 0; i < brandAndTypeEdit.idRemoveList.Count; i++)
                                {
                                    var typeBrandDTO = new TypeBrandEditDTO()
                                    {
                                        BrandTechnicsId = brandAndTypeEdit.idRemoveList[i],
                                        TypeTechnicsId = id
                                    };
                                    typeBrandRepository.RemoveTypeBrand(typeBrandDTO);
                                }
                            }
                            break;
                    }
                    UpdateComboBox(nameTable);
                }
            }
        }

        private void UpdateComboBox(NameTableToEditEnum nameTable)
        {
            comboBoxSecondName.DataSource = null;
            comboBoxSecondName.Items.Clear();
            switch (nameTable)
            {
                case NameTableToEditEnum.TypeTechnic:
                    comboBoxSecondName.ValueMember = "Id";
                    comboBoxSecondName.DisplayMember = "NameBrandTechnic";
                    comboBoxSecondName.DataSource = brandTechnicRepository.GetBrandsTechnic();
                    if (!newEntry)
                    {
                        var list = typeBrandRepository.GetTypeBrand(idType: id);
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (listBox1.Items.IndexOf(list[i].BrandTechnic?.Name) < 0)
                            {
                                listBox1.Items.Add(list[i].BrandTechnic?.Name);
                                idList?.Add(list[i].BrandTechnicsId);
                            }
                        }
                    }
                    break;
                case NameTableToEditEnum.BrandTechnic:
                    comboBoxSecondName.ValueMember = "Id";
                    comboBoxSecondName.DisplayMember = "NameTypeTechnic";
                    comboBoxSecondName.DataSource = typeTechnicRepository.GetTypesTechnic();
                    if (!newEntry)
                    {
                        var list = typeBrandRepository.GetTypeBrand(idBrand: id); 
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (listBox1.Items.IndexOf(list[i].TypeTechnic?.Name) < 0)
                            {
                                listBox1.Items.Add(list[i].TypeTechnic?.Name);
                                idList?.Add(list[i].TypeTechnicsId);
                            }
                        }
                    }
                    break;
            }
        }

        public string BtnText
        {
            get { return this.btnAdd.Text; }
            set { this.btnAdd.Text = value; }
        }

        public string NameTextBox
        {
            get { return this.nameTextBox.Text; }
            set { this.nameTextBox.Text = value; }
        }

        public string LabelSecondName
        {
            get { return this.labelSecondName.Text; }
            set { this.labelSecondName.Text = value; }
        }

        public string LabelNameInList
        {
            get { return this.labelNameInList.Text; }
            set { this.labelNameInList.Text = value; }
        }
    }
}
