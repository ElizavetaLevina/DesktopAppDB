using WinFormsApp1.Model;
using System.Data;
using System.Diagnostics;
using ClosedXML.Report;
using System.Net;
using FluentFTP;
using Color = System.Drawing.Color;
using WinFormsApp1.DTO;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public int idRow;
        public string status = "";
        public bool logInSystem = false;
        public Form1()
        {
            InitializeComponent();
            try
            {
                InProgress();
                ToolStripEnabled();
                if (Properties.Settings.Default.Size == "Small")
                {
                    this.Width = Properties.Settings.Default.WidthSmall;
                    this.Height = Properties.Settings.Default.HeightSmall;
                }
                else if (Properties.Settings.Default.Size == "Medium")
                {
                    this.Width = Properties.Settings.Default.WidthMedium;
                    this.Height = Properties.Settings.Default.HeightMedium;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void UpdateTable()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[1].HeaderText = "Дата приема";
            dataGridView1.Columns[2].HeaderText = "Дата начала ремонта";
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].HeaderText = "Дата окончания ремонта";
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].HeaderText = "Дата выдачи аппарата";
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].HeaderText = "Мастер";
            dataGridView1.Columns[6].HeaderText = "Тип аппарата";
            dataGridView1.Columns[7].HeaderText = "Производитель";
            dataGridView1.Columns[8].HeaderText = "Модель";
            dataGridView1.Columns[9].HeaderText = "Заказчик";
            dataGridView1.Columns[9].Visible = true;
            dataGridView1.Columns[10].HeaderText = "Диагноз";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;

            int[] percentInRepair = [8, 12, 12, 0, 0, 12, 14, 16, 14, 0, 12, 0, 0, 0, 0, 0];
            int[] percentCompleted = [8, 12, 0, 12, 0, 14, 16, 14, 10, 14, 0, 0, 0, 0, 0, 0];
            int[] percentOthers = [7, 10, 10, 10, 10, 9, 12, 12, 8, 12, 0, 0, 0, 0, 0, 0];

            switch (status)
            {
                case "InRepair":
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = true;
                    break;
                case "Completed":
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    break;
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Visible)
                {
                    double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percentOthers[i];
                    switch (status)
                    {
                        case "InRepair":
                            width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percentInRepair[i];
                            break;
                        case "Completed":
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
                case "InRepair":
                    InProgress();
                    break;
                case "Completed":
                    OrderСompleted();
                    break;
                case "GuaranteeIssue":
                    OrderGuarantee();
                    break;
                case "Archive":
                    OrderArchive();
                    break;
                case "Trash":
                    Trash();
                    break;
            }
        }
        private void InProgress()
        {
            status = "InRepair";
            using Context context = new();
            try
            {
                var list = context.Orders.Where(i => i.InProgress == true && i.Deleted == false).Select(
                    a => new //OrderDTO(a)
                    {
                        a.Id,
                        a.DateCreation,
                        a.DateStartWork,
                        a.DateCompleted,
                        a.DateIssue,
                        a.Master.NameMaster,
                        a.TypeTechnic.NameTypeTechnic,
                        a.BrandTechnic.NameBrandTechnic,
                        a.ModelTechnic,
                        a.Client.IdClient,
                        a.Diagnosis.Name,
                        a.Deleted,
                        a.ReturnUnderGuarantee,
                        a.Guarantee,
                        a.DateEndGuarantee,
                        a.ColorRow
                    }).OrderByDescending(i => i.DateStartWork).ToList();
                dataGridView1.DataSource = Funcs.ToDataTable(list);
                UpdateTable();
                ChangeColorRows();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OrderСompleted()
        {
            status = "Completed";
            using Context context = new();
            try
            {
                var list = context.Orders.Where(i => i.InProgress == false && !i.Deleted && i.Issue == false).Select(a => new
                {
                    a.Id,
                    a.DateCreation,
                    a.DateStartWork,
                    a.DateCompleted,
                    a.DateIssue,
                    a.Master.NameMaster,
                    a.TypeTechnic.NameTypeTechnic,
                    a.BrandTechnic.NameBrandTechnic,
                    a.ModelTechnic,
                    a.Client.IdClient,
                    a.Diagnosis.Name,
                    a.Deleted,
                    a.ReturnUnderGuarantee,
                    a.Guarantee,
                    a.DateEndGuarantee,
                    a.ColorRow
                }).OrderByDescending(i => i.DateCompleted).ToList();
                dataGridView1.DataSource = Funcs.ToDataTable(list);
                UpdateTable();
                ChangeColorRows();
            }
            catch { }
        }

        private void OrderGuarantee()
        {
            status = "GuaranteeIssue";
            using Context context = new();
            try
            {
                var list = context.Orders.Where(i => i.Issue == true && !i.Deleted && i.Guarantee > 0).Select(a => new
                {
                    a.Id,
                    a.DateCreation,
                    a.DateStartWork,
                    a.DateCompleted,
                    a.DateIssue,
                    a.Master.NameMaster,
                    a.TypeTechnic.NameTypeTechnic,
                    a.BrandTechnic.NameBrandTechnic,
                    a.ModelTechnic,
                    a.Client.IdClient,
                    a.Diagnosis.Name,
                    a.Deleted,
                    a.ReturnUnderGuarantee,
                    a.Guarantee,
                    a.DateEndGuarantee,
                    a.ColorRow
                }).OrderByDescending(i => i.DateIssue).ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    if (DateTime.Parse(list[i].DateEndGuarantee) < DateTime.Now)
                        list.Remove(list[i]);
                }

                dataGridView1.DataSource = Funcs.ToDataTable(list);
                UpdateTable();
            }
            catch { }
        }

        private void OrderArchive()
        {
            status = "Archive";
            using Context context = new();
            try
            {
                var list = context.Orders.Where(i => i.Issue == true && i.Guarantee == 0 && !i.Deleted).Select(a => new
                {
                    a.Id,
                    a.DateCreation,
                    a.DateStartWork,
                    a.DateCompleted,
                    a.DateIssue,
                    a.Master.NameMaster,
                    a.TypeTechnic.NameTypeTechnic,
                    a.BrandTechnic.NameBrandTechnic,
                    a.ModelTechnic,
                    a.Client.IdClient,
                    a.Diagnosis.Name,
                    a.Deleted,
                    a.ReturnUnderGuarantee,
                    a.Guarantee,
                    a.DateEndGuarantee,
                    a.ColorRow
                }).OrderByDescending(i => i.DateIssue).ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    if (DateTime.Parse(list[i].DateEndGuarantee) < DateTime.Now)
                        list.Remove(list[i]);
                }

                dataGridView1.DataSource = Funcs.ToDataTable(list);
                UpdateTable();
            }
            catch { }
        }

        private void Trash()
        {
            status = "Trash";
            using Context context = new();
            try
            {
                var list = context.Orders.Where(i => i.Deleted == true).Select(a => new
                {
                    a.Id,
                    a.DateCreation,
                    a.DateStartWork,
                    a.DateCompleted,
                    a.DateIssue,
                    a.Master.NameMaster,
                    a.TypeTechnic.NameTypeTechnic,
                    a.BrandTechnic.NameBrandTechnic,
                    a.ModelTechnic,
                    a.Client.IdClient,
                    a.Diagnosis.Name,
                    a.Deleted,
                    a.ReturnUnderGuarantee,
                    a.Guarantee,
                    a.DateEndGuarantee,
                    a.ColorRow
                }).OrderByDescending(i => i.Id).ToList();
                dataGridView1.DataSource = Funcs.ToDataTable(list);
                UpdateTable();
                ChangeColorRows();
            }
            catch { }
        }

        private void AddDevice()
        {
            AddDeviceForRepair addDeviceForRepair = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (addDeviceForRepair.ShowDialog() == DialogResult.OK)
            {
                status = "InRepair";
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
                idRow = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                FeaturesOrder featuresOrder = new(idRow, status, logInSystem)
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
                idRow = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                AddDetails addDetails = new(idRow)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                addDetails.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteOrder()
        {
            try
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(a => a.Id == id).ToList();

                if (status == "Trash")
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
                        CRUD.RemoveOrder(id);
                        CRUD.RemoveDetails(id);
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
                        ChangeOrder(id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                            list[0].DateStartWork, list[0].DateCompleted, list[0].DateIssue,
                            list[0].TypeTechnicId, list[0].BrandTechnicId, list[0].ModelTechnic,
                            list[0].FactoryNumber, list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                            list[0].InProgress, list[0].Guarantee, list[0].DateEndGuarantee, true,
                            list[0].ReturnUnderGuarantee, list[0].DateReturn, list[0].DateCompletedReturn,
                            list[0].DateIssueReturn, list[0].Issue, list[0].ColorRow, list[0].DateLastCall,
                            list[0].PriceAgreed, list[0].MaxPrice);

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
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(a => a.Id == id).ToList();
                ChangeOrder(
                    id, list[0].ClientId, list[0].MasterId, list[0].DateCreation, list[0].DateStartWork,
                    list[0].DateCompleted, list[0].DateIssue, list[0].TypeTechnicId,
                    list[0].BrandTechnicId, list[0].ModelTechnic, list[0].FactoryNumber,
                    list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                    list[0].InProgress, list[0].Guarantee, list[0].DateEndGuarantee, false,
                    list[0].ReturnUnderGuarantee, list[0].DateReturn, list[0].DateCompletedReturn,
                    list[0].DateIssueReturn, list[0].Issue, list[0].ColorRow, list[0].DateLastCall,
                    list[0].PriceAgreed, list[0].MaxPrice);
                Trash();
                /*UpdateDB();*/
            }
            catch { }
        }

        private void CompletedTag()
        {
            try
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(a => a.Id == id).ToList();
                var listDetails = context.Details.Where(a => a.Id == id).ToList();
                bool enabledPrice = true;

                if (list[0].ReturnUnderGuarantee)
                    enabledPrice = false;

                if (listDetails[0].IdWarehouse == null)
                {
                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Вы не использовали ни одной детали для ремонта данного устройства. " +
                        "\nХотите ли вы редактировать список деталей?",
                        ButtonNoText = "Нет",
                        ButtonVisible = true
                    };

                    if (warning.ShowDialog() == DialogResult.OK)
                    {
                        AddDetails addDetails = new(id)
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        addDetails.ShowDialog();
                        FocusButton(status);
                    }
                    else
                    {
                        switch (status)
                        {
                            case "InRepair":
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
                                CompletedOrder completedOrder = new(id)
                                {
                                    StartPosition = FormStartPosition.CenterParent,
                                    EnabledPrice = enabledPrice
                                };
                                if (completedOrder.ShowDialog() == DialogResult.OK)
                                {
                                    for (int i = 0; i < completedOrder.countProblem; i++)
                                    {
                                        int idKey = 1;
                                        if (context.Malfunctions.Any(a => a.Name == completedOrder.problem[i]))
                                        {
                                            var malfunctions = context.Malfunctions.Where(a => a.Name == completedOrder.problem[i]).ToList();
                                            if (malfunctions[0].Price != completedOrder.price[i])
                                                CRUD.ChangeMalfunction(malfunctions[0].Id, malfunctions[0].Name, completedOrder.price[i]);
                                            idKey = malfunctions[0].Id;
                                        }
                                        else
                                        {
                                            if (context.Malfunctions.Any())
                                            {
                                                idKey = context.Malfunctions.OrderBy(i => i.Id).Last().Id;
                                                idKey++;
                                            }

                                            CRUD.AddAsyncMalfunction(idKey, completedOrder.problem[i], completedOrder.price[i]);
                                        }
                                        CRUD.AddAsyncMalfunctionOrder(idKey, id, completedOrder.price[i]);
                                    }
                                    if (list[0].ReturnUnderGuarantee)
                                    {
                                        /**/
                                        int countDayInRepair = (DateTime.Parse(list[0].DateCompletedReturn) - DateTime.Parse(list[0].DateReturn)).Days;
                                        var dateEndGuarantee = DateTime.Parse(list[0].DateEndGuarantee).AddDays(countDayInRepair).ToShortDateString();
                                        ChangeOrder(id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                                            list[0].DateStartWork, completedOrder.DateComplete, list[0].DateIssue,
                                            list[0].TypeTechnicId, list[0].BrandTechnicId, list[0].ModelTechnic,
                                            list[0].FactoryNumber, list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                                            false, list[0].Guarantee, dateEndGuarantee, list[0].Deleted,
                                            list[0].ReturnUnderGuarantee, list[0].DateReturn, list[0].DateCompleted,
                                            list[0].DateIssueReturn, list[0].Issue, list[0].ColorRow,
                                            list[0].DateLastCall, list[0].PriceAgreed, list[0].MaxPrice);
                                    }
                                    else
                                    {
                                        ChangeOrder(id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                                            list[0].DateStartWork, completedOrder.DateComplete, list[0].DateIssue,
                                            list[0].TypeTechnicId, list[0].BrandTechnicId, list[0].ModelTechnic,
                                            list[0].FactoryNumber, list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                                            false, list[0].Guarantee, list[0].DateEndGuarantee, list[0].Deleted,
                                            list[0].ReturnUnderGuarantee, list[0].DateReturn, list[0].DateCompletedReturn,
                                            list[0].DateIssueReturn, list[0].Issue, list[0].ColorRow, list[0].DateLastCall,
                                            list[0].PriceAgreed, list[0].MaxPrice);

                                    }
                                    InProgress();
                                }
                                FocusButton(status);
                                /*if (completedOrder.pressBtnSave)
                                    UpdateDB();*/
                                break;
                        }
                    }
                }
                else
                {
                    switch (status)
                    {
                        case "InRepair":
                            if (!logInSystem)
                            {
                                Warning warning = new()
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
                            CompletedOrder completedOrder = new(id)
                            {
                                StartPosition = FormStartPosition.CenterParent,
                                EnabledPrice = enabledPrice
                            };
                            if (completedOrder.ShowDialog() == DialogResult.OK)
                            {
                                for (int i = 0; i < completedOrder.countProblem; i++)
                                {
                                    int idKey = 1;
                                    if (context.Malfunctions.Any(a => a.Name == completedOrder.problem[i]))
                                    {
                                        var malfunctions = context.Malfunctions.Where(a => a.Name == completedOrder.problem[i]).ToList();
                                        if (malfunctions[0].Price != completedOrder.price[i])
                                            CRUD.ChangeMalfunction(malfunctions[0].Id, malfunctions[0].Name, completedOrder.price[i]);
                                        idKey = malfunctions[0].Id;
                                    }
                                    else
                                    {
                                        if (context.Malfunctions.Any())
                                        {
                                            idKey = context.Malfunctions.OrderBy(i => i.Id).Last().Id;
                                            idKey++;
                                        }

                                        CRUD.AddAsyncMalfunction(idKey, completedOrder.problem[i], completedOrder.price[i]);
                                    }
                                    CRUD.AddAsyncMalfunctionOrder(idKey, id, completedOrder.price[i]);
                                }
                                if (list[0].ReturnUnderGuarantee)
                                {
                                    int countDayInRepair = (DateTime.Parse(completedOrder.DateComplete) - DateTime.Parse(list[0].DateReturn)).Days;
                                    var dateEndGuarantee = DateTime.Parse(list[0].DateEndGuarantee).AddDays(countDayInRepair).ToShortDateString();
                                    ChangeOrder(id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                                        list[0].DateStartWork, list[0].DateCompleted, list[0].DateIssue,
                                        list[0].TypeTechnicId, list[0].BrandTechnicId, list[0].ModelTechnic,
                                        list[0].FactoryNumber, list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                                        false, list[0].Guarantee, dateEndGuarantee, list[0].Deleted,
                                        list[0].ReturnUnderGuarantee, list[0].DateReturn, completedOrder.DateComplete,
                                        list[0].DateIssueReturn, list[0].Issue, list[0].ColorRow,
                                        list[0].DateLastCall, list[0].PriceAgreed, list[0].MaxPrice);
                                }
                                else
                                    ChangeOrder(id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                                            list[0].DateStartWork, completedOrder.DateComplete, list[0].DateIssue,
                                            list[0].TypeTechnicId, list[0].BrandTechnicId, list[0].ModelTechnic,
                                            list[0].FactoryNumber, list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                                            false, list[0].Guarantee, list[0].DateEndGuarantee, list[0].Deleted,
                                            list[0].ReturnUnderGuarantee, list[0].DateReturn, list[0].DateCompletedReturn,
                                            list[0].DateIssueReturn, list[0].Issue, list[0].ColorRow,
                                            list[0].DateLastCall, list[0].PriceAgreed, list[0].MaxPrice);
                                InProgress();
                            }
                            FocusButton(status);
                            /*if (completedOrder.pressBtnSave)
                                UpdateDB();*/
                            break;
                    }
                }
            }
            catch { }
        }

        private void IssueToClient()
        {
            try
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(a => a.Id == id).ToList();

                switch (status)
                {
                    case "Completed":
                        IssuingClient issuingClient = new(id)
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        if (issuingClient.ShowDialog() == DialogResult.OK)
                        {
                            if (list[0].ReturnUnderGuarantee)
                                ChangeOrder(id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                                list[0].DateStartWork, list[0].DateCompleted, issuingClient.DateIssue,
                                list[0].TypeTechnicId, list[0].BrandTechnicId, list[0].ModelTechnic,
                                list[0].FactoryNumber, list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                                list[0].InProgress, issuingClient.GuaranteePeriod, issuingClient.DateEndGuarantee,
                                list[0].Deleted, list[0].ReturnUnderGuarantee, list[0].DateReturn,
                                list[0].DateCompletedReturn, list[0].DateIssue, true, list[0].ColorRow,
                                list[0].DateLastCall, list[0].PriceAgreed, list[0].MaxPrice);
                            else
                                ChangeOrder(id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                                list[0].DateStartWork, list[0].DateCompleted, issuingClient.DateIssue,
                                list[0].TypeTechnicId, list[0].BrandTechnicId, list[0].ModelTechnic,
                                list[0].FactoryNumber, list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                                list[0].InProgress, issuingClient.GuaranteePeriod, issuingClient.DateEndGuarantee,
                                list[0].Deleted, list[0].ReturnUnderGuarantee, list[0].DateReturn,
                                list[0].DateCompletedReturn, list[0].DateIssueReturn, true, list[0].ColorRow,
                                list[0].DateLastCall, list[0].PriceAgreed, list[0].MaxPrice);
                            OrderСompleted();
                        }
                        FocusButton(status);
                        break;
                }
            }
            catch { }
        }

        private void ReturnInRepair()
        {
            try
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(a => a.Id == id).ToList();
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Вы действительно хотите отправить аппарат в доработку?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };

                if (warning.ShowDialog() == DialogResult.OK)
                {
                    switch (status)
                    {
                        case "Completed":
                            if (list[0].ReturnUnderGuarantee)
                                ChangeOrder(id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                                list[0].DateStartWork, list[0].DateCompleted, list[0].DateIssue, list[0].TypeTechnicId,
                                list[0].BrandTechnicId, list[0].ModelTechnic, list[0].FactoryNumber,
                                list[0].EquipmentId, list[0].DiagnosisId, list[0].Note, true, list[0].Guarantee,
                                list[0].DateEndGuarantee, list[0].Deleted, list[0].ReturnUnderGuarantee,
                                list[0].DateReturn, null, list[0].DateIssueReturn, list[0].Issue,
                                list[0].ColorRow, list[0].DateLastCall, list[0].PriceAgreed, list[0].MaxPrice);
                            else
                                ChangeOrder(id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                                list[0].DateStartWork, null, list[0].DateIssue, list[0].TypeTechnicId,
                                list[0].BrandTechnicId, list[0].ModelTechnic, list[0].FactoryNumber,
                                list[0].EquipmentId, list[0].DiagnosisId, list[0].Note, true, list[0].Guarantee,
                                list[0].DateEndGuarantee, list[0].Deleted, list[0].ReturnUnderGuarantee,
                                list[0].DateReturn, list[0].DateCompletedReturn, list[0].DateIssueReturn,
                                list[0].Issue, list[0].ColorRow, list[0].DateLastCall, list[0].PriceAgreed,
                                list[0].MaxPrice);
                            OrderСompleted();
                            break;
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
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(a => a.Id == id).ToList();
                var listWarehouse = context.Warehouse.ToList();
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Вы действительно хотите вернуть аппарат по гарантии?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };

                if (warning.ShowDialog() == DialogResult.OK)
                {
                    switch (status)
                    {
                        case "GuaranteeIssue":
                            ChangeOrder(id, list[0].ClientId, list[0].MasterId, DateTime.Now.ToShortDateString(),
                                DateTime.Now.ToShortDateString(), list[0].DateCompleted, list[0].DateIssue,
                                list[0].TypeTechnicId, list[0].BrandTechnicId, list[0].ModelTechnic,
                                list[0].FactoryNumber, list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                                true, list[0].Guarantee, list[0].DateEndGuarantee, list[0].Deleted,
                                true, list[0].DateCreation, list[0].DateCompletedReturn,
                                list[0].DateIssueReturn, false, list[0].ColorRow, list[0].DateLastCall, list[0].PriceAgreed,
                                list[0].MaxPrice);
                            OrderGuarantee();
                            break;
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
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(i => i.Id == idOrder).ToList();
                int idClient = list[0].ClientId;
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
                string typeClient = "";
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(i => i.Id == idOrder).ToList();
                int idClient = list[0].ClientId;

                FeaturesClient featuresClient = new(idClient)
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                if (featuresClient.ShowDialog() == DialogResult.OK)
                {
                    if (featuresClient.NormalType)
                        typeClient = "normal";
                    else if (featuresClient.WhiteType)
                        typeClient = "white";
                    else if (featuresClient.BlackType)
                        typeClient = "black";

                    try
                    {
                        String[] splitted = featuresClient.NameAdressClient.Split(",", 2);
                        CRUD.ChangeClient(idClient,
                        featuresClient.IdClient,
                        splitted[0],
                        splitted[1],
                        featuresClient.SecondPhone,
                        typeClient);
                    }
                    catch { }
                }
                UpdateTableData();
                FocusButton(status);
            }
            catch { }
        }

        private void AddInWhitelist()
        {
            try
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(i => i.Id == idOrder).ToList();
                int idClient = list[0].ClientId;
                var listClient = context.Clients.Where(i => i.Id == idClient).ToList();

                CRUD.ChangeClient(idClient,
                    listClient[0].IdClient,
                    listClient[0].NameClient,
                    listClient[0].Address,
                    listClient[0].NumberSecondPhone,
                    "white");
            }
            catch { }
        }

        private void AddInBlacklist()
        {
            try
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(i => i.Id == idOrder).ToList();
                int idClient = list[0].ClientId;
                var listClient = context.Clients.Where(i => i.Id == idClient).ToList();

                CRUD.ChangeClient(idClient,
                    listClient[0].IdClient,
                    listClient[0].NameClient,
                    listClient[0].Address,
                    listClient[0].NumberSecondPhone,
                    "black");
            }
            catch { }
        }

        private void RemoveMarks()
        {
            try
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Orders.Where(i => i.Id == idOrder).ToList();
                int idClient = list[0].ClientId;
                var listClient = context.Clients.Where(i => i.Id == idClient).ToList();

                CRUD.ChangeClient(idClient,
                    listClient[0].IdClient,
                    listClient[0].NameClient,
                    listClient[0].Address,
                    listClient[0].NumberSecondPhone,
                    "normal");
            }
            catch { }
        }

        private void NewOrder()
        {
            int numberRow = dataGridView1.CurrentCell.RowIndex;
            int idOrder = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
            Context context = new();
            var list = context.Orders.Where(i => i.Id == idOrder).Select(a => new
            {
                a.Id,
                a.DateCreation,
                a.MasterId,
                a.Master,
                a.TypeTechnic.NameTypeTechnic,
                a.BrandTechnic.NameBrandTechnic,
                a.ModelTechnic,
                a.FactoryNumber,
                a.Client,
                a.Equipment,
                a.Diagnosis,
                a.Note,
                a.PriceAgreed
            }).ToList();

            AddDeviceForRepair newOrder = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                TypeDevice = list[0].NameTypeTechnic,
                BrandDevice = list[0].NameBrandTechnic,
                Model = list[0].ModelTechnic,
                ClientName = list[0].Client.IdClient,
                ClientNameAddress = String.Format("{0}, {1}", list[0].Client?.NameClient, list[0].Client?.Address),
                ClientSecondPhone = list[0].Client.NumberSecondPhone,
                TypeClient = "Старый клиент",
                Equipment = list[0].Equipment.Name,
                Diagnosis = list[0].Diagnosis.Name,
                Note = list[0].Note
            };

            if (list[0].MasterId != null)
                newOrder.MasterName = list[0].Master.NameMaster;


            if (newOrder.ShowDialog() == DialogResult.OK)
            {
                status = "InRepair";
                /*UpdateDB();*/
                UpdateTableData();
            }
            FocusButton(status);
        }

        private static void ChangeOrder(int id, int clientId, int? masterId, string? dateCreation,
            string? dateStartWork, string? dateCompleted, string? dateIssue, int typeTechnicId,
            int brandTechnicId, string? modelTechnic, string? factoryNumber, int? equipmentId,
            int? diagnosisId, string? note, bool inProgress, int guarantee,
            string? dateEndGuarantee, bool deleted, bool returnUnderGuarantee, string? dateReturn,
            string? dateCompletedReturn, string? dateIssueReturn, bool issue, string color,
            string? dateLastCall, bool priceAgreed, int? maxPrice)
        {
            CRUD.ChangeOrder(id,
                       clientId,
                       masterId,
                       dateCreation,
                       dateStartWork,
                       dateCompleted,
                       dateIssue,
                       typeTechnicId,
                       brandTechnicId,
                       modelTechnic,
                       factoryNumber,
                       equipmentId,
                       diagnosisId,
                       note,
                       inProgress,
                       guarantee,
                       dateEndGuarantee,
                       deleted,
                       returnUnderGuarantee,
                       dateReturn,
                       dateCompletedReturn,
                       dateIssueReturn,
                       issue,
                       color,
                       dateLastCall,
                       priceAgreed,
                       maxPrice);
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
            Context context = new();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                var list = context.Orders.Where(i => i.Id == id).ToList();
                if (list[0].MasterId == null)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.DimGray;
                    dataGridView1.Rows[i].DefaultCellStyle.SelectionForeColor = Color.DimGray;
                    continue;
                }
                string hexColor = dataGridView1.Rows[i].Cells[13].Value.ToString();
                Color color = ColorTranslator.FromHtml(hexColor);
                if (color != CheckColor(id))
                {
                    color = CheckColor(id);
                    ChangeOrder(list[0].Id, list[0].ClientId, list[0].MasterId, list[0].DateCreation,
                            list[0].DateStartWork, list[0].DateCompleted, list[0].DateIssue,
                            list[0].TypeTechnicId, list[0].BrandTechnicId, list[0].ModelTechnic,
                            list[0].FactoryNumber, list[0].EquipmentId, list[0].DiagnosisId, list[0].Note,
                            list[0].InProgress, list[0].Guarantee, list[0].DateEndGuarantee, list[0].Deleted,
                            list[0].ReturnUnderGuarantee, list[0].DateReturn, list[0].DateCompletedReturn,
                            list[0].DateIssueReturn, list[0].Issue, ColorTranslator.ToHtml(color),
                            list[0].DateLastCall, list[0].PriceAgreed, list[0].MaxPrice);
                }
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = color;
                dataGridView1.Rows[i].DefaultCellStyle.SelectionForeColor = color;

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[12].Value))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }

        private Color CheckColor(int id)
        {
            Color color = Color.Black;
            Context context = new();
            var list = context.Orders.Where(i => i.Id == id).ToList();
            var countDays = 0;
            switch (status)
            {
                case "InRepair":
                    countDays = (DateTime.Now - DateTime.Parse(list[0].DateStartWork)).Days;
                    break;
                case "Completed":
                    countDays = (DateTime.Now - DateTime.Parse(list[0].DateCompleted)).Days;
                    break;
            }

            if (countDays < Convert.ToInt32(Properties.Settings.Default.FirstLevelText))
                color = Properties.Settings.Default.FirstLevelColor;
            else if (countDays > Convert.ToInt32(Properties.Settings.Default.SecondLevelText))
                color = Properties.Settings.Default.ThirdLevelColor;
            else
                color = Properties.Settings.Default.SecondLevelColor;
            return color;
        }

        private void ToolStripEnabled()
        {
            switch (status)
            {
                case "InRepair":
                    buttonDetails.Enabled = true;
                    buttonDelete.Enabled = true;
                    buttonRecoveryOrder.Enabled = false;
                    buttonCompletedTag.Enabled = true;
                    buttonIssue.Enabled = false;
                    buttonReturnInRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = false;
                    buttonFeaturesOrder.Enabled = true;
                    break;
                case "Completed":
                    buttonDetails.Enabled = false;
                    buttonDelete.Enabled = true;
                    buttonRecoveryOrder.Enabled = false;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = true;
                    buttonReturnInRepair.Enabled = true;
                    buttonReturnGuarantee.Enabled = false;
                    buttonFeaturesOrder.Enabled = true;
                    break;
                case "GuaranteeIssue":
                    buttonDetails.Enabled = false;
                    buttonDelete.Enabled = true;
                    buttonRecoveryOrder.Enabled = false;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = false;
                    buttonReturnInRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = true;
                    buttonFeaturesOrder.Enabled = true;
                    break;
                case "Archive":
                    buttonDetails.Enabled = false;
                    buttonDelete.Enabled = true;
                    buttonRecoveryOrder.Enabled = false;
                    buttonCompletedTag.Enabled = false;
                    buttonIssue.Enabled = false;
                    buttonReturnInRepair.Enabled = false;
                    buttonReturnGuarantee.Enabled = false;
                    buttonFeaturesOrder.Enabled = true;
                    break;
                case "Trash":
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
                case "InRepair":
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
                case "Completed":
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
                case "GuaranteeIssue":
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
                case "Archive":
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
                case "Trash":
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
                case "InRepair":
                    itemGetting.Enabled = true;
                    itemIssuing.Enabled = false;
                    break;
                case "Completed":
                    itemGetting.Enabled = true;
                    itemIssuing.Enabled = false;
                    break;
                case "GuaranteeIssue":
                    itemGetting.Enabled = true;
                    itemIssuing.Enabled = true;
                    break;
                case "Archive":
                    itemGetting.Enabled = true;
                    itemIssuing.Enabled = true;
                    break;
                case "Trash":
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
                    case "InRepair":
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
                    case "Completed":
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
                    case "GuaranteeIssue":
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
                    case "Archive":
                        item1.Enabled = true;
                        item2.Enabled = false;
                        item3.Enabled = true;
                        item4.Enabled = false;
                        item5.Enabled = false;
                        break;
                    case "Trash":
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
            AddDevice();
        }

        private void ButtonMasters_Click(object sender, EventArgs e)
        {
            AddMaster addMaster = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMaster.ShowDialog();
            FocusButton(status);
        }

        private void ButtonDevice_Click(object sender, EventArgs e)
        {
            AddDevice addDevice = new()
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
                idRow = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                FeaturesOrder featuresOrder = new(idRow, status, logInSystem)
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
            AddMaster addMaster = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMaster.ShowDialog(this);
            FocusButton(status);
        }

        private void ItemAddBrand_Click(object sender, EventArgs e)
        {
            AddBrand addBrand = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addBrand.ShowDialog();
            FocusButton(status);
        }
        private void ItemAddDevice_Click(object sender, EventArgs e)
        {
            AddDevice addDevice = new()
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
            WarehouseDetails details = new(true, "")
            {
                StartPosition = FormStartPosition.CenterParent,
                VisibleBtnAdd = false
            };
            details.ShowDialog();
            FocusButton(status);
        }

        private void ItemMalfunction_Click(object sender, EventArgs e)
        {
            MalfunctionList malfunctionList = new("malfunction")
            {
                StartPosition = FormStartPosition.CenterParent
            };
            malfunctionList.ShowDialog();
            FocusButton(status);
        }

        private void ItemDiagnosis_Click(object sender, EventArgs e)
        {
            MalfunctionList malfunctionList = new("diagnosis")
            {
                StartPosition = FormStartPosition.CenterParent,
                Text = "Диагнозы"
            };
            malfunctionList.ShowDialog();
            FocusButton(status);
        }

        private void ItemEquipment_Click(object sender, EventArgs e)
        {
            MalfunctionList malfunctionList = new("equipment")
            {
                StartPosition = FormStartPosition.CenterParent,
                Text = "Комплектация"
            };
            malfunctionList.ShowDialog();
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
            AddDevice();
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
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                ReportGetting(id);
            }
            catch { }
        }

        public void ReportGetting(int id)
        {
            try
            {
                const string outputFile = @"Output\reportGetting.xlsx";
                var template = new XLTemplate(@"Templates\reportGetting.xlsx");

                using Context context = new();
                var list = context.Orders.Where(i => i.Id == id).Select(i => new
                {
                    i.Id,
                    i.Master,
                    i.Client,
                    i.TypeTechnic,
                    i.BrandTechnic,
                    i.ModelTechnic,
                    i.FactoryNumber,
                    i.Equipment,
                    i.Diagnosis,
                    i.Note,
                    i.DateCreation,
                }).ToList();

                string device = String.Format("{0} {1} {2}", list[0].TypeTechnic?.NameTypeTechnic,
                    list[0].BrandTechnic?.NameBrandTechnic, list[0].ModelTechnic);

                template.AddVariable("Id", value: list[0].Id);
                template.AddVariable("MasterName", value: list[0].Master?.NameMaster);
                template.AddVariable("ClientName", value: list[0].Client?.NameClient);
                template.AddVariable("ClientId", value: list[0].Client?.IdClient);
                template.AddVariable("ClientAddress", value: list[0].Client?.Address);
                template.AddVariable("ClientSecondPhone", value: list[0].Client?.NumberSecondPhone);
                template.AddVariable("Device", value: device);
                template.AddVariable("FactoryNumber", value: list[0].FactoryNumber);
                template.AddVariable("Equipment", value: list[0].Equipment);
                template.AddVariable("Diagnosis", value: list[0].Diagnosis);
                template.AddVariable("Note", value: list[0].Note);
                template.AddVariable("DateCreation", value: list[0].DateCreation);
                template.AddVariable("OrgName", value: Properties.Settings.Default.NameOrg);
                template.AddVariable("OrgAddress", value: Properties.Settings.Default.AddressOrg);
                template.AddVariable("OrgPhone", value: Properties.Settings.Default.PhoneOrg);
                template.AddVariable("OrgFax", value: Properties.Settings.Default.FaxOrg);
                template.AddVariable("OrgMail", value: Properties.Settings.Default.MailOrg);

                template.Generate();
                try
                {
                    template.SaveAs(outputFile);
                }
                catch (Exception)
                {
                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Закройте файл reportGetting.xlsx и повторите попытку!"
                    };
                    warning.ShowDialog();
                    FocusButton(status);
                }

                Process.Start(new ProcessStartInfo(outputFile) { UseShellExecute = true });
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void ItemIssuing_Click(object sender, EventArgs e)
        {
            try
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                ReportIssuing(id);
            }
            catch { }
        }

        public void ReportIssuing(int id)
        {
            try
            {
                const string outputFile = @"Output\reportIssuing.xlsx";
                var template = new XLTemplate(@"Templates\reportIssuing.xlsx");

                using Context context = new();
                var list = context.Orders.Where(i => i.Id == id).Select(i => new
                {
                    i.Id,
                    i.Master,
                    i.Client,
                    i.TypeTechnic,
                    i.BrandTechnic,
                    i.ModelTechnic,
                    i.FactoryNumber,
                    i.Equipment,
                    i.Diagnosis,
                    i.Note,
                    i.DateCreation,
                    i.DateIssue,
                    i.DateEndGuarantee,
                    i.ReturnUnderGuarantee
                }).ToList();

                var listDetails = context.Details.Where(i => i.Id == id).ToList();
                var listIdWarehouse = context.Details.Where(i => i.Id == id).Select(a => new
                {
                    a.IdWarehouse
                }).ToList();

                var listFoundProblem = context.MalfunctionOrders.Where(i => i.OrderId == id).
                    Select(a => new { a.Malfunction, a.Price }).ToList();
                List<string> problemS = [];
                List<int> priceS = [];
                int problemSum = 0;
                for (int i = 0; i < listFoundProblem.Count; i++)
                {
                    problemS.Add(listFoundProblem[i].Malfunction.Name);
                    priceS.Add(listFoundProblem[i].Price);
                    problemSum += listFoundProblem[i].Price;
                }

                List<string> listNameS = [];
                List<int> listPriceSaleS = [];
                if (listIdWarehouse[0].IdWarehouse != null)
                {
                    var listWarehouse = context.Warehouse.ToList();
                    for (int i = 0; i < listIdWarehouse[0].IdWarehouse.Count; i++)
                    {
                        for (int j = 0; j < listWarehouse.Count; j++)
                        {
                            if (listIdWarehouse[0].IdWarehouse[i] == listWarehouse[j].Id)
                            {
                                listNameS.Add(listWarehouse[j].NameDetail);
                                listPriceSaleS.Add(listWarehouse[j].PriceSale);
                            }
                        }
                    }
                }
                int detailsSum = 0;

                for (int i = 0; i < listPriceSaleS.Count; i++)
                {
                    detailsSum += listPriceSaleS[i];
                }

                List<string> nameDetails = [];
                List<string> priceDetails = [];
                List<string> nameProblem = [];
                List<string> priceProblem = [];

                for (int i = 0; i < 5; i++)
                {
                    nameDetails.Add(String.Format("NameDetails{0}", i));
                    priceDetails.Add(String.Format("PriceDetails{0}", i));
                }
                for (int i = 0; i < 3; i++)
                {
                    nameProblem.Add(String.Format("FoundProblem{0}", i));
                    priceProblem.Add(String.Format("PriceRepair{0}", i));
                }

                string device = String.Format("{0} {1} {2}", list[0].TypeTechnic?.NameTypeTechnic,
                    list[0].BrandTechnic?.NameBrandTechnic, list[0].ModelTechnic);

                template.AddVariable("Id", value: list[0].Id);
                template.AddVariable("MasterName", value: list[0].Master?.NameMaster);
                template.AddVariable("ClientName", value: list[0].Client?.NameClient);
                template.AddVariable("ClientId", value: list[0].Client?.IdClient);
                template.AddVariable("ClientAddress", value: list[0].Client?.Address);
                template.AddVariable("ClientSecondPhone", value: list[0].Client?.NumberSecondPhone);
                template.AddVariable("Device", value: device);
                template.AddVariable("FactoryNumber", value: list[0].FactoryNumber);
                template.AddVariable("Equipment", value: list[0].Equipment);
                template.AddVariable("Diagnosis", value: list[0].Diagnosis);
                template.AddVariable("Note", value: list[0].Note);
                template.AddVariable("DateCreation", value: list[0].DateCreation);
                template.AddVariable("DetailsSumPrice", value: detailsSum);
                template.AddVariable("DateEndGuarantee", value: list[0].DateEndGuarantee);
                template.AddVariable("DateIssuing", value: list[0].DateIssue);
                for (int i = 0; i < nameDetails.Count; i++)
                {
                    if (i < listNameS.Count)
                    {
                        template.AddVariable(nameDetails[i], value: listNameS[i]);
                        template.AddVariable(priceDetails[i], value: listPriceSaleS[i]);
                    }
                    else
                    {
                        template.AddVariable(nameDetails[i], value: null);
                        template.AddVariable(priceDetails[i], value: null);
                    }
                }
                for (int i = 0; i < nameProblem.Count; i++)
                {
                    if (i < problemS.Count)
                    {
                        template.AddVariable(nameProblem[i], value: problemS[i]);
                        template.AddVariable(priceProblem[i], value: priceS[i]);
                    }
                    else
                    {
                        template.AddVariable(nameProblem[i], value: null);
                        template.AddVariable(priceProblem[i], value: null);
                    }
                }
                template.AddVariable("TotalPrice", value: (detailsSum + problemSum));
                template.AddVariable("OrgName", value: Properties.Settings.Default.NameOrg);
                template.AddVariable("OrgAddress", value: Properties.Settings.Default.AddressOrg);
                template.AddVariable("OrgPhone", value: Properties.Settings.Default.PhoneOrg);
                template.AddVariable("OrgFax", value: Properties.Settings.Default.FaxOrg);
                template.AddVariable("OrgMail", value: Properties.Settings.Default.MailOrg);

                template.Generate();
                try
                {
                    template.SaveAs(outputFile);
                }
                catch (Exception)
                {
                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Закройте файл reportIssuing.xlsx и повторите попытку!"
                    };
                    warning.ShowDialog();
                    FocusButton(status);
                }
                Process.Start(new ProcessStartInfo(outputFile) { UseShellExecute = true });
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ChangeColorRows();
        }

        public void FocusButton(string status)
        {
            switch (status)
            {
                case "InRepair":
                    buttonInProgress.Focus();
                    break;
                case "Completed":
                    buttonCompleted.Focus();
                    break;
                case "GuaranteeIssue":
                    buttonGuarantee.Focus();
                    break;
                case "Archive":
                    buttonArchive.Focus();
                    break;
                case "Trash":
                    buttonTrash.Focus();
                    break;
            }
        }

        public static string NameMonth(int numberMonth)
        {
            string nameMonth = "";
            switch (numberMonth)
            {
                case 1:
                    nameMonth = "январь";
                    break;
                case 2:
                    nameMonth = "февраль";
                    break;
                case 3:
                    nameMonth = "март";
                    break;
                case 4:
                    nameMonth = "апрель";
                    break;
                case 5:
                    nameMonth = "май";
                    break;
                case 6:
                    nameMonth = "июнь";
                    break;
                case 7:
                    nameMonth = "июль";
                    break;
                case 8:
                    nameMonth = "август";
                    break;
                case 9:
                    nameMonth = "сентябрь";
                    break;
                case 10:
                    nameMonth = "октябрь";
                    break;
                case 11:
                    nameMonth = "ноябрь";
                    break;
                case 12:
                    nameMonth = "декабрь";
                    break;
            }
            return nameMonth;
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
            using Context context = new();
            var list = context.Orders.Where(i => i.Id.ToString().IndexOf(textBoxIdOrder.Text) > -1 &&
            i.DateCreation.StartsWith(textBoxDateCreation.Text) &&
            ((i.DateStartWork == null && textBoxDateStartWork.Text == "") ||
            (i.DateStartWork != null && i.DateStartWork.StartsWith(textBoxDateStartWork.Text))) &&
            ((i.MasterId == null && textBoxNameMaster.Text == "") ||
            (i.MasterId != null && i.Master.NameMaster.StartsWith(textBoxNameMaster.Text))) &&
            i.TypeTechnic.NameTypeTechnic.StartsWith(textBoxTypeDevice.Text) &&
            i.BrandTechnic.NameBrandTechnic.StartsWith(textBoxBrandDevice.Text) &&
            i.ModelTechnic.StartsWith(textBoxModel.Text) &&
            i.Client.NameClient.IndexOf(textBoxNameClient.Text) > -1).Select(a => new
            {
                a.Id,
                a.DateCreation,
                a.DateStartWork,
                a.Master.NameMaster,
                a.TypeTechnic.NameTypeTechnic,
                a.BrandTechnic.NameBrandTechnic,
                a.ModelTechnic,
                a.Client.NameClient,
                a.Deleted,
                a.ReturnUnderGuarantee,
                a.ColorRow
            }).OrderByDescending(i => i.Id).ToList();
            dataGridView1.DataSource = Funcs.ToDataTable(list);
            ChangeColorRows();
            if (CheckNoFilters())
                UpdateTableData();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.Size == "Small")
            {
                Properties.Settings.Default.WidthSmall = this.Width;
                Properties.Settings.Default.HeightSmall = this.Height;
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.Size == "Medium")
            {
                Properties.Settings.Default.WidthMedium = this.Width;
                Properties.Settings.Default.HeightMedium = this.Height;
                Properties.Settings.Default.Save();
            }
        }

        private bool CheckNoFilters()
        {
            if (textBoxIdOrder.Text == "" &&
                textBoxDateCreation.Text == "" &&
                textBoxDateStartWork.Text == "" &&
                textBoxNameMaster.Text == "" &&
                textBoxTypeDevice.Text == "" &&
                textBoxBrandDevice.Text == "" &&
                textBoxModel.Text == "" &&
                textBoxNameClient.Text == "")
                return true;
            else return false;
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            textBoxIdOrder.Text = "";
            textBoxDateCreation.Text = "";
            textBoxDateStartWork.Text = "";
            textBoxNameMaster.Text = "";
            textBoxTypeDevice.Text = "";
            textBoxBrandDevice.Text = "";
            textBoxModel.Text = "";
            textBoxNameClient.Text = "";
            UpdateTableData();
            FocusButton(status);
        }

        private void ItemSmall_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Size == "Medium")
            {
                Properties.Settings.Default.WidthMedium = this.Width;
                Properties.Settings.Default.HeightMedium = this.Height;
                Properties.Settings.Default.Save();
            }
            Properties.Settings.Default.Size = "Small";
            Properties.Settings.Default.Save();

            this.Width = Properties.Settings.Default.WidthSmall;
            this.Height = Properties.Settings.Default.HeightSmall;
        }

        private void ItemMedium_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Size == "Small")
            {
                Properties.Settings.Default.WidthSmall = this.Width;
                Properties.Settings.Default.HeightSmall = this.Height;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.Size = "Medium";
            Properties.Settings.Default.Save();

            this.Width = Properties.Settings.Default.WidthMedium;
            this.Height = Properties.Settings.Default.HeightMedium;
        }

        private void SmallWindow()
        {
            buttonTrash.Location = new Point(buttonTrash.Location.X, this.Height - buttonTrash.Height
                - 52);
            var height = (buttonTrash.Location.Y - buttonInProgress.Location.Y - buttonInProgress.Height * 4) / 4;

            buttonCompleted.Location = new Point(buttonCompleted.Location.X, buttonInProgress.Location.Y +
                buttonCompleted.Height + height);

            buttonGuarantee.Location = new Point(buttonGuarantee.Location.X, buttonCompleted.Location.Y +
                buttonGuarantee.Height + height);

            buttonArchive.Location = new Point(buttonArchive.Location.X, buttonGuarantee.Location.Y +
                buttonArchive.Height + height);


            dataGridView1.Height = buttonArchive.Location.Y + buttonArchive.Height -
                dataGridView1.Location.Y;

            buttonReset.Location = new Point(buttonTrash.Location.X - 6 - buttonReset.Width,
                    buttonTrash.Location.Y);

            labelIdOrder.Location = new Point(labelIdOrder.Location.X, buttonTrash.Location.Y);
            textBoxIdOrder.Location = new Point(textBoxIdOrder.Location.X, buttonTrash.Location.Y);
            textBoxIdOrder.Width = 74;

            textBoxTypeDevice.Width = 74;
            textBoxTypeDevice.Location = new Point(buttonReset.Location.X - 11 - textBoxTypeDevice.Width,
                buttonTrash.Location.Y);
            labelTypeDevice.Location = new Point(textBoxTypeDevice.Location.X - 6 - labelTypeDevice.Width,
                buttonTrash.Location.Y);

            labelDateCreation.Location = new Point(labelDateCreation.Location.X, buttonTrash.Location.Y +
                labelDateCreation.Height + 10);
            textBoxDateCreation.Location = new Point(textBoxDateCreation.Location.X, labelDateCreation.Location.Y);
            textBoxDateCreation.Width = 74;

            labelBrandDevice.Location = new Point(labelTypeDevice.Location.X, labelDateCreation.Location.Y);
            textBoxBrandDevice.Location = new Point(textBoxTypeDevice.Location.X, labelDateCreation.Location.Y);
            textBoxBrandDevice.Width = 74;

            var width = (labelTypeDevice.Location.X - (textBoxIdOrder.Location.X + textBoxIdOrder.Width) -
                labelDateStartWork.Width - 6 - textBoxDateStartWork.Width) / 2;

            labelDateStartWork.Location = new Point(textBoxIdOrder.Location.X + textBoxIdOrder.Width +
                width, buttonTrash.Location.Y);
            textBoxDateStartWork.Location = new Point(labelDateStartWork.Location.X + labelDateStartWork.Width
                + 6, buttonTrash.Location.Y);
            textBoxDateStartWork.Width = 74;

            labelNameMaster.Location = new Point(labelDateStartWork.Location.X, labelDateCreation.Location.Y);
            textBoxNameMaster.Location = new Point(labelNameMaster.Location.X + labelNameMaster.Width
                + 6, labelDateCreation.Location.Y);
            textBoxNameMaster.Width = 74;

            textBoxModel.Location = new Point(textBoxDateCreation.Location.X,
                labelDateCreation.Location.Y + labelDateCreation.Height + 11);
            textBoxModel.Width = 74;
            labelModel.Location = new Point(textBoxModel.Location.X - 6 - labelModel.Width,
                textBoxModel.Location.Y);

            textBoxNameClient.Location = new Point(textBoxDateStartWork.Location.X, textBoxModel.Location.Y);
            textBoxNameClient.Width = 74;
            labelNameClient.Location = new Point(textBoxNameClient.Location.X - 6 - labelNameClient.Width,
                textBoxModel.Location.Y);
        }

        private void MediumWindow()
        {
            buttonReset.Location = new Point(buttonTrash.Location.X, this.Height - buttonReset.Height
                - 52);

            var height = (buttonReset.Location.Y - buttonInProgress.Location.Y - buttonInProgress.Height * 5) / 5;

            buttonCompleted.Location = new Point(buttonCompleted.Location.X, buttonInProgress.Location.Y +
                buttonCompleted.Height + height);

            buttonGuarantee.Location = new Point(buttonGuarantee.Location.X, buttonCompleted.Location.Y +
                buttonGuarantee.Height + height);

            buttonArchive.Location = new Point(buttonArchive.Location.X, buttonGuarantee.Location.Y +
                buttonArchive.Height + height);

            buttonTrash.Location = new Point(buttonTrash.Location.X, buttonArchive.Location.Y +
                buttonTrash.Height + height);

            labelIdOrder.Location = new Point(labelIdOrder.Location.X, buttonReset.Location.Y);
            textBoxIdOrder.Location = new Point(textBoxIdOrder.Location.X, buttonReset.Location.Y);
            textBoxIdOrder.Width = 120;

            textBoxModel.Width = 120;
            textBoxModel.Location = new Point(buttonReset.Location.X - 6 - textBoxModel.Width,
                buttonReset.Location.Y);
            labelModel.Location = new Point(textBoxModel.Location.X - 6 - labelModel.Width,
                textBoxModel.Location.Y);

            labelDateCreation.Location = new Point(labelDateCreation.Location.X,
                labelIdOrder.Location.Y + labelIdOrder.Height + 10);
            textBoxDateCreation.Location = new Point(textBoxDateCreation.Location.X,
                labelDateCreation.Location.Y);
            textBoxDateCreation.Width = 120;


            labelNameClient.Location = new Point(labelModel.Location.X, labelDateCreation.Location.Y);
            textBoxNameClient.Location = new Point(textBoxModel.Location.X, labelDateCreation.Location.Y);
            textBoxNameClient.Width = 120;

            var width = (labelModel.Location.X - (textBoxIdOrder.Location.X + textBoxIdOrder.Width) -
                labelDateStartWork.Width - labelTypeDevice.Width - 12 - 120 * 2) / 3;

            labelDateStartWork.Location = new Point(textBoxIdOrder.Location.X + textBoxIdOrder.Width +
                width, textBoxIdOrder.Location.Y);
            textBoxDateStartWork.Location = new Point(labelDateStartWork.Location.X +
                labelDateStartWork.Width + 6, textBoxIdOrder.Location.Y);
            textBoxDateStartWork.Width = 120;

            labelTypeDevice.Location = new Point(textBoxDateStartWork.Location.X + textBoxDateStartWork.Width
                + width, textBoxIdOrder.Location.Y);
            textBoxTypeDevice.Location = new Point(labelTypeDevice.Location.X + labelTypeDevice.Width + 6,
                textBoxIdOrder.Location.Y);
            textBoxTypeDevice.Width = 120;

            labelNameMaster.Location = new Point(labelDateStartWork.Location.X, textBoxDateCreation.Location.Y);
            textBoxNameMaster.Location = new Point(textBoxDateStartWork.Location.X, textBoxDateCreation.Location.Y);
            textBoxNameMaster.Width = 120;

            labelBrandDevice.Location = new Point(labelTypeDevice.Location.X, textBoxDateCreation.Location.Y);
            textBoxBrandDevice.Location = new Point(textBoxTypeDevice.Location.X, textBoxDateCreation.Location.Y);
            textBoxBrandDevice.Width = 120;

            dataGridView1.Height = buttonTrash.Location.Y + buttonTrash.Height -
                dataGridView1.Location.Y;
        }

        private void ChangeSizeAndLocation()
        {
            labelLogIn.Location = new Point(this.Width - labelLogIn.Width - 22, labelLogIn.Location.Y);

            buttonInProgress.Location = new Point(this.Width - buttonInProgress.Width - 22,
                buttonInProgress.Location.Y);

            buttonCompleted.Location = new Point(buttonInProgress.Location.X,
                buttonCompleted.Location.Y);

            buttonGuarantee.Location = new Point(buttonInProgress.Location.X,
                buttonGuarantee.Location.Y);

            buttonArchive.Location = new Point(buttonInProgress.Location.X,
                buttonArchive.Location.Y);

            buttonArchive.Location = new Point(buttonInProgress.Location.X,
                buttonArchive.Location.Y);

            buttonTrash.Location = new Point(buttonInProgress.Location.X,
                buttonTrash.Location.Y);

            dataGridView1.Width = buttonInProgress.Location.X - 6 - dataGridView1.Location.X;


            if (Properties.Settings.Default.Size == "Small")
            {
                SmallWindow();
            }
            else if (Properties.Settings.Default.Size == "Medium")
            {
                MediumWindow();
            }
            try
            {
                UpdateTable();
            }
            catch { }
        }

        private void DataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9 && e.RowIndex >= 0)
                {
                    var pos = dataGridView1.PointToScreen(dataGridView1.GetCellDisplayRectangle(
                        e.ColumnIndex, e.RowIndex, false).Location);
                    contextPhone.Show(new Point(pos.X, pos.Y + dataGridView1.Rows[e.RowIndex].Height));

                    numberPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    dataGridView1.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            contextPhone.Visible = false;
        }

        private void DataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DataGridView1_MouseMove(object sender, MouseEventArgs e)
        {

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
