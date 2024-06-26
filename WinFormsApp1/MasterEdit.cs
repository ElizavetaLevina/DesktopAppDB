﻿using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class MasterEdit : Form
    {
        public bool newMaster;
        public int id = 0;
        MasterRepository masterRepository = new();
        public MasterEdit(bool addMaster = false, int idMaster = 0)
        {
            InitializeComponent();
            newMaster = addMaster;
            id = idMaster;
        }

        private void TrackBarPercent_Scroll(object sender, EventArgs e)
        {
            labelPercent.Text = trackBarPercent.Value.ToString();
        }

        private void AddMasterForm_Activated(object sender, EventArgs e)
        {
            if(!newMaster)
            {
                var masterDTO = masterRepository.GetMaster(id);

                textBoxName.Text = masterDTO.NameMaster;
                textBoxName.SelectAll();
                textBoxAddress.Text = masterDTO.Address;
                textBoxNumberPhone.Text = masterDTO.NumberPhone;
                buttonAdd.Text = "Изменить данные";

                switch (masterDTO.TypeSalary)
                {
                    case "rate":
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
                    case "percentMaster":
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
                    case "percentOrganization":
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
                string typeSalary = "";
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
                    Id = id,
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
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }
    }
}
