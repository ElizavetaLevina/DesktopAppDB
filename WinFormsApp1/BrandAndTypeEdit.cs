using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class BrandAndTypeEdit : Form
    {
        public string BtnText
        {
            get { return buttonSave.Text; }
            set { buttonSave.Text = value; }
        }
        public string NameTextBox
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }
        public string LabelSecondName
        {
            get { return labelSecondName.Text; }
            set { labelSecondName.Text = value; }
        }
        public string LabelNameInList
        {
            get { return labelNameInList.Text; }
            set { labelNameInList.Text = value; }
        }
        public NameTableToEditEnum nameTable;
        public int id = 0;
        public List<int>? idList = [];
        public List<int>? idRemoveList = [];
        IBrandsTechnicsLogic brandsTechnicsLogic;
        ITypesTechnicsLogic typesTechnicsLogic;
        ITypesBrandsLogic typesBrandsLogic;
        public BrandAndTypeEdit(IBrandsTechnicsLogic _brandsTechnicsLogic, ITypesTechnicsLogic _typesTechnicsLogic,
            ITypesBrandsLogic _typesBrandsLogic)
        {
            brandsTechnicsLogic = _brandsTechnicsLogic;
            typesTechnicsLogic = _typesTechnicsLogic;
            typesBrandsLogic = _typesBrandsLogic;
            InitializeComponent();
        }

        public async void InitializeElementsFormAsync()
        {
            switch (nameTable)
            {
                case NameTableToEditEnum.TypeTechnic:
                    var name = await typesTechnicsLogic.GetTypeTechnicNameAsync(id);
                    Text = id == 0 ? "Добавление типа устройства" : "Изменение типа устройства";
                    BtnText = "Сохранить";
                    NameTextBox = name;
                    LabelSecondName = "Фирма-производитель";
                    LabelNameInList = String.Format("Фирмы-производители {0}", name);
                    break;
                case NameTableToEditEnum.BrandTechnic:
                    name = await brandsTechnicsLogic.GetBrandTechnicNameAsync(id);
                    Text = id == 0 ? "Добавление фирмы-производителя" : "Изменение названия фирмы";
                    BtnText = "Сохранить";
                    NameTextBox = name;
                    LabelSecondName = "Тип устройства";
                    LabelNameInList = String.Format("Типы устройств для {0}", name);
                    break;
            }
            UpdateComboBoxAsync();
        }

        private async void ButtonSave_ClickAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox))
            {
                label1.ForeColor = Color.Red;
                Warning warning = new();
                warning.ShowDialog();
            }
            else
            {
                switch (nameTable)
                {
                    case NameTableToEditEnum.TypeTechnic:
                        var typeTechnicDTO = await typesTechnicsLogic.GetTypeTechnicAsync(id);
                        typeTechnicDTO.Name = NameTextBox;
                        var idTypeTechnic = await typesTechnicsLogic.SaveTypeTechnicAsync(typeTechnicDTO);
                        await typesBrandsLogic.SaveTypeBrandAsync(idList, idTypeTechnic, nameTable);
                        await typesBrandsLogic.RemoveTypeBrandByListAsync(idRemoveList, idTypeTechnic, nameTable);
                        break;
                    case NameTableToEditEnum.BrandTechnic:
                        var brandTechnicDTO = await brandsTechnicsLogic.GetBrandTechnicAsync(id);
                        brandTechnicDTO.Name = NameTextBox;
                        var idBrandTechnic = await brandsTechnicsLogic.SaveBrandTechnicAsync(brandTechnicDTO);
                        await typesBrandsLogic.SaveTypeBrandAsync(idList, idBrandTechnic, nameTable);
                        await typesBrandsLogic.RemoveTypeBrandByListAsync(idRemoveList, idBrandTechnic, nameTable);
                        break;
                }
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

        private async void LinkLabelAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                            id = await brandsTechnicsLogic.GetIdBrandTechnicAsync(comboBoxSecondName.Text);
                            break;
                        case NameTableToEditEnum.BrandTechnic:
                            id = await typesTechnicsLogic.GetIdTypeTechnicAsync(comboBoxSecondName.Text);
                            break;
                    }

                    idList?.Add(id);
                    if (idRemoveList.Contains(id))
                        idRemoveList.Remove(id);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void LinkLabelDelete_LinkClickedAsync(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int id = 0;
                listBox1.Items.Remove(comboBoxSecondName.Text);
                
                switch (nameTable)
                {
                    case NameTableToEditEnum.TypeTechnic:
                        id = await brandsTechnicsLogic.GetIdBrandTechnicAsync(comboBoxSecondName.Text);
                        break;
                    case NameTableToEditEnum.BrandTechnic:
                        id = await typesTechnicsLogic.GetIdTypeTechnicAsync(comboBoxSecondName.Text);
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
                BrandAndTypeEdit brandAndTypeEdit = Program.ServiceProvider.GetRequiredService<BrandAndTypeEdit>();
                brandAndTypeEdit.nameTable = nameTable == NameTableToEditEnum.TypeTechnic ?
                    NameTableToEditEnum.BrandTechnic : NameTableToEditEnum.TypeTechnic;
                if (brandAndTypeEdit.ShowDialog() == DialogResult.OK)
                    UpdateComboBoxAsync();
            }
        }

        private async void UpdateComboBoxAsync()
        {
            comboBoxSecondName.DataSource = null;
            comboBoxSecondName.Items.Clear();
            switch (nameTable)
            {
                case NameTableToEditEnum.TypeTechnic:
                    comboBoxSecondName.ValueMember = "Id";
                    comboBoxSecondName.DisplayMember = "NameBrandTechnic";
                    comboBoxSecondName.DataSource = await brandsTechnicsLogic.GetBrandsTechnicAsync();
                    if (id != 0)
                    {
                        var list = await typesBrandsLogic.GetTypeBrandAsync(idType: id);
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
                    comboBoxSecondName.DataSource = await typesTechnicsLogic.GetTypesTechnicAsync();
                    if (id != 0)
                    {
                        var list = await typesBrandsLogic.GetTypeBrandAsync(idBrand: id); 
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
    }
}
