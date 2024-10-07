using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class OrdersLogic : IOrdersLogic
    {
        IOrderRepository _orderRepository;

        public OrdersLogic(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <inheritdoc/>
        public List<OrderTableDTO> GetOrdersForTable(StatusOrderEnum? statusOrder = null, bool? deleted = null, bool dateCreation = false,
           bool dateCompleted = false, bool dateIssue = false, bool id = false)
        {
            return _orderRepository.GetOrdersForTable(statusOrder: statusOrder, deleted: deleted, dateCreation: dateCreation,
                dateCompleted: dateCompleted, dateIssue: dateIssue, id: id);
        }

        /// <inheritdoc/>
        public void RemoveOrder(OrderEditDTO orderDTO)
        {
            _orderRepository.RemoveOrder(orderDTO);
        }


        /// <inheritdoc/>
        public OrderEditDTO GetOrder(int idOrder) 
        {
            return _orderRepository.GetOrder(idOrder);
        }

        /// <inheritdoc/>
        public List<OrderTableDTO> GetOrdersBySearch(string numberOrder, string dateCreation, string dateStartWork, string masterName,
            string device, string idClient, StatusOrderEnum? statusOrder)
        {
            return _orderRepository.GetOrdersBySearch(numberOrder: numberOrder, dateCreation: dateCreation, dateStartWork: dateStartWork,
                masterName: masterName, device: device, idClient: idClient, statusOrder: statusOrder);
        }

        /// <inheritdoc/>
        public List<OrderTableExcelDTO> GetOrdersForExcel(List<OrderTableDTO> orders)
        {
            return _orderRepository.GetOrdersForExcel(orders);
        }

        /// <inheritdoc/>
        public int GetLastIdOrder()
        {
            return (_orderRepository.GetLastNumberOrder()?.NumberOrder ?? 0) + 1;
        }

        /// <inheritdoc/>
        public async Task<int> SaveOrderAsync(OrderEditDTO orderDTO)
        {
            return await _orderRepository.SaveOrderAsync(orderDTO);
        }

        /// <inheritdoc/>
        public List<OrderEditDTO> GetOrdersForSalaries(DateTime? dateCompleted = null, 
            DateTime? dateIssue = null)
        {
            return _orderRepository.GetOrdersForSalaries(dateCompleted: dateCompleted, dateIssue: dateIssue);
        }

        /// <inheritdoc/>
        public List<OrderEditDTO> GetOrdersByIdDiagnosis(int idDiagnosis)
        {
            return _orderRepository.GetOrdersByIdDiagnosis(idDiagnosis);
        }

        /// <inheritdoc/>
        public List<OrderEditDTO> GetOrdersByIdEquipment(int idEquipment)
        {
            return _orderRepository.GetOrdersByIdEquipment(idEquipment);
        }

        /// <inheritdoc/>
        public List<OrderEditDTO> GetOrdersForChart(int year, bool master = false, int? masterId = null)
        {
            return _orderRepository.GetOrdersForChart(year, master, masterId);
        }

        /// <inheritdoc/>
        public List<OrderEditDTO> GetOrders()
        {
            return _orderRepository.GetOrders();
        }
    }
}
