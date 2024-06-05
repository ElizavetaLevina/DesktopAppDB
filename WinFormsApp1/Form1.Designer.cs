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
            contextMenu1 = new ContextMenuStrip(components);
            item1 = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            item2 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            item3 = new ToolStripMenuItem();
            item4 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            item5 = new ToolStripMenuItem();
            item5_1 = new ToolStripMenuItem();
            item5_2 = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            item5_3 = new ToolStripMenuItem();
            item5_4 = new ToolStripMenuItem();
            item6 = new ToolStripMenuItem();
            item6_1 = new ToolStripMenuItem();
            item6_2 = new ToolStripMenuItem();
            item6_3 = new ToolStripMenuItem();
            item6_3_1 = new ToolStripMenuItem();
            item6_3_2 = new ToolStripMenuItem();
            item6_3_3 = new ToolStripMenuItem();
            toolStripSeparator19 = new ToolStripSeparator();
            item7 = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            buttonMasters = new ToolStripButton();
            buttonDevice = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            buttonExit = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            buttonDetails = new ToolStripButton();
            buttonDelete = new ToolStripButton();
            buttonRecoveryOrder = new ToolStripButton();
            buttonCompletedTag = new ToolStripButton();
            buttonIssue = new ToolStripButton();
            buttonReturnInRepair = new ToolStripButton();
            buttonReturnGuarantee = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            buttonFeaturesOrder = new ToolStripButton();
            buttonFeaturesClient = new ToolStripButton();
            toolStripSeparator8 = new ToolStripSeparator();
            labelDataBase = new Label();
            contextButton1 = new ContextMenuStrip(components);
            itemAddMasters = new ToolStripMenuItem();
            itemAddBrand = new ToolStripMenuItem();
            itemAddDevice = new ToolStripMenuItem();
            itemClients = new ToolStripMenuItem();
            itemWarehouse = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            itemCopyBD = new ToolStripMenuItem();
            itemUpdateService = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            itemPathDB = new ToolStripMenuItem();
            toolStripSeparator18 = new ToolStripSeparator();
            itemOrg = new ToolStripMenuItem();
            toolStripSeparator20 = new ToolStripSeparator();
            itemExit = new ToolStripMenuItem();
            contextButton2 = new ContextMenuStrip(components);
            itemAddDeviceForRepair = new ToolStripMenuItem();
            itemFeaturesOrder = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            itemDetails = new ToolStripMenuItem();
            toolStripSeparator12 = new ToolStripSeparator();
            itemDeleteOrder = new ToolStripMenuItem();
            itemRecoveryOrder = new ToolStripMenuItem();
            toolStripSeparator13 = new ToolStripSeparator();
            itemActionsOrder = new ToolStripMenuItem();
            itemOrderCompleted = new ToolStripMenuItem();
            itemOrderIssued = new ToolStripMenuItem();
            toolStripSeparator14 = new ToolStripSeparator();
            itemReturnToRevision = new ToolStripMenuItem();
            itemReturnUnderGuarantee = new ToolStripMenuItem();
            itemActionsClient = new ToolStripMenuItem();
            itemFeaturesClient = new ToolStripMenuItem();
            toolStripSeparator15 = new ToolStripSeparator();
            itemMessageToClient = new ToolStripMenuItem();
            toolStripSeparator16 = new ToolStripSeparator();
            itemPriorityClient = new ToolStripMenuItem();
            itemAddToWhitelist = new ToolStripMenuItem();
            itemAddToBlacklist = new ToolStripMenuItem();
            itemRemoveMarks = new ToolStripMenuItem();
            toolStripSeparator17 = new ToolStripSeparator();
            itemCreateOrder = new ToolStripMenuItem();
            labelWorkData = new Label();
            labelDocuments = new Label();
            labelReports = new Label();
            contextButton3 = new ContextMenuStrip(components);
            itemGetting = new ToolStripMenuItem();
            itemIssuing = new ToolStripMenuItem();
            contextButton4 = new ContextMenuStrip(components);
            itemSalary = new ToolStripMenuItem();
            buttonAccepted = new Button();
            textBoxIdOrder = new TextBox();
            labelIdOrder = new Label();
            labelDateCreation = new Label();
            textBoxDateCreation = new TextBox();
            labelDateStartWork = new Label();
            labelNameMaster = new Label();
            textBoxDateStartWork = new TextBox();
            labelTypeDevice = new Label();
            labelBrandDevice = new Label();
            labelModel = new Label();
            labelNameClient = new Label();
            textBoxNameMaster = new TextBox();
            textBoxTypeDevice = new TextBox();
            textBoxBrandDevice = new TextBox();
            textBoxModel = new TextBox();
            textBoxNameClient = new TextBox();
            labelView = new Label();
            contextButton5 = new ContextMenuStrip(components);
            itemColor = new ToolStripMenuItem();
            itemSize = new ToolStripMenuItem();
            itemSmall = new ToolStripMenuItem();
            itemMedium = new ToolStripMenuItem();
            buttonReset = new Button();
            contextPhone = new ContextMenuStrip(components);
            numberPhone = new ToolStripMenuItem();
            buttonAddDevice = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenu1.SuspendLayout();
            toolStrip1.SuspendLayout();
            contextButton1.SuspendLayout();
            contextButton2.SuspendLayout();
            contextButton3.SuspendLayout();
            contextButton4.SuspendLayout();
            contextButton5.SuspendLayout();
            contextPhone.SuspendLayout();
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
            dataGridView1.Location = new Point(12, 85);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 22;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1195, 687);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter;
            dataGridView1.CellMouseLeave += DataGridView1_CellMouseLeave;
            dataGridView1.CellMouseMove += DataGridView1_CellMouseMove;
            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
            dataGridView1.VisibleChanged += DataGridView1_VisibleChanged;
            dataGridView1.Click += DataGridView1_Click;
            dataGridView1.MouseClick += DataGridView1_MouseClick;
            dataGridView1.MouseDoubleClick += DataGridView1_MouseDoubleClick;
            dataGridView1.MouseMove += DataGridView1_MouseMove;
            // 
            // buttonInProgress
            // 
            buttonInProgress.BackColor = Color.Transparent;
            buttonInProgress.BackgroundImage = Properties.Resources.p1;
            buttonInProgress.BackgroundImageLayout = ImageLayout.Stretch;
            buttonInProgress.Location = new Point(1218, 140);
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
            buttonCompleted.Location = new Point(1218, 268);
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
            buttonGuarantee.Location = new Point(1218, 396);
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
            buttonArchive.Location = new Point(1218, 524);
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
            buttonTrash.Location = new Point(1218, 652);
            buttonTrash.Name = "buttonTrash";
            buttonTrash.Size = new Size(110, 120);
            buttonTrash.TabIndex = 5;
            buttonTrash.Text = "Корзина";
            buttonTrash.TextAlign = ContentAlignment.BottomCenter;
            buttonTrash.UseVisualStyleBackColor = true;
            buttonTrash.Click += ButtonTrash_Click;
            // 
            // contextMenu1
            // 
            contextMenu1.ImageScalingSize = new Size(24, 24);
            contextMenu1.Items.AddRange(new ToolStripItem[] { item1, toolStripSeparator4, item2, toolStripSeparator1, item3, item4, toolStripSeparator2, item5, item6, toolStripSeparator19, item7 });
            contextMenu1.Name = "contextMenu";
            contextMenu1.Size = new Size(407, 252);
            // 
            // item1
            // 
            item1.BackgroundImageLayout = ImageLayout.Zoom;
            item1.Image = Properties.Resources.m1;
            item1.ImageScaling = ToolStripItemImageScaling.None;
            item1.Name = "item1";
            item1.Size = new Size(406, 32);
            item1.Text = "Свойства аппарата";
            item1.Click += Item1_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(403, 6);
            // 
            // item2
            // 
            item2.Image = Properties.Resources.m2;
            item2.ImageScaling = ToolStripItemImageScaling.None;
            item2.Name = "item2";
            item2.Size = new Size(406, 32);
            item2.Text = "Детали на ремонт аппарата";
            item2.Click += Item2_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(403, 6);
            // 
            // item3
            // 
            item3.Image = Properties.Resources.m3;
            item3.ImageScaling = ToolStripItemImageScaling.None;
            item3.Name = "item3";
            item3.Size = new Size(406, 32);
            item3.Text = "Удаление аппарата";
            item3.Click += Item3_Click;
            // 
            // item4
            // 
            item4.Image = Properties.Resources.m4;
            item4.ImageScaling = ToolStripItemImageScaling.None;
            item4.Name = "item4";
            item4.Size = new Size(406, 32);
            item4.Text = "Восстановление аппарата из корзины";
            item4.Click += Item4_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(403, 6);
            // 
            // item5
            // 
            item5.DropDownItems.AddRange(new ToolStripItem[] { item5_1, item5_2, toolStripSeparator3, item5_3, item5_4 });
            item5.Image = Properties.Resources.m5;
            item5.ImageScaling = ToolStripItemImageScaling.None;
            item5.Name = "item5";
            item5.Size = new Size(406, 32);
            item5.Text = "Операции над аппаратом";
            // 
            // item5_1
            // 
            item5_1.Image = Properties.Resources.m5_1;
            item5_1.ImageScaling = ToolStripItemImageScaling.None;
            item5_1.Name = "item5_1";
            item5_1.Size = new Size(473, 34);
            item5_1.Text = "Пометить аппарат как отремонтированный";
            item5_1.Click += Item5_1_Click;
            // 
            // item5_2
            // 
            item5_2.Image = Properties.Resources.m5_2;
            item5_2.ImageScaling = ToolStripItemImageScaling.None;
            item5_2.Name = "item5_2";
            item5_2.Size = new Size(473, 34);
            item5_2.Text = "Выдать аппарат клиенту";
            item5_2.Click += Item5_2_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(470, 6);
            // 
            // item5_3
            // 
            item5_3.Image = Properties.Resources.m5_3;
            item5_3.ImageScaling = ToolStripItemImageScaling.None;
            item5_3.Name = "item5_3";
            item5_3.Size = new Size(473, 34);
            item5_3.Text = "Возврат аппарата в доработку";
            item5_3.Click += Item5_3_Click;
            // 
            // item5_4
            // 
            item5_4.Image = Properties.Resources.m5_4;
            item5_4.ImageScaling = ToolStripItemImageScaling.None;
            item5_4.Name = "item5_4";
            item5_4.Size = new Size(473, 34);
            item5_4.Text = "Возврат аппарата по гарантии";
            item5_4.Click += Item5_4_Click;
            // 
            // item6
            // 
            item6.DropDownItems.AddRange(new ToolStripItem[] { item6_1, item6_2, item6_3 });
            item6.Image = Properties.Resources.m6;
            item6.ImageScaling = ToolStripItemImageScaling.None;
            item6.Name = "item6";
            item6.Size = new Size(406, 32);
            item6.Text = "Операции над клиентом";
            // 
            // item6_1
            // 
            item6_1.Image = Properties.Resources.m6_1;
            item6_1.ImageScaling = ToolStripItemImageScaling.None;
            item6_1.Name = "item6_1";
            item6_1.Size = new Size(316, 34);
            item6_1.Text = "Свойства клиента";
            item6_1.Click += Item6_1_Click;
            // 
            // item6_2
            // 
            item6_2.Image = Properties.Resources.m6_2;
            item6_2.ImageScaling = ToolStripItemImageScaling.None;
            item6_2.Name = "item6_2";
            item6_2.Size = new Size(316, 34);
            item6_2.Text = "Сообщение клиенту";
            item6_2.Click += Item6_2_Click;
            // 
            // item6_3
            // 
            item6_3.DropDownItems.AddRange(new ToolStripItem[] { item6_3_1, item6_3_2, item6_3_3 });
            item6_3.Image = Properties.Resources.m6_3;
            item6_3.ImageScaling = ToolStripItemImageScaling.None;
            item6_3.Name = "item6_3";
            item6_3.Size = new Size(316, 34);
            item6_3.Text = "Приоритетность клиента";
            // 
            // item6_3_1
            // 
            item6_3_1.Image = Properties.Resources.m6_3_1;
            item6_3_1.ImageScaling = ToolStripItemImageScaling.None;
            item6_3_1.Name = "item6_3_1";
            item6_3_1.Size = new Size(347, 34);
            item6_3_1.Text = "Добавить в белый список";
            item6_3_1.Click += Item6_3_1_Click;
            // 
            // item6_3_2
            // 
            item6_3_2.Image = Properties.Resources.m6_3_2;
            item6_3_2.ImageScaling = ToolStripItemImageScaling.None;
            item6_3_2.Name = "item6_3_2";
            item6_3_2.Size = new Size(347, 34);
            item6_3_2.Text = "Добавить в черный список";
            item6_3_2.Click += Item6_3_2_Click;
            // 
            // item6_3_3
            // 
            item6_3_3.Image = Properties.Resources.m6_1;
            item6_3_3.ImageScaling = ToolStripItemImageScaling.None;
            item6_3_3.Name = "item6_3_3";
            item6_3_3.Size = new Size(347, 34);
            item6_3_3.Text = "Снять с клиента все пометки";
            item6_3_3.Click += Item6_3_3_Click;
            // 
            // toolStripSeparator19
            // 
            toolStripSeparator19.Name = "toolStripSeparator19";
            toolStripSeparator19.Size = new Size(403, 6);
            // 
            // item7
            // 
            item7.Image = Properties.Resources.b2_8;
            item7.ImageScaling = ToolStripItemImageScaling.None;
            item7.Name = "item7";
            item7.Size = new Size(406, 32);
            item7.Text = "Создать квитанцию на основе текущей";
            item7.Click += Item7_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { buttonAddDevice, buttonMasters, buttonDevice, toolStripSeparator5, buttonExit, toolStripSeparator6, buttonDetails, buttonDelete, buttonRecoveryOrder, buttonCompletedTag, buttonIssue, buttonReturnInRepair, buttonReturnGuarantee, toolStripSeparator7, buttonFeaturesOrder, buttonFeaturesClient, toolStripSeparator8 });
            toolStrip1.Location = new Point(20, 43);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(530, 28);
            toolStrip1.TabIndex = 17;
            toolStrip1.Text = "toolStrip1";
            // 
            // buttonMasters
            // 
            buttonMasters.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonMasters.Image = Properties.Resources.main1;
            buttonMasters.ImageScaling = ToolStripItemImageScaling.None;
            buttonMasters.ImageTransparentColor = Color.Magenta;
            buttonMasters.Name = "buttonMasters";
            buttonMasters.Size = new Size(34, 23);
            buttonMasters.Text = "Работа с данными о мастерах организации";
            buttonMasters.Click += ButtonMasters_Click;
            // 
            // buttonDevice
            // 
            buttonDevice.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonDevice.Image = Properties.Resources.main2;
            buttonDevice.ImageScaling = ToolStripItemImageScaling.None;
            buttonDevice.ImageTransparentColor = Color.Magenta;
            buttonDevice.Name = "buttonDevice";
            buttonDevice.Size = new Size(34, 23);
            buttonDevice.Text = "Тип ремонтируемых устройств";
            buttonDevice.Click += ButtonDevice_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 28);
            // 
            // buttonExit
            // 
            buttonExit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonExit.Image = Properties.Resources.main5;
            buttonExit.ImageScaling = ToolStripItemImageScaling.None;
            buttonExit.ImageTransparentColor = Color.Magenta;
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(34, 23);
            buttonExit.Text = "Выход из программы";
            buttonExit.Click += ButtonExit_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 28);
            // 
            // buttonDetails
            // 
            buttonDetails.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonDetails.Image = Properties.Resources.m2;
            buttonDetails.ImageScaling = ToolStripItemImageScaling.None;
            buttonDetails.ImageTransparentColor = Color.Magenta;
            buttonDetails.Name = "buttonDetails";
            buttonDetails.Size = new Size(34, 23);
            buttonDetails.Text = "Детали, использованые в ремонте устройства";
            buttonDetails.Click += ButtonDetails_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonDelete.Image = Properties.Resources.m3;
            buttonDelete.ImageScaling = ToolStripItemImageScaling.None;
            buttonDelete.ImageTransparentColor = Color.Magenta;
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(34, 23);
            buttonDelete.Text = "Удаление объекта из базы данных";
            buttonDelete.Click += ButtonDelete_Click;
            // 
            // buttonRecoveryOrder
            // 
            buttonRecoveryOrder.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonRecoveryOrder.Image = Properties.Resources.m4;
            buttonRecoveryOrder.ImageScaling = ToolStripItemImageScaling.None;
            buttonRecoveryOrder.ImageTransparentColor = Color.Magenta;
            buttonRecoveryOrder.Name = "buttonRecoveryOrder";
            buttonRecoveryOrder.Size = new Size(34, 23);
            buttonRecoveryOrder.Text = "Восстановление удаленного ранее устройства";
            buttonRecoveryOrder.Click += ButtonRestoring_Click;
            // 
            // buttonCompletedTag
            // 
            buttonCompletedTag.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonCompletedTag.Image = Properties.Resources.m5_1;
            buttonCompletedTag.ImageScaling = ToolStripItemImageScaling.None;
            buttonCompletedTag.ImageTransparentColor = Color.Magenta;
            buttonCompletedTag.Name = "buttonCompletedTag";
            buttonCompletedTag.Size = new Size(34, 23);
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
            buttonIssue.Size = new Size(34, 23);
            buttonIssue.Text = "Выдача устройства клиенту после ремонта";
            buttonIssue.Click += ButtonIssue_Click;
            // 
            // buttonReturnInRepair
            // 
            buttonReturnInRepair.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonReturnInRepair.Image = Properties.Resources.m5_3;
            buttonReturnInRepair.ImageScaling = ToolStripItemImageScaling.None;
            buttonReturnInRepair.ImageTransparentColor = Color.Magenta;
            buttonReturnInRepair.Name = "buttonReturnInRepair";
            buttonReturnInRepair.Size = new Size(34, 23);
            buttonReturnInRepair.Text = "Возвращение аппарата в доработку";
            buttonReturnInRepair.Click += ButtonReturnInRepair_Click;
            // 
            // buttonReturnGuarantee
            // 
            buttonReturnGuarantee.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonReturnGuarantee.Image = Properties.Resources.m5_4;
            buttonReturnGuarantee.ImageScaling = ToolStripItemImageScaling.None;
            buttonReturnGuarantee.ImageTransparentColor = Color.Magenta;
            buttonReturnGuarantee.Name = "buttonReturnGuarantee";
            buttonReturnGuarantee.Size = new Size(34, 23);
            buttonReturnGuarantee.Text = "Возвращение устройтсва в ремонт по гарантии";
            buttonReturnGuarantee.Click += ButtonReturnGuarantee_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 28);
            // 
            // buttonFeaturesOrder
            // 
            buttonFeaturesOrder.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonFeaturesOrder.Image = Properties.Resources.m1;
            buttonFeaturesOrder.ImageScaling = ToolStripItemImageScaling.None;
            buttonFeaturesOrder.ImageTransparentColor = Color.Magenta;
            buttonFeaturesOrder.Name = "buttonFeaturesOrder";
            buttonFeaturesOrder.Size = new Size(34, 23);
            buttonFeaturesOrder.Text = "Свойства и параметры ремонтируемого объекта";
            buttonFeaturesOrder.Click += ButtonFeaturesOrder_Click;
            // 
            // buttonFeaturesClient
            // 
            buttonFeaturesClient.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonFeaturesClient.Image = Properties.Resources.m6;
            buttonFeaturesClient.ImageScaling = ToolStripItemImageScaling.None;
            buttonFeaturesClient.ImageTransparentColor = Color.Magenta;
            buttonFeaturesClient.Name = "buttonFeaturesClient";
            buttonFeaturesClient.Size = new Size(34, 23);
            buttonFeaturesClient.Text = "Свойства клиента";
            buttonFeaturesClient.Click += ButtonFeaturesClient_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 28);
            // 
            // labelDataBase
            // 
            labelDataBase.BackColor = SystemColors.Control;
            labelDataBase.Location = new Point(23, 9);
            labelDataBase.Name = "labelDataBase";
            labelDataBase.Size = new Size(121, 34);
            labelDataBase.TabIndex = 18;
            labelDataBase.Text = "База данных";
            labelDataBase.TextAlign = ContentAlignment.MiddleCenter;
            labelDataBase.Click += LabelDataBase_Click;
            labelDataBase.MouseEnter += LabelDataBase_MouseEnter;
            labelDataBase.MouseLeave += LabelDataBase_MouseLeave;
            // 
            // contextButton1
            // 
            contextButton1.ImageScalingSize = new Size(24, 24);
            contextButton1.Items.AddRange(new ToolStripItem[] { itemAddMasters, itemAddBrand, itemAddDevice, itemClients, itemWarehouse, toolStripSeparator9, itemCopyBD, itemUpdateService, toolStripSeparator10, itemPathDB, toolStripSeparator18, itemOrg, toolStripSeparator20, itemExit });
            contextButton1.Name = "contextMenuStripButton1";
            contextButton1.Size = new Size(364, 348);
            // 
            // itemAddMasters
            // 
            itemAddMasters.Image = Properties.Resources.main1;
            itemAddMasters.ImageScaling = ToolStripItemImageScaling.None;
            itemAddMasters.Name = "itemAddMasters";
            itemAddMasters.Size = new Size(363, 32);
            itemAddMasters.Text = "Работники организации";
            itemAddMasters.Click += ItemAddMasters_Click;
            // 
            // itemAddBrand
            // 
            itemAddBrand.Image = Properties.Resources.b1_2;
            itemAddBrand.ImageScaling = ToolStripItemImageScaling.None;
            itemAddBrand.Name = "itemAddBrand";
            itemAddBrand.Size = new Size(363, 32);
            itemAddBrand.Text = "Фирмы-производители устройств";
            itemAddBrand.Click += ItemAddBrand_Click;
            // 
            // itemAddDevice
            // 
            itemAddDevice.Image = Properties.Resources.main2;
            itemAddDevice.ImageScaling = ToolStripItemImageScaling.None;
            itemAddDevice.Name = "itemAddDevice";
            itemAddDevice.Size = new Size(363, 32);
            itemAddDevice.Text = "Типы устройств";
            itemAddDevice.Click += ItemAddDevice_Click;
            // 
            // itemClients
            // 
            itemClients.Image = Properties.Resources.men;
            itemClients.ImageScaling = ToolStripItemImageScaling.None;
            itemClients.Name = "itemClients";
            itemClients.Size = new Size(363, 32);
            itemClients.Text = "Справочник клиентов";
            itemClients.Click += ItemClients_Click;
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
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(360, 6);
            // 
            // itemCopyBD
            // 
            itemCopyBD.Image = Properties.Resources.main3_1;
            itemCopyBD.ImageScaling = ToolStripItemImageScaling.None;
            itemCopyBD.Name = "itemCopyBD";
            itemCopyBD.Size = new Size(363, 32);
            itemCopyBD.Text = "Сделать копию бд";
            itemCopyBD.Click += ItemCopyBD_Click;
            // 
            // itemUpdateService
            // 
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
            // itemOrg
            // 
            itemOrg.Image = Properties.Resources.b2_10;
            itemOrg.ImageScaling = ToolStripItemImageScaling.None;
            itemOrg.Name = "itemOrg";
            itemOrg.Size = new Size(363, 32);
            itemOrg.Text = "Сведения об организации";
            itemOrg.Click += ItemOrg_Click;
            // 
            // toolStripSeparator20
            // 
            toolStripSeparator20.Name = "toolStripSeparator20";
            toolStripSeparator20.Size = new Size(360, 6);
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
            // contextButton2
            // 
            contextButton2.ImageScalingSize = new Size(24, 24);
            contextButton2.Items.AddRange(new ToolStripItem[] { itemAddDeviceForRepair, itemFeaturesOrder, toolStripSeparator11, itemDetails, toolStripSeparator12, itemDeleteOrder, itemRecoveryOrder, toolStripSeparator13, itemActionsOrder, itemActionsClient, toolStripSeparator17, itemCreateOrder });
            contextButton2.Name = "contextMenuStripButton2";
            contextButton2.Size = new Size(407, 284);
            // 
            // itemAddDeviceForRepair
            // 
            itemAddDeviceForRepair.Image = Properties.Resources.b2_1;
            itemAddDeviceForRepair.ImageScaling = ToolStripItemImageScaling.None;
            itemAddDeviceForRepair.Name = "itemAddDeviceForRepair";
            itemAddDeviceForRepair.Size = new Size(406, 32);
            itemAddDeviceForRepair.Text = "Добавление аппарата";
            itemAddDeviceForRepair.Click += ItemAddDeviceForRepair_Click;
            // 
            // itemFeaturesOrder
            // 
            itemFeaturesOrder.Image = Properties.Resources.m1;
            itemFeaturesOrder.ImageScaling = ToolStripItemImageScaling.None;
            itemFeaturesOrder.Name = "itemFeaturesOrder";
            itemFeaturesOrder.Size = new Size(406, 32);
            itemFeaturesOrder.Text = "Свойства аппарата";
            itemFeaturesOrder.Click += ItemFeaturesOrder_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(403, 6);
            // 
            // itemDetails
            // 
            itemDetails.Image = Properties.Resources.m2;
            itemDetails.ImageScaling = ToolStripItemImageScaling.None;
            itemDetails.Name = "itemDetails";
            itemDetails.Size = new Size(406, 32);
            itemDetails.Text = "Детали на ремонт аппарата";
            itemDetails.Click += ItemDetails_Click;
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new Size(403, 6);
            // 
            // itemDeleteOrder
            // 
            itemDeleteOrder.Image = Properties.Resources.m3;
            itemDeleteOrder.ImageScaling = ToolStripItemImageScaling.None;
            itemDeleteOrder.Name = "itemDeleteOrder";
            itemDeleteOrder.Size = new Size(406, 32);
            itemDeleteOrder.Text = "Удаление аппарата";
            itemDeleteOrder.Click += ItemDeleteOrder_Click;
            // 
            // itemRecoveryOrder
            // 
            itemRecoveryOrder.Image = Properties.Resources.m4;
            itemRecoveryOrder.ImageScaling = ToolStripItemImageScaling.None;
            itemRecoveryOrder.Name = "itemRecoveryOrder";
            itemRecoveryOrder.Size = new Size(406, 32);
            itemRecoveryOrder.Text = "Восстановление аппарата из корзины";
            itemRecoveryOrder.Click += ItemRecoveryOrder_Click;
            // 
            // toolStripSeparator13
            // 
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new Size(403, 6);
            // 
            // itemActionsOrder
            // 
            itemActionsOrder.DropDownItems.AddRange(new ToolStripItem[] { itemOrderCompleted, itemOrderIssued, toolStripSeparator14, itemReturnToRevision, itemReturnUnderGuarantee });
            itemActionsOrder.Image = Properties.Resources.m5;
            itemActionsOrder.ImageScaling = ToolStripItemImageScaling.None;
            itemActionsOrder.Name = "itemActionsOrder";
            itemActionsOrder.Size = new Size(406, 32);
            itemActionsOrder.Text = "Операции над аппаратом";
            // 
            // itemOrderCompleted
            // 
            itemOrderCompleted.Image = Properties.Resources.m5_1;
            itemOrderCompleted.ImageScaling = ToolStripItemImageScaling.None;
            itemOrderCompleted.Name = "itemOrderCompleted";
            itemOrderCompleted.Size = new Size(473, 34);
            itemOrderCompleted.Text = "Пометить аппарат как отремонтированный";
            itemOrderCompleted.Click += ItemOrderCompleted_Click;
            // 
            // itemOrderIssued
            // 
            itemOrderIssued.Image = Properties.Resources.m5_2;
            itemOrderIssued.ImageScaling = ToolStripItemImageScaling.None;
            itemOrderIssued.Name = "itemOrderIssued";
            itemOrderIssued.Size = new Size(473, 34);
            itemOrderIssued.Text = "Выдать аппарат клиенту";
            itemOrderIssued.Click += ItemOrderIssued_Click;
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new Size(470, 6);
            // 
            // itemReturnToRevision
            // 
            itemReturnToRevision.Image = Properties.Resources.m5_3;
            itemReturnToRevision.ImageScaling = ToolStripItemImageScaling.None;
            itemReturnToRevision.Name = "itemReturnToRevision";
            itemReturnToRevision.Size = new Size(473, 34);
            itemReturnToRevision.Text = "Возврат аппарата в доработку";
            itemReturnToRevision.Click += ItemReturnToRevision_Click;
            // 
            // itemReturnUnderGuarantee
            // 
            itemReturnUnderGuarantee.Image = Properties.Resources.m5_4;
            itemReturnUnderGuarantee.ImageScaling = ToolStripItemImageScaling.None;
            itemReturnUnderGuarantee.Name = "itemReturnUnderGuarantee";
            itemReturnUnderGuarantee.Size = new Size(473, 34);
            itemReturnUnderGuarantee.Text = "Возврат аппарата по гарантии";
            itemReturnUnderGuarantee.Click += ItemReturnUnderGuarantee_Click;
            // 
            // itemActionsClient
            // 
            itemActionsClient.DropDownItems.AddRange(new ToolStripItem[] { itemFeaturesClient, toolStripSeparator15, itemMessageToClient, toolStripSeparator16, itemPriorityClient });
            itemActionsClient.Image = Properties.Resources.m6;
            itemActionsClient.ImageScaling = ToolStripItemImageScaling.None;
            itemActionsClient.Name = "itemActionsClient";
            itemActionsClient.Size = new Size(406, 32);
            itemActionsClient.Text = "Операции над клиентом";
            // 
            // itemFeaturesClient
            // 
            itemFeaturesClient.Image = Properties.Resources.m6_1;
            itemFeaturesClient.ImageScaling = ToolStripItemImageScaling.None;
            itemFeaturesClient.Name = "itemFeaturesClient";
            itemFeaturesClient.Size = new Size(278, 34);
            itemFeaturesClient.Text = "Свойства клиента";
            itemFeaturesClient.Click += ItemFeaturesClient_Click;
            // 
            // toolStripSeparator15
            // 
            toolStripSeparator15.Name = "toolStripSeparator15";
            toolStripSeparator15.Size = new Size(275, 6);
            // 
            // itemMessageToClient
            // 
            itemMessageToClient.Image = Properties.Resources.m6_2;
            itemMessageToClient.ImageScaling = ToolStripItemImageScaling.None;
            itemMessageToClient.Name = "itemMessageToClient";
            itemMessageToClient.Size = new Size(278, 34);
            itemMessageToClient.Text = "Сообщение клиенту";
            itemMessageToClient.Click += ItemMessageToClient_Click;
            // 
            // toolStripSeparator16
            // 
            toolStripSeparator16.Name = "toolStripSeparator16";
            toolStripSeparator16.Size = new Size(275, 6);
            // 
            // itemPriorityClient
            // 
            itemPriorityClient.DropDownItems.AddRange(new ToolStripItem[] { itemAddToWhitelist, itemAddToBlacklist, itemRemoveMarks });
            itemPriorityClient.Image = Properties.Resources.m6_3;
            itemPriorityClient.ImageScaling = ToolStripItemImageScaling.None;
            itemPriorityClient.Name = "itemPriorityClient";
            itemPriorityClient.Size = new Size(278, 34);
            itemPriorityClient.Text = "Приоритет клиента";
            // 
            // itemAddToWhitelist
            // 
            itemAddToWhitelist.Image = Properties.Resources.m6_3_1;
            itemAddToWhitelist.ImageScaling = ToolStripItemImageScaling.None;
            itemAddToWhitelist.Name = "itemAddToWhitelist";
            itemAddToWhitelist.Size = new Size(406, 34);
            itemAddToWhitelist.Text = "Добавить клиента в \"белый список\"";
            itemAddToWhitelist.Click += ItemAddToWhitelist_Click;
            // 
            // itemAddToBlacklist
            // 
            itemAddToBlacklist.Image = Properties.Resources.m6_3_2;
            itemAddToBlacklist.ImageScaling = ToolStripItemImageScaling.None;
            itemAddToBlacklist.Name = "itemAddToBlacklist";
            itemAddToBlacklist.Size = new Size(406, 34);
            itemAddToBlacklist.Text = "Добавить в \"черный список\"";
            itemAddToBlacklist.Click += ItemAddToBlacklist_Click;
            // 
            // itemRemoveMarks
            // 
            itemRemoveMarks.Image = Properties.Resources.m6_1;
            itemRemoveMarks.ImageScaling = ToolStripItemImageScaling.None;
            itemRemoveMarks.Name = "itemRemoveMarks";
            itemRemoveMarks.Size = new Size(406, 34);
            itemRemoveMarks.Text = "Снять все метки с клиента";
            itemRemoveMarks.Click += ItemRemoveMarks_Click;
            // 
            // toolStripSeparator17
            // 
            toolStripSeparator17.Name = "toolStripSeparator17";
            toolStripSeparator17.Size = new Size(403, 6);
            // 
            // itemCreateOrder
            // 
            itemCreateOrder.Image = Properties.Resources.b2_8;
            itemCreateOrder.ImageScaling = ToolStripItemImageScaling.None;
            itemCreateOrder.Name = "itemCreateOrder";
            itemCreateOrder.Size = new Size(406, 32);
            itemCreateOrder.Text = "Создать квитанцию на основе текущей";
            itemCreateOrder.Click += ItemSearchOrder_Click;
            // 
            // labelWorkData
            // 
            labelWorkData.BackColor = SystemColors.Control;
            labelWorkData.Location = new Point(144, 9);
            labelWorkData.Name = "labelWorkData";
            labelWorkData.Size = new Size(168, 34);
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
            labelDocuments.Location = new Point(312, 9);
            labelDocuments.Name = "labelDocuments";
            labelDocuments.Size = new Size(120, 34);
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
            labelReports.Location = new Point(432, 9);
            labelReports.Name = "labelReports";
            labelReports.Size = new Size(88, 34);
            labelReports.TabIndex = 23;
            labelReports.Text = "Отчеты";
            labelReports.TextAlign = ContentAlignment.MiddleCenter;
            labelReports.Click += LabelReports_Click;
            labelReports.MouseEnter += LabelReports_MouseEnter;
            labelReports.MouseLeave += LabelReports_MouseLeave;
            // 
            // contextButton3
            // 
            contextButton3.ImageScalingSize = new Size(24, 24);
            contextButton3.Items.AddRange(new ToolStripItem[] { itemGetting, itemIssuing });
            contextButton3.Name = "contextMenuStripButton3";
            contextButton3.Size = new Size(361, 68);
            // 
            // itemGetting
            // 
            itemGetting.Name = "itemGetting";
            itemGetting.Size = new Size(360, 32);
            itemGetting.Text = "Квитанция о получении в ремонт";
            itemGetting.Click += ItemGetting_Click;
            // 
            // itemIssuing
            // 
            itemIssuing.Name = "itemIssuing";
            itemIssuing.Size = new Size(360, 32);
            itemIssuing.Text = "Квитанция о выдачи аппарата";
            itemIssuing.Click += ItemIssuing_Click;
            // 
            // contextButton4
            // 
            contextButton4.ImageScalingSize = new Size(24, 24);
            contextButton4.Items.AddRange(new ToolStripItem[] { itemSalary });
            contextButton4.Name = "contextButton4";
            contextButton4.Size = new Size(219, 36);
            // 
            // itemSalary
            // 
            itemSalary.Name = "itemSalary";
            itemSalary.Size = new Size(218, 32);
            itemSalary.Text = "Расчет зарплаты";
            itemSalary.Click += ItemSalary_Click;
            // 
            // buttonAccepted
            // 
            buttonAccepted.BackgroundImage = Properties.Resources.p0;
            buttonAccepted.BackgroundImageLayout = ImageLayout.Stretch;
            buttonAccepted.Location = new Point(1218, 12);
            buttonAccepted.Name = "buttonAccepted";
            buttonAccepted.Size = new Size(110, 120);
            buttonAccepted.TabIndex = 0;
            buttonAccepted.Text = "Принятые";
            buttonAccepted.TextAlign = ContentAlignment.BottomCenter;
            buttonAccepted.UseVisualStyleBackColor = true;
            buttonAccepted.Click += ButtonAccepted_Click;
            // 
            // textBoxIdOrder
            // 
            textBoxIdOrder.Location = new Point(168, 786);
            textBoxIdOrder.Name = "textBoxIdOrder";
            textBoxIdOrder.Size = new Size(148, 31);
            textBoxIdOrder.TabIndex = 25;
            textBoxIdOrder.TextChanged += TextBoxIdOrder_TextChanged;
            // 
            // labelIdOrder
            // 
            labelIdOrder.Location = new Point(2, 786);
            labelIdOrder.Name = "labelIdOrder";
            labelIdOrder.Size = new Size(160, 31);
            labelIdOrder.TabIndex = 26;
            labelIdOrder.Text = "Номер квитанции";
            labelIdOrder.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelDateCreation
            // 
            labelDateCreation.Location = new Point(2, 833);
            labelDateCreation.Name = "labelDateCreation";
            labelDateCreation.Size = new Size(160, 32);
            labelDateCreation.TabIndex = 27;
            labelDateCreation.Text = "Дата приема";
            labelDateCreation.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxDateCreation
            // 
            textBoxDateCreation.Location = new Point(168, 834);
            textBoxDateCreation.Name = "textBoxDateCreation";
            textBoxDateCreation.Size = new Size(148, 31);
            textBoxDateCreation.TabIndex = 28;
            textBoxDateCreation.TextChanged += TextBoxDateCreation_TextChanged;
            // 
            // labelDateStartWork
            // 
            labelDateStartWork.Font = new Font("Segoe UI", 9F);
            labelDateStartWork.Location = new Point(322, 786);
            labelDateStartWork.Name = "labelDateStartWork";
            labelDateStartWork.Size = new Size(177, 31);
            labelDateStartWork.TabIndex = 29;
            labelDateStartWork.Text = "Дата начала работы";
            labelDateStartWork.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelNameMaster
            // 
            labelNameMaster.Location = new Point(322, 837);
            labelNameMaster.Name = "labelNameMaster";
            labelNameMaster.Size = new Size(177, 25);
            labelNameMaster.TabIndex = 30;
            labelNameMaster.Text = "Мастер";
            labelNameMaster.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxDateStartWork
            // 
            textBoxDateStartWork.Location = new Point(505, 786);
            textBoxDateStartWork.Name = "textBoxDateStartWork";
            textBoxDateStartWork.Size = new Size(150, 31);
            textBoxDateStartWork.TabIndex = 31;
            textBoxDateStartWork.TextChanged += TextBoxDateStartWork_TextChanged;
            // 
            // labelTypeDevice
            // 
            labelTypeDevice.Location = new Point(664, 786);
            labelTypeDevice.Name = "labelTypeDevice";
            labelTypeDevice.Size = new Size(140, 31);
            labelTypeDevice.TabIndex = 32;
            labelTypeDevice.Text = "Тип аппарата";
            labelTypeDevice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelBrandDevice
            // 
            labelBrandDevice.Location = new Point(664, 833);
            labelBrandDevice.Name = "labelBrandDevice";
            labelBrandDevice.Size = new Size(140, 32);
            labelBrandDevice.TabIndex = 33;
            labelBrandDevice.Text = "Производитель";
            labelBrandDevice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelModel
            // 
            labelModel.Location = new Point(967, 786);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(86, 31);
            labelModel.TabIndex = 34;
            labelModel.Text = "Модель";
            labelModel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelNameClient
            // 
            labelNameClient.Location = new Point(967, 833);
            labelNameClient.Name = "labelNameClient";
            labelNameClient.Size = new Size(86, 32);
            labelNameClient.TabIndex = 35;
            labelNameClient.Text = "Заказчик";
            labelNameClient.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxNameMaster
            // 
            textBoxNameMaster.Location = new Point(505, 834);
            textBoxNameMaster.Name = "textBoxNameMaster";
            textBoxNameMaster.Size = new Size(150, 31);
            textBoxNameMaster.TabIndex = 36;
            textBoxNameMaster.TextChanged += TextBoxNameMaster_TextChanged;
            // 
            // textBoxTypeDevice
            // 
            textBoxTypeDevice.Location = new Point(810, 786);
            textBoxTypeDevice.Name = "textBoxTypeDevice";
            textBoxTypeDevice.Size = new Size(150, 31);
            textBoxTypeDevice.TabIndex = 37;
            textBoxTypeDevice.TextChanged += TextBoxTypeDevice_TextChanged;
            // 
            // textBoxBrandDevice
            // 
            textBoxBrandDevice.Location = new Point(810, 834);
            textBoxBrandDevice.Name = "textBoxBrandDevice";
            textBoxBrandDevice.Size = new Size(150, 31);
            textBoxBrandDevice.TabIndex = 38;
            textBoxBrandDevice.TextChanged += TextBoxBrandDevice_TextChanged;
            // 
            // textBoxModel
            // 
            textBoxModel.Location = new Point(1057, 786);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.Size = new Size(150, 31);
            textBoxModel.TabIndex = 39;
            textBoxModel.TextChanged += TextBoxModel_TextChanged;
            // 
            // textBoxNameClient
            // 
            textBoxNameClient.Location = new Point(1057, 833);
            textBoxNameClient.Name = "textBoxNameClient";
            textBoxNameClient.Size = new Size(150, 31);
            textBoxNameClient.TabIndex = 40;
            textBoxNameClient.TextChanged += TextBoxNameClient_TextChanged;
            // 
            // labelView
            // 
            labelView.BackColor = SystemColors.Control;
            labelView.Font = new Font("Segoe UI", 9F);
            labelView.Location = new Point(520, 9);
            labelView.Name = "labelView";
            labelView.Size = new Size(88, 34);
            labelView.TabIndex = 41;
            labelView.Text = "Вид";
            labelView.TextAlign = ContentAlignment.MiddleCenter;
            labelView.Click += LabelView_Click;
            labelView.MouseEnter += LabelView_MouseEnter;
            labelView.MouseLeave += LabelView_MouseLeave;
            // 
            // contextButton5
            // 
            contextButton5.ImageScalingSize = new Size(24, 24);
            contextButton5.Items.AddRange(new ToolStripItem[] { itemColor, itemSize });
            contextButton5.Name = "contextButton5";
            contextButton5.Size = new Size(189, 68);
            // 
            // itemColor
            // 
            itemColor.Name = "itemColor";
            itemColor.Size = new Size(188, 32);
            itemColor.Text = "Цвета";
            itemColor.Click += ItemColor_Click;
            // 
            // itemSize
            // 
            itemSize.DropDownItems.AddRange(new ToolStripItem[] { itemSmall, itemMedium });
            itemSize.Name = "itemSize";
            itemSize.Size = new Size(188, 32);
            itemSize.Text = "Размер окна";
            // 
            // itemSmall
            // 
            itemSmall.Name = "itemSmall";
            itemSmall.Size = new Size(205, 34);
            itemSmall.Text = "Маленький";
            itemSmall.Click += ItemSmall_Click;
            // 
            // itemMedium
            // 
            itemMedium.Name = "itemMedium";
            itemMedium.Size = new Size(205, 34);
            itemMedium.Text = "Средний";
            itemMedium.Click += ItemMedium_Click;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = SystemColors.Control;
            buttonReset.Location = new Point(1218, 785);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(110, 79);
            buttonReset.TabIndex = 42;
            buttonReset.Text = "Сброс фильтров";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += ButtonReset_Click;
            // 
            // contextPhone
            // 
            contextPhone.ImageScalingSize = new Size(24, 24);
            contextPhone.Items.AddRange(new ToolStripItem[] { numberPhone });
            contextPhone.Name = "contextPhone";
            contextPhone.Size = new Size(132, 42);
            // 
            // numberPhone
            // 
            numberPhone.Font = new Font("Segoe UI", 12F);
            numberPhone.Name = "numberPhone";
            numberPhone.Size = new Size(131, 38);
            numberPhone.Text = "One";
            // 
            // buttonAddDevice
            // 
            buttonAddDevice.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonAddDevice.Image = Properties.Resources.b2_1;
            buttonAddDevice.ImageScaling = ToolStripItemImageScaling.None;
            buttonAddDevice.ImageTransparentColor = Color.Magenta;
            buttonAddDevice.Name = "buttonAddDevice";
            buttonAddDevice.Size = new Size(34, 23);
            buttonAddDevice.Text = "Добавление аппарата";
            buttonAddDevice.Click += ButtonAddDevice_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1337, 879);
            Controls.Add(buttonAccepted);
            Controls.Add(buttonReset);
            Controls.Add(labelView);
            Controls.Add(textBoxNameClient);
            Controls.Add(textBoxModel);
            Controls.Add(textBoxBrandDevice);
            Controls.Add(textBoxTypeDevice);
            Controls.Add(textBoxNameMaster);
            Controls.Add(labelNameClient);
            Controls.Add(labelModel);
            Controls.Add(labelBrandDevice);
            Controls.Add(labelTypeDevice);
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
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DesktopAppDB";
            FormClosing += Form1_FormClosing;
            SizeChanged += Form1_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenu1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            contextButton1.ResumeLayout(false);
            contextButton2.ResumeLayout(false);
            contextButton3.ResumeLayout(false);
            contextButton4.ResumeLayout(false);
            contextButton5.ResumeLayout(false);
            contextPhone.ResumeLayout(false);
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
        private ContextMenuStrip contextMenu1;
        private ToolStripMenuItem item1;
        private ToolStripMenuItem item2;
        private ToolStripMenuItem item3;
        private ToolStripMenuItem item4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem item5;
        private ToolStripMenuItem item6;
        private ToolStripMenuItem item5_1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem item5_2;
        private ToolStripMenuItem item5_3;
        private ToolStripMenuItem item5_4;
        private ToolStripMenuItem item6_1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem item6_2;
        private ToolStripMenuItem item6_3;
        private ToolStripMenuItem item6_3_1;
        private ToolStripMenuItem item6_3_2;
        private ToolStripMenuItem item6_3_3;
        private ToolStrip toolStrip1;
        private ToolStripButton buttonMasters;
        private ToolStripButton buttonDevice;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton buttonSettings;
        private ToolStripButton buttonPrinter;
        private ToolStripButton buttonExit;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton buttonDetails;
        private ToolStripButton buttonDelete;
        private ToolStripButton buttonRecoveryOrder;
        private ToolStripButton buttonCompletedTag;
        private ToolStripButton buttonIssue;
        private ToolStripButton buttonReturnInRepair;
        private ToolStripButton buttonReturnGuarantee;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton buttonFeaturesOrder;
        private ToolStripButton buttonFeaturesClient;
        private ToolStripSeparator toolStripSeparator8;
        private Label labelDataBase;
        private ContextMenuStrip contextButton1;
        private ToolStripMenuItem itemAddMasters;
        private ContextMenuStrip contextButton2;
        private ToolStripMenuItem itemAddDeviceForRepair;
        private Label labelWorkData;
        private Label labelDocuments;
        private Label labelReports;
        private ContextMenuStrip contextButton3;
        private ToolStripMenuItem itemAddBrand;
        private ToolStripMenuItem itemAddDevice;
        private ToolStripMenuItem itemClients;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem itemCopyBD;
        private ToolStripMenuItem itemPrinter;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem itemExit;
        private ToolStripMenuItem itemFeaturesOrder;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem itemDetails;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem itemDeleteOrder;
        private ToolStripMenuItem itemRecoveryOrder;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem itemActionsClient;
        private ToolStripMenuItem itemActionsOrder;
        private ToolStripMenuItem itemOrderCompleted;
        private ToolStripMenuItem itemOrderIssued;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem itemReturnToRevision;
        private ToolStripMenuItem itemReturnUnderGuarantee;
        private ToolStripMenuItem itemFeaturesClient;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem itemMessageToClient;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem itemPriorityClient;
        private ToolStripMenuItem itemAddToWhitelist;
        private ToolStripMenuItem itemAddToBlacklist;
        private ToolStripMenuItem itemRemoveMarks;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripMenuItem itemCreateOrder;
        private ContextMenuStrip contextButton4;
        private ToolStripMenuItem itemSalary;
        private ToolStripMenuItem itemGetting;
        private ToolStripMenuItem itemIssuing;
        private ToolStripMenuItem itemUpdateService;
        private Button buttonAccepted;
        private TextBox textBoxIdOrder;
        private Label labelIdOrder;
        private Label labelDateCreation;
        private TextBox textBoxDateCreation;
        private Label labelDateStartWork;
        private Label labelNameMaster;
        private TextBox textBoxDateStartWork;
        private Label labelTypeDevice;
        private Label labelBrandDevice;
        private Label labelModel;
        private Label labelNameClient;
        private TextBox textBoxNameMaster;
        private TextBox textBoxTypeDevice;
        private TextBox textBoxBrandDevice;
        private TextBox textBoxModel;
        private TextBox textBoxNameClient;
        private Label labelView;
        private ContextMenuStrip contextButton5;
        private ToolStripMenuItem itemColor;
        private Button buttonReset;
        private ToolStripMenuItem itemSize;
        private ToolStripMenuItem itemSmall;
        private ToolStripMenuItem itemMedium;
        private ToolStripMenuItem itemPathDB;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripMenuItem item7;
        private ToolStripMenuItem itemWarehouse;
        private ContextMenuStrip contextPhone;
        private ToolStripMenuItem numberPhone;
        private ToolStripMenuItem itemOrg;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripButton buttonAddDevice;
    }
}
