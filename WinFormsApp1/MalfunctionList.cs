using System.Windows.Forms;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class MalfunctionList : Form
    {
        public string status;
        public MalfunctionList(string _status)
        {
            InitializeComponent();
            status = _status;
            UpdateTable();
        }

        private void UpdateTable()
        {
            Context context = new();
            switch (status) 
            {
                case "malfunction":
                    dataGridView1.DataSource = context.Malfunctions.ToList();
                    dataGridView1.Columns[2].HeaderText = "Цена";
                    int[] percent = [0, 70, 30];

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                        dataGridView1.Columns[i].Width = Convert.ToInt32(width);
                    }
                    break;
                case "diagnosis":
                    dataGridView1.DataSource = context.Diagnosis.ToList();
                    dataGridView1.Columns[1].Width = dataGridView1.Width;
                    break;
                case "equipment":
                    dataGridView1.DataSource = context.Equipment.ToList();
                    dataGridView1.Columns[1].Width = dataGridView1.Width;
                    break;
            }

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название";
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Context context = new();
            MalfunctionChange malfunctionChange = new(status)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            switch (status)
            {
                case "malfunction":
                    malfunctionChange.Text = "Добавить неисправность";
                    break;
                case "diagnosis":
                    malfunctionChange.Text = "Добавить диагноз";
                    malfunctionChange.LabelPriceVisible = false;
                    malfunctionChange.LabelRubVisible = false;
                    malfunctionChange.TextBoxPriceVisisble = false;
                    break;
                case "equipment":
                    malfunctionChange.Text = "Добавить комплектацию";
                    malfunctionChange.LabelPriceVisible = false;
                    malfunctionChange.LabelRubVisible = false;
                    malfunctionChange.TextBoxPriceVisisble = false;
                    break;
            }

            if (malfunctionChange.ShowDialog() == DialogResult.OK)
            {
                int idKey = 1;
                switch (status)
                {
                    case "malfunction":
                        if (context.Malfunctions.Any())
                        {
                            idKey = context.Malfunctions.OrderBy(i => i.Id).Last().Id;
                            idKey++;
                        }
                        CRUD.AddAsyncMalfunction(idKey, malfunctionChange.TextBoxName,
                            Convert.ToInt32(malfunctionChange.TextBoxPrice));
                        break;
                    case "diagnosis":
                        if (context.Diagnosis.Any())
                        {
                            idKey = context.Diagnosis.OrderBy(i => i.Id).Last().Id;
                            idKey++;
                        }
                        CRUD.AddAsyncDiagnosis(idKey, malfunctionChange.TextBoxName);
                        break;
                    case "equipment":
                        if (context.Equipment.Any())
                        {
                            idKey = context.Equipment.OrderBy(i => i.Id).Last().Id;
                            idKey++;
                        }
                        CRUD.AddAsyncEquipment(idKey, malfunctionChange.TextBoxName);
                        break;
                }
                UpdateTable();
            }
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                
                MalfunctionChange malfunctionChange = new(status)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                switch (status)
                {
                    case "malfunction":
                        var listMalfunction = context.Malfunctions.Where(i => i.Id == id).ToList();
                        malfunctionChange.Text = "Изменение неисправности";
                        malfunctionChange.TextBoxName = listMalfunction[0].Name;
                        malfunctionChange.TextBoxPrice = listMalfunction[0].Price.ToString();
                        break;
                    case "diagnosis":
                        var listDiagnosis = context.Diagnosis.Where(i => i.Id == id).ToList();
                        malfunctionChange.Text = "Изменение диагноза";
                        malfunctionChange.TextBoxName = listDiagnosis[0].Name;
                        malfunctionChange.LabelPriceVisible = false;
                        malfunctionChange.LabelRubVisible = false;
                        malfunctionChange.TextBoxPriceVisisble = false;
                        break;
                    case "equipment":
                        var listEquipment = context.Equipment.Where(i => i.Id == id).ToList();
                        malfunctionChange.Text = "Изменение комплектации";
                        malfunctionChange.TextBoxName = listEquipment[0].Name;
                        malfunctionChange.LabelPriceVisible = false;
                        malfunctionChange.LabelRubVisible = false;
                        malfunctionChange.TextBoxPriceVisisble = false;
                        break;
                }
                
                if (malfunctionChange.ShowDialog() == DialogResult.OK)
                {
                    switch (status)
                    {
                        case "malfunction":
                            CRUD.ChangeMalfunction(id, malfunctionChange.TextBoxName,
                                Convert.ToInt32(malfunctionChange.TextBoxPrice));
                            break;
                        case "diagnosis":
                            CRUD.ChangeDiagnosis(id, malfunctionChange.TextBoxName);
                            break;
                        case "equipment":
                            CRUD.ChangeEquipment(id, malfunctionChange.TextBoxName);
                            break;
                    }
                }
                UpdateTable();                
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                Context context = new();
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                switch (status)
                {
                    case "malfunction":
                        CRUD.RemoveMalfunction(id);
                        var list = context.MalfunctionOrders.Where(i => i.MalfunctionId == id).ToList();
                        for (int i = 0; i < list.Count; i++)
                        {
                            CRUD.RemoveMalfunctionOrder(id, list[i].OrderId, list[i].Price);
                        }
                        break;
                    case "diagnosis":
                        CRUD.RemoveDiagnosis(id);
                        var listDiagnosis = context.Orders.Where(i => i.DiagnosisId == id).ToList();
                        for (int i = 0; i < listDiagnosis.Count; i++)
                        {
                            CRUD.ChangeOrder(listDiagnosis[i].Id, listDiagnosis[i].ClientId, listDiagnosis[i].MasterId,
                                listDiagnosis[i].DateCreation, listDiagnosis[i].DateStartWork, listDiagnosis[i].DateCompleted,
                                listDiagnosis[i].DateIssue, listDiagnosis[i].TypeTechnicId, listDiagnosis[i].BrandTechnicId,
                                listDiagnosis[i].ModelTechnic, listDiagnosis[i].FactoryNumber, listDiagnosis[i].EquipmentId,
                                null, listDiagnosis[i].Note, listDiagnosis[i].InProgress, listDiagnosis[i].Guarantee,
                                listDiagnosis[i].DateEndGuarantee, listDiagnosis[i].Deleted, listDiagnosis[i].ReturnUnderGuarantee,
                                listDiagnosis[i].DateReturn, listDiagnosis[i].DateCompletedReturn, listDiagnosis[i].DateIssueReturn,
                                listDiagnosis[i].Issue, listDiagnosis[i].ColorRow, listDiagnosis[i].DateLastCall,
                                listDiagnosis[i].PriceAgreed, listDiagnosis[i].MaxPrice);
                        }
                        break;
                    case "equipment":
                        CRUD.RemoveEquipment(id);
                        var listEquipment = context.Orders.Where(i => i.EquipmentId == id).ToList();
                        for (int i = 0; i < listEquipment.Count; i++)
                        {
                            CRUD.ChangeOrder(listEquipment[i].Id, listEquipment[i].ClientId, listEquipment[i].MasterId,
                                listEquipment[i].DateCreation, listEquipment[i].DateStartWork, listEquipment[i].DateCompleted,
                                listEquipment[i].DateIssue, listEquipment[i].TypeTechnicId, listEquipment[i].BrandTechnicId,
                                listEquipment[i].ModelTechnic, listEquipment[i].FactoryNumber, listEquipment[i].EquipmentId,
                                null, listEquipment[i].Note, listEquipment[i].InProgress, listEquipment[i].Guarantee,
                                listEquipment[i].DateEndGuarantee, listEquipment[i].Deleted, listEquipment[i].ReturnUnderGuarantee,
                                listEquipment[i].DateReturn, listEquipment[i].DateCompletedReturn, listEquipment[i].DateIssueReturn,
                                listEquipment[i].Issue, listEquipment[i].ColorRow, listEquipment[i].DateLastCall,
                                listEquipment[i].PriceAgreed, listEquipment[i].MaxPrice);
                        }
                        break;
                }                
                UpdateTable();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
