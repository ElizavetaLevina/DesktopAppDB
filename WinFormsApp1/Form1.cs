using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic;
using WinFormsApp1.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public int IdOrder { get { return Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
            Cells[nameof(OrderTableDTO.Id)].Value);} }
        public string IdClient { get { return dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
            Cells[nameof(OrderTableDTO.IdClient)].Value.ToString(); } }
        StatusOrderEnum status;
        public bool logInSystem = false;
        IWarehousesLogic warehousesLogic;
        IOrdersLogic ordersLogic;
        IClientsLogic clientsLogic;
        IMalfunctionsOrdersLogic malfunctionsOrdersLogic;
        List<OrderTableDTO> orders;
        public Form1(IWarehousesLogic _warehousesLogic, IOrdersLogic _ordersLogic, IClientsLogic _clientLogic,
            IMalfunctionsOrdersLogic _malfunctionsOrdersLogic)
        {
            warehousesLogic = _warehousesLogic;
            ordersLogic = _ordersLogic;
            clientsLogic = _clientLogic;
            malfunctionsOrdersLogic = _malfunctionsOrdersLogic;
            InitializeComponent();
            InitializeElementsForm();
        }

        private void InitializeElementsForm()
        {
            try
            {
                InProgressAsync();
                NameColumns();
                ToolStripEnabled();
                Width = Properties.Settings.Default.WidthMedium;
                Height = Properties.Settings.Default.HeightMedium;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void NameColumns() 
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[nameof(OrderTableDTO.Id)].Visible = false;
            dataGridView1.Columns[nameof(OrderTableDTO.NumberOrder)].HeaderText = "�";
            dataGridView1.Columns[nameof(OrderTableDTO.DateCreation)].HeaderText = "���� ������";
            dataGridView1.Columns[nameof(OrderTableDTO.DateStartWork)].HeaderText = "���� ������ �������";
            dataGridView1.Columns[nameof(OrderTableDTO.DateCompleted)].HeaderText = "���� ��������� �������";
            dataGridView1.Columns[nameof(OrderTableDTO.DateIssue)].HeaderText = "���� ������ ��������";
            dataGridView1.Columns[nameof(OrderTableDTO.MasterName)].HeaderText = "������";
            dataGridView1.Columns[nameof(OrderTableDTO.NameDevice)].HeaderText = "��� ��������/�������������/������";
            dataGridView1.Columns[nameof(OrderTableDTO.IdClient)].HeaderText = "��������";
            dataGridView1.Columns[nameof(OrderTableDTO.Diagnosis)].HeaderText = "�������";
            dataGridView1.Columns[nameof(OrderTableDTO.Deleted)].Visible = false;
            dataGridView1.Columns[nameof(OrderTableDTO.ReturnUnderGuarantee)].Visible = false;
            dataGridView1.Columns[nameof(OrderTableDTO.Guarantee)].Visible = false;
            dataGridView1.Columns[nameof(OrderTableDTO.DateEndGuarantee)].Visible = false;
            dataGridView1.Columns[nameof(OrderTableDTO.ColorRow)].Visible = false;
        }

        private void UpdateVisibilityColumns()
        {
            dataGridView1.Columns[nameof(OrderTableDTO.DateStartWork)].Visible = true;
            dataGridView1.Columns[nameof(OrderTableDTO.DateCompleted)].Visible = true;
            dataGridView1.Columns[nameof(OrderTableDTO.DateIssue)].Visible = true;
            dataGridView1.Columns[nameof(OrderTableDTO.Diagnosis)].Visible = false;
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    dataGridView1.Columns[nameof(OrderTableDTO.DateCompleted)].Visible = false;
                    dataGridView1.Columns[nameof(OrderTableDTO.DateIssue)].Visible = false;
                    dataGridView1.Columns[nameof(OrderTableDTO.Diagnosis)].Visible = true;
                    break;
                case StatusOrderEnum.Completed:
                    dataGridView1.Columns[nameof(OrderTableDTO.DateStartWork)].Visible = false;
                    dataGridView1.Columns[nameof(OrderTableDTO.DateIssue)].Visible = false;
                    break;
            }
            
        }

        private void UpdateWidthColumns()
        {
            int[] percentInRepair = [0, 8, 11, 11, 0, 0, 12, 34, 12, 12, 0, 0, 0, 0, 0];
            int[] percentCompleted = [0, 8, 12, 0, 12, 0, 14, 40, 14, 0, 0, 0, 0, 0, 0];
            int[] percentOthers = [0, 7, 10, 10, 10, 10, 9, 32, 12, 0, 0, 0, 0, 0, 0];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Visible)
                {
                    double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percentOthers[i];
                    switch (status)
                    {
                        case StatusOrderEnum.InRepair:
                            width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percentInRepair[i];
                            break;
                        case StatusOrderEnum.Completed:
                            width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percentCompleted[i];
                            break;
                    }
                    dataGridView1.Columns[i].Width = Convert.ToInt32(width);
                }
            }
        }

        private void UpdateTableData()
        {
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    InProgressAsync();
                    break;
                case StatusOrderEnum.Completed:
                    Order�ompletedAsync();
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    OrderGuaranteeAsync();
                    break;
                case StatusOrderEnum.Archive:
                    OrderArchiveAsync();
                    break;
                case StatusOrderEnum.Trash:
                    TrashAsync();
                    break;
            }
        }

        private async void InProgressAsync()
        {
            Enabled = false;
            status = StatusOrderEnum.InRepair;
            try
            {
                orders = await ordersLogic.GetOrdersForTableAsync(statusOrder: status, deleted: false, dateCreation: true);
                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateVisibilityColumns();
                UpdateWidthColumns();
                ChangeColorRowsAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Enabled = true;
        }

        private async void Order�ompletedAsync()
        {
            Enabled = false;
            status = StatusOrderEnum.Completed;
            try
            {
                orders = await ordersLogic.GetOrdersForTableAsync(statusOrder: status, deleted: false, dateCompleted: true);
                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateVisibilityColumns();
                UpdateWidthColumns();
                ChangeColorRowsAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Enabled = true;
        }

        private async void OrderGuaranteeAsync()
        {
            Enabled = false;
            status = StatusOrderEnum.GuaranteeIssue;
            try
            {
                orders = await ordersLogic.GetOrdersForTableAsync(statusOrder: status, deleted: false, dateIssue: true);

                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].DateEndGuarantee.Value.Date < DateTime.Now.Date)
                        orders.Remove(orders[i]);
                }
                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateVisibilityColumns();
                UpdateWidthColumns();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Enabled = true;
        }

        private async void OrderArchiveAsync()
        {
            Enabled = false;
            status = StatusOrderEnum.Archive;
            try
            {
                orders = await ordersLogic.GetOrdersForTableAsync(statusOrder: status, deleted: false, dateIssue: true);

                foreach(var order in orders)
                {
                    if (order.DateEndGuarantee.Value.Date >= DateTime.Now.Date)
                        orders.Remove(order);
                }

                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateVisibilityColumns();
                UpdateWidthColumns();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Enabled = true;
        }

        private async void TrashAsync()
        {
            Enabled = false;
            status = StatusOrderEnum.Trash;
            try
            {
                orders = await ordersLogic.GetOrdersForTableAsync(deleted: true, dateCompleted: true);
                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateVisibilityColumns();
                UpdateWidthColumns();
                ChangeColorRowsAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Enabled = true;
        }

        private void AddDeviceIntoRepair()
        {
            AddDeviceIntoRepair addDeviceIntoRepair = Program.ServiceProvider.GetRequiredService<AddDeviceIntoRepair>();

            if (addDeviceIntoRepair.ShowDialog() == DialogResult.OK)
            {
                status = StatusOrderEnum.InRepair;
                UpdateTableData();
                ToolStripEnabled();
            }
            FocusButton(status);
        }

        private void PropertiesOrder()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            PropertiesOrder propertiesOrder = Program.ServiceProvider.GetRequiredService<PropertiesOrder>();
            propertiesOrder.InitializeElementsFormAsync(IdOrder, status, logInSystem);
            propertiesOrder.ShowDialog();
            if (propertiesOrder.logIn)
            {
                logInSystem = true;
                labelLogIn.Text = Properties.Settings.Default.LoginInSystem;
            }
            FocusButton(status);
            UpdateTableData();
        }

        private void DetailsInOrder()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            DetailsInOrder detailsInOrder = Program.ServiceProvider.GetRequiredService<DetailsInOrder>();
            detailsInOrder.idOrder = IdOrder;
            detailsInOrder.UpdateTableAsync();
            detailsInOrder.ShowDialog();
        }

        private async void RemoveOrderAsync()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            Warning warning = new()
            {
                LabelText = status == StatusOrderEnum.Trash ? "�� ������������� ������ ������� ������� �� �������?" :
                "�� ������������� ������ ����������� ������� � �������?",
                ButtonNoText = "���",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
            {
                var orderDTO = await ordersLogic.GetOrderAsync(IdOrder);
                if (orderDTO.Deleted)
                    await ordersLogic.RemoveOrderAsync(orderDTO);
                else
                {
                    orderDTO.Deleted = true;
                    await ordersLogic.SaveOrderAsync(orderDTO);
                }
                UpdateTableData();
            }
            FocusButton(status);
        }

        private async void RecoveryOrderAsync()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            var orderDTO = await ordersLogic.GetOrderAsync(IdOrder);
            orderDTO.Deleted = false;
            await ordersLogic.SaveOrderAsync(orderDTO);
            TrashAsync();
        }

        private async void CompletedTagAsync()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            int numberRow = dataGridView1.CurrentCell.RowIndex;
            var nameMaster = dataGridView1.Rows[numberRow].Cells[nameof(OrderTableDTO.MasterName)].Value.ToString();
            //var returnUnderGuarantee = Convert.ToBoolean(dataGridView1.Rows[numberRow].
            //Cells[nameof(OrderTableDTO.ReturnUnderGuarantee)].Value);
            Warning warning = new();
            if (string.IsNullOrEmpty(nameMaster))
            {
                warning.LabelText = "������ � ������ �� ������!";
                warning.ShowDialog();
                return;
            }
            if (!logInSystem)
            {
                warning.LabelText = "������� � �������!";
                warning.ButtonYesText = "�����";
                warning.ButtonNoText = "������";
                warning.ButtonVisible = true;
                if (warning.ShowDialog() == DialogResult.OK)
                {
                    LogInToTheSystem();
                    if (!logInSystem)
                        return;
                }
                else return;
            }


            if (await warehousesLogic.GetCountDetailsInOrderAsync(IdOrder) == 0)
            {
                warning = new()
                {
                    LabelText = "�� �� ������������ �� ����� ������ ��� ������� ������� ����������. " +
                        "\n������ �� �� ������������� ������ �������?",
                    ButtonNoText = "���",
                    ButtonVisible = true
                };
                if (warning.ShowDialog() == DialogResult.OK)
                {
                    DetailsInOrder detailsInOrder = Program.ServiceProvider.GetRequiredService<DetailsInOrder>();
                    detailsInOrder.idOrder = IdOrder;
                    detailsInOrder.ShowDialog();
                }
            }
            if (status == StatusOrderEnum.InRepair)
            {
                CompletedOrder completedOrder = Program.ServiceProvider.GetRequiredService<CompletedOrder>();
                completedOrder.idOrder = IdOrder;
                completedOrder.InitializeElementsFormAsync();
                if (completedOrder.ShowDialog() == DialogResult.OK)
                    InProgressAsync();
                FocusButton(status);
            }
        }

        private void IssueToClient()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            if (status == StatusOrderEnum.Completed)
            {
                IssuingClient issuingClient = Program.ServiceProvider.GetRequiredService<IssuingClient>();
                issuingClient.idOrder = IdOrder;
                issuingClient.InitializeElementsFormAsync();
                if (issuingClient.ShowDialog() == DialogResult.OK)
                    Order�ompletedAsync();
                FocusButton(status);
            }
        }

        private async void ReturnIntoRepairAsync()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            Warning warning = new()
            {
                LabelText = "�� ������������� ������ ��������� ������� � ���������?",
                ButtonNoText = "���",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
            {
                if (status == StatusOrderEnum.Completed)
                {
                    var orderDTO = await ordersLogic.GetOrderAsync(IdOrder);
                    orderDTO.StatusOrder = StatusOrderEnum.InRepair;
                    if (orderDTO.ReturnUnderGuarantee)
                        orderDTO.DateCompletedReturn = null;
                    else
                        orderDTO.DateCompleted = null;
                    await ordersLogic.SaveOrderAsync(orderDTO);

                    var malfunctionsOrderDTO = await malfunctionsOrdersLogic.GetMalfunctionOrdersByIdOrderAsync(IdOrder);
                    foreach(var item in  malfunctionsOrderDTO)
                    {
                        await malfunctionsOrdersLogic.RemoveMalfunctionOrderAsync(item);
                    }
                    Order�ompletedAsync();
                }
                FocusButton(status);
            }
        }

        private async void ReturnGuaranteeAsync()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            Warning warning = new()
            {
                LabelText = "�� ������������� ������ ������� ������� �� ��������?",
                ButtonNoText = "���",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
            {
                if (status == StatusOrderEnum.GuaranteeIssue)
                {
                    var orderDTO = await ordersLogic.GetOrderAsync(IdOrder);
                    orderDTO.DateCreation = DateTime.Now.ToUniversalTime();
                    orderDTO.DateStartWork = DateTime.Now.ToUniversalTime();
                    orderDTO.StatusOrder = StatusOrderEnum.InRepair;
                    orderDTO.ReturnUnderGuarantee = true;
                    await ordersLogic.SaveOrderAsync(orderDTO);
                    OrderGuaranteeAsync();
                }
                FocusButton(status);
            }
        }

        private void SendMessage()
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            MessageToClient message = Program.ServiceProvider.GetRequiredService<MessageToClient>();
            message.InitializeClientAsync(IdClient);
            message.ShowDialog();
        }

        private void PropertiesClient()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            PropertiesClient propertiesClient = Program.ServiceProvider.GetRequiredService<PropertiesClient>();
            propertiesClient.idClient = IdClient;
            propertiesClient.InitializeElementsFormsAsync();
            if (propertiesClient.ShowDialog() == DialogResult.OK)
                UpdateTableData();
            FocusButton(status);
        }

        private async void AddInWhitelistAsync()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            var clientDTO = await clientsLogic.GetClientByIdClientAsync(IdClient);
            clientDTO.TypeClient = TypeClientEnum.white;
            await clientsLogic.SaveClientAsync(clientDTO);
        }

        private async void AddInBlacklistAsync()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            var clientDTO = await clientsLogic.GetClientByIdClientAsync(IdClient);
            clientDTO.TypeClient = TypeClientEnum.black;
            await clientsLogic.SaveClientAsync(clientDTO);
        }

        private async void RemoveMarksAsync()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            var clientDTO = await clientsLogic.GetClientByIdClientAsync(IdClient);
            clientDTO.TypeClient = TypeClientEnum.normal;
            await clientsLogic.SaveClientAsync(clientDTO);
        }

        private void RepeatOrder()
        {
            AddDeviceIntoRepair addDeviceIntoRepair = Program.ServiceProvider.GetRequiredService<AddDeviceIntoRepair>();
            addDeviceIntoRepair.FillOrderAsync(IdOrder);

            if (addDeviceIntoRepair.ShowDialog() == DialogResult.OK)
            {
                status = StatusOrderEnum.InRepair;
                UpdateTableData();
            }
            FocusButton(status);
        }

        private async void ExportTableToExcelAsync()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            var ordersForExcel = await ordersLogic.GetOrdersForExcelAsync(orders);
            ReportsLogic.ExportMainTable(saveFileDialog1.FileName, ordersForExcel);
        }

        private void ButtonInProgress_Click(object sender, EventArgs e)
        {
            InProgressAsync();
            ToolStripEnabled();
        }

        private void ButtonCompleted_Click(object sender, EventArgs e)
        {
            Order�ompletedAsync();
            ToolStripEnabled();
        }

        private void ButtonGuarantee_Click(object sender, EventArgs e)
        {
            OrderGuaranteeAsync();
            ToolStripEnabled();
        }

        private void ButtonArchive_Click(object sender, EventArgs e)
        {
            OrderArchiveAsync();
            ToolStripEnabled();
        }

        private void ButtonTrash_Click(object sender, EventArgs e)
        {
            TrashAsync();
            ToolStripEnabled();
        }

        private async void ChangeColorRowsAsync()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var color = ColorTranslator.FromHtml(dataGridView1.Rows[i].
                    Cells[nameof(OrderTableDTO.ColorRow)].Value.ToString());
                var orderDTO = await ordersLogic.GetOrderAsync(Convert.ToInt32(dataGridView1.Rows[i].
                    Cells[nameof(OrderTableDTO.Id)].Value));
                if (color != ColorsRowsHelper.ColorDefinition(orderDTO))
                {
                    color = ColorsRowsHelper.ColorDefinition(orderDTO);
                    orderDTO.ColorRow = ColorTranslator.ToHtml(color);
                    await ordersLogic.SaveOrderAsync(orderDTO);
                }
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = color;
                dataGridView1.Rows[i].DefaultCellStyle.SelectionForeColor = color;

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[nameof(OrderTableDTO.ReturnUnderGuarantee)].Value))
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }

        private void ToolStripEnabled()
        {
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    buttonDetails.Enabled = true;
                    buttonRemove.Enabled = true;
                    buttonRecovery.Enabled = false;
                    buttonCompletedTag.Enabled = true;
                    buttonIssue.Enabled = false;
                    buttonReturnIntoRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = false;
                    buttonPropertiesOrder.Enabled = true;
                    break;
                case StatusOrderEnum.Completed:
                    buttonDetails.Enabled = false;
                    buttonRemove.Enabled = true;
                    buttonRecovery.Enabled = false;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = true;
                    buttonReturnIntoRepair.Enabled = true;
                    buttonReturnGuarantee.Enabled = false;
                    buttonPropertiesOrder.Enabled = true;
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    buttonDetails.Enabled = false;
                    buttonRemove.Enabled = true;
                    buttonRecovery.Enabled = false;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = false;
                    buttonReturnIntoRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = true;
                    buttonPropertiesOrder.Enabled = true;
                    break;
                case StatusOrderEnum.Archive:
                    buttonDetails.Enabled = false;
                    buttonRemove.Enabled = true;
                    buttonRecovery.Enabled = false;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = false;
                    buttonReturnIntoRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = false;
                    buttonPropertiesOrder.Enabled = true;
                    break;
                case StatusOrderEnum.Trash:
                    buttonDetails.Enabled = false;
                    buttonRemove.Enabled = true;
                    buttonRecovery.Enabled = true;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = false;
                    buttonReturnIntoRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = false;
                    buttonPropertiesOrder.Enabled = false;
                    break;
            }
        }

        private void ContextButton2()
        {
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    itemPropertiesMenuWorkingWithData.Enabled = true;
                    itemDetailsMenuWorkingWithData.Enabled = true;
                    itemRemoveMenuWorkingWithData.Enabled = true;
                    itemRecoveryMenuWorkingWithData.Enabled = false;
                    itemActionsDeviceMenuWorkingWithData.Enabled = true;
                    itemCompletedTagMenuWorkingWithData.Enabled = true;
                    itemIssueMenuWorkingWithData.Enabled = false;
                    itemReturnMenuWorkingWithData.Enabled = false;
                    itemReturnGuaranteeMenuWorkingWithData.Enabled = false;
                    itemPropertiesClientMenuWorkingWithData.Enabled = true;
                    itemWhiteListWorkingWithData.Enabled = true;
                    itemBlackListWorkingWithData.Enabled = true;
                    itemUnmarkWorkingWithData.Enabled = true;
                    break;
                case StatusOrderEnum.Completed:
                    itemPropertiesMenuWorkingWithData.Enabled = true;
                    itemDetailsMenuWorkingWithData.Enabled = false;
                    itemRemoveMenuWorkingWithData.Enabled = true;
                    itemRecoveryMenuWorkingWithData.Enabled = false;
                    itemActionsDeviceMenuWorkingWithData.Enabled = true;
                    itemCompletedTagMenuWorkingWithData.Enabled = false;
                    itemIssueMenuWorkingWithData.Enabled = true;
                    itemReturnMenuWorkingWithData.Enabled = true;
                    itemReturnGuaranteeMenuWorkingWithData.Enabled = false;
                    itemPropertiesClientMenuWorkingWithData.Enabled = true;
                    itemWhiteListWorkingWithData.Enabled = true;
                    itemBlackListWorkingWithData.Enabled = true;
                    itemUnmarkWorkingWithData.Enabled = true;
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    itemPropertiesMenuWorkingWithData.Enabled = true;
                    itemDetailsMenuWorkingWithData.Enabled = false;
                    itemRemoveMenuWorkingWithData.Enabled = true;
                    itemRecoveryMenuWorkingWithData.Enabled = false;
                    itemActionsDeviceMenuWorkingWithData.Enabled = true;
                    itemCompletedTagMenuWorkingWithData.Enabled = false;
                    itemIssueMenuWorkingWithData.Enabled = false;
                    itemReturnMenuWorkingWithData.Enabled = false;
                    itemReturnGuaranteeMenuWorkingWithData.Enabled = true;
                    itemPropertiesClientMenuWorkingWithData.Enabled = true;
                    itemWhiteListWorkingWithData.Enabled = true;
                    itemBlackListWorkingWithData.Enabled = true;
                    itemUnmarkWorkingWithData.Enabled = true;
                    break;
                case StatusOrderEnum.Archive:
                    itemPropertiesMenuWorkingWithData.Enabled = true;
                    itemDetailsMenuWorkingWithData.Enabled = false;
                    itemRemoveMenuWorkingWithData.Enabled = true;
                    itemRecoveryMenuWorkingWithData.Enabled = false;
                    itemActionsDeviceMenuWorkingWithData.Enabled = false;
                    itemPropertiesClientMenuWorkingWithData.Enabled = true;
                    itemWhiteListWorkingWithData.Enabled = true;
                    itemBlackListWorkingWithData.Enabled = true;
                    itemUnmarkWorkingWithData.Enabled = true;
                    break;
                case StatusOrderEnum.Trash:
                    itemPropertiesMenuWorkingWithData.Enabled = false;
                    itemDetailsMenuWorkingWithData.Enabled = false;
                    itemRemoveMenuWorkingWithData.Enabled = true;
                    itemRecoveryMenuWorkingWithData.Enabled = true;
                    itemActionsDeviceMenuWorkingWithData.Enabled = false;
                    itemPropertiesClientMenuWorkingWithData.Enabled = true;
                    itemWhiteListWorkingWithData.Enabled = true;
                    itemBlackListWorkingWithData.Enabled = true;
                    itemUnmarkWorkingWithData.Enabled = true;
                    break;
            }
            if (dataGridView1.RowCount > 0)
                itemNewOrderAsCurrentMenuWorkingWithData.Enabled = true;
            else
                itemNewOrderAsCurrentMenuWorkingWithData.Enabled = false;

        }

        private void ContextButton3()
        {
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    itemGettingDevice.Enabled = true;
                    itemIssuingDevice.Enabled = false;
                    break;
                case StatusOrderEnum.Completed:
                    itemGettingDevice.Enabled = true;
                    itemIssuingDevice.Enabled = false;
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    itemGettingDevice.Enabled = true;
                    itemIssuingDevice.Enabled = true;
                    break;
                case StatusOrderEnum.Archive:
                    itemGettingDevice.Enabled = true;
                    itemIssuingDevice.Enabled = true;
                    break;
                case StatusOrderEnum.Trash:
                    itemGettingDevice.Enabled = false;
                    itemIssuingDevice.Enabled = false;
                    break;
            }
        }

        private void DataGridView1_VisibleChanged(object sender, EventArgs e)
        {
            ChangeColorRowsAsync();
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dataGridView1.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right && ht.Type != DataGridViewHitTestType.None)
            {
                contextMenuRightMouse.Show(MousePosition);
                switch (status)
                {
                    case StatusOrderEnum.InRepair:
                        itemPropertiesMenuRightMouse.Enabled = true;
                        itemDetailsMenuRightMouse.Enabled = true;
                        itemRemoveMenuRightMouse.Enabled = true;
                        itemRecoveryMenuRightMouse.Enabled = false;
                        itemActionDeviceMenuRightMouse.Enabled = true;
                        itemCompletedTagMenuRightMouse.Enabled = true;
                        itemIssueMenuRightMouse.Enabled = false;
                        itemReturnIntoRepairMenuRightMouse.Enabled = false;
                        itemReturnGuaranteeMenuRightMouse.Enabled = false;
                        break;
                    case StatusOrderEnum.Completed:
                        itemPropertiesMenuRightMouse.Enabled = true;
                        itemDetailsMenuRightMouse.Enabled = false;
                        itemRemoveMenuRightMouse.Enabled = true;
                        itemRecoveryMenuRightMouse.Enabled = false;
                        itemActionDeviceMenuRightMouse.Enabled = true;
                        itemCompletedTagMenuRightMouse.Enabled = false;
                        itemIssueMenuRightMouse.Enabled = true;
                        itemReturnIntoRepairMenuRightMouse.Enabled = true;
                        itemReturnGuaranteeMenuRightMouse.Enabled = false;
                        break;
                    case StatusOrderEnum.GuaranteeIssue:
                        itemPropertiesMenuRightMouse.Enabled = true;
                        itemDetailsMenuRightMouse.Enabled = false;
                        itemRemoveMenuRightMouse.Enabled = true;
                        itemRecoveryMenuRightMouse.Enabled = false;
                        itemActionDeviceMenuRightMouse.Enabled = true;
                        itemCompletedTagMenuRightMouse.Enabled = false;
                        itemIssueMenuRightMouse.Enabled = false;
                        itemReturnIntoRepairMenuRightMouse.Enabled = false;
                        itemReturnGuaranteeMenuRightMouse.Enabled = true;
                        break;
                    case StatusOrderEnum.Archive:
                        itemPropertiesMenuRightMouse.Enabled = true;
                        itemDetailsMenuRightMouse.Enabled = false;
                        itemRemoveMenuRightMouse.Enabled = true;
                        itemRecoveryMenuRightMouse.Enabled = false;
                        itemActionDeviceMenuRightMouse.Enabled = false;
                        break;
                    case StatusOrderEnum.Trash:
                        itemPropertiesMenuRightMouse.Enabled = false;
                        itemDetailsMenuRightMouse.Enabled = false;
                        itemRemoveMenuRightMouse.Enabled = true;
                        itemRecoveryMenuRightMouse.Enabled = true;
                        itemActionDeviceMenuRightMouse.Enabled = false;
                        break;
                }
            }
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            }
        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (status != StatusOrderEnum.Trash)
                PropertiesOrder();
        }

        private void ItemPropertiesMenuRightMouse_Click(object sender, EventArgs e)
        {
            PropertiesOrder();
        }

        private void ItemDetailsMenuRightMouse_Click(object sender, EventArgs e)
        {
            DetailsInOrder();
        }

        private void ItemRemoveMenuRightMouse_Click(object sender, EventArgs e)
        {
            RemoveOrderAsync();
        }

        private void ItemRecoveryMenuRightMouse_Click(object sender, EventArgs e)
        {
            RecoveryOrderAsync();
        }

        private void ItemCompletedTagMenuRightMouse_Click(object sender, EventArgs e)
        {
            CompletedTagAsync();
        }

        private void ItemIssueMenuRightMouse_Click(object sender, EventArgs e)
        {
            IssueToClient();
        }

        private void ItemReturnIntoRepairMenuRightMouse_Click(object sender, EventArgs e)
        {
            ReturnIntoRepairAsync();
        }

        private void ItemReturnGuaranteeMenuRightMouse_Click(object sender, EventArgs e)
        {
            ReturnGuaranteeAsync();
        }

        private void ItemPropertiesClientMenuRightMouse_Click(object sender, EventArgs e)
        {
            PropertiesClient();
        }

        private void ItemMessageClientMenuRightMouse_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void ItemWhiteListMenuRightMouse_Click(object sender, EventArgs e)
        {
            AddInWhitelistAsync();
        }

        private void ItemBlackListMenuRightMouse_Click(object sender, EventArgs e)
        {
            AddInBlacklistAsync();
        }

        private void ItemUnmarkMenuRightMouse_Click(object sender, EventArgs e)
        {
            RemoveMarksAsync();
        }

        private void ItemNewOrderAsCurrentMenuRightMouse_Click(object sender, EventArgs e)
        {
            RepeatOrder();
        }

        private void ButtonAddDeviceIntoRepair_Click(object sender, EventArgs e)
        {
            AddDeviceIntoRepair();
        }

        private void ButtonMasters_Click(object sender, EventArgs e)
        {
            Masters addMaster = Program.ServiceProvider.GetRequiredService<Masters>();
            addMaster.ShowDialog();
            FocusButton(status);
        }

        private void ButtonTypesDevices_Click(object sender, EventArgs e)
        {
            TypesTechnic addDevice = Program.ServiceProvider.GetRequiredService<TypesTechnic>();
            addDevice.ShowDialog();
            FocusButton(status);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Warning warning = new()
            {
                LabelText = "�� ������������� ������ ����� �� ���������?",
                ButtonNoText = "���",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
                Application.Exit();
            FocusButton(status);
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            DetailsInOrder();
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            RemoveOrderAsync();
        }

        private void ButtonRecovery_Click(object sender, EventArgs e)
        {
            RecoveryOrderAsync();
        }

        private void ButtonCompletedTag_Click(object sender, EventArgs e)
        {
            CompletedTagAsync();
        }

        private void ButtonIssue_Click(object sender, EventArgs e)
        {
            IssueToClient();
        }

        private void ButtonReturnIntoRepair_Click(object sender, EventArgs e)
        {
            ReturnIntoRepairAsync();
        }

        private void ButtonReturnGuarantee_Click(object sender, EventArgs e)
        {
            ReturnGuaranteeAsync();
        }

        private void ButtonPropertiesOrder_Click(object sender, EventArgs e)
        {
            PropertiesOrder();
        }

        private void ButtonPropertiesClient_Click(object sender, EventArgs e)
        {
            PropertiesClient();
        }

        private void LabelDataBase_MouseEnter(object sender, EventArgs e)
        {
            labelDataBase.BackColor = SystemColors.Highlight;
            labelDataBase.ForeColor = System.Drawing.Color.White;
        }

        private void LabelDataBase_MouseLeave(object sender, EventArgs e)
        {
            labelDataBase.BackColor = SystemColors.Control;
            labelDataBase.ForeColor = System.Drawing.Color.Black;
        }

        private void LabelWorkData_MouseEnter(object sender, EventArgs e)
        {
            labelWorkData.BackColor = SystemColors.Highlight;
            labelWorkData.ForeColor = System.Drawing.Color.White;
        }

        private void LabelWorkData_MouseLeave(object sender, EventArgs e)
        {
            labelWorkData.BackColor = SystemColors.Control;
            labelWorkData.ForeColor = System.Drawing.Color.Black;
        }

        private void LabelDocuments_MouseEnter(object sender, EventArgs e)
        {
            labelDocuments.BackColor = SystemColors.Highlight;
            labelDocuments.ForeColor = System.Drawing.Color.White;
        }

        private void LabelDocuments_MouseLeave(object sender, EventArgs e)
        {
            labelDocuments.BackColor = SystemColors.Control;
            labelDocuments.ForeColor = System.Drawing.Color.Black;
        }

        private void LabelReports_MouseEnter(object sender, EventArgs e)
        {
            labelReports.BackColor = SystemColors.Highlight;
            labelReports.ForeColor = System.Drawing.Color.White;
        }

        private void LabelReports_MouseLeave(object sender, EventArgs e)
        {
            labelReports.BackColor = SystemColors.Control;
            labelReports.ForeColor = System.Drawing.Color.Black;
        }

        private void LabelView_MouseEnter(object sender, EventArgs e)
        {
            labelView.BackColor = SystemColors.Highlight;
            labelView.ForeColor = System.Drawing.Color.White;
        }

        private void LabelView_MouseLeave(object sender, EventArgs e)
        {
            labelView.BackColor = SystemColors.Control;
            labelView.ForeColor = System.Drawing.Color.Black;
        }

        private void LabelLogIn_MouseEnter(object sender, EventArgs e)
        {
            labelLogIn.BackColor = SystemColors.Highlight;
            labelLogIn.ForeColor = System.Drawing.Color.White;
        }

        private void LabelLogIn_MouseLeave(object sender, EventArgs e)
        {
            labelLogIn.BackColor = SystemColors.Control;
            labelLogIn.ForeColor = System.Drawing.Color.Black;
        }

        private void LabelDataBase_Click(object sender, EventArgs e)
        {
            var screenPos = labelDataBase.PointToScreen(Point.Empty);
            contextMenuDataBase.Show(new Point(screenPos.X, screenPos.Y + labelDataBase.Height));
        }

        private void LabelWorkData_Click(object sender, EventArgs e)
        {
            ContextButton2();
            var screenPos = labelWorkData.PointToScreen(Point.Empty);
            contextMenuWorkingWithData.Show(new Point(screenPos.X, screenPos.Y + labelWorkData.Height));
        }

        private void LabelDocuments_Click(object sender, EventArgs e)
        {
            ContextButton3();
            var screenPos = labelDocuments.PointToScreen(Point.Empty);
            contextMenuPayments.Show(new Point(screenPos.X, screenPos.Y + labelDocuments.Height));
        }

        private void LabelReports_Click(object sender, EventArgs e)
        {
            var screenPos = labelReports.PointToScreen(Point.Empty);
            contextMenuReports.Show(new Point(screenPos.X, screenPos.Y + labelReports.Height));
        }

        private void LabelView_Click(object sender, EventArgs e)
        {
            var screenPos = labelView.PointToScreen(Point.Empty);
            contextMenuView.Show(new Point(screenPos.X, screenPos.Y + labelReports.Height));
        }

        private void ItemMasters_Click(object sender, EventArgs e)
        {
            Masters addMaster = Program.ServiceProvider.GetRequiredService<Masters>();
            addMaster.ShowDialog();
            FocusButton(status);
        }

        private void ItemBrands_Click(object sender, EventArgs e)
        {
            BrandsTechnic addBrand = Program.ServiceProvider.GetRequiredService<BrandsTechnic>();
            addBrand.ShowDialog();
            FocusButton(status);
        }

        private void ItemTypesDevices_Click(object sender, EventArgs e)
        {
            TypesTechnic addDevice = Program.ServiceProvider.GetRequiredService<TypesTechnic>();
            addDevice.ShowDialog();
            FocusButton(status);
        }

        private void ItemClientsDirectory_Click(object sender, EventArgs e)
        {
            GuideClients guideClients = Program.ServiceProvider.GetRequiredService<GuideClients>();
            guideClients.ShowDialog();
            FocusButton(status);
        }

        private void ItemWarehouse_Click(object sender, EventArgs e)
        {
            DetailsInWarehouse details = Program.ServiceProvider.GetRequiredService<DetailsInWarehouse>();
            details.VisibleBtnAdd = false;
            details.ShowDialog();
            FocusButton(status);
        }

        private void ItemMalfunction_Click(object sender, EventArgs e)
        {
            MalfunctionEquipmentDiagnosis malfunctionEquipmentDiagnosis = Program.ServiceProvider
                .GetRequiredService<MalfunctionEquipmentDiagnosis>();
            malfunctionEquipmentDiagnosis.status = NameTableToEditEnum.Malfunction;
            malfunctionEquipmentDiagnosis.UpdateTableAsync();
            malfunctionEquipmentDiagnosis.ShowDialog();
            FocusButton(status);
        }

        private void ItemDiagnosis_Click(object sender, EventArgs e)
        {
            MalfunctionEquipmentDiagnosis malfunctionEquipmentDiagnosis = Program.ServiceProvider
                .GetRequiredService<MalfunctionEquipmentDiagnosis>();
            malfunctionEquipmentDiagnosis.Text = "��������";
            malfunctionEquipmentDiagnosis.status = NameTableToEditEnum.Diagnosis;
            malfunctionEquipmentDiagnosis.UpdateTableAsync();
            malfunctionEquipmentDiagnosis.ShowDialog();
            UpdateTableData();
            FocusButton(status);
        }

        private void ItemEquipment_Click(object sender, EventArgs e)
        {
            MalfunctionEquipmentDiagnosis malfunctionEquipmentDiagnosis = Program.ServiceProvider
                .GetRequiredService<MalfunctionEquipmentDiagnosis>();
            malfunctionEquipmentDiagnosis.Text = "������������";
            malfunctionEquipmentDiagnosis.status = NameTableToEditEnum.Equipment;
            malfunctionEquipmentDiagnosis.UpdateTableAsync();
            malfunctionEquipmentDiagnosis.ShowDialog();
            FocusButton(status);
        }

        private void ItemExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportTableToExcelAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ItemCopyBD_Click(object sender, EventArgs e)
        {
        }

        private void ItemUpdateService_Click(object sender, EventArgs e)
        {
            UpdateDB();
        }

        private void ItemPathDB_Click(object sender, EventArgs e)
        {
            PathDB pathDB = new();
            pathDB.ShowDialog();
            UpdateTableData();
        }

        private void ItemOrganization_Click(object sender, EventArgs e)
        {
            Organization organization = new();
            organization.ShowDialog();
        }

        private void ItemLogIn_Click(object sender, EventArgs e)
        {
            LogInToTheSystem();
        }

        private void ItemExit_Click(object sender, EventArgs e)
        {
            Warning warning = new()
            {
                LabelText = "�� ������������� ������ ����� �� ���������?",
                ButtonNoText = "���",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
                Application.Exit();
            FocusButton(status);
        }

        private void ItemNewOrderMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            AddDeviceIntoRepair();
        }

        private void ItemPropertiesMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            PropertiesOrder();
        }

        private void ItemDetailsMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            DetailsInOrder();
        }

        private void ItemRemoveMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            RemoveOrderAsync();
        }

        private void ItemRecoveryMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            RecoveryOrderAsync();
        }

        private void ItemCompletedTagMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            CompletedTagAsync();
        }

        private void ItemIssueMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            IssueToClient();
        }

        private void ItemReturnMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            ReturnIntoRepairAsync();
        }

        private void ItemReturnGuaranteeMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            ReturnGuaranteeAsync();
        }

        private void ItemPropertiesClientMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            PropertiesClient();
        }

        private void ItemMessageClientMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void ItemWhiteListWorkingWithData_Click(object sender, EventArgs e)
        {
            AddInWhitelistAsync();
        }

        private void ItemBlackListWorkingWithData_Click(object sender, EventArgs e)
        {
            AddInBlacklistAsync();
        }

        private void ItemUnmarkWorkingWithData_Click(object sender, EventArgs e)
        {
            RemoveMarksAsync();
        }

        private void ItemNewOrderAsCurrentMenuWorkingWithData_Click(object sender, EventArgs e)
        {
            RepeatOrder();
        }

        private void ItemReportOrganization_Click(object sender, EventArgs e)
        {
            ReportsOrganization reportsOrganization = Program.ServiceProvider.GetRequiredService<ReportsOrganization>();
            reportsOrganization.ShowDialog();
            FocusButton(status);
        }

        private void ItemSalary_Click(object sender, EventArgs e)
        {

            CalculatingEmployeeSalaries salary = Program.ServiceProvider.GetRequiredService<CalculatingEmployeeSalaries>();
            salary.ShowDialog();
            FocusButton(status);
        }

        private void ItemColor_Click(object sender, EventArgs e)
        {
            View view = Program.ServiceProvider.GetRequiredService<View>();
            view.ShowDialog();
            UpdateTableData();
        }

        private async void ItemGettingDevice_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            var orderDTO = await ordersLogic.GetOrderAsync(IdOrder);
            ReportsLogic.GettingDeviceReport(orderDTO);
            FocusButton(status);
        }

        private async void ItemIssuingDevice_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            var orderDTO = await ordersLogic.GetOrderAsync(IdOrder);
            var detalsDTO = await warehousesLogic.GetDetailsInOrderAsync(IdOrder);
            var malfunctionOrderDTO = await malfunctionsOrdersLogic.GetMalfunctionOrdersByIdOrderAsync(IdOrder);
            ReportsLogic.IssuingDeviceReport(orderDTO, detalsDTO, malfunctionOrderDTO);
            FocusButton(status);
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ChangeColorRowsAsync();
        }

        public void FocusButton(StatusOrderEnum status)
        {
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    buttonInProgress.Focus();
                    break;
                case StatusOrderEnum.Completed:
                    buttonCompleted.Focus();
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    buttonGuarantee.Focus();
                    break;
                case StatusOrderEnum.Archive:
                    buttonArchive.Focus();
                    break;
                case StatusOrderEnum.Trash:
                    buttonTrash.Focus();
                    break;
            }
        }

        private static void UpdateDB()
        {
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            FocusButton(status);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ChangeSizeAndLocation();
        }

        private void TextBoxIdOrder_TextChanged(object sender, EventArgs e)
        {
            SearchAsync();
        }

        private void TextBoxDateCreation_TextChanged(object sender, EventArgs e)
        {
            SearchAsync();
        }

        private void TextBoxDateStartWork_TextChanged(object sender, EventArgs e)
        {
            SearchAsync();
        }

        private void TextBoxNameMaster_TextChanged(object sender, EventArgs e)
        {
            SearchAsync();
        }

        private void TextBoxDevice_TextChanged(object sender, EventArgs e)
        {
            SearchAsync();
        }

        private void TextBoxNameClient_TextChanged(object sender, EventArgs e)
        {
            SearchAsync();
        }

        private void CheckBoxSearch_CheckedChanged(object sender, EventArgs e)
        {
            SearchAsync();
        }

        private async void SearchAsync()
        {
            if (CheckNoFilters())
            {
                UpdateTableData();
                return;
            }
            StatusOrderEnum? statusOrder = null;
            if (!checkBoxSearch.Checked)
                statusOrder = status;
            orders = await ordersLogic.GetOrdersBySearchAsync(numberOrder: textBoxIdOrder.Text,
                dateCreation: textBoxDateCreation.Text, dateStartWork: textBoxDateStartWork.Text,
                masterName: textBoxNameMaster.Text, device: textBoxDevice.Text, idClient: textBoxNameClient.Text,
                statusOrder: statusOrder);

            dataGridView1.DataSource = Funcs.ToDataTable(orders);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.WidthMedium = Width;
            Properties.Settings.Default.HeightMedium = Height;
            Properties.Settings.Default.Save();
        }

        private bool CheckNoFilters()
        {
            return (string.IsNullOrEmpty(textBoxIdOrder.Text) &&
                string.IsNullOrEmpty(textBoxDateCreation.Text) &&
                string.IsNullOrEmpty(textBoxDateStartWork.Text) &&
                string.IsNullOrEmpty(textBoxNameMaster.Text) &&
                string.IsNullOrEmpty(textBoxDevice.Text) &&
                string.IsNullOrEmpty(textBoxNameClient.Text));
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            textBoxIdOrder.Text = string.Empty;
            textBoxDateCreation.Text = string.Empty;
            textBoxDateStartWork.Text = string.Empty;
            textBoxNameMaster.Text = string.Empty;
            textBoxDevice.Text = string.Empty;
            textBoxNameClient.Text = string.Empty;
            UpdateTableData();
            FocusButton(status);
        }

        private void ChangeSizeAndLocation()
        {
            int buttonMenuX = Width - buttonInProgress.Width - 25;
            int heightButtonMenu = buttonInProgress.Height;
            dataGridView1.Width = Width - buttonInProgress.Width - 50;
            dataGridView1.Height = Height - dataGridView1.Location.Y - heightButtonMenu - 50;

            int marginHeightMenuX = (dataGridView1.Height - heightButtonMenu * 5) / 4;
            int bottomTable = dataGridView1.Height + dataGridView1.Location.Y;
            labelLogIn.Location = new Point(buttonMenuX, labelLogIn.Location.Y);
            buttonInProgress.Location = new Point(buttonMenuX, buttonInProgress.Location.Y);
            buttonCompleted.Location = new Point(buttonMenuX, buttonInProgress.Location.Y + heightButtonMenu + marginHeightMenuX);
            buttonGuarantee.Location = new Point(buttonMenuX, buttonCompleted.Location.Y + heightButtonMenu + marginHeightMenuX);
            buttonArchive.Location = new Point(buttonMenuX, buttonGuarantee.Location.Y + heightButtonMenu + marginHeightMenuX);
            buttonTrash.Location = new Point(buttonMenuX, bottomTable - buttonTrash.Height);
            buttonReset.Location = new Point(buttonMenuX, bottomTable + 15);

            int endTable = dataGridView1.Width + dataGridView1.Location.X;
            int widthTextBox = textBoxIdOrder.Width;
            int widthLT = 4;
            int marginWidthFilter = (endTable - checkBoxSearch.Width - (widthTextBox + widthLT) * 3 - labelIdOrder.Width - 
                labelDateStartWork.Width - labelDevice.Width) / 3;


            int secondColumn = textBoxIdOrder.Location.X + textBoxIdOrder.Width + marginWidthFilter;
            labelIdOrder.Location = new Point(labelIdOrder.Location.X, buttonReset.Location.Y);
            textBoxIdOrder.Location = new Point(textBoxIdOrder.Location.X, buttonReset.Location.Y);
            labelDateStartWork.Location = new Point(secondColumn, buttonReset.Location.Y);
            textBoxDateStartWork.Location = new Point(secondColumn + labelDateStartWork.Width + widthLT, buttonReset.Location.Y);
            int thirdColumn = textBoxDateStartWork.Location.X + textBoxDateStartWork.Width + marginWidthFilter;
            labelDevice.Location = new Point(thirdColumn, buttonReset.Location.Y);
            textBoxDevice.Location = new Point(thirdColumn + labelDevice.Width + widthLT, buttonReset.Location.Y);

            checkBoxSearch.Location = new Point(textBoxDevice.Location.X + textBoxDevice.Width + marginWidthFilter, bottomTable + 15);

            int bottomMargin = buttonReset.Location.Y + buttonReset.Height - labelDateCreation.Height;
            labelDateCreation.Location = new Point(labelDateCreation.Location.X, bottomMargin);
            textBoxDateCreation.Location = new Point(textBoxDateCreation.Location.X, bottomMargin);
            labelNameMaster.Location = new Point(secondColumn, bottomMargin);
            textBoxNameMaster.Location = new Point(secondColumn + labelNameMaster.Width + widthLT, bottomMargin);
            labelNameClient.Location = new Point(thirdColumn, bottomMargin);
            textBoxNameClient.Location = new Point(thirdColumn + labelNameClient.Width + widthLT, bottomMargin);

            UpdateWidthColumns();
        }

        private void DataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            labelClientId.Visible = false;
        }

        private void DataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8 && e.RowIndex >= 0)
                {
                    labelClientId.Visible = true;
                    var rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    labelClientId.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    labelClientId.Location = new Point(rectangle.X + dataGridView1.Location.X - labelClientId.Width,
                        rectangle.Y + dataGridView1.Location.Y);
                }
                else
                    labelClientId.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            timer1.Interval = 600000;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (logInSystem)
            {
                logInSystem = false;
                labelLogIn.Text = "�����";
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void LabelLogIn_Click(object sender, EventArgs e)
        {
            if (logInSystem)
            {
                var screenPos = labelLogIn.PointToScreen(Point.Empty);
                contextMenuAccount.Show(new Point(screenPos.X - (contextMenuAccount.Width - labelLogIn.Width),
                    screenPos.Y + labelLogIn.Height));
            }
            else LogInToTheSystem();
        }

        public void LogInToTheSystem()
        {
            LogInSystem logIn = new(true);
            if (logIn.ShowDialog() == DialogResult.OK)
            {
                logInSystem = true;
                labelLogIn.Text = Properties.Settings.Default.LoginInSystem;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                if (!logInSystem)
                {
                    LogInToTheSystem();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void ItemChangeData_Click(object sender, EventArgs e)
        {
            LogInSystem logInSystem = new(false);
            logInSystem.ShowDialog();
        }

        private void ItemLogOut_Click(object sender, EventArgs e)
        {
            labelLogIn.Text = "�����";
            logInSystem = false;
        }
    }
}
