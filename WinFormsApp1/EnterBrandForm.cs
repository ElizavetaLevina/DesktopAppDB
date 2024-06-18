using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class EnterBrandForm : Form
    {
        public bool newEntry = false;
        public string name;
        public int id;
        public List<int>? idList = [];
        public List<int>? idRemoveList = [];
        BrandTechnicRepository brandTechnicRepository = new();
        TypeTechnicRepository typeTechnicRepository = new();
        TypeBrandRepository typeBrandRepository = new();
        public EnterBrandForm(string _name, bool _newEntry = true, int _id = 0)
        {
            InitializeComponent();
            name = _name;
            newEntry = _newEntry;
            id = _id;
            UpdateComboBox(name);

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length == 0)
            {
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                warning.ShowDialog();

                if (nameTextBox.Text.Length == 0)
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;
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

        private void EnterBrandForm_Activated(object sender, EventArgs e)
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

                    switch (name)
                    {
                        case "type":
                            var listBrand = brandTechnicRepository.GetBrandTechnics(whole: false, name: comboBoxSecondName.Text);
                            id = listBrand[0].Id;
                            break;
                        case "brand":
                            var listType = typeTechnicRepository.GetTypeTechnics(whole: false, name: comboBoxSecondName.Text);
                            id = listType[0].Id;
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
                
                switch (name)
                {
                    case "type":
                        var listBrand = brandTechnicRepository.GetBrandTechnics(whole: false, name: comboBoxSecondName.Text);
                        id = listBrand[0].Id;
                        break;
                    case "brand":
                        var listType = typeTechnicRepository.GetTypeTechnics(whole: false, name: comboBoxSecondName.Text);
                        id = listType[0].Id;
                        break;
                }

                idList?.Remove(id);
                idRemoveList?.Add(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            switch (name)
            {
                case "type":
                    labelNameInList.Text = String.Format("Фирмы-производители для {0}", nameTextBox.Text);
                    break;
                case "brand":
                    labelNameInList.Text = String.Format("Типы устройств для {0}", nameTextBox.Text);
                    break;
            }
        }

        private void LinkLabelChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string _name = "";
            string secondName = "";
            string nameInList = "";
            switch (name)
            {
                case "type":
                    _name = "brand";
                    secondName = "Тип устройства";
                    nameInList = "Типы устройств для ";
                    break;
                case "brand":
                    _name = "type";
                    secondName = "Фирма-производитель";
                    nameInList = "Фирмы-производители для ";
                    break;
            }
            EnterBrandForm enterBrandForm = new(_name)
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelSecondName = secondName,
                LabelNameInList = nameInList
            };
            
            if (enterBrandForm.ShowDialog() == DialogResult.OK)
            {
                switch (name)
                {
                    case "type":
                        if (!brandTechnicRepository.GetBrandTechnics(whole: false, name: enterBrandForm.NameTextBox).Any())
                        {
                            Task.Run(async () =>
                            {
                                var brandTechnicDTO = new BrandTechnicEditDTO() { Id = 0, Name = enterBrandForm.NameTextBox };
                                await brandTechnicRepository.SaveBrandTechnicAsync(brandTechnicDTO);
                            });
                        }
                        if (enterBrandForm.idList != null)
                        {
                            for (int i = 0; i < enterBrandForm.idList.Count; i++)
                            {
                                if (!typeBrandRepository.GetTypeBrand(idBrand: id, idType: enterBrandForm.idList[i]).Any())
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
                        if (enterBrandForm.idRemoveList != null)
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
                        break;
                    case "brand":
                        if (!typeTechnicRepository.GetTypeTechnics(whole: false, name: enterBrandForm.NameTextBox).Any())
                        {
                            Task.Run(async () =>
                            {
                                var typeTechnicDTO = new TypeTechnicEditDTO() { Id = 0, Name = enterBrandForm.NameTextBox };
                                await typeTechnicRepository.SaveTypeTechnicAsync(typeTechnicDTO);
                            });

                        }
                        if (enterBrandForm.idList != null)
                        {
                            for (int i = 0; i < enterBrandForm.idList.Count; i++)
                            {
                                if (!typeBrandRepository.GetTypeBrand(idBrand: enterBrandForm.idList[i], idType: id).Any())
                                {
                                    int brandId = enterBrandForm.idList[i];
                                    Task.Run(async () =>
                                    {
                                        var typeBrandDTO = new TypeBrandEditDTO()
                                        {
                                            BrandTechnicsId = brandId,
                                            TypeTechnicsId = id
                                        };
                                        await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                                    });
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
                                    TypeTechnicsId = id
                                };
                                typeBrandRepository.RemoveTypeBrand(typeBrandDTO);
                            }
                        }
                        break;
                }
                UpdateComboBox(name);
            }
        }

        private void UpdateComboBox(string name)
        {
            comboBoxSecondName.DataSource = null;
            comboBoxSecondName.Items.Clear();
            switch (name)
            {
                case "type":
                    comboBoxSecondName.ValueMember = "Id";
                    comboBoxSecondName.DisplayMember = "NameBrandTechnic";
                    comboBoxSecondName.DataSource = brandTechnicRepository.GetBrandTechnics();
                    if (!newEntry)
                    {
                        var list = typeBrandRepository.GetTypeBrand(idType: id);
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (listBox1.Items.IndexOf(list[i].BrandTechnic?.NameBrandTechnic) < 0)
                            {
                                listBox1.Items.Add(list[i].BrandTechnic?.NameBrandTechnic);
                                idList?.Add(list[i].BrandTechnicsId);
                            }
                        }
                    }
                    break;
                case "brand":
                    comboBoxSecondName.ValueMember = "Id";
                    comboBoxSecondName.DisplayMember = "NameTypeTechnic";
                    comboBoxSecondName.DataSource = typeTechnicRepository.GetTypeTechnics();
                    if (!newEntry)
                    {
                        var list = typeBrandRepository.GetTypeBrand(idBrand: id); 
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (listBox1.Items.IndexOf(list[i].TypeTechnic?.NameTypeTechnic) < 0)
                            {
                                listBox1.Items.Add(list[i].TypeTechnic?.NameTypeTechnic);
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
