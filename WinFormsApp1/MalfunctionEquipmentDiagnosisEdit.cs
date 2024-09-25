using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class MalfunctionEquipmentDiagnosisEdit : Form
    {
        NameTableToEditEnum status;
        public MalfunctionEquipmentDiagnosisEdit(NameTableToEditEnum _status)
        {
            InitializeComponent();
            status = _status;
        }

        private void Save()
        {
            Warning warning = new();
            switch (status)
            {
                case NameTableToEditEnum.Malfunction:
                    if (!string.IsNullOrEmpty(TextBoxName) && !string.IsNullOrEmpty(TextBoxPrice))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        warning.ShowDialog();
                    break;
                case NameTableToEditEnum.Diagnosis:
                    if (!string.IsNullOrEmpty(TextBoxName))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        warning.ShowDialog();
                    break;
                case NameTableToEditEnum.Equipment:
                    if (!string.IsNullOrEmpty(TextBoxName))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        warning.ShowDialog();
                    break;
            }
        }

        private void TextBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((status == NameTableToEditEnum.Diagnosis || status == NameTableToEditEnum.Equipment) && 
                e.KeyCode == Keys.Enter)
                Save();
        }

        private void TextBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Save();
        }

        public string TextBoxName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        public string TextBoxPrice
        {
            get { return textBoxPrice.Text; }
            set { textBoxPrice.Text = value; }
        }

        public bool LabelPriceVisible
        {
            get { return labelPrice.Visible; }
            set { labelPrice.Visible = value; }
        }

        public bool LabelRubVisible
        {
            get { return labelRub.Visible; }
            set { labelRub.Visible = value; }
        }

        public bool TextBoxPriceVisisble
        {
            get { return textBoxPrice.Visible; }
            set { textBoxPrice.Visible = value; }
        }
    }
}
