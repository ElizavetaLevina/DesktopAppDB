using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class DetailsInOrder : Form
    {
        public int idOrder;
        List<WarehouseTableDTO> list;
        WarehouseRepository warehouseRepository = new();
        OrderRepository orderRepository = new();
        public DetailsInOrder(int id)
        {
            InitializeComponent();
            idOrder = id;
            UpdateTable();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonAddDetail_Click(object sender, EventArgs e)
        {
            var order = orderRepository.GetOrder(id: idOrder);

            DetailsInWarehouse details = new(false, order.BrandTechnic?.NameBrandTechnic)
            {
                StartPosition = FormStartPosition.CenterParent,
                VisibleBtnAdd = true
            };

            if (details.ShowDialog() == DialogResult.OK)
            {
                var warehouse = warehouseRepository.GetWarehouse(id: details.idDetail);
                warehouse.Availability = false;
                warehouse.IdOrder = idOrder;

                var task = Task.Run(async () => 
                {
                    await warehouseRepository.SaveWarehouseAsync(warehouse);
                });
                task.Wait();
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            int summDetails = 0;
            int[] percent = [0, 70, 0, 30, 0, 0, 0];

            list = warehouseRepository.GetWarehousesForTable(idOrder: idOrder);
            dataGridView1.DataSource = Funcs.ToDataTable(list);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["NameDetail"].HeaderText = "Название детали";
            dataGridView1.Columns["PricePurchase"].Visible = false;
            dataGridView1.Columns["PriceSale"].HeaderText = "Цена";
            dataGridView1.Columns["DatePurchase"].Visible = false;
            dataGridView1.Columns["Availability"].Visible = false;
            dataGridView1.Columns["IdOrder"].Visible = false;

            foreach(var detail in list)
            {
                summDetails += detail.PriceSale;
            }

            labelCount.Text = String.Format("{0} шт.", list.Count);
            labelPrice.Text = String.Format("{0} руб.", summDetails);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }
        }

        private void ButtonChangeDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int idDetail = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var warehouse = warehouseRepository.GetWarehouse(id: idDetail);

                DetailEdit changeDetail = new(true, idDetail)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Изменение данных",
                    NameDetail = warehouse.NameDetail,
                    PricePurchase = warehouse.PricePurchase,
                    PriceSale = warehouse.PriceSale,
                    DatePurchase = warehouse.DatePurchase
                };
     
                if (changeDetail.ShowDialog() == DialogResult.OK)
                {
                    warehouse.NameDetail = changeDetail.NameDetail;
                    warehouse.PricePurchase = changeDetail.PricePurchase;
                    warehouse.PriceSale = changeDetail.PriceSale;
                    warehouse.DatePurchase = changeDetail.DatePurchase;

                    var task = Task.Run(async () =>
                    {
                        await warehouseRepository.SaveWarehouseAsync(warehouse);
                    });
                    task.Wait();
                    UpdateTable();
                }
            }
        }

        private void ButtonRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Warning warning = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    LabelText = "Вы действительно хотите удалить деталь из заказа?",
                    ButtonNoText = "Нет",
                    ButtonVisible = true
                };

                if (warning.ShowDialog() == DialogResult.OK)
                {
                    int numberRow = dataGridView1.CurrentCell.RowIndex;
                    int idDetail = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                    var warehouse = warehouseRepository.GetWarehouse(id: idDetail);
                    warehouse.Availability = true;
                    warehouse.IdOrder = null;

                    var task = Task.Run(async () =>
                    {
                        await warehouseRepository.SaveWarehouseAsync(warehouse);
                    });
                    task.Wait();
                    UpdateTable();
                }
            }
        }
    }
}
