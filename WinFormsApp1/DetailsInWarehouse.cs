using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1.DTO;
using WinFormsApp1.Helpers;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class DetailsInWarehouse : Form
    {
        public bool VisibleBtnAdd
        {
            get { return buttonAdd.Visible; }
            set { buttonAdd.Visible = value; }
        }
        public int IdDetail
        {
            get
            {
                return Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
            Cells[nameof(WarehouseTableDTO.Id)].Value);
            }
        }
        public string? brandDevice = null;
        public bool newDetail = true;
        IWarehousesLogic warehousesLogic;
        public DetailsInWarehouse(IWarehousesLogic _warehousesLogic)
        {
            warehousesLogic = _warehousesLogic;
            InitializeComponent();
        }

        public void InitializeDataTable()
        {
            if (newDetail)
                dataGridView1.DataSource = Funcs.ToDataTable(warehousesLogic.GetWarehousesForTable(availability: true, 
                    datePurchase: true));
            else
            {
                textBoxDevice.Visible = true;
                textBoxDevice.Text = brandDevice;
                dataGridView1.DataSource = Funcs.ToDataTable(warehousesLogic.GetWarehousesForTable(availability: true, 
                    datePurchase: true, name: brandDevice));
            }
            UpdateTable();
        }

        private void UpdateTable()
        {
            try
            {
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
            DetailEdit detailEdit = Program.ServiceProvider.GetRequiredService<DetailEdit>();
            detailEdit.InitializeElementsForm();
            detailEdit.ShowDialog();
            dataGridView1.DataSource = Funcs.ToDataTable(warehousesLogic.GetWarehousesForTable(availability: true, 
                datePurchase: true, name: textBoxDevice.Text));
            UpdateTable();
        }

        private void ButtonDeleteDetail_Click(object sender, EventArgs e)
        {
            Warning warning = new()
            {
                LabelText = "Вы действительно хотите удалить деталь со склада?",
                ButtonNoText = "Нет",
                ButtonVisible = true
            };

            if (warning.ShowDialog() == DialogResult.OK)
            {
                var warehouseDTO = warehousesLogic.GetWarehouse(IdDetail);
                warehousesLogic.RemoveWarehouse(warehouseDTO);
                dataGridView1.DataSource = Funcs.ToDataTable(warehousesLogic.GetWarehousesForTable(availability: true,
                datePurchase: true));
                UpdateTable();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TextBoxDevice_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Funcs.ToDataTable(warehousesLogic.GetWarehousesForTable(availability: true,
                datePurchase: true, name: textBoxDevice.Text));
            UpdateTable();
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
            DetailEdit addDetail = Program.ServiceProvider.GetRequiredService<DetailEdit>();
            addDetail.changeDetail = true;
            addDetail.idDetail = IdDetail;
            addDetail.InitializeElementsForm();
            addDetail.ShowDialog();
            dataGridView1.DataSource = Funcs.ToDataTable(warehousesLogic.GetWarehousesForTable(availability: true,
                datePurchase: true));
            UpdateTable();
        }
    }
}
