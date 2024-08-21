using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class OrdersLogic
    {
        OrderRepository orderRepository = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();

        /// <summary>
        /// Возвращение устройства в ремонта по гарантии
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
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

        /// <summary>
        /// Получение списка заказов для главной таблицы
        /// </summary>
        /// <param name="statusOrder">Статус заказа</param>
        /// <param name="deleted">Удален</param>
        /// <param name="dateCreation">Дата создания заказа</param>
        /// <param name="dateCompleted">Дата завершения заказа</param>
        /// <param name="dateIssue">Дата выдачи заказа</param>
        /// <param name="id">Идентификатор заказа</param>
        /// <returns>Список заказов</returns>
        public List<OrderTableDTO> GetOrdersForTable(StatusOrderEnum? statusOrder = null, bool? deleted = null, bool dateCreation = false,
           bool dateCompleted = false, bool dateIssue = false, bool id = false)
        {
            return orderRepository.GetOrdersForTable(statusOrder: statusOrder, deleted: deleted, dateCreation: dateCreation,
                dateCompleted: dateCompleted, dateIssue: dateIssue, id: id);
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
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

        /// <summary>
        /// Возвращение заказа из корзины
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
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

        /// <summary>
        /// Возвращение заказа в доработку
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
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

        /// <summary>
        /// Получение заказа по идентификатору
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns></returns>
        public OrderEditDTO GetOrder(int idOrder) 
        {
            return orderRepository.GetOrder(idOrder);
        }

        /// <summary>
        /// Проверка сохраненного цвета и перезапись при несовпадении
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <param name="status">Статус заказа</param>
        /// <param name="savedColor">Сохраненный цвет </param>
        /// <returns></returns>
        public Color ChangeColorRows(int idOrder, StatusOrderEnum status, Color savedColor)
        {
            var orderDTO = orderRepository.GetOrder(idOrder);
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

        /// <summary>
        /// Определение цвета 
        /// </summary>
        /// <param name="orderDTO">DTO заказа</param>
        /// <param name="status">Статус заказа</param>
        /// <returns>Цвет</returns>
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

        /// <summary>
        /// Получение списка заказов по параметрам поиска
        /// </summary>
        /// <param name="numberOrder">Номер квитанции</param>
        /// <param name="dateCreation">Дата создания заказа</param>
        /// <param name="dateStartWork">Дата начала работы над заказом</param>
        /// <param name="masterName">Имя мастера</param>
        /// <param name="device">Устройство</param>
        /// <param name="idClient">Id клиента</param>
        /// <param name="statusOrder">Статус заказа</param>
        /// <returns></returns>
        public List<OrderTableDTO> GetOrdersBySearch(string numberOrder, string dateCreation, string dateStartWork, string masterName,
            string device, string idClient, StatusOrderEnum? statusOrder)
        {
            return orderRepository.GetOrdersBySearch(numberOrder: numberOrder, dateCreation: dateCreation, dateStartWork: dateStartWork,
                masterName: masterName, device: device, idClient: idClient, statusOrder: statusOrder);
        }

        /// <summary>
        /// Получение последнего + 1 номера квитанции
        /// </summary>
        /// <returns>Номер квитанции</returns>
        public int GetLastIdOrder()
        {
            return orderRepository.GetLastNumberOrder();
        }

        /// <summary>
        /// Сохранение заказа
        /// </summary>
        /// <param name="orderDTO">DTO заказа</param>
        /// <returns>Идентификатор заказа</returns>
        public int SaveOrder(OrderEditDTO orderDTO)
        {
            int idOrder = 0;
            var task = Task.Run(async () =>
            {
                idOrder = await orderRepository.SaveOrderAsync(orderDTO);
            });
            task.Wait();
            return idOrder;
        }

        /// <summary>
        /// Получение списка заказов для расчета зарплаты
        /// </summary>
        /// <param name="dateCompleted">Дата завершения заказа</param>
        /// <param name="dateIssue">Дата выдачи заказа</param>
        /// <returns></returns>
        public List<OrderEditDTO> GetOrdersForSalaries(DateTime? dateCompleted = null, DateTime? dateIssue = null)
        {
            return orderRepository.GetOrdersForSalaries(dateCompleted: dateCompleted, dateIssue: dateIssue);
        }
    }
}
