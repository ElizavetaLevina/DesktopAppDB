﻿using System.IO.Ports;
using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class MessageToClient : Form
    {
        IClientsLogic clientsLogic;
        ClientEditDTO clientDTO;
        public MessageToClient(IClientsLogic _clientsLogic)
        {
            clientsLogic = _clientsLogic;
            InitializeComponent();
        }

        public async void InitializeClientAsync(string idClient)
        {
            clientDTO = await clientsLogic.GetClientAsync(idClient);
            textBoxPhone.Text = clientDTO.IdClient;
        }


        private void Item1_Click(object sender, EventArgs e)
        {
            textBoxPhone.Text = clientDTO.IdClient;
        }

        private void Item2_Click(object sender, EventArgs e)
        {
            textBoxPhone.Text = clientDTO.NumberSecondPhone;
        }

        private void ButtonChangeNumber_Click(object sender, EventArgs e)
        {
            contextMenu.Show(MousePosition);
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            Warning warning = new();
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
            Close();
        }
    }
}
