using System.Data;
using WinFormsApp1.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsApp1
{
    public partial class AddDetails : Form
    {
        public int idOrder;
        public AddDetails(int id)
        {
            InitializeComponent();
            idOrder = id;
            UpdateTable();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonAddDetail_Click(object sender, EventArgs e)
        {
            Context context = new();
            var listOrder = context.Orders.Where(i => i.Id == idOrder).Select(a => new
            {
                a.BrandTechnic,
                a.ModelTechnic
            }).ToList();
            WarehouseDetails details = new(false, (listOrder[0].BrandTechnic.NameBrandTechnic + listOrder[0].ModelTechnic))
            {
                StartPosition = FormStartPosition.CenterParent,
                VisibleBtnAdd = true
            };
            details.ShowDialog();
            
            var listIdWarehouse = context.Details.Where(i => i.Id == idOrder).Select(
                a => new { a.IdWarehouse }).ToList();

            int idDetailWarehouse = details.id;
            var list = context.Warehouse.ToList();
            if (details.Add)
            {
                List<int> listIdWarehouseS = [];
                if (listIdWarehouse[0].IdWarehouse != null)
                    listIdWarehouseS = new(listIdWarehouse[0].IdWarehouse);


                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Id == details.id)
                        listIdWarehouseS.Add(list[i].Id);
                }
                var listWarehouse = context.Warehouse.Where(i => i.Id == details.id).ToList();
                CRUD.ChangeWarehouse(details.id, listWarehouse[0].NameDetail,
                    listWarehouse[0].PricePurchase, listWarehouse[0].PriceSale,
                    listWarehouse[0].DatePurchase, false, idOrder);
                CRUD.ChangeDetails(idOrder, listIdWarehouseS);
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            int summDetails = 0;
            using Context context = new();
            
            var listIdWarehouse = context.Details.Where(i => i.Id == idOrder).Select(a => new 
            {
                a.IdWarehouse
            }).ToList();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns.Add("Name", "Название детали");
            dataGridView1.Columns.Add("PriceSale", "Цена");

            int[] percent = [0, 70, 30];

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width -
                        dataGridView1.RowHeadersWidth) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }

            if (listIdWarehouse[0].IdWarehouse != null) {
                var listWarehouse = context.Warehouse.ToList();
                List<int> listIdS = [];
                List<string> listNameS = [];
                List<int> listPriceSaleS = [];
                
                for (int i = 0; i < listIdWarehouse[0].IdWarehouse.Count; i++)
                {
                    for (int j = 0; j < listWarehouse.Count; j++)
                    {
                        if (listIdWarehouse[0].IdWarehouse[i] == listWarehouse[j].Id)
                        {
                            listIdS.Add(listWarehouse[j].Id);
                            listNameS.Add(listWarehouse[j].NameDetail);
                            listPriceSaleS.Add(listWarehouse[j].PriceSale);
                        }
                    }
                }

                for (int i = 0; i < listIdS.Count; i++)
                {
                    dataGridView1.Rows.Add(listIdS[i], listNameS[i], listPriceSaleS[i]);
                    summDetails += listPriceSaleS[i];
                }
                labelCount.Text = listPriceSaleS.Count.ToString() + " шт.";
                labelPrice.Text = summDetails.ToString() + " руб.";
            }
        }

        private void ButtonChangeDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int idRow = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                var list = context.Warehouse.Where(i => i.Id == idRow).ToList();

                AddDetailToWarehouse changeDetail = new(true)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Изменение данных",
                    NameDetail = list[0].NameDetail,
                    PricePurchase = list[0].PricePurchase,
                    PriceSale = list[0].PriceSale,
                    DatePurchase = list[0].DatePurchase
                };
                changeDetail.ShowDialog();

                if (changeDetail.pressChangeDetail)
                {
                    CRUD.ChangeWarehouse(idRow, changeDetail.NameDetail, changeDetail.PricePurchase,
                        changeDetail.PriceSale, changeDetail.DatePurchase, list[0].Availability,
                        list[0].IdOrder);
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
                    ButtonText = "Нет",
                    ButtonVisible = true
                };
                warning.ShowDialog();

                if (warning.pressBtnYes)
                {
                    Context context = new();
                    int numberRow = dataGridView1.CurrentCell.RowIndex;
                    int idRow = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                    var listSelectDetail = context.Warehouse.Where(i => i.Id == idRow).ToList();

                    var listIdWarehouse = context.Details.Where(i => i.Id == idOrder).Select(a => new
                    {
                        a.IdWarehouse
                    }).ToList();

                    var listWarehouse = context.Warehouse.ToList();
                    List<int> listIdS = [];

                    for (int i = 0; i < listIdWarehouse[0].IdWarehouse.Count; i++)
                    {
                        for (int j = 0; j < listWarehouse.Count; j++)
                        {
                            if (listIdWarehouse[0].IdWarehouse[i] == listWarehouse[j].Id)
                            {
                                listIdS.Add(listWarehouse[j].Id);
                            }
                        }
                    }
                    //!!!!!!!!!!!!!!!!!!!!
                    listIdS.RemoveAt(numberRow);

                    CRUD.ChangeDetails(idOrder, listIdS);
                    CRUD.ChangeWarehouse(idRow, listSelectDetail[0].NameDetail,
                        listSelectDetail[0].PricePurchase, listSelectDetail[0].PriceSale,
                        listSelectDetail[0].DatePurchase, true, null);
                    UpdateTable();
                }
            }
        }
    }
}
