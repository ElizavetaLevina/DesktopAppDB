using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class MasterEdit : Form
    {
        public bool newMaster;
        public int idMaster;
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
                var masterDTO = masterRepository.GetMaster(idMaster);
                var typeSalary = (TypeSalaryEnum)System.Enum.Parse(typeof(TypeSalaryEnum), masterDTO.TypeSalary);

                textBoxName.Text = masterDTO.NameMaster;
                textBoxName.SelectAll();
                textBoxAddress.Text = masterDTO.Address;
                textBoxNumberPhone.Text = masterDTO.NumberPhone;
                buttonAdd.Text = "Изменить данные";
                
                switch (typeSalary)
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
                string typeSalary = string.Empty;
                int rate = 0;

                if (radioButtonRate.Checked)
                {
                    typeSalary = "rate";
                    rate = Convert.ToInt32(textBoxRate.Text);
                }
                else if (radioButtonProfitMaster.Checked)
                {
                    typeSalary = "percentMaster";
                    rate = Convert.ToInt32(labelPercent.Text);

                }
                else if (radioButtonProfitOrganization.Checked)
                {
                    typeSalary = "percentOrganization";
                    rate = Convert.ToInt32(labelPercent.Text);
                }

                var masterDTO = new MasterEditDTO()
                {
                    Id = idMaster,
                    NameMaster = textBoxName.Text,
                    Address = textBoxAddress.Text,
                    NumberPhone = textBoxNumberPhone.Text,
                    TypeSalary = typeSalary,
                    Rate = rate
                };

                var task = Task.Run(async () =>
                {
                    await masterRepository.SaveMasterAsync(masterDTO);
                });
                task.Wait();
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
