using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class MalfunctionEquipmentDiagnosisList : Form
    {
        public string status;
        MalfunctionRepository malfunctionRepository = new();
        DiagnosisRepository diagnosisRepository = new();
        EquipmentRepository equipmentRepository = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();
        OrderRepository orderRepository = new();
        public MalfunctionEquipmentDiagnosisList(string _status)
        {
            InitializeComponent();
            status = _status;
            UpdateTable();
        }

        private void UpdateTable()
        {
            switch (status) 
            {
                case "malfunction":
                    dataGridView1.DataSource = malfunctionRepository.GetMalfunctions();
                    dataGridView1.Columns["Id"].Visible = false;
                    dataGridView1.Columns["Name"].HeaderText = "Название";
                    dataGridView1.Columns["Price"].HeaderText = "Цена";
                    int[] percent = [0, 70, 30];

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                        dataGridView1.Columns[i].Width = Convert.ToInt32(width);
                    }
                    break;
                case "diagnosis":
                    dataGridView1.DataSource = diagnosisRepository.GetDiagnoses();
                    dataGridView1.Columns["Id"].Visible = false;
                    dataGridView1.Columns["Name"].HeaderText = "Название";
                    dataGridView1.Columns["Name"].Width = dataGridView1.Width;
                    break;
                case "equipment":
                    dataGridView1.DataSource = equipmentRepository.GetEquipments();
                    dataGridView1.Columns["Id"].Visible = false;
                    dataGridView1.Columns["Name"].HeaderText = "Название";
                    dataGridView1.Columns["Name"].Width = dataGridView1.Width;
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
                case "malfunction":
                    malfunctionEquipmentDiagnosisEdit.Text = "Добавить неисправность";
                    break;
                case "diagnosis":
                    malfunctionEquipmentDiagnosisEdit.Text = "Добавить диагноз";
                    malfunctionEquipmentDiagnosisEdit.LabelPriceVisible = false;
                    malfunctionEquipmentDiagnosisEdit.LabelRubVisible = false;
                    malfunctionEquipmentDiagnosisEdit.TextBoxPriceVisisble = false;
                    break;
                case "equipment":
                    malfunctionEquipmentDiagnosisEdit.Text = "Добавить комплектацию";
                    malfunctionEquipmentDiagnosisEdit.LabelPriceVisible = false;
                    malfunctionEquipmentDiagnosisEdit.LabelRubVisible = false;
                    malfunctionEquipmentDiagnosisEdit.TextBoxPriceVisisble = false;
                    break;
            }

            if (malfunctionEquipmentDiagnosisEdit.ShowDialog() == DialogResult.OK)
            {
                Task task;
                switch (status)
                {
                    case "malfunction":
                        var malfunctionDTO = new MalfunctionEditDTO()
                        {
                            Id = 0,
                            Name = malfunctionEquipmentDiagnosisEdit.TextBoxName,
                            Price = Convert.ToInt32(malfunctionEquipmentDiagnosisEdit.TextBoxPrice)
                        };
                        task = Task.Run(async () =>
                        {
                            await malfunctionRepository.SaveMalfunctionAsync(malfunctionDTO);
                        });
                        task.Wait();
                        break;
                    case "diagnosis":
                        var diagnosisDTO = new DiagnosisEditDTO()
                        {
                            Id = 0,
                            Name = malfunctionEquipmentDiagnosisEdit.TextBoxName
                        };
                        task = Task.Run(async () =>
                        {
                            await diagnosisRepository.SaveDiagnosisAsync(diagnosisDTO);
                        });
                        task.Wait();
                        break;
                    case "equipment":
                        var equipmentDTO = new EquipmentEditDTO()
                        {
                            Id = 0,
                            Name = malfunctionEquipmentDiagnosisEdit.TextBoxName
                        };
                        task = Task.Run(async () =>
                        {
                            await equipmentRepository.SaveEquipmentAsync(equipmentDTO);
                        });
                        task.Wait();
                        break;
                }
                UpdateTable();
            }
        }

        private async void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MalfunctionEditDTO malfunctionDTO = new();
                DiagnosisEditDTO diagnosisDTO = new();
                EquipmentEditDTO equipmentDTO = new();

                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);

                MalfunctionEquipmentDiagnosisEdit malfunctionEquipmentDiagnosisEdit = new(status)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                switch (status)
                {
                    case "malfunction":
                        malfunctionDTO = malfunctionRepository.GetMalfunction(id);
                        malfunctionEquipmentDiagnosisEdit.Text = "Изменение неисправности";
                        malfunctionEquipmentDiagnosisEdit.TextBoxName = malfunctionDTO.Name;
                        malfunctionEquipmentDiagnosisEdit.TextBoxPrice = malfunctionDTO.Price.ToString();
                        break;
                    case "diagnosis":
                        diagnosisDTO = diagnosisRepository.GetDiagnosis(id);
                        malfunctionEquipmentDiagnosisEdit.Text = "Изменение диагноза";
                        malfunctionEquipmentDiagnosisEdit.TextBoxName = diagnosisDTO.Name;
                        malfunctionEquipmentDiagnosisEdit.LabelPriceVisible = false;
                        malfunctionEquipmentDiagnosisEdit.LabelRubVisible = false;
                        malfunctionEquipmentDiagnosisEdit.TextBoxPriceVisisble = false;
                        break;
                    case "equipment":
                        equipmentDTO = equipmentRepository.GetEquipment(id);
                        malfunctionEquipmentDiagnosisEdit.Text = "Изменение комплектации";
                        malfunctionEquipmentDiagnosisEdit.TextBoxName = equipmentDTO.Name;
                        malfunctionEquipmentDiagnosisEdit.LabelPriceVisible = false;
                        malfunctionEquipmentDiagnosisEdit.LabelRubVisible = false;
                        malfunctionEquipmentDiagnosisEdit.TextBoxPriceVisisble = false;
                        break;
                }
                
                if (malfunctionEquipmentDiagnosisEdit.ShowDialog() == DialogResult.OK)
                {
                    Task task;
                    switch (status)
                    {
                        case "malfunction":
                            malfunctionDTO.Name = malfunctionEquipmentDiagnosisEdit.TextBoxName;
                            malfunctionDTO.Price = Convert.ToInt32(malfunctionEquipmentDiagnosisEdit.TextBoxPrice);
                            task = Task.Run(async() => {
                                await malfunctionRepository.SaveMalfunctionAsync(malfunctionDTO);
                            });
                            task.Wait();
                            break;
                        case "diagnosis":
                            diagnosisDTO.Name = malfunctionEquipmentDiagnosisEdit.TextBoxName;
                            task = Task.Run(async () =>
                            {
                                await diagnosisRepository.SaveDiagnosisAsync(diagnosisDTO);
                            });
                            task.Wait();
                            break;
                        case "equipment":
                            equipmentDTO.Name = malfunctionEquipmentDiagnosisEdit.TextBoxName;
                            task = Task.Run(async () =>
                            {
                                await equipmentRepository.SaveEquipmentAsync(equipmentDTO);
                            });
                            task.Wait();
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
                Task task;
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells["Id"].Value);
                switch (status)
                {
                    case "malfunction":
                        var malfunctionDTO = malfunctionRepository.GetMalfunction(id);
                        var malfunctionOrderDTO = malfunctionOrderRepository.GetMalfunctionOrdersByIdMalfunction(id);
                        foreach(var malfunctionOrder in malfunctionOrderDTO)
                        {
                            malfunctionOrderRepository.RemoveMalfunctionOrder(malfunctionOrder);
                        }
                        malfunctionRepository.RemoveMalfunction(malfunctionDTO);
                        break;
                    case "diagnosis":
                        var diagnosisDTO = diagnosisRepository.GetDiagnosis(id);
                        var ordersDTO = orderRepository.GetOrdersByIdDiagnosis(id);
                        foreach(var order in ordersDTO)
                        {
                            order.DiagnosisId = null;
                            task = Task.Run(async () =>
                            {
                                await orderRepository.SaveOrderAsync(order);
                            });
                            task.Wait();
                        }
                        diagnosisRepository.RemoveDiagnosis(diagnosisDTO);
                        break;
                    case "equipment":
                        var equipmentDTO = equipmentRepository.GetEquipment(id);
                        ordersDTO = orderRepository.GetOrdersByIdEquipment(id);
                        foreach (var order in ordersDTO)
                        {
                            order.EquipmentId = null;
                            task = Task.Run(async () =>
                            {
                                await orderRepository.SaveOrderAsync(order);
                            });
                            task.Wait();
                        }
                        equipmentRepository.RemoveEquipment(equipmentDTO);
                        break;
                }                
                UpdateTable();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
