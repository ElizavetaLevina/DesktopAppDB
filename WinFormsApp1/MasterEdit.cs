using System.Net;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic;
using WinFormsApp1.Model;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class MasterEdit : Form
    {
        public bool newMaster;
        public int idMaster;
        MastersLogic mastersLogic = new();
        MasterEditDTO masterDTO = new();
        MasterRepository masterRepository = new();
        public MasterEdit(bool addMaster = false, int _idMaster = 0)
        {
            InitializeComponent();
            newMaster = addMaster;
            idMaster = _idMaster;
        }

        private void TrackBarPercent_Scroll(object sender, EventArgs e)
        {
            labelPercent.Text = trackBarPercent.Value.ToString();
        }

        private void AddMasterForm_Activated(object sender, EventArgs e)
        {
            linkLabelRateEdit.Visible = !newMaster;
            if (!newMaster)
            {
                masterDTO = mastersLogic.GetMaster(idMaster);

                textBoxName.Text = masterDTO.NameMaster;
                textBoxName.SelectAll();
                textBoxAddress.Text = masterDTO.Address;
                textBoxNumberPhone.Text = masterDTO.NumberPhone;
                buttonAdd.Text = "Изменить данные";
                
                switch (masterDTO.TypeSalary)
                {
                    case TypeSalaryEnum.rate:
                        radioButtonRate.Checked = true;
                        radioButtonProfitMaster.Checked = false;
                        radioButtonProfitOrganization.Checked = false;
                        textBoxRate.Enabled = true;
                        textBoxRate.Text = masterDTO.Rate.ToString();
                        labelRate.Enabled = true;
                        trackBarPercent.Enabled = false;
                        labelPercent.Enabled = false;
                        labelSymbolPercent.Enabled = false;
                        break;
                    case TypeSalaryEnum.percentMaster:
                        radioButtonRate.Checked = false;
                        radioButtonProfitMaster.Checked = true;
                        radioButtonProfitOrganization.Checked = false;
                        textBoxRate.Enabled = false;
                        labelRate.Enabled = false;
                        trackBarPercent.Enabled = true;
                        trackBarPercent.Value = masterDTO.Rate;
                        labelPercent.Enabled = true;
                        labelPercent.Text = masterDTO.Rate.ToString();
                        labelSymbolPercent.Enabled = true;
                        break;
                    case TypeSalaryEnum.percentOrganization:
                        radioButtonRate.Checked = false;
                        radioButtonProfitMaster.Checked = false;
                        radioButtonProfitOrganization.Checked = true;
                        textBoxRate.Enabled = false;
                        labelRate.Enabled = false;
                        trackBarPercent.Enabled = true;
                        trackBarPercent.Value = masterDTO.Rate;
                        labelPercent.Enabled = true;
                        labelPercent.Text = masterDTO.Rate.ToString();
                        labelSymbolPercent.Enabled = true;
                        break;
                }
            }
        }

        private void RadioButtonRate_Click(object sender, EventArgs e)
        {
            trackBarPercent.Enabled = false;
            labelPercent.Enabled = false;
            labelSymbolPercent.Enabled = false;
            textBoxRate.Enabled = true;
            labelRate.Enabled = true;
        }

        private void RadioButtonProfitMaster_Click(object sender, EventArgs e)
        {
            trackBarPercent.Enabled = true;
            labelPercent.Enabled = true;
            labelSymbolPercent.Enabled = true;
            textBoxRate.Enabled = false;
            labelRate.Enabled = false;
        }

        private void RadioButtonProfitOrganization_Click(object sender, EventArgs e)
        {
            trackBarPercent.Enabled = true;
            labelPercent.Enabled = true;
            labelSymbolPercent.Enabled = true;
            textBoxRate.Enabled = false;
            labelRate.Enabled = false;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (radioButtonRate.Checked && textBoxRate.TextLength == 0)
            {
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                warning.ShowDialog();
            }
            else
            {
                masterDTO.NameMaster = textBoxName.Text;
                masterDTO.Address = textBoxAddress.Text;
                masterDTO.NumberPhone = textBoxNumberPhone.Text;
                if (radioButtonRate.Checked)
                {
                    masterDTO.TypeSalary = TypeSalaryEnum.rate;
                    masterDTO.Rate = Convert.ToInt32(textBoxRate.Text);
                }
                else if (radioButtonProfitMaster.Checked)
                {
                    masterDTO.TypeSalary = TypeSalaryEnum.percentMaster;
                    masterDTO.Rate = Convert.ToInt32(labelPercent.Text);

                }
                else if (radioButtonProfitOrganization.Checked)
                {
                    masterDTO.TypeSalary = TypeSalaryEnum.percentOrganization;
                    masterDTO.Rate = Convert.ToInt32(labelPercent.Text);
                }
                mastersLogic.SaveMaster(masterDTO);
            }
            Close();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBoxRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void LinkLabelRateEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RateMasterEdit rateMasterEdit = new(idMaster) 
            {
                StartPosition = FormStartPosition.CenterParent
            };
            rateMasterEdit.ShowDialog();
        }
    }
}
