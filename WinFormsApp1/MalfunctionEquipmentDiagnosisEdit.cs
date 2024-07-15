﻿using WinFormsApp1.Enum;

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

        private void TextBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            switch (status)
            {
                case NameTableToEditEnum.Malfunction:
                    if (textBoxName.Text != "" && textBoxPrice.Text != "")
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        warning.ShowDialog();
                    break;
                case NameTableToEditEnum.Diagnosis:
                    if (textBoxName.Text != "")
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        warning.ShowDialog();
                    break;
                case NameTableToEditEnum.Equipment:
                    if (textBoxName.Text != "")
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        warning.ShowDialog();
                    break;
            }
            
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
