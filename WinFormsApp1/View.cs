using WinFormsApp1.Model;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
            textBoxFirstLevel.Text = Properties.Settings.Default.FirstLevelText;
            textBoxSecondLevelFrom.Text = Properties.Settings.Default.FirstLevelText;
            textBoxSecondLevelBefore.Text = Properties.Settings.Default.SecondLevelText;
            textBoxThirdLevel.Text = Properties.Settings.Default.SecondLevelText;
            button1.BackColor = Properties.Settings.Default.FirstLevelColor;
            button2.BackColor = Properties.Settings.Default.SecondLevelColor;
            button3.BackColor = Properties.Settings.Default.ThirdLevelColor;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button1.BackColor;
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button2.BackColor;
            colorDialog1.ShowDialog();
            button2.BackColor = colorDialog1.Color;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button3.BackColor;
            colorDialog1.ShowDialog();
            button3.BackColor = colorDialog1.Color;
        }


        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (textBoxFirstLevel.Text == "" && textBoxSecondLevelFrom.Text == "" &&
                textBoxSecondLevelBefore.Text == "" && textBoxThirdLevel.Text == "")
            {
                warning.LabelText = "Не все поля заполнены!";
                warning.ShowDialog();
            }
            else if (Convert.ToInt32(textBoxFirstLevel.Text) >=
                Convert.ToInt32(textBoxSecondLevelBefore.Text))
            {
                warning.LabelText = "Поле хранение менее должно быть меньше, чем поле хранение более!";
                warning.ShowDialog();
            }
            else
            {
                Properties.Settings.Default.FirstLevelColor = button1.BackColor;
                Properties.Settings.Default.SecondLevelColor = button2.BackColor;
                Properties.Settings.Default.ThirdLevelColor = button3.BackColor;
                Properties.Settings.Default.FirstLevelText = textBoxFirstLevel.Text;
                Properties.Settings.Default.SecondLevelText = textBoxSecondLevelBefore.Text;
                Properties.Settings.Default.Save();

                Context context = new();
                var list = context.Orders.ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    CRUD.ChangeOrder(list[i].Id,
                        list[i].ClientId,
                        list[i].MasterId,
                        list[i].DateCreation,
                        list[i].DateStartWork,
                        list[i].DateCompleted,
                        list[i].DateIssue,
                        list[i].TypeTechnicId,
                        list[i].BrandTechnicId,
                        list[i].ModelTechnic,
                        list[i].FactoryNumber,
                        list[i].EquipmentId,
                        list[i].DiagnosisId,
                        list[i].Note,
                        list[i].InProgress,
                        list[i].Guarantee,
                        list[i].DateEndGuarantee,
                        list[i].Deleted,
                        list[i].ReturnUnderGuarantee,
                        list[i].DateReturn,
                        list[i].DateCompletedReturn,
                        list[i].DateIssueReturn,
                        list[i].Issue,
                        ColorTranslator.ToHtml(FindColor(i)),
                        list[i].DateLastCall,
                        list[i].PriceAgreed,
                        list[i].MaxPrice);
                }
                this.Close();

            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxFirstLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

        private void TextBoxSecondLevelBefore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

        private void TextBoxFirstLevel_TextChanged(object sender, EventArgs e)
        {
            textBoxSecondLevelFrom.Text = textBoxFirstLevel.Text;
        }

        private void TextBoxSecondLevelBefore_TextChanged(object sender, EventArgs e)
        {
            textBoxThirdLevel.Text = textBoxSecondLevelBefore.Text;
        }

        private Color FindColor(int id)
        {
            Context context = new();
            string status = "";
            Color color = Color.Black;
            DateTime date = DateTime.Now;
            var list = context.Orders.ToList();
            if (list[id].InProgress == true && list[id].Deleted == false &&
                list[id].MasterId != null)
            {
                status = "InRepair";
                date = list[id].DateStartWork.Value;
            }
            else if (list[id].InProgress == false && !list[id].Deleted &&
                list[id].Issue == false)
            {
                status = "Completed";
                date = list[id].DateCompleted.Value;
            }

            if (status == "InRepair" || status == "Completed")
            {
                if ((DateTime.Now - date).Days < Convert.ToInt32(textBoxFirstLevel.Text))
                {
                    color = button1.BackColor;
                }
                else if ((DateTime.Now - date).Days > Convert.ToInt32(textBoxThirdLevel.Text))
                {
                    color = button3.BackColor;
                }
                else color = button2.BackColor;
            }

            return color;

        }
    }
}
