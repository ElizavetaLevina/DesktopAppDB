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
        public async Task<List<OrderTableDTO>> GetOrdersForTableAsync(StatusOrderEnum? statusOrder = null, bool? deleted = null, 
            bool dateCreation = false, bool dateCompleted = false, bool dateIssue = false, bool id = false)
        {
            return await _orderRepository.GetOrdersForTableAsync(statusOrder: statusOrder, deleted: deleted, dateCreation: dateCreation,
                dateCompleted: dateCompleted, dateIssue: dateIssue, id: id);
        }

        /// <inheritdoc/>
        public async Task RemoveOrderAsync(OrderEditDTO orderDTO)
        {
            await _orderRepository.RemoveOrderAsync(orderDTO); 
        }


        /// <inheritdoc/>
        public async Task<OrderEditDTO> GetOrderAsync(int idOrder) 
        {
            return await _orderRepository.GetOrderAsync(idOrder);
        }

        /// <inheritdoc/>
        public async Task<List<OrderTableDTO>> GetOrdersBySearchAsync(string numberOrder, string dateCreation, string dateStartWork, string masterName,
            string device, string idClient, StatusOrderEnum? statusOrder)
        {
            return await _orderRepository.GetOrdersBySearchAsync(numberOrder: numberOrder, dateCreation: dateCreation, 
                dateStartWork: dateStartWork, masterName: masterName, device: device, idClient: idClient, statusOrder: statusOrder);
        }

        /// <inheritdoc/>
        public async Task<List<OrderTableExcelDTO>> GetOrdersForExcelAsync(List<OrderTableDTO> orders)
        {
            return await _orderRepository.GetOrdersForExcelAsync(orders);
        }

        /// <inheritdoc/>
        public async Task<int> GetLastIdOrderAsync()
        {
            var orderDTO = await _orderRepository.GetLastNumberOrderAsync();
            return (orderDTO?.NumberOrder ?? 0) + 1;
        }

        /// <inheritdoc/>
        public async Task<int> SaveOrderAsync(OrderEditDTO orderDTO)
        {
            return await _orderRepository.SaveOrderAsync(orderDTO);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersForSalariesAsync(DateTime? dateCompleted = null, 
            DateTime? dateIssue = null)
        {
            return await _orderRepository.GetOrdersForSalariesAsync(dateCompleted: dateCompleted, dateIssue: dateIssue);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersByIdDiagnosisAsync(int idDiagnosis)
        {
            return await _orderRepository.GetOrdersByIdDiagnosisAsync(idDiagnosis);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersByIdEquipmentAsync(int idEquipment)
        {
            return await _orderRepository.GetOrdersByIdEquipmentAsync(idEquipment);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersForChartAsync(int year, bool master = false, int? masterId = null)
        {
            return await _orderRepository.GetOrdersForChartAsync(year, master, masterId);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }
    }
}
