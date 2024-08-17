using System.Windows.Forms;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Repository;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.Logic
{
    public class OrdersLogic
    {
        OrderRepository orderRepository = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();

        public void ReturnGuarantee(int idOrder) 
        {
            var orderDTO = orderRepository.GetOrder(idOrder);

            orderDTO.DateCreation = DateTime.Now;
            orderDTO.DateStartWork = DateTime.Now;
            orderDTO.StatusOrder = StatusOrderEnum.InRepair;
            orderDTO.ReturnUnderGuarantee = true;

            var task = Task.Run(async () =>
            {
                await orderRepository.SaveOrderAsync(orderDTO);
            });
            task.Wait();
        }

        public List<OrderTableDTO> GetOrdersForTable(StatusOrderEnum? statusOrder = null, bool? deleted = null, bool dateCreation = false,
           bool dateCompleted = false, bool dateIssue = false, bool id = false)
        {
            return orderRepository.GetOrdersForTable(statusOrder: statusOrder, deleted: deleted, dateCreation: dateCreation,
                dateCompleted: dateCompleted, dateIssue: dateIssue, id: id);
        }

        public void RemoveOrder(int idOrder)
        {
            var orderDTO = orderRepository.GetOrder(idOrder);

            if (orderDTO.Deleted)
            {
                orderRepository.RemoveOrder(orderDTO);
            }
            else
            {
                orderDTO.Deleted = true;
                var task = Task.Run(async () =>
                {
                    await orderRepository.SaveOrderAsync(orderDTO);
                });
                task.Wait();
            }
        }

        public void RecoveryOrder(int idOrder)
        {
            var orderDTO = orderRepository.GetOrder(idOrder);
            orderDTO.Deleted = false;
            var task = Task.Run(async () =>
            {
                await orderRepository.SaveOrderAsync(orderDTO);
            });
            task.Wait();
        }

        public void ReturnInRepair(int idOrder)
        {
            var orderDTO = orderRepository.GetOrder(idOrder);
            var malfunctionsOrderDTO = malfunctionOrderRepository.GetMalfunctionOrdersByIdOrder(idOrder);

            orderDTO.StatusOrder = StatusOrderEnum.InRepair;
            if (orderDTO.ReturnUnderGuarantee)
                orderDTO.DateCompletedReturn = null;
            else
                orderDTO.DateCompleted = null;
            var task = Task.Run(async () =>
            {
                await orderRepository.SaveOrderAsync(orderDTO);
            });
            task.Wait();

            foreach (var malfunctionOrder in malfunctionsOrderDTO)
            {
                malfunctionOrderRepository.RemoveMalfunctionOrder(malfunctionOrder);
            }
        }

        public OrderEditDTO GetOrder(int idOrder) 
        {
            return orderRepository.GetOrder(idOrder);
        }

        public Color ChangeColorRows(int idOrder, StatusOrderEnum status, string hexColor)
        {
            var orderDTO = orderRepository.GetOrder(idOrder);
            var savedColor = ColorTranslator.FromHtml(hexColor);
            if (savedColor != ColorDefinition(orderDTO, status))
            {
                savedColor = ColorDefinition(orderDTO, status);
                orderDTO.ColorRow = ColorTranslator.ToHtml(savedColor);
                var task = Task.Run(async () =>
                {
                    await orderRepository.SaveOrderAsync(orderDTO);
                });
                task.Wait();
            }
            return savedColor;
        }

        private Color ColorDefinition(OrderEditDTO orderDTO, StatusOrderEnum status)
        {
            Color newColor;
            var countDays = 0;
            switch (status)
            {
                case StatusOrderEnum.InRepair:
                    countDays = (DateTime.Now - orderDTO.DateStartWork.Value).Days;
                    break;
                case StatusOrderEnum.Completed:
                    countDays = (DateTime.Now - orderDTO.DateCompleted.Value).Days;
                    break;
            }

            if (countDays < Convert.ToInt32(Properties.Settings.Default.FirstLevelText))
                newColor = Properties.Settings.Default.FirstLevelColor;
            else if (countDays > Convert.ToInt32(Properties.Settings.Default.SecondLevelText))
                newColor = Properties.Settings.Default.ThirdLevelColor;
            else if (orderDTO.StatusOrder == StatusOrderEnum.GuaranteeIssue || orderDTO.StatusOrder == StatusOrderEnum.Archive)
                newColor = Color.Black;
            else
                newColor = Properties.Settings.Default.SecondLevelColor;
            return newColor;
        }

        public List<OrderTableDTO> GetOrdersBySearch(string numberOrder, string dateCreation, string dateStartWork, string masterName,
            string device, string idClient, StatusOrderEnum? statusOrder)
        {
            return orderRepository.GetOrdersBySearch(numberOrder: numberOrder, dateCreation: dateCreation, dateStartWork: dateStartWork,
                masterName: masterName, device: device, idClient: idClient, statusOrder: statusOrder);
        }
    }
}
