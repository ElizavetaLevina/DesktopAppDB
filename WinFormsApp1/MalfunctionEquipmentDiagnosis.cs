using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class MalfunctionEquipmentDiagnosis : Form
    {
        NameTableToEditEnum status;
        MalfunctionsLogic malfunctionsLogic = new();
        DiagnosesLogic diagnosesLogic = new();
        EquipmentsLogic equipmentsLogic = new();
        MalfunctionsOrdersLogic malfunctionsOrdersLogic = new();
        OrdersLogic ordersLogic = new();
        public MalfunctionEquipmentDiagnosis(NameTableToEditEnum _status)
        {
            InitializeComponent();
            status = _status;
            UpdateTable();
        }

        private void UpdateTable()
        {
            switch (status) 
            {
                case NameTableToEditEnum.Malfunction:
                    dataGridView1.DataSource = malfunctionsLogic.GetMalfunctions();
                    dataGridView1.Columns[nameof(MalfunctionEditDTO.Id)].Visible = false;
                    dataGridView1.Columns[nameof(MalfunctionEditDTO.Name)].HeaderText = "Название";
                    dataGridView1.Columns[nameof(MalfunctionEditDTO.Price)].HeaderText = "Цена";
                    int[] percent = [0, 70, 30];

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                        dataGridView1.Columns[i].Width = Convert.ToInt32(width);
                    }
                    break;
                case NameTableToEditEnum.Diagnosis:
                    dataGridView1.DataSource = diagnosesLogic.GetDiagnoses();
                    dataGridView1.Columns[nameof(MalfunctionEditDTO.Id)].Visible = false;
                    dataGridView1.Columns[nameof(MalfunctionEditDTO.Name)].HeaderText = "Название";
                    dataGridView1.Columns[nameof(MalfunctionEditDTO.Name)].Width = dataGridView1.Width;
                    break;
                case NameTableToEditEnum.Equipment:
                    dataGridView1.DataSource = equipmentsLogic.GetEquipments();
                    dataGridView1.Columns[nameof(MalfunctionEditDTO.Id)].Visible = false;
                    dataGridView1.Columns[nameof(MalfunctionEditDTO.Name)].HeaderText = "Название";
                    dataGridView1.Columns[nameof(MalfunctionEditDTO.Name)].Width = dataGridView1.Width;
                    break;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            MalfunctionEquipmentDiagnosisEdit malfunctionEquipmentDiagnosisEdit = new(status)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            switch (status)
            {
                case NameTableToEditEnum.Malfunction:
                    malfunctionEquipmentDiagnosisEdit.Text = "Добавить неисправность";
                    break;
                case NameTableToEditEnum.Diagnosis:
                    malfunctionEquipmentDiagnosisEdit.Text = "Добавить диагноз";
                    malfunctionEquipmentDiagnosisEdit.LabelPriceVisible = false;
                    malfunctionEquipmentDiagnosisEdit.LabelRubVisible = false;
                    malfunctionEquipmentDiagnosisEdit.TextBoxPriceVisisble = false;
                    break;
                case NameTableToEditEnum.Equipment:
                    malfunctionEquipmentDiagnosisEdit.Text = "Добавить комплектацию";
                    malfunctionEquipmentDiagnosisEdit.LabelPriceVisible = false;
                    malfunctionEquipmentDiagnosisEdit.LabelRubVisible = false;
                    malfunctionEquipmentDiagnosisEdit.TextBoxPriceVisisble = false;
                    break;
            }

            if (malfunctionEquipmentDiagnosisEdit.ShowDialog() == DialogResult.OK)
            {
                switch (status)
                {
                    case NameTableToEditEnum.Malfunction:
                        var malfunctionDTO = new MalfunctionEditDTO()
                        {
                            Name = malfunctionEquipmentDiagnosisEdit.TextBoxName,
                            Price = Convert.ToInt32(malfunctionEquipmentDiagnosisEdit.TextBoxPrice)
                        };
                        malfunctionsLogic.SaveMalfunction(malfunctionDTO);
                        break;
                    case NameTableToEditEnum.Diagnosis:
                        var diagnosisDTO = new DiagnosisEditDTO()
                        {
                            Name = malfunctionEquipmentDiagnosisEdit.TextBoxName
                        };
                        diagnosesLogic.SaveDiagnosis(diagnosisDTO);
                        break;
                    case NameTableToEditEnum.Equipment:
                        var equipmentDTO = new EquipmentEditDTO()
                        {
                            Name = malfunctionEquipmentDiagnosisEdit.TextBoxName
                        };
                        equipmentsLogic.SaveEquipment(equipmentDTO);
                        break;
                }
                UpdateTable();
            }
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MalfunctionEditDTO malfunctionDTO = new();
                DiagnosisEditDTO diagnosisDTO = new();
                EquipmentEditDTO equipmentDTO = new();

                MalfunctionEquipmentDiagnosisEdit malfunctionEquipmentDiagnosisEdit = new(status)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                switch (status)
                {
                    case NameTableToEditEnum.Malfunction:
                        malfunctionDTO = malfunctionsLogic.GetMalfunction(Id);
                        malfunctionEquipmentDiagnosisEdit.Text = "Изменение неисправности";
                        malfunctionEquipmentDiagnosisEdit.TextBoxName = malfunctionDTO.Name;
                        malfunctionEquipmentDiagnosisEdit.TextBoxPrice = malfunctionDTO.Price.ToString();
                        break;
                    case NameTableToEditEnum.Diagnosis:
                        diagnosisDTO = diagnosesLogic.GetDiagnosis(Id);
                        malfunctionEquipmentDiagnosisEdit.Text = "Изменение диагноза";
                        malfunctionEquipmentDiagnosisEdit.TextBoxName = diagnosisDTO.Name;
                        malfunctionEquipmentDiagnosisEdit.LabelPriceVisible = false;
                        malfunctionEquipmentDiagnosisEdit.LabelRubVisible = false;
                        malfunctionEquipmentDiagnosisEdit.TextBoxPriceVisisble = false;
                        break;
                    case NameTableToEditEnum.Equipment:
                        equipmentDTO = equipmentsLogic.GetEquipment(Id);
                        malfunctionEquipmentDiagnosisEdit.Text = "Изменение комплектации";
                        malfunctionEquipmentDiagnosisEdit.TextBoxName = equipmentDTO.Name;
                        malfunctionEquipmentDiagnosisEdit.LabelPriceVisible = false;
                        malfunctionEquipmentDiagnosisEdit.LabelRubVisible = false;
                        malfunctionEquipmentDiagnosisEdit.TextBoxPriceVisisble = false;
                        break;
                }
                
                if (malfunctionEquipmentDiagnosisEdit.ShowDialog() == DialogResult.OK)
                {
                    switch (status)
                    {
                        case NameTableToEditEnum.Malfunction:
                            malfunctionDTO.Name = malfunctionEquipmentDiagnosisEdit.TextBoxName;
                            malfunctionDTO.Price = Convert.ToInt32(malfunctionEquipmentDiagnosisEdit.TextBoxPrice);
                            malfunctionsLogic.SaveMalfunction(malfunctionDTO);
                            break;
                        case NameTableToEditEnum.Diagnosis:
                            diagnosisDTO.Name = malfunctionEquipmentDiagnosisEdit.TextBoxName;
                            diagnosesLogic.SaveDiagnosis(diagnosisDTO);
                            break;
                        case NameTableToEditEnum.Equipment:
                            equipmentDTO.Name = malfunctionEquipmentDiagnosisEdit.TextBoxName;
                            equipmentsLogic.SaveEquipment(equipmentDTO);
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
                switch (status)
                {
                    case NameTableToEditEnum.Malfunction:
                        var malfunctionDTO = malfunctionsLogic.GetMalfunction(Id);
                        var malfunctionOrderDTO = malfunctionsOrdersLogic.GetMalfunctionOrdersByIdMalfunction(Id);
                        foreach(var malfunctionOrder in malfunctionOrderDTO)
                        {
                            malfunctionsOrdersLogic.RemoveMalfunctionOrder(malfunctionOrder);
                        }
                        malfunctionsLogic.RemoveMalfunction(malfunctionDTO);
                        break;
                    case NameTableToEditEnum.Diagnosis:
                        var diagnosisDTO = diagnosesLogic.GetDiagnosis(Id);
                        var ordersDTO = ordersLogic.GetOrdersByIdDiagnosis(Id);
                        foreach(var order in ordersDTO)
                        {
                            order.DiagnosisId = null;
                            ordersLogic.SaveOrder(order);
                        }
                        diagnosesLogic.RemoveDiagnosis(diagnosisDTO);
                        break;
                    case NameTableToEditEnum.Equipment:
                        var equipmentDTO = equipmentsLogic.GetEquipment(Id);
                        ordersDTO = ordersLogic.GetOrdersByIdEquipment(Id);
                        foreach (var order in ordersDTO)
                        {
                            order.EquipmentId = null;
                            ordersLogic.SaveOrder(order);
                        }
                        equipmentsLogic.RemoveEquipment(equipmentDTO);
                        break;
                }                
                UpdateTable();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public int Id
        {
            get { return Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
                Cells[nameof(MalfunctionEditDTO.Id)].Value); }
        }
    }
}
