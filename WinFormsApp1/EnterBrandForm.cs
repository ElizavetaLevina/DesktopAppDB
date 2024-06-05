using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using WinFormsApp1.Model;
using Context = WinFormsApp1.Model.Context;

namespace WinFormsApp1
{
    public partial class EnterBrandForm : Form
    {
        public bool Add = false;
        public bool New = false;
        public string name;
        public int id;
        public List<int>? idList = [];
        public List<int>? idRemoveList = [];
        public EnterBrandForm(string _name, bool _New, int _id)
        {
            InitializeComponent();
            name = _name;
            New = _New;
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
                Add = true;
                this.Close();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    listBox1.Items.Add(comboBoxSecondName.Text);
                    int id = 0;
                    using (Context context = new())
                    {
                        switch (name)
                        {
                            case "type":
                                var listBrand = context.BrandTechnices.Where(i =>
                                i.NameBrandTechnic == comboBoxSecondName.Text).ToList();
                                id = listBrand[0].Id;
                                break;
                            case "brand":
                                var listType = context.TypeTechnices.Where(i =>
                                i.NameTypeTechnic == comboBoxSecondName.Text).ToList();
                                id = listType[0].Id;
                                break;

                        }
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
                listBox1.Items.Remove(comboBoxSecondName.Text);
                int id = 0;
                using (Context context = new())
                {
                    switch (name)
                    {
                        case "type":
                            var listBrand = context.BrandTechnices.Where(i =>
                            i.NameBrandTechnic == comboBoxSecondName.Text).ToList();
                            id = listBrand[0].Id;
                            break;
                        case "brand":
                            var listType = context.TypeTechnices.Where(i =>
                            i.NameTypeTechnic == comboBoxSecondName.Text).ToList();
                            id = listType[0].Id;
                            break;

                    }
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
            Context context = new();
            string _name = "";
            string secondName = "";
            string nameInList = "";
            int idKey = 0;
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
            EnterBrandForm enterBrandForm = new(_name, true, 0)
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelSecondName = secondName,
                LabelNameInList = nameInList
            };
            enterBrandForm.ShowDialog();
            if (enterBrandForm.Add)
            {
                switch (name)
                {
                    case "type":
                        if(!context.BrandTechnices.Any(a => a.NameBrandTechnic == enterBrandForm.NameTextBox))
                        {
                            idKey = context.BrandTechnices.OrderBy(i => i.Id).Last().Id + 1;
                            CRUD.AddAsyncBrandTechnic(idKey, enterBrandForm.NameTextBox);
                        }
                        if (enterBrandForm.idList != null)
                        {
                            for (int i = 0; i < enterBrandForm.idList.Count; i++)
                            {
                                if (!context.TypeBrands.Any(a => a.TypeTechnicsId == id &&
                                a.BrandTechnicsId == enterBrandForm.idList[i]))
                                {
                                    CRUD.AddAsyncTypeBrand(id, enterBrandForm.idList[i]);
                                }
                            }
                        }
                        if (enterBrandForm.idRemoveList != null)
                        {
                            for (int i = 0; i < enterBrandForm.idRemoveList.Count; i++)
                            {
                                CRUD.RemoveTypeBrand(id, enterBrandForm.idRemoveList[i]);
                            }
                        }
                        break;
                    case "brand":
                        if (!context.TypeTechnices.Any(a => a.NameTypeTechnic == enterBrandForm.NameTextBox))
                        {
                            idKey = context.TypeTechnices.OrderBy(i => i.Id).Last().Id + 1;
                            CRUD.AddAsyncTypeTechnic(idKey, enterBrandForm.NameTextBox);
                        }
                        if (enterBrandForm.idList != null)
                        {
                            for (int i = 0; i < enterBrandForm.idList.Count; i++)
                            {
                                if (!context.TypeBrands.Any(a => a.TypeTechnicsId == id &&
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
                        break;
                }
                UpdateComboBox(name);
            }
        }

        private void UpdateComboBox(string name)
        {
            Context context = new();
            comboBoxSecondName.DataSource = null;
            comboBoxSecondName.Items.Clear();
            switch (name)
            {
                case "type":
                    comboBoxSecondName.ValueMember = "Id";
                    comboBoxSecondName.DisplayMember = "NameBrandTechnic";
                    comboBoxSecondName.DataSource = context.BrandTechnices.ToList();
                    if (!New)
                    {
                        var list = context.TypeBrands.Where(i => i.TypeTechnicsId == id).ToList();
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
                    comboBoxSecondName.DataSource = context.TypeTechnices.ToList();
                    if (!New)
                    {
                        var list = context.TypeBrands.Where(i => i.BrandTechnicsId == id).ToList();
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
