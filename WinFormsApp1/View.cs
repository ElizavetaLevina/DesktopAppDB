﻿using WinFormsApp1.DTO;
using WinFormsApp1.Repository;
using Color = System.Drawing.Color;

namespace WinFormsApp1
{
    public partial class View : Form
    {
        OrderRepository orderRepository = new OrderRepository();
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

                var ordersDTO = orderRepository.GetOrders();
                foreach(var order in ordersDTO)
                {
                    order.ColorRow = ColorTranslator.ToHtml(FindColor(order));
                    Task.Run(async () =>
                    {
                        await orderRepository.SaveOrderAsync(order);
                    });
                }
                Close();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
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

        private Color FindColor(OrderEditDTO order)
        {
            string status = "";
            Color color = Color.Black;
            DateTime date = DateTime.Now;
            if (order.InProgress && !order.Deleted && order.MasterId != null)
            {
                status = "InRepair";
                date = order.DateStartWork.Value;
            }
            else if (!order.InProgress && !order.Deleted && !order.Issue)
            {
                status = "Completed";
                date = order.DateCompleted.Value;
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
