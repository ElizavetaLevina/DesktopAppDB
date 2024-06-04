using DocumentFormat.OpenXml.InkML;
using System.Data;
using WinFormsApp1.Model;
using Context = WinFormsApp1.Model.Context;

namespace WinFormsApp1
{
    public partial class WarehouseDetails : Form
    {
        public bool Add = false;
        public int id = 0;
        public string device;
        public bool newDetail;
        List<Warehouse> list;
        public WarehouseDetails(bool _newDetail, string _device)
        {
            InitializeComponent();
            device = _device;
            newDetail = _newDetail;
            Context context = new();
            if (!newDetail)
            {
                textBoxDevice.Visible = true;
                textBoxDevice.Text = device;
                list = context.Warehouse.Where(i => i.NameDetail.IndexOf(device) > -1 && i.Availability).OrderByDescending(i => i.DatePurchase).ToList();
            }
            else
                list = context.Warehouse.Where(i => i.Availability).OrderByDescending(i => i.DatePurchase).ToList();
            dataGridView1.DataSource = Funcs.ToDataTable(list);
            UpdateTable();
        }

        private void UpdateTable()
        {
            try
            {
                int[] percent = [10, 40, 17, 17, 16, 0, 0, 0];

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[1].HeaderText = "Название детали";
                dataGridView1.Columns[2].HeaderText = "Цена покупки";
                dataGridView1.Columns[3].HeaderText = "Цена продажи";
                dataGridView1.Columns[4].HeaderText = "Дата покупки";
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    double width = Convert.ToDouble(dataGridView1.Width -
                        dataGridView1.RowHeadersWidth) / 100.0 * percent[i];
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
            AddDetailToWarehouse addDetail = new(false)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addDetail.ShowDialog();
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
                ButtonText = "Нет",
                ButtonVisible = true
            };
            warning.ShowDialog();
            if (warning.pressBtnYes)
            {
                CRUD.RemoveWarehouse(id);
                UpdateTable();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            int numberRow = dataGridView1.CurrentCell.RowIndex;
            id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
            this.Close();
        }

        private void TextBoxDevice_TextChanged(object sender, EventArgs e)
        {
            Context context = new();
            list = context.Warehouse.Where(i => i.NameDetail.IndexOf(textBoxDevice.Text) > -1 
            && i.Availability).OrderByDescending(i => i.DatePurchase).ToList();
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

        public bool VisibleBtnAdd
        {
            get { return this.buttonAdd.Visible; }
            set { this.buttonAdd.Visible = value; }
        }
    }
}
