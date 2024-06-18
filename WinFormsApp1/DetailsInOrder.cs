using WinFormsApp1.DTO;
using WinFormsApp1.Model;
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
            list = warehouseRepository.GetWarehousesForTable(idOrder: idOrder);
            dataGridView1.DataSource = Funcs.ToDataTable(list);
            UpdateTable();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonAddDetail_Click(object sender, EventArgs e)
        {
            var listOrder = orderRepository.GetOrders(id: idOrder);

            WarehouseDetails details = new(false, listOrder[0].BrandTechnic?.NameBrandTechnic)
            {
                StartPosition = FormStartPosition.CenterParent,
                VisibleBtnAdd = true
            };

            if (details.ShowDialog() == DialogResult.OK)
            {
                var detail = warehouseRepository.GetWarehouses(id: details.idDetail);
                var warehouseDTO = new WarehouseEditDTO()
                {
                    Id = details.idDetail,
                    NameDetail = detail[0].NameDetail,
                    PricePurchase = detail[0].PricePurchase,
                    PriceSale = detail[0].PriceSale,
                    DatePurchase = detail[0].DatePurchase,
                    Availability = false,
                    IdOrder = idOrder
                };

                var task = Task.Run(async () => 
                {
                    await warehouseRepository.SaveWarehouseAsync(warehouseDTO);
                });
                task.Wait();
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            int summDetails = 0;
            int[] percent = [0, 70, 0, 30, 0, 0, 0];

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["NameDetail"].HeaderText = "Название детали";
            dataGridView1.Columns["PricePurchase"].Visible = false;
            dataGridView1.Columns["PriceSale"].HeaderText = "Цена";
            dataGridView1.Columns["DatePurchase"].Visible = false;
            dataGridView1.Columns["Availability"].Visible = false;
            dataGridView1.Columns["IdOrder"].Visible = false;


            for(int i = 0; i < list.Count; i++)
            {
                summDetails += list[i].PriceSale;
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
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int idDetail = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var detail = warehouseRepository.GetWarehouses(id: idDetail);

                AddDetailToWarehouse changeDetail = new(true, idDetail)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Изменение данных",
                    NameDetail = detail[0].NameDetail,
                    PricePurchase = detail[0].PricePurchase,
                    PriceSale = detail[0].PriceSale,
                    DatePurchase = detail[0].DatePurchase
                };
     
                if (changeDetail.ShowDialog() == DialogResult.OK)
                {
                    var warehouseDTO = new WarehouseEditDTO()
                    {
                        Id = idDetail,
                        NameDetail = changeDetail.NameDetail,
                        PricePurchase = changeDetail.PricePurchase,
                        PriceSale = changeDetail.PriceSale,
                        DatePurchase = changeDetail.DatePurchase,
                        Availability = detail[0].Availability,
                        IdOrder = detail[0].IdOrder
                    };

                    var task = Task.Run(async () =>
                    {
                        await warehouseRepository.SaveWarehouseAsync(warehouseDTO);
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
                    var detail = warehouseRepository.GetWarehouses(id: idDetail);
                    var warehouseDTO = new WarehouseEditDTO()
                    {
                        Id = idDetail,
                        NameDetail = detail[0].NameDetail,
                        PricePurchase = detail[0].PricePurchase,
                        PriceSale = detail[0].PriceSale,
                        DatePurchase = detail[0].DatePurchase,
                        Availability = true,
                        IdOrder = null
                    };

                    var task = Task.Run(async () =>
                    {
                        await warehouseRepository.SaveWarehouseAsync(warehouseDTO);
                    });
                    task.Wait();
                    UpdateTable();
                }
            }
        }
    }
}
