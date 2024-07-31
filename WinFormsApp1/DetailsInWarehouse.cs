using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class DetailsInWarehouse : Form
    {
        public int idDetail = 0;
        public string? brandDevice;
        public bool newDetail;
        List<WarehouseTableDTO> list;
        WarehouseRepository warehouseRepository = new();
        public DetailsInWarehouse(bool _newDetail, string? _brandDevice = null)
        {
            InitializeComponent();
            brandDevice = _brandDevice;
            newDetail = _newDetail;
            UpdateTable();
        }

        private void UpdateTable()
        {
            try
            {
                if (newDetail)
                    list = warehouseRepository.GetWarehousesForTable(availability: true, datePurchase: true);
                else
                {
                    textBoxDevice.Visible = true;
                    textBoxDevice.Text = brandDevice;
                    list = warehouseRepository.GetWarehousesForTable(availability: true, datePurchase: true, name: brandDevice);
                }
                dataGridView1.DataSource = Funcs.ToDataTable(list);

                int[] percent = [10, 40, 17, 17, 16, 0, 0];

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[nameof(WarehouseTableDTO.Id)].HeaderText = "№";
                dataGridView1.Columns[nameof(WarehouseTableDTO.NameDetail)].HeaderText = "Название детали";
                dataGridView1.Columns[nameof(WarehouseTableDTO.PricePurchase)].HeaderText = "Цена покупки";
                dataGridView1.Columns[nameof(WarehouseTableDTO.PriceSale)].HeaderText = "Цена продажи";
                dataGridView1.Columns[nameof(WarehouseTableDTO.DatePurchase)].HeaderText = "Дата покупки";
                dataGridView1.Columns[nameof(WarehouseTableDTO.Availability)].Visible = false;
                dataGridView1.Columns[nameof(WarehouseTableDTO.IdOrder)].Visible = false;

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                    dataGridView1.Columns[i].Width = Convert.ToInt32(width);
                }

                if (dataGridView1.RowCount > 0)
                {
                    buttonDeleteDetail.Enabled = true;
                    buttonAdd.Enabled = true;
                    buttonChangeDetail.Enabled = true;
                }
                else
                {
                    buttonDeleteDetail.Enabled = false;
                    buttonAdd.Enabled = false;
                    buttonChangeDetail.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAddDetails_Click(object sender, EventArgs e)
        {
            DetailEdit addDetail = new(false)
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
            int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[nameof(WarehouseTableDTO.Id)].Value);
            Warning warning = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                LabelText = "Вы действительно хотите удалить деталь со склада?",
                ButtonNoText = "Нет",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
            {
                var warehouseDTO = warehouseRepository.GetWarehouse(id);
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
            idDetail = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[nameof(WarehouseTableDTO.Id)].Value);
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
                buttonChangeDetail.Enabled = true;
            }
            else
            {
                buttonDeleteDetail.Enabled = false;
                buttonAdd.Enabled = false;
                buttonChangeDetail.Enabled = false;
            }
        }

        private void ButtonChangeDetail_Click(object sender, EventArgs e)
        {
            int numberRow = dataGridView1.CurrentCell.RowIndex;
            int idDetail = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[nameof(WarehouseTableDTO.Id)].Value);
            var warehouse = warehouseRepository.GetWarehouse(id: idDetail);

            DetailEdit addDetail = new(true, idDetail)
            {
                StartPosition = FormStartPosition.CenterParent,
                NameDetail = warehouse.NameDetail,
                PricePurchase = warehouse.PricePurchase,
                PriceSale = warehouse.PriceSale,
                DatePurchase = warehouse.DatePurchase
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
