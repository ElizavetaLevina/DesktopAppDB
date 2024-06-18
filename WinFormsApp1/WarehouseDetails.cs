using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class WarehouseDetails : Form
    {
        public int idDetail = 0;
        public string? brandDevice;
        public bool newDetail;
        List<WarehouseTableDTO> list;
        WarehouseRepository warehouseRepository = new();
        public WarehouseDetails(bool _newDetail, string? _brandDevice = null)
        {
            InitializeComponent();
            brandDevice = _brandDevice;
            newDetail = _newDetail;
            if (newDetail)
                list = warehouseRepository.GetWarehousesForTable(availability: true, datePurchase: true);
            else
            {
                textBoxDevice.Visible = true;
                textBoxDevice.Text = brandDevice;
                list = warehouseRepository.GetWarehousesForTable(availability: true, datePurchase: true, name: brandDevice);
            }
            dataGridView1.DataSource = Funcs.ToDataTable(list);
            UpdateTable();
        }

        private void UpdateTable()
        {
            try
            {
                int[] percent = [10, 40, 17, 17, 16, 0, 0];

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Id"].HeaderText = "№";
                dataGridView1.Columns["NameDetail"].HeaderText = "Название детали";
                dataGridView1.Columns["PricePurchase"].HeaderText = "Цена покупки";
                dataGridView1.Columns["PriceSale"].HeaderText = "Цена продажи";
                dataGridView1.Columns["DatePurchase"].HeaderText = "Дата покупки";
                dataGridView1.Columns["Availability"].Visible = false;
                dataGridView1.Columns["IdOrder"].Visible = false;

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                    dataGridView1.Columns[i].Width = Convert.ToInt32(width);
                }

                if (dataGridView1.RowCount > 0)
                {
                    buttonDeleteDetail.Enabled = true;
                    buttonAdd.Enabled = true;
                }
                else
                {
                    buttonDeleteDetail.Enabled = false;
                    buttonAdd.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAddDetails_Click(object sender, EventArgs e)
        {
            AddDetailToWarehouse addDetail = new(false, 0)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addDetail.ShowDialog();
            list = warehouseRepository.GetWarehousesForTable(availability: true, datePurchase: true);
            dataGridView1.DataSource = Funcs.ToDataTable(list);
            UpdateTable();
        }

        private void ButtonDeleteDetail_Click(object sender, EventArgs e)
        {
            int numberRow = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelText = "Вы действительно хотите удалить деталь со склада?",
                ButtonNoText = "Нет",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
            {
                var warehouseDTO = new WarehouseEditDTO() { Id = id };
                warehouseRepository.RemoveWarehouse(warehouseDTO);
                UpdateTable();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            int numberRow = dataGridView1.CurrentCell.RowIndex;
            idDetail = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TextBoxDevice_TextChanged(object sender, EventArgs e)
        {
            list = warehouseRepository.GetWarehousesForTable(availability: true, datePurchase: true, name: textBoxDevice.Text);
            dataGridView1.DataSource = Funcs.ToDataTable(list);
            if (dataGridView1.RowCount > 0)
            {
                buttonDeleteDetail.Enabled = true;
                buttonAdd.Enabled = true;
            }
            else
            {
                buttonDeleteDetail.Enabled = false;
                buttonAdd.Enabled = false;
            }
        }

        private void ButtonChangeDetail_Click(object sender, EventArgs e)
        {
            int numberRow = dataGridView1.CurrentCell.RowIndex;
            int idDetail = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
            List<WarehouseDTO> listChangeDetail = warehouseRepository.GetWarehouses(id: idDetail);

            AddDetailToWarehouse addDetail = new(true, idDetail)
            {
                StartPosition = FormStartPosition.CenterParent,
                NameDetail = listChangeDetail[0].NameDetail,
                PricePurchase = listChangeDetail[0].PricePurchase,
                PriceSale = listChangeDetail[0].PriceSale,
                DatePurchase = listChangeDetail[0].DatePurchase
            };
            addDetail.ShowDialog();
            list = warehouseRepository.GetWarehousesForTable(availability: true, datePurchase: true);
            dataGridView1.DataSource = Funcs.ToDataTable(list);
            UpdateTable();
        }

        public bool VisibleBtnAdd
        {
            get { return buttonAdd.Visible; }
            set { buttonAdd.Visible = value; }
        }
    }
}
