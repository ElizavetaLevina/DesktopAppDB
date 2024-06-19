using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class MessageToClient : Form
    {
        public int idClient;
        public MessageToClient(int id)
        {
            InitializeComponent();
            idClient = id;
            using (Context context = new())
            {
                var list = context.Clients.Where(i => i.Id == idClient).ToList();
                textBoxPhone.Text = list[0].IdClient;
            }
        }


        private void Item1_Click(object sender, EventArgs e)
        {
            using (Context context = new())
            {
                var list = context.Clients.Where(i => i.Id == idClient).ToList();
                textBoxPhone.Text = list[0].IdClient;
            }
        }

        private void Item2_Click(object sender, EventArgs e)
        {
            using (Context context = new())
            {
                var list = context.Clients.Where(i => i.Id == idClient).ToList();
                textBoxPhone.Text = list[0].NumberSecondPhone;
            }
        }

        private void ButtonChangeNumber_Click(object sender, EventArgs e)
        {
            contextMenu.Show(MousePosition);
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            try
            {
                SerialPort serialPort = new()
                {
                    PortName = textBoxPort.Text
                };
                serialPort.Open();
                serialPort.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                serialPort.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                serialPort.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                Thread.Sleep(100);
                serialPort.WriteLine("AT+CMGS=\"" + textBoxPhone.Text + "\"" + Environment.NewLine);
                Thread.Sleep(100);
                serialPort.WriteLine(textBoxMessage.Text + Environment.NewLine);
                Thread.Sleep(100);
                serialPort.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);
                var response = serialPort.ReadExisting();
                if (response.Contains("ERROR"))
                {
                    warning.LabelText = "Не удалось отправить сообщение!";
                    warning.ShowDialog();
                }
                else
                {
                    warning.LabelText = "Сообщение отправлено!";
                    warning.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                warning.LabelText = exp.Message;
                warning.ShowDialog();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
