using WinFormsApp1.Helpers;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class View : Form
    {
        IOrdersLogic ordersLogic;
        public View(IOrdersLogic _ordersLogic)
        {
            ordersLogic = _ordersLogic;
            InitializeComponent();
            InitializeElementsForm();
        }

        private void InitializeElementsForm()
        {
            textBoxFirstLevel.Text = Properties.Settings.Default.FirstLevelText;
            textBoxSecondLevelFrom.Text = Properties.Settings.Default.FirstLevelText;
            textBoxSecondLevelBefore.Text = Properties.Settings.Default.SecondLevelText;
            textBoxThirdLevel.Text = Properties.Settings.Default.SecondLevelText;
            buttonFirstColor.BackColor = Properties.Settings.Default.FirstLevelColor;
            buttonSecondColor.BackColor = Properties.Settings.Default.SecondLevelColor;
            buttonThirdColor.BackColor = Properties.Settings.Default.ThirdLevelColor;
        }

        private void ButtonFirstColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = buttonFirstColor.BackColor;
            colorDialog1.ShowDialog();
            buttonFirstColor.BackColor = colorDialog1.Color;
        }

        private void ButtonSecondColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = buttonSecondColor.BackColor;
            colorDialog1.ShowDialog();
            buttonSecondColor.BackColor = colorDialog1.Color;
        }

        private void ButtonThirdColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = buttonThirdColor.BackColor;
            colorDialog1.ShowDialog();
            buttonThirdColor.BackColor = colorDialog1.Color;
        }

        private async void ButtonSave_ClickAsync(object sender, EventArgs e)
        {
            Warning warning = new();
            if (string.IsNullOrEmpty(textBoxFirstLevel.Text) || string.IsNullOrEmpty(textBoxSecondLevelFrom.Text) &&
                string.IsNullOrEmpty(textBoxSecondLevelBefore.Text) || string.IsNullOrEmpty(textBoxThirdLevel.Text))
            {
                warning.LabelText = "Не все поля заполнены!";
                warning.ShowDialog();
                return;
            }
            else if (Convert.ToInt32(textBoxFirstLevel.Text) >=
                Convert.ToInt32(textBoxSecondLevelBefore.Text))
            {
                warning.LabelText = "Поле хранение менее должно быть меньше, чем поле хранение более!";
                warning.ShowDialog();
                return;
            }
            Properties.Settings.Default.FirstLevelColor = buttonFirstColor.BackColor;
            Properties.Settings.Default.SecondLevelColor = buttonSecondColor.BackColor;
            Properties.Settings.Default.ThirdLevelColor = buttonThirdColor.BackColor;
            Properties.Settings.Default.FirstLevelText = textBoxFirstLevel.Text;
            Properties.Settings.Default.SecondLevelText = textBoxSecondLevelBefore.Text;
            Properties.Settings.Default.Save();

            var ordersDTO = ordersLogic.GetOrders();
            foreach (var order in ordersDTO)
            {
                order.ColorRow = ColorTranslator.ToHtml(ColorsRowsHelper.ColorDefinition(order));
                await ordersLogic.SaveOrderAsync(order);
            }
            Close();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBoxFirstLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void TextBoxSecondLevelBefore_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void TextBoxFirstLevel_TextChanged(object sender, EventArgs e)
        {
            textBoxSecondLevelFrom.Text = textBoxFirstLevel.Text;
        }

        private void TextBoxSecondLevelBefore_TextChanged(object sender, EventArgs e)
        {
            textBoxThirdLevel.Text = textBoxSecondLevelBefore.Text;
        }

        private void View_Load(object sender, EventArgs e)
        {

        }
    }
}
