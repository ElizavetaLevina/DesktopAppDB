using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IWarehouseRepository
    {
        /// <summary>
        /// Получение списка деталей на складе
        /// </summary>
        /// <returns>Список деталей на складе</returns>
        public List<WarehouseTableDTO> GetWarehousesForTable(bool? availability = null, bool datePurchase = false, string? name = null,
            int? idOrder = null);
        

        /// <summary>
        /// Получение списка деталей на складе
        /// </summary>
        /// <returns>Список деталей на складе</returns>
        public List<WarehouseDTO> GetWarehouses();

        /// <summary>
        /// Получение детали по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Деталь</returns>
        public WarehouseEditDTO GetWarehouse(int id);

        /// <summary>
        /// Получение списка деталей заказе по номеру
        /// </summary>
        /// <param name="idOrder">Номер заказа</param>
        /// <returns>Список деталей</returns>
        public List<WarehouseEditDTO> GetDetailsInOrder(int idOrder);

        public Task SaveWarehouseAsync(WarehouseEditDTO warehouseDTO, CancellationToken token = default);

        public Task RemoveWarehouseAsync(WarehouseEditDTO warehouseDTO, CancellationToken token = default);
    }
}
