using WinFormsApp1.DTO;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class DetailsInOrder : Form
    {
        public int idOrder;
        public int IdDetail { get { return Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
            Cells[nameof(WarehouseTableDTO.Id)].Value); } }
        List<WarehouseTableDTO> list;
        WarehousesLogic warehousesLogic = new();
        OrdersLogic ordersLogic = new();
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
            DetailsInWarehouse details = new(false, ordersLogic.GetOrder(idOrder).BrandTechnic?.Name)
            {
                StartPosition = FormStartPosition.CenterParent,
                VisibleBtnAdd = true
            };

            if (details.ShowDialog() == DialogResult.OK)
            {
                var warehouseDTO = warehousesLogic.GetWarehouse(id: details.IdDetail);
                warehouseDTO.Availability = false;
                warehouseDTO.IdOrder = idOrder;
                warehousesLogic.SaveDetail(warehouseDTO);
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            int[] percent = [0, 70, 0, 30, 0, 0, 0];

            list = warehousesLogic.GetWarehousesForTable(idOrder: idOrder);
            dataGridView1.DataSource = Funcs.ToDataTable(list);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[nameof(WarehouseTableDTO.Id)].Visible = false;
            dataGridView1.Columns[nameof(WarehouseTableDTO.NameDetail)].HeaderText = "Название детали";
            dataGridView1.Columns[nameof(WarehouseTableDTO.PricePurchase)].Visible = false;
            dataGridView1.Columns[nameof(WarehouseTableDTO.PriceSale)].HeaderText = "Цена";
            dataGridView1.Columns[nameof(WarehouseTableDTO.DatePurchase)].Visible = false;
            dataGridView1.Columns[nameof(WarehouseTableDTO.Availability)].Visible = false;
            dataGridView1.Columns[nameof(WarehouseTableDTO.IdOrder)].Visible = false;

            labelCount.Text = String.Format("{0} шт.", list.Count);
            labelPrice.Text = String.Format("{0} руб.", list.Sum(i => i.PriceSale));

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
                var warehouseDTO = warehousesLogic.GetWarehouse(id: IdDetail);

                DetailEdit changeDetail = new(true, warehouseDTO)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
     
                if (changeDetail.ShowDialog() == DialogResult.OK)
                {
                    warehouseDTO.NameDetail = changeDetail.NameDetail;
                    warehouseDTO.PricePurchase = changeDetail.PricePurchase;
                    warehouseDTO.PriceSale = changeDetail.PriceSale;
                    warehouseDTO.DatePurchase = changeDetail.DatePurchase;
                    warehousesLogic.SaveDetail(warehouseDTO);
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
                    var warehouseDTO = warehousesLogic.GetWarehouse(id: IdDetail);
                    warehouseDTO.Availability = true;
                    warehouseDTO.IdOrder = null;
                    warehousesLogic.SaveDetail(warehouseDTO);
                    UpdateTable();
                }
            }
        }
    }
}
