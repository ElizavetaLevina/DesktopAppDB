using System.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class AddMasterForm : Form
    {
        public bool add = false;
        public int id = 0;
        public AddMasterForm(bool addMaster, int idMaster)
        {
            InitializeComponent();
            this.add = addMaster;
            this.id = idMaster;
        }

        private void TrackBarPercent_Scroll(object sender, EventArgs e)
        {
            labelPercent.Text = trackBarPercent.Value.ToString();
        }

        private void AddMasterForm_Activated(object sender, EventArgs e)
        {
            if(!add)
            {
                Context context = new();
                var list = context.Masters.Where(i => i.Id == id).ToList();

                textBoxName.Text = list[0].NameMaster;
                textBoxName.SelectAll();
                textBoxAddress.Text = list[0].Address;
                textBoxNumberPhone.Text = list[0].NumberPhone;
                buttonAdd.Text = "Изменить данные";

                switch (list[0].TypeSalary)
                {
                    case "rate":
                        radioButtonRate.Checked = true;
                        radioButtonProfitMaster.Checked = false;
                        radioButtonProfitOrganization.Checked = false;
                        textBoxRate.Enabled = true;
                        textBoxRate.Text = list[0].Rate.ToString();
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
                        trackBarPercent.Value = list[0].Rate;
                        labelPercent.Enabled = true;
                        labelPercent.Text = list[0].Rate.ToString();
                        labelSymbolPercent.Enabled = true;
                        break;
                    case "percentOrganization":
                        radioButtonRate.Checked = false;
                        radioButtonProfitMaster.Checked = false;
                        radioButtonProfitOrganization.Checked = true;
                        textBoxRate.Enabled = false;
                        labelRate.Enabled = false;
                        trackBarPercent.Enabled = true;
                        trackBarPercent.Value = list[0].Rate;
                        labelPercent.Enabled = true;
                        labelPercent.Text = list[0].Rate.ToString();
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
            else {
                int idKey = 1;
                string typeSalary = "";
                int rate = 0;
                using Context context = new();
                if (context.Masters.Any())
                {
                    idKey = context.Masters.OrderBy(i => i.Id).Last().Id;
                    idKey++;
                }
                if (radioButtonRate.Checked)
                {
                    typeSalary = "rate";
                    rate = Convert.ToInt32(textBoxRate.Text);
                } else if (radioButtonProfitMaster.Checked)
                {
                    typeSalary = "percentMaster";
                    rate = Convert.ToInt32(labelPercent.Text);

                } else if (radioButtonProfitOrganization.Checked)
                {
                    typeSalary = "percentOrganization";
                    rate = Convert.ToInt32(labelPercent.Text);
                }

                if (add)
                {
                    CRUD.AddAsyncMaster(idKey, textBoxName.Text, textBoxAddress.Text,
                        textBoxNumberPhone.Text, typeSalary, rate);
                } else
                {
                    CRUD.ChangeMaster(id, textBoxName.Text, textBoxAddress.Text,
                        textBoxNumberPhone.Text, typeSalary, rate);
                }
            }
            this.Close();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }
    }
}
