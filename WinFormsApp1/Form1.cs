using System.Net;
using FluentFTP;
using Color = System.Drawing.Color;
using WinFormsApp1.DTO;
using WinFormsApp1.Repository;
using WinFormsApp1.Reports;
using WinFormsApp1.Enum;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public int idOrder;
        StatusOrderEnum status;
        public bool logInSystem = false;

        OrderRepository orderRepository = new();
        WarehouseRepository warehouseRepository = new();
        ClientRepository clientRepository = new();
        GettingReport gettingReport = new();
        IssuingReport issuingReport = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();
        public Form1()
        {
            InitializeComponent();
            try
            {
                InProgress();
                ToolStripEnabled();
                if (Properties.Settings.Default.Size == "Small")
                {
                    Width = Properties.Settings.Default.WidthSmall;
                    Height = Properties.Settings.Default.HeightSmall;
                }
                else if (Properties.Settings.Default.Size == "Medium")
                {
                    Width = Properties.Settings.Default.WidthMedium;
                    Height = Properties.Settings.Default.HeightMedium;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void UpdateTable()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "№";
            dataGridView1.Columns[2].HeaderText = "Дата приема";
            dataGridView1.Columns[3].HeaderText = "Дата начала ремонта";
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].HeaderText = "Дата окончания ремонта";
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].HeaderText = "Дата выдачи аппарата";
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].HeaderText = "Мастер";
            dataGridView1.Columns[7].HeaderText = "Тип аппарата/Производитель/Модель";
            dataGridView1.Columns[8].HeaderText = "Заказчик";
            dataGridView1.Columns[9].HeaderText = "Диагноз";
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;

            int[] percentInRepair = [0, 8, 11, 11, 0, 0, 12, 34, 12, 12, 0, 0, 0, 0, 0];
            int[] percentCompleted = [0, 8, 12, 0, 12, 0, 14, 40, 14, 0, 0, 0, 0, 0, 0];
            int[] percentOthers = [0, 7, 10, 10, 10, 10, 9, 32, 12, 0, 0, 0, 0, 0, 0];

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
                    InProgress();
                    break;
                case StatusOrderEnum.Completed:
                    OrderСompleted();
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    OrderGuarantee();
                    break;
                case StatusOrderEnum.Archive:
                    OrderArchive();
                    break;
                case StatusOrderEnum.Trash:
                    Trash();
                    break;
            }
        }
        private void InProgress()
        {
            status = StatusOrderEnum.InRepair;
            try
            {
                List<OrderTableDTO> orders = orderRepository.GetOrdersForTable(inProgress: true, deleted: false, dateCreation: true);
                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateTable();
                ChangeColorRows();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OrderСompleted()
        {
            status = StatusOrderEnum.Completed;
            try
            {
                List<OrderTableDTO> orders = orderRepository.GetOrdersForTable(inProgress: false, deleted: false, issue: false,
                    dateCompleted: true);
                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateTable();
                ChangeColorRows();
            }
            catch { }
        }

        private void OrderGuarantee()
        {
            status = StatusOrderEnum.GuaranteeIssue;
            try
            {
                List<OrderTableDTO> orders = orderRepository.GetOrdersForTable(inProgress: false, deleted: false, issue: true,
                    dateIssue: true);

                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].DateEndGuarantee.Value.Date < DateTime.Now.Date)
                        orders.Remove(orders[i]);
                }

                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateTable();
            }
            catch { }
        }

        private void OrderArchive()
        {
            status = StatusOrderEnum.Archive;
            try
            {
                List<OrderTableDTO> orders = orderRepository.GetOrdersForTable(inProgress: false, deleted: false, issue: true,
                    dateIssue: true);
                dataGridView1.DataSource = Funcs.ToDataTable(orders);

                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].DateEndGuarantee.Value.Date >= DateTime.Now.Date)
                        orders.Remove(orders[i]);
                }

                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateTable();
            }
            catch { }
        }

        private void Trash()
        {
            status = StatusOrderEnum.Trash;
            try
            {
                List<OrderTableDTO> orders = orderRepository.GetOrdersForTable(deleted: true, dateCompleted: true);
                dataGridView1.DataSource = Funcs.ToDataTable(orders);
                UpdateTable();
                ChangeColorRows();
            }
            catch { }
        }

        private void AddDeviceIntoRepair()
        {
            AddDeviceIntoRepair addDeviceForRepair = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (addDeviceForRepair.ShowDialog() == DialogResult.OK)
            {
                status = StatusOrderEnum.InRepair;
                /*UpdateDB();*/
                UpdateTableData();
                ToolStripEnabled();
            }
            FocusButton(status);
        }

        private void FeaturesOrderItem()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                FeaturesOrder featuresOrder = new(idOrder, status, logInSystem)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                featuresOrder.ShowDialog();
                if (featuresOrder.logIn)
                {
                    logInSystem = true;
                    labelLogIn.Text = Properties.Settings.Default.Login;
                }
                FocusButton(status);
                UpdateTableData();
                /*if (featuresOrder.pressBtnSave)
                    UpdateDB();*/
            }
            catch { }
        }

        private void DetailsItem()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                DetailsInOrder detailsInOrder = new(idOrder)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                detailsInOrder.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteOrder()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);

                if (status == StatusOrderEnum.Trash)
                {
                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Вы действительно хотите удалить аппарат из корзины?",
                        ButtonNoText = "Нет",
                        ButtonVisible = true
                    };

                    if (warning.ShowDialog() == DialogResult.OK)
                    {
                        orderRepository.RemoveOrder(orderDTO);
                        Trash();
                    }
                    FocusButton(status);
                }
                else
                {
                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Вы действительно хотите переместить аппарат в корзину?",
                        ButtonNoText = "Нет",
                        ButtonVisible = true
                    };

                    if (warning.ShowDialog() == DialogResult.OK)
                    {
                        orderDTO.Deleted = true;
                        var task = Task.Run(async () =>
                        {
                            await orderRepository.SaveOrderAsync(orderDTO);
                        });
                        task.Wait();
                        UpdateTableData();
                        /*UpdateDB();*/
                    }
                    FocusButton(status);
                }
            }
            catch { }
        }

        private void RecoveryOrder()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                orderDTO.Deleted = false;
                var task = Task.Run(async () =>
                {
                    await orderRepository.SaveOrderAsync(orderDTO);
                });
                task.Wait();
                Trash();
                /*UpdateDB();*/
            }
            catch { }
        }

        private void CompletedTag()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[nameof(OrderTableDTO.Id)].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                Warning warning = new();
                if (orderDTO.MainMasterId == null)
                {
                    warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Мастер в заказе не указан!"
                    };
                    warning.ShowDialog();
                    return;
                }
                if (!logInSystem)
                {
                    warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Войдите в систему!",
                        ButtonYesText = "Войти",
                        ButtonNoText = "Отмена",
                        ButtonVisible = true
                    };
                    if (warning.ShowDialog() == DialogResult.OK)
                    {
                        LogInToTheSystem();
                        if (!logInSystem)
                            return;
                    }
                    else return;
                }

                
                bool enabledPrice = true;

                if (orderDTO.ReturnUnderGuarantee)
                    enabledPrice = false;


                var detailsList = warehouseRepository.GetDetailsInOrder(idOrder);
                if (detailsList.Count == 0)
                {
                    warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Вы не использовали ни одной детали для ремонта данного устройства. " +
                            "\nХотите ли вы редактировать список деталей?",
                        ButtonNoText = "Нет",
                        ButtonVisible = true
                    };
                    if (warning.ShowDialog() == DialogResult.OK)
                    {
                        DetailsInOrder detailsInOrder = new(idOrder)
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        detailsInOrder.ShowDialog();
                    }
                }
                if (status == StatusOrderEnum.InRepair)
                {
                    CompletedOrder completedOrder = new(idOrder)
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        EnabledPrice = enabledPrice
                    };
                    if (completedOrder.ShowDialog() == DialogResult.OK)
                    {
                        InProgress();
                        /*UpdateDB(); */
                    }
                    FocusButton(status);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void IssueToClient()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);

                if(status == StatusOrderEnum.Completed)
                {
                    IssuingClient issuingClient = new(idOrder)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (issuingClient.ShowDialog() == DialogResult.OK)
                    {
                        OrderСompleted();
                    }
                    FocusButton(status);
                }
            }
            catch { }
        }

        private void ReturnInRepair()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                var malfunctionsOrderDTO = malfunctionOrderRepository.GetMalfunctionOrdersByIdOrder(idOrder);
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Вы действительно хотите отправить аппарат в доработку?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };

                if (warning.ShowDialog() == DialogResult.OK)
                {
                    if(status == StatusOrderEnum.Completed)
                    {
                        orderDTO.InProgress = true;
                        if (orderDTO.ReturnUnderGuarantee)
                            orderDTO.DateCompletedReturn = null;
                        else
                            orderDTO.DateCompleted = null;
                        var task = Task.Run(async () =>
                        {
                            await orderRepository.SaveOrderAsync(orderDTO);
                        });
                        task.Wait();

                        foreach(var malfunctionOrder in malfunctionsOrderDTO)
                        {
                            malfunctionOrderRepository.RemoveMalfunctionOrder(malfunctionOrder);
                        }
                        OrderСompleted();
                    }
                    /*UpdateDB();*/
                    FocusButton(status);
                }
            }
            catch { }
        }

        private void ReturnGuarantee()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Вы действительно хотите вернуть аппарат по гарантии?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };

                if (warning.ShowDialog() == DialogResult.OK)
                {
                    if (status == StatusOrderEnum.GuaranteeIssue)
                    {
                        orderDTO.DateCreation = DateTime.Now;
                        orderDTO.DateStartWork = DateTime.Now;
                        orderDTO.InProgress = true;
                        orderDTO.ReturnUnderGuarantee = true;
                        orderDTO.Issue = false;

                        var task = Task.Run(async () =>
                        {
                            await orderRepository.SaveOrderAsync(orderDTO);
                        });
                        task.Wait();
                        OrderGuarantee();
                    }
                    /*UpdateDB();*/
                    FocusButton(status);
                }
            }
            catch { }
        }

        private void SendMessage()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                int idClient = orderDTO.ClientId;
                MessageToClient message = new(idClient)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                message.ShowDialog();
            }
            catch { }
        }

        private void FeaturesClient()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                int idClient = orderDTO.ClientId;

                FeaturesClient featuresClient = new(idClient)
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                if (featuresClient.ShowDialog() == DialogResult.OK)
                    UpdateTableData();
                FocusButton(status);
            }
            catch { }
        }

        private void AddInWhitelist()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                var clientDTO = clientRepository.GetClient(orderDTO.ClientId);
                clientDTO.TypeClient = TypeClientEnum.white.ToString();
                var task = Task.Run(async () =>
                {
                    await clientRepository.SaveClientAsync(clientDTO);
                });
                task.Wait();
            }
            catch { }
        }

        private void AddInBlacklist()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                var clientDTO = clientRepository.GetClient(orderDTO.ClientId);
                clientDTO.TypeClient = TypeClientEnum.black.ToString();
                var task = Task.Run(async () =>
                {
                    await clientRepository.SaveClientAsync(clientDTO);
                });
                task.Wait();
            }
            catch { }
        }

        private void RemoveMarks()
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                var clientDTO = clientRepository.GetClient(orderDTO.ClientId);
                clientDTO.TypeClient = TypeClientEnum.normal.ToString();
                var task = Task.Run(async () =>
                {
                    await clientRepository.SaveClientAsync(clientDTO);
                });
                task.Wait();
            }
            catch { }
        }

        private void NewOrder()
        {
            int numberRow = dataGridView1.CurrentCell.RowIndex;
            idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
            var orderDTO = orderRepository.GetOrder(idOrder);

            AddDeviceIntoRepair newOrder = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                
                MainMasterName = orderDTO.MainMasterId == null ? "-" : orderDTO.MainMaster?.NameMaster,
                AdditionalMasterName = orderDTO.AdditionalMasterId == null ? "-" : orderDTO.AdditionalMaster?.NameMaster,
                TypeDevice = orderDTO.TypeTechnic.Name,
                BrandDevice = orderDTO.BrandTechnic.Name,
                FactoryNumber = orderDTO.FactoryNumber,
                Model = orderDTO.ModelTechnic,
                ClientName = orderDTO.Client.IdClient,
                ClientNameAddress = orderDTO.Client?.NameAndAddressClient,
                ClientSecondPhone = orderDTO.Client.NumberSecondPhone,
                TypeClient = "Старый клиент",
                Equipment = orderDTO.Equipment?.Name,
                Diagnosis = orderDTO.Diagnosis?.Name,
                Note = orderDTO.Note
            };

            if (newOrder.ShowDialog() == DialogResult.OK)
            {
                status = StatusOrderEnum.InRepair;
                /*UpdateDB();*/
                UpdateTableData();
            }
            FocusButton(status);
        }

        private void ButtonInProgress_Click(object sender, EventArgs e)
        {
            InProgress();
            ToolStripEnabled();
        }

        private void ButtonCompleted_Click(object sender, EventArgs e)
        {
            OrderСompleted();
            ToolStripEnabled();
        }

        private void ButtonGuarantee_Click(object sender, EventArgs e)
        {
            OrderGuarantee();
            ToolStripEnabled();
        }

        private void ButtonArchive_Click(object sender, EventArgs e)
        {
            OrderArchive();
            ToolStripEnabled();
        }

        private void ButtonTrash_Click(object sender, EventArgs e)
        {
            Trash();
            ToolStripEnabled();
        }

        private void ChangeColorRows()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                idOrder = Convert.ToInt32(dataGridView1.Rows[i].Cells["Id"].Value);
                var orderDTO = orderRepository.GetOrder(idOrder);
                if (orderDTO.MainMasterId == null)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.DimGray;
                    dataGridView1.Rows[i].DefaultCellStyle.SelectionForeColor = Color.DimGray;
                    continue;
                }
                string hexColor = dataGridView1.Rows[i].Cells["ColorRow"].Value.ToString();
                Color color = ColorTranslator.FromHtml(hexColor);
                if (color != CheckColor(idOrder))
                {
                    color = CheckColor(idOrder);
                    orderDTO.ColorRow = ColorTranslator.ToHtml(color);
                    var task = Task.Run(async () =>
                    {
                        await orderRepository.SaveOrderAsync(orderDTO);
                    });
                    task.Wait();
                }
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = color;
                dataGridView1.Rows[i].DefaultCellStyle.SelectionForeColor = color;

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["ReturnUnderGuarantee"].Value))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }

        private Color CheckColor(int idOrder)
        {
            Color color;
            var orderDTO = orderRepository.GetOrder(idOrder);
            var countDays = 0;
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    countDays = (DateTime.Now - orderDTO.DateStartWork.Value).Days;
                    break;
                case StatusOrderEnum.Completed:
                    countDays = (DateTime.Now - orderDTO.DateCompleted.Value).Days;
                    break;
            }

            if (countDays < Convert.ToInt32(Properties.Settings.Default.FirstLevelText))
                color = Properties.Settings.Default.FirstLevelColor;
            else if (countDays > Convert.ToInt32(Properties.Settings.Default.SecondLevelText))
                color = Properties.Settings.Default.ThirdLevelColor;
            else if (orderDTO.Issue)
                color = Color.Black;
            else
                color = Properties.Settings.Default.SecondLevelColor;
            return color;
        }

        private void ToolStripEnabled()
        {
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    buttonDetails.Enabled = true;
                    buttonDelete.Enabled = true;
                    buttonRecoveryOrder.Enabled = false;
                    buttonCompletedTag.Enabled = true;
                    buttonIssue.Enabled = false;
                    buttonReturnInRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = false;
                    buttonFeaturesOrder.Enabled = true;
                    break;
                case StatusOrderEnum.Completed:
                    buttonDetails.Enabled = false;
                    buttonDelete.Enabled = true;
                    buttonRecoveryOrder.Enabled = false;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = true;
                    buttonReturnInRepair.Enabled = true;
                    buttonReturnGuarantee.Enabled = false;
                    buttonFeaturesOrder.Enabled = true;
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    buttonDetails.Enabled = false;
                    buttonDelete.Enabled = true;
                    buttonRecoveryOrder.Enabled = false;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = false;
                    buttonReturnInRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = true;
                    buttonFeaturesOrder.Enabled = true;
                    break;
                case StatusOrderEnum.Archive:
                    buttonDetails.Enabled = false;
                    buttonDelete.Enabled = true;
                    buttonRecoveryOrder.Enabled = false;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = false;
                    buttonReturnInRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = false;
                    buttonFeaturesOrder.Enabled = true;
                    break;
                case StatusOrderEnum.Trash:
                    buttonDetails.Enabled = false;
                    buttonDelete.Enabled = true;
                    buttonRecoveryOrder.Enabled = true;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = false;
                    buttonReturnInRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = false;
                    buttonFeaturesOrder.Enabled = false;
                    break;
            }
        }

        private void ContextButton2()
        {
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    itemFeaturesOrder.Enabled = true;
                    itemDetails.Enabled = true;
                    itemDeleteOrder.Enabled = true;
                    itemRecoveryOrder.Enabled = false;
                    itemActionsOrder.Enabled = true;
                    itemOrderCompleted.Enabled = true;
                    itemOrderIssued.Enabled = false;
                    itemReturnToRevision.Enabled = false;
                    itemReturnUnderGuarantee.Enabled = false;
                    itemFeaturesClient.Enabled = true;
                    itemAddToWhitelist.Enabled = true;
                    itemAddToBlacklist.Enabled = true;
                    itemRemoveMarks.Enabled = true;
                    break;
                case StatusOrderEnum.Completed:
                    itemFeaturesOrder.Enabled = true;
                    itemDetails.Enabled = false;
                    itemDeleteOrder.Enabled = true;
                    itemRecoveryOrder.Enabled = false;
                    itemActionsOrder.Enabled = true;
                    itemOrderCompleted.Enabled = false;
                    itemOrderIssued.Enabled = true;
                    itemReturnToRevision.Enabled = true;
                    itemReturnUnderGuarantee.Enabled = false;
                    itemFeaturesClient.Enabled = true;
                    itemAddToWhitelist.Enabled = true;
                    itemAddToBlacklist.Enabled = true;
                    itemRemoveMarks.Enabled = true;
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    itemFeaturesOrder.Enabled = true;
                    itemDetails.Enabled = false;
                    itemDeleteOrder.Enabled = true;
                    itemRecoveryOrder.Enabled = false;
                    itemActionsOrder.Enabled = true;
                    itemOrderCompleted.Enabled = false;
                    itemOrderIssued.Enabled = false;
                    itemReturnToRevision.Enabled = false;
                    itemReturnUnderGuarantee.Enabled = true;
                    itemFeaturesClient.Enabled = true;
                    itemAddToWhitelist.Enabled = true;
                    itemAddToBlacklist.Enabled = true;
                    itemRemoveMarks.Enabled = true;
                    break;
                case StatusOrderEnum.Archive:
                    itemFeaturesOrder.Enabled = true;
                    itemDetails.Enabled = false;
                    itemDeleteOrder.Enabled = true;
                    itemRecoveryOrder.Enabled = false;
                    itemActionsOrder.Enabled = false;
                    itemFeaturesClient.Enabled = true;
                    itemAddToWhitelist.Enabled = true;
                    itemAddToBlacklist.Enabled = true;
                    itemRemoveMarks.Enabled = true;
                    break;
                case StatusOrderEnum.Trash:
                    itemFeaturesOrder.Enabled = false;
                    itemDetails.Enabled = false;
                    itemDeleteOrder.Enabled = true;
                    itemRecoveryOrder.Enabled = true;
                    itemActionsOrder.Enabled = false;
                    itemFeaturesClient.Enabled = true;
                    itemAddToWhitelist.Enabled = true;
                    itemAddToBlacklist.Enabled = true;
                    itemRemoveMarks.Enabled = true;
                    break;
            }
            if (dataGridView1.RowCount > 0)
                itemCreateOrder.Enabled = true;
            else
                itemCreateOrder.Enabled = false;

        }

        private void ContextButton3()
        {
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    itemGetting.Enabled = true;
                    itemIssuing.Enabled = false;
                    break;
                case StatusOrderEnum.Completed:
                    itemGetting.Enabled = true;
                    itemIssuing.Enabled = false;
                    break;
                case StatusOrderEnum.GuaranteeIssue:
                    itemGetting.Enabled = true;
                    itemIssuing.Enabled = true;
                    break;
                case StatusOrderEnum.Archive:
                    itemGetting.Enabled = true;
                    itemIssuing.Enabled = true;
                    break;
                case StatusOrderEnum.Trash:
                    itemGetting.Enabled = false;
                    itemIssuing.Enabled = false;
                    break;
            }
        }

        private void DataGridView1_VisibleChanged(object sender, EventArgs e)
        {
            ChangeColorRows();
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dataGridView1.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right && ht.Type != DataGridViewHitTestType.None)
            {
                contextMenu1.Show(MousePosition);
                switch (status)
                {
                    case StatusOrderEnum.InRepair:
                        item1.Enabled = true;
                        item2.Enabled = true;
                        item3.Enabled = true;
                        item4.Enabled = false;
                        item5.Enabled = true;
                        item5_1.Enabled = true;
                        item5_2.Enabled = false;
                        item5_3.Enabled = false;
                        item5_4.Enabled = false;
                        break;
                    case StatusOrderEnum.Completed:
                        item1.Enabled = true;
                        item2.Enabled = false;
                        item3.Enabled = true;
                        item4.Enabled = false;
                        item5.Enabled = true;
                        item5_1.Enabled = false;
                        item5_2.Enabled = true;
                        item5_3.Enabled = true;
                        item5_4.Enabled = false;
                        break;
                    case StatusOrderEnum.GuaranteeIssue:
                        item1.Enabled = true;
                        item2.Enabled = false;
                        item3.Enabled = true;
                        item4.Enabled = false;
                        item5.Enabled = true;
                        item5_1.Enabled = false;
                        item5_2.Enabled = false;
                        item5_3.Enabled = false;
                        item5_4.Enabled = true;
                        break;
                    case StatusOrderEnum.Archive:
                        item1.Enabled = true;
                        item2.Enabled = false;
                        item3.Enabled = true;
                        item4.Enabled = false;
                        item5.Enabled = false;
                        break;
                    case StatusOrderEnum.Trash:
                        item1.Enabled = false;
                        item2.Enabled = false;
                        item3.Enabled = true;
                        item4.Enabled = true;
                        item5.Enabled = false;
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

        private void Item1_Click(object sender, EventArgs e)
        {
            FeaturesOrderItem();
        }

        private void Item2_Click(object sender, EventArgs e)
        {
            DetailsItem();
        }

        private void Item3_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        private void Item4_Click(object sender, EventArgs e)
        {
            RecoveryOrder();
        }

        private void Item5_1_Click(object sender, EventArgs e)
        {
            CompletedTag();
        }

        private void Item5_2_Click(object sender, EventArgs e)
        {
            IssueToClient();
        }

        private void Item5_3_Click(object sender, EventArgs e)
        {
            ReturnInRepair();
        }

        private void Item5_4_Click(object sender, EventArgs e)
        {
            ReturnGuarantee();
        }

        private void Item6_1_Click(object sender, EventArgs e)
        {
            FeaturesClient();
        }

        private void Item6_2_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void Item6_3_1_Click(object sender, EventArgs e)
        {
            AddInWhitelist();
        }

        private void Item6_3_2_Click(object sender, EventArgs e)
        {
            AddInBlacklist();
        }

        private void Item6_3_3_Click(object sender, EventArgs e)
        {
            RemoveMarks();
        }

        private void Item7_Click(object sender, EventArgs e)
        {
            NewOrder();
        }

        private void ButtonAddDevice_Click(object sender, EventArgs e)
        {
            AddDeviceIntoRepair();
        }

        private void ButtonMasters_Click(object sender, EventArgs e)
        {
            Masters addMaster = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMaster.ShowDialog();
            FocusButton(status);
        }

        private void ButtonDevice_Click(object sender, EventArgs e)
        {
            TypesTechnic addDevice = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addDevice.ShowDialog();
            FocusButton(status);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelText = "Вы действительно хотите выйти из программы?",
                ButtonNoText = "Нет",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
                Application.Exit();
            FocusButton(status);
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            DetailsItem();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        private void ButtonRestoring_Click(object sender, EventArgs e)
        {
            RecoveryOrder();
        }

        private void ButtonCompletedTag_Click(object sender, EventArgs e)
        {
            CompletedTag();
        }

        private void ButtonIssue_Click(object sender, EventArgs e)
        {
            IssueToClient();
        }

        private void ButtonReturnInRepair_Click(object sender, EventArgs e)
        {
            ReturnInRepair();
        }

        private void ButtonReturnGuarantee_Click(object sender, EventArgs e)
        {
            ReturnGuarantee();
        }

        private void ButtonFeaturesOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                FeaturesOrder featuresOrder = new(idOrder, status, logInSystem)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                featuresOrder.ShowDialog();
                FocusButton(status);
                UpdateTableData();
                /*if (featuresOrder.pressBtnSave)
                    UpdateDB();*/
            }
            catch { }
        }

        private void ButtonFeaturesClient_Click(object sender, EventArgs e)
        {
            FeaturesClient();
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
            contextButton1.Show(new Point(screenPos.X, screenPos.Y + labelDataBase.Height));
        }

        private void LabelWorkData_Click(object sender, EventArgs e)
        {
            ContextButton2();
            var screenPos = labelWorkData.PointToScreen(Point.Empty);
            contextButton2.Show(new Point(screenPos.X, screenPos.Y + labelWorkData.Height));
        }

        private void LabelDocuments_Click(object sender, EventArgs e)
        {
            ContextButton3();
            var screenPos = labelDocuments.PointToScreen(Point.Empty);
            contextButton3.Show(new Point(screenPos.X, screenPos.Y + labelDocuments.Height));
        }

        private void LabelReports_Click(object sender, EventArgs e)
        {
            var screenPos = labelReports.PointToScreen(Point.Empty);
            contextButton4.Show(new Point(screenPos.X, screenPos.Y + labelReports.Height));
        }

        private void LabelView_Click(object sender, EventArgs e)
        {
            var screenPos = labelView.PointToScreen(Point.Empty);
            contextButton5.Show(new Point(screenPos.X, screenPos.Y + labelReports.Height));
        }

        private void ItemAddMasters_Click(object sender, EventArgs e)
        {
            Masters addMaster = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMaster.ShowDialog();
            FocusButton(status);
        }

        private void ItemAddBrand_Click(object sender, EventArgs e)
        {
            BrandsTechnic addBrand = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addBrand.ShowDialog();
            FocusButton(status);
        }
        private void ItemAddDevice_Click(object sender, EventArgs e)
        {
            TypesTechnic addDevice = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addDevice.ShowDialog();
            FocusButton(status);
        }

        private void ItemClients_Click(object sender, EventArgs e)
        {
            GuideClients guideClients = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            guideClients.ShowDialog();
            FocusButton(status);
        }

        private void ItemWarehouse_Click(object sender, EventArgs e)
        {
            DetailsInWarehouse details = new(true)
            {
                StartPosition = FormStartPosition.CenterParent,
                VisibleBtnAdd = false
            };
            details.ShowDialog();
            FocusButton(status);
        }

        private void ItemMalfunction_Click(object sender, EventArgs e)
        {
            MalfunctionEquipmentDiagnosis malfunctionEquipmentDiagnosis = new(NameTableToEditEnum.Malfunction)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            malfunctionEquipmentDiagnosis.ShowDialog();
            FocusButton(status);
        }

        private void ItemDiagnosis_Click(object sender, EventArgs e)
        {
            MalfunctionEquipmentDiagnosis malfunctionEquipmentDiagnosis = new(NameTableToEditEnum.Diagnosis)
            {
                StartPosition = FormStartPosition.CenterParent,
                Text = "Диагнозы"
            };
            malfunctionEquipmentDiagnosis.ShowDialog();
            UpdateTableData();
            FocusButton(status);
        }

        private void ItemEquipment_Click(object sender, EventArgs e)
        {
            MalfunctionEquipmentDiagnosis malfunctionEquipmentDiagnosis = new(NameTableToEditEnum.Equipment)
            {
                StartPosition = FormStartPosition.CenterParent,
                Text = "Комплектация"
            };
            malfunctionEquipmentDiagnosis.ShowDialog();
            FocusButton(status);
        }

        private void ItemCopyBD_Click(object sender, EventArgs e)
        {
            try
            {
                var pickDatabaseFrom = Environment.CurrentDirectory;
                var srcFile = Path.Combine(pickDatabaseFrom, "computerservice.db");
                var destFile = Path.Combine(pickDatabaseFrom, "./Res/computerservice.db");
                if (File.Exists(destFile))
                    File.Delete(destFile);
            }
            catch
            {
                Warning warning = new()
                {
                    LabelText = "Ошибка при создании резервной копии базы данных!",
                    StartPosition = FormStartPosition.CenterParent
                };
                warning.ShowDialog();
            }
        }

        private void ItemUpdateService_Click(object sender, EventArgs e)
        {
            UpdateDB();
        }

        private void ItemPathDB_Click(object sender, EventArgs e)
        {
            PathDB pathDB = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            pathDB.ShowDialog();
            /*UpdateDB();*/
            UpdateTableData();
        }

        private void ItemOrg_Click(object sender, EventArgs e)
        {
            Organization org = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            org.ShowDialog();
        }

        private void ItemLogIn_Click(object sender, EventArgs e)
        {
            LogInToTheSystem();
        }

        private void ItemExit_Click(object sender, EventArgs e)
        {
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelText = "Вы действительно хотите выйти из программы?",
                ButtonNoText = "Нет",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
                Application.Exit();
            FocusButton(status);
        }

        private void ItemAddDeviceForRepair_Click(object sender, EventArgs e)
        {
            AddDeviceIntoRepair();
        }

        private void ItemFeaturesOrder_Click(object sender, EventArgs e)
        {
            FeaturesOrderItem();
        }

        private void ItemDetails_Click(object sender, EventArgs e)
        {
            DetailsItem();
        }

        private void ItemDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        private void ItemRecoveryOrder_Click(object sender, EventArgs e)
        {
            RecoveryOrder();
        }

        private void ItemOrderCompleted_Click(object sender, EventArgs e)
        {
            CompletedTag();
        }

        private void ItemOrderIssued_Click(object sender, EventArgs e)
        {
            IssueToClient();
        }

        private void ItemReturnToRevision_Click(object sender, EventArgs e)
        {
            ReturnInRepair();
        }

        private void ItemReturnUnderGuarantee_Click(object sender, EventArgs e)
        {
            ReturnGuarantee();
        }

        private void ItemFeaturesClient_Click(object sender, EventArgs e)
        {
            FeaturesClient();
        }

        private void ItemMessageToClient_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void ItemAddToWhitelist_Click(object sender, EventArgs e)
        {
            AddInWhitelist();
        }

        private void ItemAddToBlacklist_Click(object sender, EventArgs e)
        {
            AddInBlacklist();
        }

        private void ItemRemoveMarks_Click(object sender, EventArgs e)
        {
            RemoveMarks();
        }

        private void ItemSearchOrder_Click(object sender, EventArgs e)
        {
            NewOrder();
        }

        private void ItemSalary_Click(object sender, EventArgs e)
        {
            CalculatingEmployeeSalaries salary = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            salary.ShowDialog();
            FocusButton(status);
        }

        private void ItemColor_Click(object sender, EventArgs e)
        {
            View view = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            view.ShowDialog();
            UpdateTableData();
        }

        private void ItemGetting_Click(object sender, EventArgs e)
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                gettingReport.Report(idOrder);
                FocusButton(status);
            }
            catch { }
        }

        private void ItemIssuing_Click(object sender, EventArgs e)
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                issuingReport.Report(idOrder);
                FocusButton(status);
            }
            catch { }
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ChangeColorRows();
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

        private static void CopyDBForService()
        {
            var pickDatabaseFrom = Environment.CurrentDirectory;
            var srcFile = Path.Combine(pickDatabaseFrom, "computerservice.db");
            var destFile = Path.Combine(pickDatabaseFrom, "./Service/computerservice.db");
            if (File.Exists(destFile))
                File.Delete(destFile);

            File.Copy(srcFile, destFile);
        }

        private static void UpdateDB()
        {
            try
            {
                CopyDBForService();
                var path = Path.Combine(Environment.CurrentDirectory, "./Service/computerservice.db");
                FtpClient client = new()
                {
                    Host = "198.37.116.30",
                    Credentials = new NetworkCredential("lizaveta", "wYwu6@L?2mhUT2?")
                };
                client.Connect();
                client.UploadFile(path, "www.webappdb.somee.com//computerservice.db");

            }
            catch (Exception exp)
            {
                Warning warning = new()
                {
                    LabelText = exp.Message,
                    StartPosition = FormStartPosition.CenterParent
                };

                warning.ShowDialog();
            }
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            FocusButton(status);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ChangeSizeAndLocation();
        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FeaturesOrderItem();
        }

        private void TextBoxIdOrder_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void TextBoxDateCreation_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void TextBoxDateStartWork_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void TextBoxNameMaster_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void TextBoxTypeDevice_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void TextBoxBrandDevice_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void TextBoxModel_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void TextBoxNameClient_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            var ordersDTO = orderRepository.GetOrdersBySearch(numberOrder: textBoxIdOrder.Text, 
                dateCreation: textBoxDateCreation.Text, dateStartWork: textBoxDateStartWork.Text, 
                masterName: textBoxNameMaster.Text, typeTechnic: textBoxTypeDevice.Text, 
                brandTechnic: textBoxBrandDevice.Text, modelTechnic: textBoxModel.Text, idClient: textBoxNameClient.Text);
  
            dataGridView1.DataSource = Funcs.ToDataTable(ordersDTO);
            ChangeColorRows();
            if (CheckNoFilters())
                UpdateTableData();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.Size == "Small")
            {
                Properties.Settings.Default.WidthSmall = Width;
                Properties.Settings.Default.HeightSmall = Height;
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.Size == "Medium")
            {
                Properties.Settings.Default.WidthMedium = Width;
                Properties.Settings.Default.HeightMedium = Height;
                Properties.Settings.Default.Save();
            }
        }

        private bool CheckNoFilters()
        {
            if (string.IsNullOrEmpty(textBoxIdOrder.Text) &&
                string.IsNullOrEmpty(textBoxDateCreation.Text) &&
                string.IsNullOrEmpty(textBoxDateStartWork.Text) &&
                string.IsNullOrEmpty(textBoxNameMaster.Text) &&
                string.IsNullOrEmpty(textBoxTypeDevice.Text) &&
                string.IsNullOrEmpty(textBoxBrandDevice.Text) &&
                string.IsNullOrEmpty(textBoxModel.Text) &&
                string.IsNullOrEmpty(textBoxNameClient.Text))
                return true;
            else return false;
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            textBoxIdOrder.Text = string.Empty;
            textBoxDateCreation.Text = string.Empty;
            textBoxDateStartWork.Text = string.Empty;
            textBoxNameMaster.Text = string.Empty;
            textBoxTypeDevice.Text = string.Empty;
            textBoxBrandDevice.Text = string.Empty;
            textBoxModel.Text = string.Empty;
            textBoxNameClient.Text = string.Empty;
            UpdateTableData();
            FocusButton(status);
        }

        private void ItemSmall_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Size == "Medium")
            {
                Properties.Settings.Default.WidthMedium = Width;
                Properties.Settings.Default.HeightMedium = Height;
                Properties.Settings.Default.Save();
            }
            Properties.Settings.Default.Size = "Small";
            Properties.Settings.Default.Save();

            Width = Properties.Settings.Default.WidthSmall;
            Height = Properties.Settings.Default.HeightSmall;
        }

        private void ItemMedium_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Size == "Small")
            {
                Properties.Settings.Default.WidthSmall = Width;
                Properties.Settings.Default.HeightSmall = Height;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.Size = "Medium";
            Properties.Settings.Default.Save();

            Width = Properties.Settings.Default.WidthMedium;
            Height = Properties.Settings.Default.HeightMedium;
        }

        private void SmallWindow()
        {
            int buttonMenuX = Width - buttonInProgress.Width - 25;
            int heightButtonMenu = buttonInProgress.Height;

            dataGridView1.Width = Width - buttonInProgress.Width - 50;
            dataGridView1.Height = Height - dataGridView1.Location.Y - heightButtonMenu - 70;

            int endTable = dataGridView1.Width + dataGridView1.Location.X;
            int marginHeightMenuX = (dataGridView1.Height - heightButtonMenu * 4) / 3;

            labelLogIn.Location = new Point(buttonMenuX, labelLogIn.Location.Y);
            buttonInProgress.Location = new Point(buttonMenuX, buttonInProgress.Location.Y);
            buttonCompleted.Location = new Point(buttonMenuX, buttonInProgress.Location.Y + heightButtonMenu + marginHeightMenuX);
            buttonGuarantee.Location = new Point(buttonMenuX, buttonCompleted.Location.Y + heightButtonMenu + marginHeightMenuX);
            buttonArchive.Location = new Point(buttonMenuX, buttonGuarantee.Location.Y + heightButtonMenu + marginHeightMenuX);
            buttonTrash.Location = new Point(buttonMenuX, Height - buttonTrash.Height - 60);
            buttonReset.Location = new Point(endTable - buttonReset.Width, buttonTrash.Location.Y);
            buttonReset.Height = heightButtonMenu;

            int widthTextBox = 74;
            int widthLT = 4;
            int thirdLine = buttonReset.Location.Y + buttonReset.Height - labelDateCreation.Height;
            int secondLine = thirdLine - labelDateCreation.Height - 11;
            int thirdColumn = buttonReset.Location.X - widthTextBox - 15;
            int marginWidthFilter = ((thirdColumn + textBoxTypeDevice.Width) - (widthTextBox + widthLT) * 3 - 
                labelIdOrder.Width - labelDateStartWork.Width - labelTypeDevice.Width) / 2;

            labelIdOrder.Location = new Point(labelIdOrder.Location.X, buttonReset.Location.Y);
            textBoxIdOrder.Location = new Point(textBoxIdOrder.Location.X, buttonReset.Location.Y);
            textBoxIdOrder.Width = widthTextBox;
            int secondColumn = textBoxIdOrder.Location.X + textBoxIdOrder.Width + marginWidthFilter;
            labelDateStartWork.Location = new Point(secondColumn, buttonReset.Location.Y);
            textBoxDateStartWork.Location = new Point(secondColumn + labelDateStartWork.Width + widthLT, buttonReset.Location.Y);
            textBoxDateStartWork.Width = widthTextBox;
            textBoxTypeDevice.Location = new Point(thirdColumn, buttonReset.Location.Y);
            textBoxTypeDevice.Width = widthTextBox;
            labelTypeDevice.Location = new Point(thirdColumn - labelTypeDevice.Width - widthLT, buttonReset.Location.Y);
            textBoxModel.Location = new Point(textBoxIdOrder.Location.X, thirdLine);
            textBoxModel.Width = widthTextBox;
            labelModel.Location = new Point(textBoxModel.Location.X - labelModel.Width - widthLT, thirdLine);

            labelDateCreation.Location = new Point(labelDateCreation.Location.X, secondLine);
            textBoxDateCreation.Location = new Point(textBoxDateCreation.Location.X, secondLine);
            textBoxDateCreation.Width = widthTextBox;
            labelNameMaster.Location = new Point(secondColumn, secondLine);
            textBoxNameMaster.Location = new Point(secondColumn + labelNameMaster.Width + widthLT, secondLine);
            textBoxNameMaster.Width = widthTextBox;
            textBoxBrandDevice.Location = new Point(thirdColumn, secondLine);
            textBoxBrandDevice.Width = widthTextBox;
            labelBrandDevice.Location = new Point(thirdColumn - labelBrandDevice.Width - widthLT, secondLine);
            textBoxNameClient.Location = new Point(textBoxNameMaster.Location.X, thirdLine);
            textBoxNameClient.Width = widthTextBox;
            labelNameClient.Location = new Point(textBoxNameClient.Location.X - labelNameClient.Width - widthLT, thirdLine);
        }

        private void MediumWindow()
        {
            int buttonMenuX = Width - buttonInProgress.Width - 25;
            int heightButtonMenu = buttonInProgress.Height;
            int heightReset = 77;
            
            dataGridView1.Width = Width - buttonInProgress.Width - 50;
            dataGridView1.Height = Height - dataGridView1.Location.Y - heightReset - 70;

            int bottomTable = dataGridView1.Height + dataGridView1.Location.Y;
            int marginHeightMenuX = (dataGridView1.Height - heightButtonMenu * 5) / 4; 

            labelLogIn.Location = new Point(buttonMenuX, labelLogIn.Location.Y);
            buttonInProgress.Location = new Point(buttonMenuX, buttonInProgress.Location.Y);
            buttonCompleted.Location = new Point(buttonMenuX, buttonInProgress.Location.Y + heightButtonMenu + marginHeightMenuX);
            buttonGuarantee.Location = new Point(buttonMenuX, buttonCompleted.Location.Y + heightButtonMenu + marginHeightMenuX);
            buttonArchive.Location = new Point(buttonMenuX, buttonGuarantee.Location.Y + heightButtonMenu + marginHeightMenuX);
            buttonTrash.Location = new Point(buttonMenuX, bottomTable - buttonTrash.Height);
            buttonReset.Location = new Point(buttonMenuX, Height - heightReset - 60);
            buttonReset.Height = heightReset;

            int bottomMargin = buttonReset.Location.Y + buttonReset.Height - labelDateCreation.Height;
            int endTable = dataGridView1.Width + dataGridView1.Location.X;
            int widthTextBox = 120;
            int widthLT = 4;
            int marginWidthFilter = (endTable - (widthTextBox + widthLT) * 4 - labelIdOrder.Width - labelDateStartWork.Width -
                labelTypeDevice.Width - labelModel.Width) / 3;

            labelIdOrder.Location = new Point(labelIdOrder.Location.X, buttonReset.Location.Y);
            textBoxIdOrder.Location = new Point(textBoxIdOrder.Location.X, buttonReset.Location.Y);
            textBoxIdOrder.Width = widthTextBox;
            int secondColumn = textBoxIdOrder.Location.X + textBoxIdOrder.Width + marginWidthFilter;
            labelDateStartWork.Location = new Point(secondColumn, buttonReset.Location.Y);
            textBoxDateStartWork.Location = new Point(secondColumn + labelDateStartWork.Width + widthLT, buttonReset.Location.Y);
            textBoxDateStartWork.Width = widthTextBox;
            int thirdColumn = textBoxDateStartWork.Location.X + textBoxDateStartWork.Width + marginWidthFilter;
            labelTypeDevice.Location = new Point(thirdColumn, buttonReset.Location.Y);
            textBoxTypeDevice.Location = new Point(thirdColumn + labelTypeDevice.Width + widthLT, buttonReset.Location.Y);
            textBoxTypeDevice.Width = widthTextBox;
            textBoxModel.Location = new Point(endTable - widthTextBox, buttonReset.Location.Y);
            textBoxModel.Width = widthTextBox;
            labelModel.Location = new Point(textBoxModel.Location.X - labelModel.Width - widthLT, buttonReset.Location.Y);
            

            labelDateCreation.Location = new Point(labelDateCreation.Location.X, bottomMargin);
            textBoxDateCreation.Location = new Point(textBoxDateCreation.Location.X, bottomMargin);
            textBoxDateCreation.Width = widthTextBox;
            labelNameMaster.Location = new Point(secondColumn, bottomMargin);
            textBoxNameMaster.Location = new Point(secondColumn + labelNameMaster.Width + widthLT, bottomMargin);
            textBoxNameMaster.Width = widthTextBox;
            labelBrandDevice.Location = new Point(thirdColumn, bottomMargin);
            textBoxBrandDevice.Location = new Point(thirdColumn + labelBrandDevice.Width + widthLT, bottomMargin);
            textBoxBrandDevice.Width = widthTextBox;
            textBoxNameClient.Location = new Point(endTable - widthTextBox, bottomMargin);
            textBoxNameClient.Width = widthTextBox;
            labelNameClient.Location = new Point(textBoxNameClient.Location.X - labelNameClient.Width - widthLT, bottomMargin);
        }

        private void ChangeSizeAndLocation()
        {
            if (Properties.Settings.Default.Size == "Small")
                SmallWindow();
            else if (Properties.Settings.Default.Size == "Medium")
                MediumWindow();
            try
            {
                UpdateTable();
            }
            catch { }
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
                    /*labelClientId.Location = new Point(rectangle.X + dataGridView1.Location.X,
                        rectangle.Y + dataGridView1.Location.Y + rectangle.Height);*/
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
                labelLogIn.Text = "Войти";
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
                contextAccount.Show(new Point(screenPos.X - (contextAccount.Width - labelLogIn.Width),
                    screenPos.Y + labelLogIn.Height));
            }
            else LogInToTheSystem();
        }

        public void LogInToTheSystem()
        {
            LogInSystem logIn = new(true)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (logIn.ShowDialog() == DialogResult.OK)
            {
                logInSystem = true;
                labelLogIn.Text = Properties.Settings.Default.Login;
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
            LogInSystem logInSystem = new(false)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            logInSystem.ShowDialog();
        }

        private void ItemLogOut_Click(object sender, EventArgs e)
        {
            labelLogIn.Text = "Войти";
            logInSystem = false;
        }
    }
}
