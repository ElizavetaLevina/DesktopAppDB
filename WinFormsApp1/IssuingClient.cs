﻿using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class IssuingClient : Form
    {
        public DateTime DateIssue
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }
        public int GuaranteePeriod
        {
            get { return Convert.ToInt32(textBoxGuarantee.Text); }
            set { textBoxGuarantee.Text = value.ToString(); }
        }
        public DateTime DateEndGuarantee
        {
            get { return DateTime.Parse(labelGuaranteePeriod.Text); }
            set { labelGuaranteePeriod.Text = value.ToString(); }
        }
        public int idOrder;
        IOrdersLogic ordersLogic;
        IMalfunctionsOrdersLogic malfunctionsOrdersLogic;
        IWarehousesLogic warehousesLogic;
        OrderEditDTO orderDTO;
        public IssuingClient(IOrdersLogic _ordersLogic, IMalfunctionsOrdersLogic _malfunctionsOrdersLogic, 
            IWarehousesLogic _warehousesLogic)
        {
            ordersLogic = _ordersLogic;
            malfunctionsOrdersLogic = _malfunctionsOrdersLogic;
            warehousesLogic = _warehousesLogic;
            InitializeComponent();
        }

        public async void InitializeElementsFormAsync()
        {
            orderDTO = await ordersLogic.GetOrderAsync(idOrder);
            var malfunctionOrderDTO = await malfunctionsOrdersLogic.GetMalfunctionOrdersByIdOrderAsync(idOrder);
            var detailsDTO = await warehousesLogic.GetDetailsInOrderAsync(idOrder);

            labelPriceDetails.Text = String.Format("{0} руб.", detailsDTO.Sum(i => i.PriceSale));
            labelCountDetails.Text = String.Format("{0} шт.", detailsDTO.Count);
            labelPriceRepair.Text = malfunctionOrderDTO.Sum(i => i.Price).ToString();
            labelTotalPrice.Text = String.Format("{0} руб.", detailsDTO.Sum(i => i.PriceSale) +
                malfunctionOrderDTO.Sum(i => i.Price));
            labelGuaranteePeriod.Text = DateTime.Now.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
            labelNameClient.Text = orderDTO.Client?.IdClient;
            labelDateCreate.Text = orderDTO.DateCreation?.ToShortDateString();
            labelEquipment.Text = orderDTO.Equipment?.Name;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LinkLabelDateNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void TextBoxGuarantee_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !KeyPressHelper.CheckKeyPress(false, null, e.KeyChar);
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if ((int)(dateTimePicker1.Value - orderDTO.DateCompleted.Value).TotalDays < 0)
                dateTimePicker1.Value = orderDTO.DateCompleted.Value;
            if (Convert.ToInt32(textBoxGuarantee.Text) > 0)
                labelGuaranteePeriod.Text = dateTimePicker1.Value.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
        }

        private void TextBoxGuarantee_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxGuarantee.Text.Length) > 0)
            {
                labelIsGuarantee.Text = "Гарантия до";
                labelGuaranteePeriod.Text = dateTimePicker1.Value.AddMonths(Convert.ToInt32(textBoxGuarantee.Text)).Date.ToShortDateString();
            } else
            {
                labelIsGuarantee.Text = "Без гарантии";
                labelGuaranteePeriod.Text = string.Empty;
            }
        }

        private async void ButtonIssueDevice_ClickAsync(object sender, EventArgs e)
        {
            if (textBoxGuarantee.Text.Length > 0)
            {
                if (orderDTO.ReturnUnderGuarantee)
                    orderDTO.DateIssueReturn = orderDTO.DateIssue;

                orderDTO.DateIssue = DateIssue.ToUniversalTime();
                orderDTO.Guarantee = GuaranteePeriod;
                orderDTO.DateEndGuarantee = DateEndGuarantee.ToUniversalTime();
                if (orderDTO.Guarantee > 0 && orderDTO.DateEndGuarantee > DateTime.Now)
                    orderDTO.StatusOrder = StatusOrderEnum.GuaranteeIssue;
                else
                    orderDTO.StatusOrder = StatusOrderEnum.Archive;

                await ordersLogic.SaveOrderAsync(orderDTO);

                Warning warning = new()
                {
                    LabelText = "Распечатать квитанцию?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };
                if (warning.ShowDialog() == DialogResult.OK)
                {
                    var orderDTO = await ordersLogic.GetOrderAsync(idOrder);
                    var detalsDTO = await warehousesLogic.GetDetailsInOrderAsync(idOrder);
                    var malfunctionOrderDTO = await malfunctionsOrdersLogic.GetMalfunctionOrdersByIdOrderAsync(idOrder);
                    ReportsLogic.IssuingDeviceReport(orderDTO, detalsDTO, malfunctionOrderDTO);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Warning warning = new()
                {
                    LabelText = "Не введена гарантия!"
                };
                warning.ShowDialog();
            }
        }
    }
}
