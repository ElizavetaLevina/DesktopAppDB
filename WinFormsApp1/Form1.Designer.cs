using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            buttonInProgress = new Button();
            buttonCompleted = new Button();
            buttonGuarantee = new Button();
            buttonArchive = new Button();
            buttonTrash = new Button();
            contextMenuRightMouse = new ContextMenuStrip(components);
            itemPropertiesMenuRightMouse = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            itemDetailsMenuRightMouse = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            itemRemoveMenuRightMouse = new ToolStripMenuItem();
            itemRecoveryMenuRightMouse = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            itemActionDeviceMenuRightMouse = new ToolStripMenuItem();
            itemCompletedTagMenuRightMouse = new ToolStripMenuItem();
            itemIssueMenuRightMouse = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            itemReturnIntoRepairMenuRightMouse = new ToolStripMenuItem();
            itemReturnGuaranteeMenuRightMouse = new ToolStripMenuItem();
            itemActionClientMenuRightMouse = new ToolStripMenuItem();
            itemPropertiesClientMenuRightMouse = new ToolStripMenuItem();
            itemMessageClientMenuRightMouse = new ToolStripMenuItem();
            itemPriorityClientMenuRightMouse = new ToolStripMenuItem();
            itemWhiteListMenuRightMouse = new ToolStripMenuItem();
            itemBlackListMenuRightMouse = new ToolStripMenuItem();
            itemUnmarkMenuRightMouse = new ToolStripMenuItem();
            toolStripSeparator19 = new ToolStripSeparator();
            itemNewOrderAsCurrentMenuRightMouse = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            buttonAddDeviceIntoRepair = new ToolStripButton();
            buttonMasters = new ToolStripButton();
            buttonTypesDevices = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            buttonExit = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            buttonDetails = new ToolStripButton();
            buttonRemove = new ToolStripButton();
            buttonRecovery = new ToolStripButton();
            buttonCompletedTag = new ToolStripButton();
            buttonIssue = new ToolStripButton();
            buttonReturnIntoRepair = new ToolStripButton();
            buttonReturnGuarantee = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            buttonPropertiesOrder = new ToolStripButton();
            buttonPropertiesClient = new ToolStripButton();
            toolStripSeparator8 = new ToolStripSeparator();
            labelDataBase = new Label();
            contextMenuDataBase = new ContextMenuStrip(components);
            itemMasters = new ToolStripMenuItem();
            itemBrands = new ToolStripMenuItem();
            itemTypesDevices = new ToolStripMenuItem();
            itemClientsDirectory = new ToolStripMenuItem();
            itemWarehouse = new ToolStripMenuItem();
            itemMalfunction = new ToolStripMenuItem();
            itemDiagnosis = new ToolStripMenuItem();
            itemEquipment = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            itemExportToExcel = new ToolStripMenuItem();
            itemCopyBD = new ToolStripMenuItem();
            itemUpdateService = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            itemPathDB = new ToolStripMenuItem();
            toolStripSeparator18 = new ToolStripSeparator();
            itemOrganization = new ToolStripMenuItem();
            toolStripSeparator20 = new ToolStripSeparator();
            itemLogIn = new ToolStripMenuItem();
            toolStripSeparator21 = new ToolStripSeparator();
            itemExit = new ToolStripMenuItem();
            contextMenuWorkingWithData = new ContextMenuStrip(components);
            itemNewOrderMenuWorkingWithData = new ToolStripMenuItem();
            itemPropertiesMenuWorkingWithData = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            itemDetailsMenuWorkingWithData = new ToolStripMenuItem();
            toolStripSeparator12 = new ToolStripSeparator();
            itemRemoveMenuWorkingWithData = new ToolStripMenuItem();
            itemRecoveryMenuWorkingWithData = new ToolStripMenuItem();
            toolStripSeparator13 = new ToolStripSeparator();
            itemActionsDeviceMenuWorkingWithData = new ToolStripMenuItem();
            itemCompletedTagMenuWorkingWithData = new ToolStripMenuItem();
            itemIssueMenuWorkingWithData = new ToolStripMenuItem();
            toolStripSeparator14 = new ToolStripSeparator();
            itemReturnMenuWorkingWithData = new ToolStripMenuItem();
            itemReturnGuaranteeMenuWorkingWithData = new ToolStripMenuItem();
            itemActionsClientMenuWorkingWithData = new ToolStripMenuItem();
            itemPropertiesClientMenuWorkingWithData = new ToolStripMenuItem();
            toolStripSeparator15 = new ToolStripSeparator();
            itemMessageClientMenuWorkingWithData = new ToolStripMenuItem();
            toolStripSeparator16 = new ToolStripSeparator();
            itemPriorityClientMenuWorkingWithData = new ToolStripMenuItem();
            itemWhiteListWorkingWithData = new ToolStripMenuItem();
            itemBlackListWorkingWithData = new ToolStripMenuItem();
            itemUnmarkWorkingWithData = new ToolStripMenuItem();
            toolStripSeparator17 = new ToolStripSeparator();
            itemNewOrderAsCurrentMenuWorkingWithData = new ToolStripMenuItem();
            labelWorkData = new Label();
            labelDocuments = new Label();
            labelReports = new Label();
            contextMenuPayments = new ContextMenuStrip(components);
            itemGettingDevice = new ToolStripMenuItem();
            itemIssuingDevice = new ToolStripMenuItem();
            contextMenuReports = new ContextMenuStrip(components);
            itemReportOrganization = new ToolStripMenuItem();
            itemSalary = new ToolStripMenuItem();
            textBoxIdOrder = new TextBox();
            labelIdOrder = new Label();
            labelDateCreation = new Label();
            textBoxDateCreation = new TextBox();
            labelDateStartWork = new Label();
            labelNameMaster = new Label();
            textBoxDateStartWork = new TextBox();
            labelDevice = new Label();
            labelNameClient = new Label();
            textBoxNameMaster = new TextBox();
            textBoxDevice = new TextBox();
            textBoxNameClient = new TextBox();
            labelView = new Label();
            contextMenuView = new ContextMenuStrip(components);
            itemColor = new ToolStripMenuItem();
            buttonReset = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            labelLogIn = new Label();
            contextMenuAccount = new ContextMenuStrip(components);
            itemChangeData = new ToolStripMenuItem();
            itemLogOut = new ToolStripMenuItem();
            labelClientId = new Label();
            saveFileDialog1 = new SaveFileDialog();
            checkBoxSearch = new CheckBox();
            itemSmall = new ToolStripMenuItem();
            itemMedium = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuRightMouse.SuspendLayout();
            toolStrip1.SuspendLayout();
            contextMenuDataBase.SuspendLayout();
            contextMenuWorkingWithData.SuspendLayout();
            contextMenuPayments.SuspendLayout();
            contextMenuReports.SuspendLayout();
            contextMenuView.SuspendLayout();
            contextMenuAccount.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(224, 224, 224);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(11, 90);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 22;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1194, 687);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            dataGridView1.CellMouseLeave += DataGridView1_CellMouseLeave;
            dataGridView1.CellMouseMove += DataGridView1_CellMouseMove;
            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
            dataGridView1.VisibleChanged += DataGridView1_VisibleChanged;
            dataGridView1.Click += DataGridView1_Click;
            dataGridView1.MouseClick += DataGridView1_MouseClick;
            dataGridView1.MouseDoubleClick += DataGridView1_MouseDoubleClick;
            // 
            // buttonInProgress
            // 
            buttonInProgress.BackColor = Color.Transparent;
            buttonInProgress.BackgroundImage = Properties.Resources.p1;
            buttonInProgress.BackgroundImageLayout = ImageLayout.Stretch;
            buttonInProgress.Location = new Point(1219, 85);
            buttonInProgress.Name = "buttonInProgress";
            buttonInProgress.Size = new Size(110, 120);
            buttonInProgress.TabIndex = 1;
            buttonInProgress.Text = "В ремонте";
            buttonInProgress.TextAlign = ContentAlignment.BottomCenter;
            buttonInProgress.UseVisualStyleBackColor = false;
            buttonInProgress.Click += ButtonInProgress_Click;
            // 
            // buttonCompleted
            // 
            buttonCompleted.BackgroundImage = Properties.Resources.p2;
            buttonCompleted.BackgroundImageLayout = ImageLayout.Stretch;
            buttonCompleted.Location = new Point(1219, 223);
            buttonCompleted.Name = "buttonCompleted";
            buttonCompleted.Size = new Size(110, 120);
            buttonCompleted.TabIndex = 2;
            buttonCompleted.Text = "Сделанные";
            buttonCompleted.TextAlign = ContentAlignment.BottomCenter;
            buttonCompleted.UseVisualStyleBackColor = true;
            buttonCompleted.Click += ButtonCompleted_Click;
            // 
            // buttonGuarantee
            // 
            buttonGuarantee.BackgroundImage = Properties.Resources.p3;
            buttonGuarantee.BackgroundImageLayout = ImageLayout.Stretch;
            buttonGuarantee.Location = new Point(1219, 363);
            buttonGuarantee.Name = "buttonGuarantee";
            buttonGuarantee.Size = new Size(110, 120);
            buttonGuarantee.TabIndex = 3;
            buttonGuarantee.Text = "Гарантия";
            buttonGuarantee.TextAlign = ContentAlignment.BottomCenter;
            buttonGuarantee.UseVisualStyleBackColor = true;
            buttonGuarantee.Click += ButtonGuarantee_Click;
            // 
            // buttonArchive
            // 
            buttonArchive.BackgroundImage = Properties.Resources.p4;
            buttonArchive.BackgroundImageLayout = ImageLayout.Stretch;
            buttonArchive.Location = new Point(1219, 508);
            buttonArchive.Name = "buttonArchive";
            buttonArchive.Size = new Size(110, 120);
            buttonArchive.TabIndex = 4;
            buttonArchive.Text = "Архив";
            buttonArchive.TextAlign = ContentAlignment.BottomCenter;
            buttonArchive.UseVisualStyleBackColor = true;
            buttonArchive.Click += ButtonArchive_Click;
            // 
            // buttonTrash
            // 
            buttonTrash.BackgroundImage = Properties.Resources.p5;
            buttonTrash.BackgroundImageLayout = ImageLayout.Stretch;
            buttonTrash.Location = new Point(1219, 652);
            buttonTrash.Name = "buttonTrash";
            buttonTrash.Size = new Size(110, 120);
            buttonTrash.TabIndex = 5;
            buttonTrash.Text = "Корзина";
            buttonTrash.TextAlign = ContentAlignment.BottomCenter;
            buttonTrash.UseVisualStyleBackColor = true;
            buttonTrash.Click += ButtonTrash_Click;
            // 
            // contextMenuRightMouse
            // 
            contextMenuRightMouse.ImageScalingSize = new Size(24, 24);
            contextMenuRightMouse.Items.AddRange(new ToolStripItem[] { itemPropertiesMenuRightMouse, toolStripSeparator4, itemDetailsMenuRightMouse, toolStripSeparator1, itemRemoveMenuRightMouse, itemRecoveryMenuRightMouse, toolStripSeparator2, itemActionDeviceMenuRightMouse, itemActionClientMenuRightMouse, toolStripSeparator19, itemNewOrderAsCurrentMenuRightMouse });
            contextMenuRightMouse.Name = "contextMenu";
            contextMenuRightMouse.Size = new Size(407, 252);
            // 
            // itemPropertiesMenuRightMouse
            // 
            itemPropertiesMenuRightMouse.BackgroundImageLayout = ImageLayout.Zoom;
            itemPropertiesMenuRightMouse.Image = Properties.Resources.m1;
            itemPropertiesMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemPropertiesMenuRightMouse.Name = "itemPropertiesMenuRightMouse";
            itemPropertiesMenuRightMouse.Size = new Size(406, 32);
            itemPropertiesMenuRightMouse.Text = "Свойства аппарата";
            itemPropertiesMenuRightMouse.Click += ItemPropertiesMenuRightMouse_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(403, 6);
            // 
            // itemDetailsMenuRightMouse
            // 
            itemDetailsMenuRightMouse.Image = Properties.Resources.m2;
            itemDetailsMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemDetailsMenuRightMouse.Name = "itemDetailsMenuRightMouse";
            itemDetailsMenuRightMouse.Size = new Size(406, 32);
            itemDetailsMenuRightMouse.Text = "Детали на ремонт аппарата";
            itemDetailsMenuRightMouse.Click += ItemDetailsMenuRightMouse_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(403, 6);
            // 
            // itemRemoveMenuRightMouse
            // 
            itemRemoveMenuRightMouse.Image = Properties.Resources.m3;
            itemRemoveMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemRemoveMenuRightMouse.Name = "itemRemoveMenuRightMouse";
            itemRemoveMenuRightMouse.Size = new Size(406, 32);
            itemRemoveMenuRightMouse.Text = "Удаление аппарата";
            itemRemoveMenuRightMouse.Click += ItemRemoveMenuRightMouse_Click;
            // 
            // itemRecoveryMenuRightMouse
            // 
            itemRecoveryMenuRightMouse.Image = Properties.Resources.m4;
            itemRecoveryMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemRecoveryMenuRightMouse.Name = "itemRecoveryMenuRightMouse";
            itemRecoveryMenuRightMouse.Size = new Size(406, 32);
            itemRecoveryMenuRightMouse.Text = "Восстановление аппарата из корзины";
            itemRecoveryMenuRightMouse.Click += ItemRecoveryMenuRightMouse_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(403, 6);
            // 
            // itemActionDeviceMenuRightMouse
            // 
            itemActionDeviceMenuRightMouse.DropDownItems.AddRange(new ToolStripItem[] { itemCompletedTagMenuRightMouse, itemIssueMenuRightMouse, toolStripSeparator3, itemReturnIntoRepairMenuRightMouse, itemReturnGuaranteeMenuRightMouse });
            itemActionDeviceMenuRightMouse.Image = Properties.Resources.m5;
            itemActionDeviceMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemActionDeviceMenuRightMouse.Name = "itemActionDeviceMenuRightMouse";
            itemActionDeviceMenuRightMouse.Size = new Size(406, 32);
            itemActionDeviceMenuRightMouse.Text = "Операции над аппаратом";
            // 
            // itemCompletedTagMenuRightMouse
            // 
            itemCompletedTagMenuRightMouse.Image = Properties.Resources.m5_1;
            itemCompletedTagMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemCompletedTagMenuRightMouse.Name = "itemCompletedTagMenuRightMouse";
            itemCompletedTagMenuRightMouse.Size = new Size(473, 34);
            itemCompletedTagMenuRightMouse.Text = "Пометить аппарат как отремонтированный";
            itemCompletedTagMenuRightMouse.Click += ItemCompletedTagMenuRightMouse_Click;
            // 
            // itemIssueMenuRightMouse
            // 
            itemIssueMenuRightMouse.Image = Properties.Resources.m5_2;
            itemIssueMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemIssueMenuRightMouse.Name = "itemIssueMenuRightMouse";
            itemIssueMenuRightMouse.Size = new Size(473, 34);
            itemIssueMenuRightMouse.Text = "Выдать аппарат клиенту";
            itemIssueMenuRightMouse.Click += ItemIssueMenuRightMouse_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(470, 6);
            // 
            // itemReturnIntoRepairMenuRightMouse
            // 
            itemReturnIntoRepairMenuRightMouse.Image = Properties.Resources.m5_3;
            itemReturnIntoRepairMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemReturnIntoRepairMenuRightMouse.Name = "itemReturnIntoRepairMenuRightMouse";
            itemReturnIntoRepairMenuRightMouse.Size = new Size(473, 34);
            itemReturnIntoRepairMenuRightMouse.Text = "Возврат аппарата в доработку";
            itemReturnIntoRepairMenuRightMouse.Click += ItemReturnIntoRepairMenuRightMouse_Click;
            // 
            // itemReturnGuaranteeMenuRightMouse
            // 
            itemReturnGuaranteeMenuRightMouse.Image = Properties.Resources.m5_4;
            itemReturnGuaranteeMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemReturnGuaranteeMenuRightMouse.Name = "itemReturnGuaranteeMenuRightMouse";
            itemReturnGuaranteeMenuRightMouse.Size = new Size(473, 34);
            itemReturnGuaranteeMenuRightMouse.Text = "Возврат аппарата по гарантии";
            itemReturnGuaranteeMenuRightMouse.Click += ItemReturnGuaranteeMenuRightMouse_Click;
            // 
            // itemActionClientMenuRightMouse
            // 
            itemActionClientMenuRightMouse.DropDownItems.AddRange(new ToolStripItem[] { itemPropertiesClientMenuRightMouse, itemMessageClientMenuRightMouse, itemPriorityClientMenuRightMouse });
            itemActionClientMenuRightMouse.Image = Properties.Resources.m6;
            itemActionClientMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemActionClientMenuRightMouse.Name = "itemActionClientMenuRightMouse";
            itemActionClientMenuRightMouse.Size = new Size(406, 32);
            itemActionClientMenuRightMouse.Text = "Операции над клиентом";
            // 
            // itemPropertiesClientMenuRightMouse
            // 
            itemPropertiesClientMenuRightMouse.Image = Properties.Resources.m6_1;
            itemPropertiesClientMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemPropertiesClientMenuRightMouse.Name = "itemPropertiesClientMenuRightMouse";
            itemPropertiesClientMenuRightMouse.Size = new Size(316, 34);
            itemPropertiesClientMenuRightMouse.Text = "Свойства клиента";
            itemPropertiesClientMenuRightMouse.Click += ItemPropertiesClientMenuRightMouse_Click;
            // 
            // itemMessageClientMenuRightMouse
            // 
            itemMessageClientMenuRightMouse.Image = Properties.Resources.m6_2;
            itemMessageClientMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemMessageClientMenuRightMouse.Name = "itemMessageClientMenuRightMouse";
            itemMessageClientMenuRightMouse.Size = new Size(316, 34);
            itemMessageClientMenuRightMouse.Text = "Сообщение клиенту";
            itemMessageClientMenuRightMouse.Click += ItemMessageClientMenuRightMouse_Click;
            // 
            // itemPriorityClientMenuRightMouse
            // 
            itemPriorityClientMenuRightMouse.DropDownItems.AddRange(new ToolStripItem[] { itemWhiteListMenuRightMouse, itemBlackListMenuRightMouse, itemUnmarkMenuRightMouse });
            itemPriorityClientMenuRightMouse.Image = Properties.Resources.m6_3;
            itemPriorityClientMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemPriorityClientMenuRightMouse.Name = "itemPriorityClientMenuRightMouse";
            itemPriorityClientMenuRightMouse.Size = new Size(316, 34);
            itemPriorityClientMenuRightMouse.Text = "Приоритетность клиента";
            // 
            // itemWhiteListMenuRightMouse
            // 
            itemWhiteListMenuRightMouse.Image = Properties.Resources.m6_3_1;
            itemWhiteListMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemWhiteListMenuRightMouse.Name = "itemWhiteListMenuRightMouse";
            itemWhiteListMenuRightMouse.Size = new Size(347, 34);
            itemWhiteListMenuRightMouse.Text = "Добавить в белый список";
            itemWhiteListMenuRightMouse.Click += ItemWhiteListMenuRightMouse_Click;
            // 
            // itemBlackListMenuRightMouse
            // 
            itemBlackListMenuRightMouse.Image = Properties.Resources.m6_3_2;
            itemBlackListMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemBlackListMenuRightMouse.Name = "itemBlackListMenuRightMouse";
            itemBlackListMenuRightMouse.Size = new Size(347, 34);
            itemBlackListMenuRightMouse.Text = "Добавить в черный список";
            itemBlackListMenuRightMouse.Click += ItemBlackListMenuRightMouse_Click;
            // 
            // itemUnmarkMenuRightMouse
            // 
            itemUnmarkMenuRightMouse.Image = Properties.Resources.m6_1;
            itemUnmarkMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemUnmarkMenuRightMouse.Name = "itemUnmarkMenuRightMouse";
            itemUnmarkMenuRightMouse.Size = new Size(347, 34);
            itemUnmarkMenuRightMouse.Text = "Снять с клиента все пометки";
            itemUnmarkMenuRightMouse.Click += ItemUnmarkMenuRightMouse_Click;
            // 
            // toolStripSeparator19
            // 
            toolStripSeparator19.Name = "toolStripSeparator19";
            toolStripSeparator19.Size = new Size(403, 6);
            // 
            // itemNewOrderAsCurrentMenuRightMouse
            // 
            itemNewOrderAsCurrentMenuRightMouse.Image = Properties.Resources.b2_8;
            itemNewOrderAsCurrentMenuRightMouse.ImageScaling = ToolStripItemImageScaling.None;
            itemNewOrderAsCurrentMenuRightMouse.Name = "itemNewOrderAsCurrentMenuRightMouse";
            itemNewOrderAsCurrentMenuRightMouse.Size = new Size(406, 32);
            itemNewOrderAsCurrentMenuRightMouse.Text = "Создать квитанцию на основе текущей";
            itemNewOrderAsCurrentMenuRightMouse.Click += ItemNewOrderAsCurrentMenuRightMouse_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { buttonAddDeviceIntoRepair, buttonMasters, buttonTypesDevices, toolStripSeparator5, buttonExit, toolStripSeparator6, buttonDetails, buttonRemove, buttonRecovery, buttonCompletedTag, buttonIssue, buttonReturnIntoRepair, buttonReturnGuarantee, toolStripSeparator7, buttonPropertiesOrder, buttonPropertiesClient, toolStripSeparator8 });
            toolStrip1.Location = new Point(20, 45);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 3, 0);
            toolStrip1.Size = new Size(485, 25);
            toolStrip1.TabIndex = 17;
            toolStrip1.Text = "toolStrip1";
            // 
            // buttonAddDeviceIntoRepair
            // 
            buttonAddDeviceIntoRepair.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonAddDeviceIntoRepair.Image = Properties.Resources.b2_1;
            buttonAddDeviceIntoRepair.ImageScaling = ToolStripItemImageScaling.None;
            buttonAddDeviceIntoRepair.ImageTransparentColor = Color.Magenta;
            buttonAddDeviceIntoRepair.Name = "buttonAddDeviceIntoRepair";
            buttonAddDeviceIntoRepair.Size = new Size(34, 20);
            buttonAddDeviceIntoRepair.Text = "Добавление аппарата";
            buttonAddDeviceIntoRepair.Click += ButtonAddDeviceIntoRepair_Click;
            // 
            // buttonMasters
            // 
            buttonMasters.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonMasters.Image = Properties.Resources.main1;
            buttonMasters.ImageScaling = ToolStripItemImageScaling.None;
            buttonMasters.ImageTransparentColor = Color.Magenta;
            buttonMasters.Name = "buttonMasters";
            buttonMasters.Size = new Size(34, 20);
            buttonMasters.Text = "Работа с данными о мастерах организации";
            buttonMasters.Click += ButtonMasters_Click;
            // 
            // buttonTypesDevices
            // 
            buttonTypesDevices.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonTypesDevices.Image = Properties.Resources.main2;
            buttonTypesDevices.ImageScaling = ToolStripItemImageScaling.None;
            buttonTypesDevices.ImageTransparentColor = Color.Magenta;
            buttonTypesDevices.Name = "buttonTypesDevices";
            buttonTypesDevices.Size = new Size(34, 20);
            buttonTypesDevices.Text = "Тип ремонтируемых устройств";
            buttonTypesDevices.Click += ButtonTypesDevices_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            // 
            // buttonExit
            // 
            buttonExit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonExit.Image = Properties.Resources.main5;
            buttonExit.ImageScaling = ToolStripItemImageScaling.None;
            buttonExit.ImageTransparentColor = Color.Magenta;
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(34, 20);
            buttonExit.Text = "Выход из программы";
            buttonExit.Click += ButtonExit_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 25);
            // 
            // buttonDetails
            // 
            buttonDetails.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonDetails.Image = Properties.Resources.m2;
            buttonDetails.ImageScaling = ToolStripItemImageScaling.None;
            buttonDetails.ImageTransparentColor = Color.Magenta;
            buttonDetails.Name = "buttonDetails";
            buttonDetails.Size = new Size(34, 20);
            buttonDetails.Text = "Детали, использованые в ремонте устройства";
            buttonDetails.Click += ButtonDetails_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonRemove.Image = Properties.Resources.m3;
            buttonRemove.ImageScaling = ToolStripItemImageScaling.None;
            buttonRemove.ImageTransparentColor = Color.Magenta;
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(34, 20);
            buttonRemove.Text = "Удаление объекта из базы данных";
            buttonRemove.Click += ButtonRemove_Click;
            // 
            // buttonRecovery
            // 
            buttonRecovery.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonRecovery.Image = Properties.Resources.m4;
            buttonRecovery.ImageScaling = ToolStripItemImageScaling.None;
            buttonRecovery.ImageTransparentColor = Color.Magenta;
            buttonRecovery.Name = "buttonRecovery";
            buttonRecovery.Size = new Size(34, 20);
            buttonRecovery.Text = "Восстановление удаленного ранее устройства";
            buttonRecovery.Click += ButtonRecovery_Click;
            // 
            // buttonCompletedTag
            // 
            buttonCompletedTag.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonCompletedTag.Image = Properties.Resources.m5_1;
            buttonCompletedTag.ImageScaling = ToolStripItemImageScaling.None;
            buttonCompletedTag.ImageTransparentColor = Color.Magenta;
            buttonCompletedTag.Name = "buttonCompletedTag";
            buttonCompletedTag.Size = new Size(34, 20);
            buttonCompletedTag.Text = "Пометка устройства как отремонтированного";
            buttonCompletedTag.Click += ButtonCompletedTag_Click;
            // 
            // buttonIssue
            // 
            buttonIssue.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonIssue.Image = Properties.Resources.m5_2;
            buttonIssue.ImageScaling = ToolStripItemImageScaling.None;
            buttonIssue.ImageTransparentColor = Color.Magenta;
            buttonIssue.Name = "buttonIssue";
            buttonIssue.Size = new Size(34, 20);
            buttonIssue.Text = "Выдача устройства клиенту после ремонта";
            buttonIssue.Click += ButtonIssue_Click;
            // 
            // buttonReturnIntoRepair
            // 
            buttonReturnIntoRepair.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonReturnIntoRepair.Image = Properties.Resources.m5_3;
            buttonReturnIntoRepair.ImageScaling = ToolStripItemImageScaling.None;
            buttonReturnIntoRepair.ImageTransparentColor = Color.Magenta;
            buttonReturnIntoRepair.Name = "buttonReturnIntoRepair";
            buttonReturnIntoRepair.Size = new Size(34, 20);
            buttonReturnIntoRepair.Text = "Возвращение аппарата в доработку";
            buttonReturnIntoRepair.Click += ButtonReturnIntoRepair_Click;
            // 
            // buttonReturnGuarantee
            // 
            buttonReturnGuarantee.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonReturnGuarantee.Image = Properties.Resources.m5_4;
            buttonReturnGuarantee.ImageScaling = ToolStripItemImageScaling.None;
            buttonReturnGuarantee.ImageTransparentColor = Color.Magenta;
            buttonReturnGuarantee.Name = "buttonReturnGuarantee";
            buttonReturnGuarantee.Size = new Size(34, 20);
            buttonReturnGuarantee.Text = "Возвращение устройтсва в ремонт по гарантии";
            buttonReturnGuarantee.Click += ButtonReturnGuarantee_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 25);
            // 
            // buttonPropertiesOrder
            // 
            buttonPropertiesOrder.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonPropertiesOrder.Image = Properties.Resources.m1;
            buttonPropertiesOrder.ImageScaling = ToolStripItemImageScaling.None;
            buttonPropertiesOrder.ImageTransparentColor = Color.Magenta;
            buttonPropertiesOrder.Name = "buttonPropertiesOrder";
            buttonPropertiesOrder.Size = new Size(34, 20);
            buttonPropertiesOrder.Text = "Свойства и параметры ремонтируемого объекта";
            buttonPropertiesOrder.Click += ButtonPropertiesOrder_Click;
            // 
            // buttonPropertiesClient
            // 
            buttonPropertiesClient.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonPropertiesClient.Image = Properties.Resources.m6;
            buttonPropertiesClient.ImageScaling = ToolStripItemImageScaling.None;
            buttonPropertiesClient.ImageTransparentColor = Color.Magenta;
            buttonPropertiesClient.Name = "buttonPropertiesClient";
            buttonPropertiesClient.Size = new Size(34, 20);
            buttonPropertiesClient.Text = "Свойства клиента";
            buttonPropertiesClient.Click += ButtonPropertiesClient_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 25);
            // 
            // labelDataBase
            // 
            labelDataBase.BackColor = SystemColors.Control;
            labelDataBase.Location = new Point(23, 8);
            labelDataBase.Name = "labelDataBase";
            labelDataBase.Size = new Size(121, 33);
            labelDataBase.TabIndex = 18;
            labelDataBase.Text = "База данных";
            labelDataBase.TextAlign = ContentAlignment.MiddleCenter;
            labelDataBase.Click += LabelDataBase_Click;
            labelDataBase.MouseEnter += LabelDataBase_MouseEnter;
            labelDataBase.MouseLeave += LabelDataBase_MouseLeave;
            // 
            // contextMenuDataBase
            // 
            contextMenuDataBase.ImageScalingSize = new Size(24, 24);
            contextMenuDataBase.Items.AddRange(new ToolStripItem[] { itemMasters, itemBrands, itemTypesDevices, itemClientsDirectory, itemWarehouse, itemMalfunction, itemDiagnosis, itemEquipment, toolStripSeparator9, itemExportToExcel, itemCopyBD, itemUpdateService, toolStripSeparator10, itemPathDB, toolStripSeparator18, itemOrganization, toolStripSeparator20, itemLogIn, toolStripSeparator21, itemExit });
            contextMenuDataBase.Name = "contextMenuStripButton1";
            contextMenuDataBase.Size = new Size(364, 514);
            // 
            // itemMasters
            // 
            itemMasters.Image = Properties.Resources.main1;
            itemMasters.ImageScaling = ToolStripItemImageScaling.None;
            itemMasters.Name = "itemMasters";
            itemMasters.Size = new Size(363, 32);
            itemMasters.Text = "Работники организации";
            itemMasters.Click += ItemMasters_Click;
            // 
            // itemBrands
            // 
            itemBrands.Image = Properties.Resources.b1_2;
            itemBrands.ImageScaling = ToolStripItemImageScaling.None;
            itemBrands.Name = "itemBrands";
            itemBrands.Size = new Size(363, 32);
            itemBrands.Text = "Фирмы-производители устройств";
            itemBrands.Click += ItemBrands_Click;
            // 
            // itemTypesDevices
            // 
            itemTypesDevices.Image = Properties.Resources.main2;
            itemTypesDevices.ImageScaling = ToolStripItemImageScaling.None;
            itemTypesDevices.Name = "itemTypesDevices";
            itemTypesDevices.Size = new Size(363, 32);
            itemTypesDevices.Text = "Типы устройств";
            itemTypesDevices.Click += ItemTypesDevices_Click;
            // 
            // itemClientsDirectory
            // 
            itemClientsDirectory.Image = Properties.Resources.men;
            itemClientsDirectory.ImageScaling = ToolStripItemImageScaling.None;
            itemClientsDirectory.Name = "itemClientsDirectory";
            itemClientsDirectory.Size = new Size(363, 32);
            itemClientsDirectory.Text = "Справочник клиентов";
            itemClientsDirectory.Click += ItemClientsDirectory_Click;
            // 
            // itemWarehouse
            // 
            itemWarehouse.Image = Properties.Resources.b2_9;
            itemWarehouse.ImageScaling = ToolStripItemImageScaling.None;
            itemWarehouse.Name = "itemWarehouse";
            itemWarehouse.Size = new Size(363, 32);
            itemWarehouse.Text = "Склад";
            itemWarehouse.Click += ItemWarehouse_Click;
            // 
            // itemMalfunction
            // 
            itemMalfunction.Image = Properties.Resources.b2_17;
            itemMalfunction.ImageScaling = ToolStripItemImageScaling.None;
            itemMalfunction.Name = "itemMalfunction";
            itemMalfunction.Size = new Size(363, 32);
            itemMalfunction.Text = "Неисправности";
            itemMalfunction.Click += ItemMalfunction_Click;
            // 
            // itemDiagnosis
            // 
            itemDiagnosis.Image = Properties.Resources.b2_16;
            itemDiagnosis.ImageScaling = ToolStripItemImageScaling.None;
            itemDiagnosis.Name = "itemDiagnosis";
            itemDiagnosis.Size = new Size(363, 32);
            itemDiagnosis.Text = "Диагнозы";
            itemDiagnosis.Click += ItemDiagnosis_Click;
            // 
            // itemEquipment
            // 
            itemEquipment.Image = Properties.Resources.b2_15;
            itemEquipment.ImageScaling = ToolStripItemImageScaling.None;
            itemEquipment.Name = "itemEquipment";
            itemEquipment.Size = new Size(363, 32);
            itemEquipment.Text = "Комплектация";
            itemEquipment.Click += ItemEquipment_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(360, 6);
            // 
            // itemExportToExcel
            // 
            itemExportToExcel.Image = Properties.Resources.b2_12;
            itemExportToExcel.ImageScaling = ToolStripItemImageScaling.None;
            itemExportToExcel.Name = "itemExportToExcel";
            itemExportToExcel.Size = new Size(363, 32);
            itemExportToExcel.Text = "Экспортировать таблицу в Excel";
            itemExportToExcel.Click += ItemExportToExcel_Click;
            // 
            // itemCopyBD
            // 
            itemCopyBD.Enabled = false;
            itemCopyBD.Image = Properties.Resources.main3_1;
            itemCopyBD.ImageScaling = ToolStripItemImageScaling.None;
            itemCopyBD.Name = "itemCopyBD";
            itemCopyBD.Size = new Size(363, 32);
            itemCopyBD.Text = "Сделать копию бд";
            itemCopyBD.Click += ItemCopyBD_Click;
            // 
            // itemUpdateService
            // 
            itemUpdateService.Enabled = false;
            itemUpdateService.Image = Properties.Resources.main3_2;
            itemUpdateService.ImageScaling = ToolStripItemImageScaling.None;
            itemUpdateService.Name = "itemUpdateService";
            itemUpdateService.Size = new Size(363, 32);
            itemUpdateService.Text = "Обновление бд на сервере";
            itemUpdateService.Click += ItemUpdateService_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(360, 6);
            // 
            // itemPathDB
            // 
            itemPathDB.Image = Properties.Resources.main3_3;
            itemPathDB.ImageScaling = ToolStripItemImageScaling.None;
            itemPathDB.Name = "itemPathDB";
            itemPathDB.Size = new Size(363, 32);
            itemPathDB.Text = "Путь базы данных";
            itemPathDB.Click += ItemPathDB_Click;
            // 
            // toolStripSeparator18
            // 
            toolStripSeparator18.Name = "toolStripSeparator18";
            toolStripSeparator18.Size = new Size(360, 6);
            // 
            // itemOrganization
            // 
            itemOrganization.Image = Properties.Resources.b2_10;
            itemOrganization.ImageScaling = ToolStripItemImageScaling.None;
            itemOrganization.Name = "itemOrganization";
            itemOrganization.Size = new Size(363, 32);
            itemOrganization.Text = "Сведения об организации";
            itemOrganization.Click += ItemOrganization_Click;
            // 
            // toolStripSeparator20
            // 
            toolStripSeparator20.Name = "toolStripSeparator20";
            toolStripSeparator20.Size = new Size(360, 6);
            // 
            // itemLogIn
            // 
            itemLogIn.Image = Properties.Resources.b2_11;
            itemLogIn.ImageScaling = ToolStripItemImageScaling.None;
            itemLogIn.Name = "itemLogIn";
            itemLogIn.ShortcutKeys = Keys.Control | Keys.D;
            itemLogIn.Size = new Size(363, 32);
            itemLogIn.Text = "Вход в систему";
            itemLogIn.Click += ItemLogIn_Click;
            // 
            // toolStripSeparator21
            // 
            toolStripSeparator21.Name = "toolStripSeparator21";
            toolStripSeparator21.Size = new Size(360, 6);
            // 
            // itemExit
            // 
            itemExit.Image = Properties.Resources.main5;
            itemExit.ImageScaling = ToolStripItemImageScaling.None;
            itemExit.Name = "itemExit";
            itemExit.Size = new Size(363, 32);
            itemExit.Text = "Выход из программы";
            itemExit.Click += ItemExit_Click;
            // 
            // contextMenuWorkingWithData
            // 
            contextMenuWorkingWithData.ImageScalingSize = new Size(24, 24);
            contextMenuWorkingWithData.Items.AddRange(new ToolStripItem[] { itemNewOrderMenuWorkingWithData, itemPropertiesMenuWorkingWithData, toolStripSeparator11, itemDetailsMenuWorkingWithData, toolStripSeparator12, itemRemoveMenuWorkingWithData, itemRecoveryMenuWorkingWithData, toolStripSeparator13, itemActionsDeviceMenuWorkingWithData, itemActionsClientMenuWorkingWithData, toolStripSeparator17, itemNewOrderAsCurrentMenuWorkingWithData });
            contextMenuWorkingWithData.Name = "contextMenuStripButton2";
            contextMenuWorkingWithData.Size = new Size(407, 284);
            // 
            // itemNewOrderMenuWorkingWithData
            // 
            itemNewOrderMenuWorkingWithData.Image = Properties.Resources.b2_1;
            itemNewOrderMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemNewOrderMenuWorkingWithData.Name = "itemNewOrderMenuWorkingWithData";
            itemNewOrderMenuWorkingWithData.Size = new Size(406, 32);
            itemNewOrderMenuWorkingWithData.Text = "Добавление аппарата";
            itemNewOrderMenuWorkingWithData.Click += ItemNewOrderMenuWorkingWithData_Click;
            // 
            // itemPropertiesMenuWorkingWithData
            // 
            itemPropertiesMenuWorkingWithData.Image = Properties.Resources.m1;
            itemPropertiesMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemPropertiesMenuWorkingWithData.Name = "itemPropertiesMenuWorkingWithData";
            itemPropertiesMenuWorkingWithData.Size = new Size(406, 32);
            itemPropertiesMenuWorkingWithData.Text = "Свойства аппарата";
            itemPropertiesMenuWorkingWithData.Click += ItemPropertiesMenuWorkingWithData_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(403, 6);
            // 
            // itemDetailsMenuWorkingWithData
            // 
            itemDetailsMenuWorkingWithData.Image = Properties.Resources.m2;
            itemDetailsMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemDetailsMenuWorkingWithData.Name = "itemDetailsMenuWorkingWithData";
            itemDetailsMenuWorkingWithData.Size = new Size(406, 32);
            itemDetailsMenuWorkingWithData.Text = "Детали на ремонт аппарата";
            itemDetailsMenuWorkingWithData.Click += ItemDetailsMenuWorkingWithData_Click;
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new Size(403, 6);
            // 
            // itemRemoveMenuWorkingWithData
            // 
            itemRemoveMenuWorkingWithData.Image = Properties.Resources.m3;
            itemRemoveMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemRemoveMenuWorkingWithData.Name = "itemRemoveMenuWorkingWithData";
            itemRemoveMenuWorkingWithData.Size = new Size(406, 32);
            itemRemoveMenuWorkingWithData.Text = "Удаление аппарата";
            itemRemoveMenuWorkingWithData.Click += ItemRemoveMenuWorkingWithData_Click;
            // 
            // itemRecoveryMenuWorkingWithData
            // 
            itemRecoveryMenuWorkingWithData.Image = Properties.Resources.m4;
            itemRecoveryMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemRecoveryMenuWorkingWithData.Name = "itemRecoveryMenuWorkingWithData";
            itemRecoveryMenuWorkingWithData.Size = new Size(406, 32);
            itemRecoveryMenuWorkingWithData.Text = "Восстановление аппарата из корзины";
            itemRecoveryMenuWorkingWithData.Click += ItemRecoveryMenuWorkingWithData_Click;
            // 
            // toolStripSeparator13
            // 
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new Size(403, 6);
            // 
            // itemActionsDeviceMenuWorkingWithData
            // 
            itemActionsDeviceMenuWorkingWithData.DropDownItems.AddRange(new ToolStripItem[] { itemCompletedTagMenuWorkingWithData, itemIssueMenuWorkingWithData, toolStripSeparator14, itemReturnMenuWorkingWithData, itemReturnGuaranteeMenuWorkingWithData });
            itemActionsDeviceMenuWorkingWithData.Image = Properties.Resources.m5;
            itemActionsDeviceMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemActionsDeviceMenuWorkingWithData.Name = "itemActionsDeviceMenuWorkingWithData";
            itemActionsDeviceMenuWorkingWithData.Size = new Size(406, 32);
            itemActionsDeviceMenuWorkingWithData.Text = "Операции над аппаратом";
            // 
            // itemCompletedTagMenuWorkingWithData
            // 
            itemCompletedTagMenuWorkingWithData.Image = Properties.Resources.m5_1;
            itemCompletedTagMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemCompletedTagMenuWorkingWithData.Name = "itemCompletedTagMenuWorkingWithData";
            itemCompletedTagMenuWorkingWithData.Size = new Size(473, 34);
            itemCompletedTagMenuWorkingWithData.Text = "Пометить аппарат как отремонтированный";
            itemCompletedTagMenuWorkingWithData.Click += ItemCompletedTagMenuWorkingWithData_Click;
            // 
            // itemIssueMenuWorkingWithData
            // 
            itemIssueMenuWorkingWithData.Image = Properties.Resources.m5_2;
            itemIssueMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemIssueMenuWorkingWithData.Name = "itemIssueMenuWorkingWithData";
            itemIssueMenuWorkingWithData.Size = new Size(473, 34);
            itemIssueMenuWorkingWithData.Text = "Выдать аппарат клиенту";
            itemIssueMenuWorkingWithData.Click += ItemIssueMenuWorkingWithData_Click;
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new Size(470, 6);
            // 
            // itemReturnMenuWorkingWithData
            // 
            itemReturnMenuWorkingWithData.Image = Properties.Resources.m5_3;
            itemReturnMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemReturnMenuWorkingWithData.Name = "itemReturnMenuWorkingWithData";
            itemReturnMenuWorkingWithData.Size = new Size(473, 34);
            itemReturnMenuWorkingWithData.Text = "Возврат аппарата в доработку";
            itemReturnMenuWorkingWithData.Click += ItemReturnMenuWorkingWithData_Click;
            // 
            // itemReturnGuaranteeMenuWorkingWithData
            // 
            itemReturnGuaranteeMenuWorkingWithData.Image = Properties.Resources.m5_4;
            itemReturnGuaranteeMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemReturnGuaranteeMenuWorkingWithData.Name = "itemReturnGuaranteeMenuWorkingWithData";
            itemReturnGuaranteeMenuWorkingWithData.Size = new Size(473, 34);
            itemReturnGuaranteeMenuWorkingWithData.Text = "Возврат аппарата по гарантии";
            itemReturnGuaranteeMenuWorkingWithData.Click += ItemReturnGuaranteeMenuWorkingWithData_Click;
            // 
            // itemActionsClientMenuWorkingWithData
            // 
            itemActionsClientMenuWorkingWithData.DropDownItems.AddRange(new ToolStripItem[] { itemPropertiesClientMenuWorkingWithData, toolStripSeparator15, itemMessageClientMenuWorkingWithData, toolStripSeparator16, itemPriorityClientMenuWorkingWithData });
            itemActionsClientMenuWorkingWithData.Image = Properties.Resources.m6;
            itemActionsClientMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemActionsClientMenuWorkingWithData.Name = "itemActionsClientMenuWorkingWithData";
            itemActionsClientMenuWorkingWithData.Size = new Size(406, 32);
            itemActionsClientMenuWorkingWithData.Text = "Операции над клиентом";
            // 
            // itemPropertiesClientMenuWorkingWithData
            // 
            itemPropertiesClientMenuWorkingWithData.Image = Properties.Resources.m6_1;
            itemPropertiesClientMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemPropertiesClientMenuWorkingWithData.Name = "itemPropertiesClientMenuWorkingWithData";
            itemPropertiesClientMenuWorkingWithData.Size = new Size(278, 34);
            itemPropertiesClientMenuWorkingWithData.Text = "Свойства клиента";
            itemPropertiesClientMenuWorkingWithData.Click += ItemPropertiesClientMenuWorkingWithData_Click;
            // 
            // toolStripSeparator15
            // 
            toolStripSeparator15.Name = "toolStripSeparator15";
            toolStripSeparator15.Size = new Size(275, 6);
            // 
            // itemMessageClientMenuWorkingWithData
            // 
            itemMessageClientMenuWorkingWithData.Image = Properties.Resources.m6_2;
            itemMessageClientMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemMessageClientMenuWorkingWithData.Name = "itemMessageClientMenuWorkingWithData";
            itemMessageClientMenuWorkingWithData.Size = new Size(278, 34);
            itemMessageClientMenuWorkingWithData.Text = "Сообщение клиенту";
            itemMessageClientMenuWorkingWithData.Click += ItemMessageClientMenuWorkingWithData_Click;
            // 
            // toolStripSeparator16
            // 
            toolStripSeparator16.Name = "toolStripSeparator16";
            toolStripSeparator16.Size = new Size(275, 6);
            // 
            // itemPriorityClientMenuWorkingWithData
            // 
            itemPriorityClientMenuWorkingWithData.DropDownItems.AddRange(new ToolStripItem[] { itemWhiteListWorkingWithData, itemBlackListWorkingWithData, itemUnmarkWorkingWithData });
            itemPriorityClientMenuWorkingWithData.Image = Properties.Resources.m6_3;
            itemPriorityClientMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemPriorityClientMenuWorkingWithData.Name = "itemPriorityClientMenuWorkingWithData";
            itemPriorityClientMenuWorkingWithData.Size = new Size(278, 34);
            itemPriorityClientMenuWorkingWithData.Text = "Приоритет клиента";
            // 
            // itemWhiteListWorkingWithData
            // 
            itemWhiteListWorkingWithData.Image = Properties.Resources.m6_3_1;
            itemWhiteListWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemWhiteListWorkingWithData.Name = "itemWhiteListWorkingWithData";
            itemWhiteListWorkingWithData.Size = new Size(406, 34);
            itemWhiteListWorkingWithData.Text = "Добавить клиента в \"белый список\"";
            itemWhiteListWorkingWithData.Click += ItemWhiteListWorkingWithData_Click;
            // 
            // itemBlackListWorkingWithData
            // 
            itemBlackListWorkingWithData.Image = Properties.Resources.m6_3_2;
            itemBlackListWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemBlackListWorkingWithData.Name = "itemBlackListWorkingWithData";
            itemBlackListWorkingWithData.Size = new Size(406, 34);
            itemBlackListWorkingWithData.Text = "Добавить в \"черный список\"";
            itemBlackListWorkingWithData.Click += ItemBlackListWorkingWithData_Click;
            // 
            // itemUnmarkWorkingWithData
            // 
            itemUnmarkWorkingWithData.Image = Properties.Resources.m6_1;
            itemUnmarkWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemUnmarkWorkingWithData.Name = "itemUnmarkWorkingWithData";
            itemUnmarkWorkingWithData.Size = new Size(406, 34);
            itemUnmarkWorkingWithData.Text = "Снять все метки с клиента";
            itemUnmarkWorkingWithData.Click += ItemUnmarkWorkingWithData_Click;
            // 
            // toolStripSeparator17
            // 
            toolStripSeparator17.Name = "toolStripSeparator17";
            toolStripSeparator17.Size = new Size(403, 6);
            // 
            // itemNewOrderAsCurrentMenuWorkingWithData
            // 
            itemNewOrderAsCurrentMenuWorkingWithData.Image = Properties.Resources.b2_8;
            itemNewOrderAsCurrentMenuWorkingWithData.ImageScaling = ToolStripItemImageScaling.None;
            itemNewOrderAsCurrentMenuWorkingWithData.Name = "itemNewOrderAsCurrentMenuWorkingWithData";
            itemNewOrderAsCurrentMenuWorkingWithData.Size = new Size(406, 32);
            itemNewOrderAsCurrentMenuWorkingWithData.Text = "Создать квитанцию на основе текущей";
            itemNewOrderAsCurrentMenuWorkingWithData.Click += ItemNewOrderAsCurrentMenuWorkingWithData_Click;
            // 
            // labelWorkData
            // 
            labelWorkData.BackColor = SystemColors.Control;
            labelWorkData.Location = new Point(144, 8);
            labelWorkData.Name = "labelWorkData";
            labelWorkData.Size = new Size(169, 33);
            labelWorkData.TabIndex = 21;
            labelWorkData.Text = "Работа с данными";
            labelWorkData.TextAlign = ContentAlignment.MiddleCenter;
            labelWorkData.Click += LabelWorkData_Click;
            labelWorkData.MouseEnter += LabelWorkData_MouseEnter;
            labelWorkData.MouseLeave += LabelWorkData_MouseLeave;
            // 
            // labelDocuments
            // 
            labelDocuments.BackColor = SystemColors.Control;
            labelDocuments.Location = new Point(311, 8);
            labelDocuments.Name = "labelDocuments";
            labelDocuments.Size = new Size(120, 33);
            labelDocuments.TabIndex = 22;
            labelDocuments.Text = "Документы";
            labelDocuments.TextAlign = ContentAlignment.MiddleCenter;
            labelDocuments.Click += LabelDocuments_Click;
            labelDocuments.MouseEnter += LabelDocuments_MouseEnter;
            labelDocuments.MouseLeave += LabelDocuments_MouseLeave;
            // 
            // labelReports
            // 
            labelReports.BackColor = SystemColors.Control;
            labelReports.Location = new Point(431, 8);
            labelReports.Name = "labelReports";
            labelReports.Size = new Size(89, 33);
            labelReports.TabIndex = 23;
            labelReports.Text = "Отчеты";
            labelReports.TextAlign = ContentAlignment.MiddleCenter;
            labelReports.Click += LabelReports_Click;
            labelReports.MouseEnter += LabelReports_MouseEnter;
            labelReports.MouseLeave += LabelReports_MouseLeave;
            // 
            // contextMenuPayments
            // 
            contextMenuPayments.ImageScalingSize = new Size(24, 24);
            contextMenuPayments.Items.AddRange(new ToolStripItem[] { itemGettingDevice, itemIssuingDevice });
            contextMenuPayments.Name = "contextMenuStripButton3";
            contextMenuPayments.Size = new Size(361, 68);
            // 
            // itemGettingDevice
            // 
            itemGettingDevice.Image = Properties.Resources.b2_13;
            itemGettingDevice.ImageScaling = ToolStripItemImageScaling.None;
            itemGettingDevice.Name = "itemGettingDevice";
            itemGettingDevice.Size = new Size(360, 32);
            itemGettingDevice.Text = "Квитанция о получении в ремонт";
            itemGettingDevice.Click += ItemGettingDevice_ClickAsync;
            // 
            // itemIssuingDevice
            // 
            itemIssuingDevice.Image = Properties.Resources.b2_13;
            itemIssuingDevice.ImageScaling = ToolStripItemImageScaling.None;
            itemIssuingDevice.Name = "itemIssuingDevice";
            itemIssuingDevice.Size = new Size(360, 32);
            itemIssuingDevice.Text = "Квитанция о выдачи аппарата";
            itemIssuingDevice.Click += ItemIssuingDevice_ClickAsync;
            // 
            // contextMenuReports
            // 
            contextMenuReports.ImageScalingSize = new Size(24, 24);
            contextMenuReports.Items.AddRange(new ToolStripItem[] { itemReportOrganization, itemSalary });
            contextMenuReports.Name = "contextButton4";
            contextMenuReports.Size = new Size(364, 68);
            // 
            // itemReportOrganization
            // 
            itemReportOrganization.Image = Properties.Resources.b2_14;
            itemReportOrganization.ImageScaling = ToolStripItemImageScaling.None;
            itemReportOrganization.Name = "itemReportOrganization";
            itemReportOrganization.Size = new Size(363, 32);
            itemReportOrganization.Text = "Отчет работы организации за год";
            itemReportOrganization.Click += ItemReportOrganization_Click;
            // 
            // itemSalary
            // 
            itemSalary.Image = Properties.Resources.b2_14;
            itemSalary.ImageScaling = ToolStripItemImageScaling.None;
            itemSalary.Name = "itemSalary";
            itemSalary.Size = new Size(363, 32);
            itemSalary.Text = "Расчет зарплаты";
            itemSalary.Click += ItemSalary_Click;
            // 
            // textBoxIdOrder
            // 
            textBoxIdOrder.Location = new Point(169, 787);
            textBoxIdOrder.Name = "textBoxIdOrder";
            textBoxIdOrder.Size = new Size(148, 31);
            textBoxIdOrder.TabIndex = 25;
            textBoxIdOrder.TextChanged += TextBoxIdOrder_TextChanged;
            // 
            // labelIdOrder
            // 
            labelIdOrder.Location = new Point(5, 787);
            labelIdOrder.Name = "labelIdOrder";
            labelIdOrder.Size = new Size(160, 31);
            labelIdOrder.TabIndex = 26;
            labelIdOrder.Text = "Номер квитанции";
            labelIdOrder.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelDateCreation
            // 
            labelDateCreation.Location = new Point(5, 832);
            labelDateCreation.Name = "labelDateCreation";
            labelDateCreation.Size = new Size(160, 31);
            labelDateCreation.TabIndex = 27;
            labelDateCreation.Text = "Дата приема";
            labelDateCreation.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxDateCreation
            // 
            textBoxDateCreation.Location = new Point(169, 833);
            textBoxDateCreation.Name = "textBoxDateCreation";
            textBoxDateCreation.Size = new Size(148, 31);
            textBoxDateCreation.TabIndex = 28;
            textBoxDateCreation.TextChanged += TextBoxDateCreation_TextChanged;
            // 
            // labelDateStartWork
            // 
            labelDateStartWork.Font = new Font("Segoe UI", 9F);
            labelDateStartWork.Location = new Point(325, 787);
            labelDateStartWork.Name = "labelDateStartWork";
            labelDateStartWork.Size = new Size(177, 31);
            labelDateStartWork.TabIndex = 29;
            labelDateStartWork.Text = "Дата начала работы";
            labelDateStartWork.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelNameMaster
            // 
            labelNameMaster.Location = new Point(325, 833);
            labelNameMaster.Name = "labelNameMaster";
            labelNameMaster.Size = new Size(177, 31);
            labelNameMaster.TabIndex = 30;
            labelNameMaster.Text = "Мастер";
            labelNameMaster.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxDateStartWork
            // 
            textBoxDateStartWork.Location = new Point(506, 787);
            textBoxDateStartWork.Name = "textBoxDateStartWork";
            textBoxDateStartWork.Size = new Size(150, 31);
            textBoxDateStartWork.TabIndex = 31;
            textBoxDateStartWork.TextChanged += TextBoxDateStartWork_TextChanged;
            // 
            // labelDevice
            // 
            labelDevice.Location = new Point(720, 787);
            labelDevice.Name = "labelDevice";
            labelDevice.Size = new Size(86, 31);
            labelDevice.TabIndex = 32;
            labelDevice.Text = "Аппарат";
            labelDevice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelNameClient
            // 
            labelNameClient.Location = new Point(720, 833);
            labelNameClient.Name = "labelNameClient";
            labelNameClient.Size = new Size(86, 31);
            labelNameClient.TabIndex = 35;
            labelNameClient.Text = "Заказчик";
            labelNameClient.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxNameMaster
            // 
            textBoxNameMaster.Location = new Point(506, 833);
            textBoxNameMaster.Name = "textBoxNameMaster";
            textBoxNameMaster.Size = new Size(150, 31);
            textBoxNameMaster.TabIndex = 36;
            textBoxNameMaster.TextChanged += TextBoxNameMaster_TextChanged;
            // 
            // textBoxDevice
            // 
            textBoxDevice.Location = new Point(810, 787);
            textBoxDevice.Name = "textBoxDevice";
            textBoxDevice.Size = new Size(150, 31);
            textBoxDevice.TabIndex = 37;
            textBoxDevice.TextChanged += TextBoxDevice_TextChanged;
            // 
            // textBoxNameClient
            // 
            textBoxNameClient.Location = new Point(810, 832);
            textBoxNameClient.Name = "textBoxNameClient";
            textBoxNameClient.Size = new Size(150, 31);
            textBoxNameClient.TabIndex = 40;
            textBoxNameClient.TextChanged += TextBoxNameClient_TextChanged;
            // 
            // labelView
            // 
            labelView.BackColor = SystemColors.Control;
            labelView.Font = new Font("Segoe UI", 9F);
            labelView.Location = new Point(520, 8);
            labelView.Name = "labelView";
            labelView.Size = new Size(89, 33);
            labelView.TabIndex = 41;
            labelView.Text = "Вид";
            labelView.TextAlign = ContentAlignment.MiddleCenter;
            labelView.Click += LabelView_Click;
            labelView.MouseEnter += LabelView_MouseEnter;
            labelView.MouseLeave += LabelView_MouseLeave;
            // 
            // contextMenuView
            // 
            contextMenuView.ImageScalingSize = new Size(24, 24);
            contextMenuView.Items.AddRange(new ToolStripItem[] { itemColor });
            contextMenuView.Name = "contextButton5";
            contextMenuView.Size = new Size(133, 36);
            // 
            // itemColor
            // 
            itemColor.Image = Properties.Resources.b2_20;
            itemColor.ImageScaling = ToolStripItemImageScaling.None;
            itemColor.Name = "itemColor";
            itemColor.Size = new Size(132, 32);
            itemColor.Text = "Цвета";
            itemColor.Click += ItemColor_Click;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = SystemColors.Control;
            buttonReset.Location = new Point(1219, 787);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(110, 77);
            buttonReset.TabIndex = 42;
            buttonReset.Text = "Сброс фильтров";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += ButtonReset_Click;
            // 
            // timer1
            // 
            timer1.Tick += Timer1_Tick;
            // 
            // labelLogIn
            // 
            labelLogIn.Location = new Point(1219, 12);
            labelLogIn.Margin = new Padding(3);
            labelLogIn.Name = "labelLogIn";
            labelLogIn.Size = new Size(107, 33);
            labelLogIn.TabIndex = 43;
            labelLogIn.Text = "Войти";
            labelLogIn.TextAlign = ContentAlignment.MiddleCenter;
            labelLogIn.Click += LabelLogIn_Click;
            labelLogIn.MouseEnter += LabelLogIn_MouseEnter;
            labelLogIn.MouseLeave += LabelLogIn_MouseLeave;
            // 
            // contextMenuAccount
            // 
            contextMenuAccount.ImageScalingSize = new Size(24, 24);
            contextMenuAccount.Items.AddRange(new ToolStripItem[] { itemChangeData, itemLogOut });
            contextMenuAccount.Name = "contextAccount";
            contextMenuAccount.Size = new Size(282, 68);
            // 
            // itemChangeData
            // 
            itemChangeData.Image = Properties.Resources.b2_19;
            itemChangeData.ImageScaling = ToolStripItemImageScaling.None;
            itemChangeData.Name = "itemChangeData";
            itemChangeData.Size = new Size(281, 32);
            itemChangeData.Text = "Изменить логин/пароль";
            itemChangeData.Click += ItemChangeData_Click;
            // 
            // itemLogOut
            // 
            itemLogOut.Image = Properties.Resources.b2_18;
            itemLogOut.ImageScaling = ToolStripItemImageScaling.None;
            itemLogOut.Name = "itemLogOut";
            itemLogOut.Size = new Size(281, 32);
            itemLogOut.Text = "Выйти из системы";
            itemLogOut.Click += ItemLogOut_Click;
            // 
            // labelClientId
            // 
            labelClientId.AutoSize = true;
            labelClientId.Font = new Font("Segoe UI", 13F);
            labelClientId.Location = new Point(1216, 89);
            labelClientId.Name = "labelClientId";
            labelClientId.Size = new Size(29, 36);
            labelClientId.TabIndex = 44;
            labelClientId.Text = "0";
            labelClientId.Visible = false;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileName = "MainTable";
            saveFileDialog1.Filter = "Excel file(*.xlsx)|*.xlsx";
            // 
            // checkBoxSearch
            // 
            checkBoxSearch.AutoSize = true;
            checkBoxSearch.Checked = true;
            checkBoxSearch.CheckState = CheckState.Checked;
            checkBoxSearch.Location = new Point(1016, 789);
            checkBoxSearch.Name = "checkBoxSearch";
            checkBoxSearch.Size = new Size(189, 29);
            checkBoxSearch.TabIndex = 45;
            checkBoxSearch.Text = "Глобальный поиск";
            checkBoxSearch.UseVisualStyleBackColor = true;
            checkBoxSearch.CheckedChanged += CheckBoxSearch_CheckedChanged;
            // 
            // itemSmall
            // 
            itemSmall.Name = "itemSmall";
            itemSmall.Size = new Size(32, 19);
            // 
            // itemMedium
            // 
            itemMedium.Name = "itemMedium";
            itemMedium.Size = new Size(32, 19);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1337, 878);
            Controls.Add(checkBoxSearch);
            Controls.Add(labelClientId);
            Controls.Add(labelLogIn);
            Controls.Add(buttonReset);
            Controls.Add(labelView);
            Controls.Add(textBoxNameClient);
            Controls.Add(textBoxDevice);
            Controls.Add(textBoxNameMaster);
            Controls.Add(labelNameClient);
            Controls.Add(labelDevice);
            Controls.Add(textBoxDateStartWork);
            Controls.Add(labelNameMaster);
            Controls.Add(labelDateStartWork);
            Controls.Add(textBoxDateCreation);
            Controls.Add(labelDateCreation);
            Controls.Add(labelIdOrder);
            Controls.Add(textBoxIdOrder);
            Controls.Add(labelReports);
            Controls.Add(labelDocuments);
            Controls.Add(labelWorkData);
            Controls.Add(labelDataBase);
            Controls.Add(toolStrip1);
            Controls.Add(buttonTrash);
            Controls.Add(buttonArchive);
            Controls.Add(buttonGuarantee);
            Controls.Add(buttonCompleted);
            Controls.Add(buttonInProgress);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DesktopAppDB";
            Activated += Form1_Activated;
            Deactivate += Form1_Deactivate;
            FormClosing += Form1_FormClosing;
            SizeChanged += Form1_SizeChanged;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuRightMouse.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            contextMenuDataBase.ResumeLayout(false);
            contextMenuWorkingWithData.ResumeLayout(false);
            contextMenuPayments.ResumeLayout(false);
            contextMenuReports.ResumeLayout(false);
            contextMenuView.ResumeLayout(false);
            contextMenuAccount.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button buttonInProgress;
        private Button buttonCompleted;
        private Button buttonGuarantee;
        private Button buttonArchive;
        private Button buttonTrash;
        private ContextMenuStrip contextMenuRightMouse;
        private ToolStripMenuItem itemPropertiesMenuRightMouse;
        private ToolStripMenuItem itemDetailsMenuRightMouse;
        private ToolStripMenuItem itemRemoveMenuRightMouse;
        private ToolStripMenuItem itemRecoveryMenuRightMouse;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem itemActionDeviceMenuRightMouse;
        private ToolStripMenuItem itemActionClientMenuRightMouse;
        private ToolStripMenuItem itemCompletedTagMenuRightMouse;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem itemIssueMenuRightMouse;
        private ToolStripMenuItem itemReturnIntoRepairMenuRightMouse;
        private ToolStripMenuItem itemReturnGuaranteeMenuRightMouse;
        private ToolStripMenuItem itemPropertiesClientMenuRightMouse;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem itemMessageClientMenuRightMouse;
        private ToolStripMenuItem itemPriorityClientMenuRightMouse;
        private ToolStripMenuItem itemWhiteListMenuRightMouse;
        private ToolStripMenuItem itemBlackListMenuRightMouse;
        private ToolStripMenuItem itemUnmarkMenuRightMouse;
        private ToolStrip toolStrip1;
        private ToolStripButton buttonMasters;
        private ToolStripButton buttonTypesDevices;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton buttonSettings;
        private ToolStripButton buttonPrinter;
        private ToolStripButton buttonExit;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton buttonDetails;
        private ToolStripButton buttonRemove;
        private ToolStripButton buttonRecovery;
        private ToolStripButton buttonCompletedTag;
        private ToolStripButton buttonIssue;
        private ToolStripButton buttonReturnIntoRepair;
        private ToolStripButton buttonReturnGuarantee;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton buttonPropertiesOrder;
        private ToolStripButton buttonPropertiesClient;
        private ToolStripSeparator toolStripSeparator8;
        private Label labelDataBase;
        private ContextMenuStrip contextMenuDataBase;
        private ToolStripMenuItem itemMasters;
        private ContextMenuStrip contextMenuWorkingWithData;
        private ToolStripMenuItem itemNewOrderMenuWorkingWithData;
        private Label labelWorkData;
        private Label labelDocuments;
        private Label labelReports;
        private ContextMenuStrip contextMenuPayments;
        private ToolStripMenuItem itemBrands;
        private ToolStripMenuItem itemTypesDevices;
        private ToolStripMenuItem itemClientsDirectory;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem itemCopyBD;
        private ToolStripMenuItem itemPrinter;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem itemExit;
        private ToolStripMenuItem itemPropertiesMenuWorkingWithData;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem itemDetailsMenuWorkingWithData;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem itemRemoveMenuWorkingWithData;
        private ToolStripMenuItem itemRecoveryMenuWorkingWithData;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem itemActionsClientMenuWorkingWithData;
        private ToolStripMenuItem itemActionsDeviceMenuWorkingWithData;
        private ToolStripMenuItem itemCompletedTagMenuWorkingWithData;
        private ToolStripMenuItem itemIssueMenuWorkingWithData;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem itemReturnMenuWorkingWithData;
        private ToolStripMenuItem itemReturnGuaranteeMenuWorkingWithData;
        private ToolStripMenuItem itemPropertiesClientMenuWorkingWithData;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem itemMessageClientMenuWorkingWithData;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem itemPriorityClientMenuWorkingWithData;
        private ToolStripMenuItem itemWhiteListWorkingWithData;
        private ToolStripMenuItem itemBlackListWorkingWithData;
        private ToolStripMenuItem itemUnmarkWorkingWithData;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripMenuItem itemNewOrderAsCurrentMenuWorkingWithData;
        private ContextMenuStrip contextMenuReports;
        private ToolStripMenuItem itemSalary;
        private ToolStripMenuItem itemGettingDevice;
        private ToolStripMenuItem itemIssuingDevice;
        private ToolStripMenuItem itemUpdateService;
        private TextBox textBoxIdOrder;
        private Label labelIdOrder;
        private Label labelDateCreation;
        private TextBox textBoxDateCreation;
        private Label labelDateStartWork;
        private Label labelNameMaster;
        private TextBox textBoxDateStartWork;
        private Label labelDevice;
        private Label labelNameClient;
        private TextBox textBoxNameMaster;
        private TextBox textBoxDevice;
        private TextBox textBoxNameClient;
        private Label labelView;
        private ContextMenuStrip contextMenuView;
        private ToolStripMenuItem itemColor;
        private Button buttonReset;
        private ToolStripMenuItem itemPathDB;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripMenuItem itemNewOrderAsCurrentMenuRightMouse;
        private ToolStripMenuItem itemWarehouse;
        private ToolStripMenuItem itemOrganization;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripButton buttonAddDeviceIntoRepair;
        private ToolStripMenuItem itemMalfunction;
        private ToolStripMenuItem itemDiagnosis;
        private ToolStripMenuItem itemEquipment;
        private ToolStripMenuItem itemLogIn;
        private ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.Timer timer1;
        private Label labelLogIn;
        private ContextMenuStrip contextMenuAccount;
        private ToolStripMenuItem itemChangeData;
        private ToolStripMenuItem itemLogOut;
        private Label labelClientId;
        private ToolStripMenuItem itemReportOrganization;
        private ToolStripMenuItem itemExportToExcel;
        private SaveFileDialog saveFileDialog1;
        private CheckBox checkBoxSearch;
        private ToolStripMenuItem itemSmall;
        private ToolStripMenuItem itemMedium;
    }
}
