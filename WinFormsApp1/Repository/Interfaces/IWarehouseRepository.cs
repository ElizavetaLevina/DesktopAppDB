using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IWarehouseRepository
    {
        /// <summary>
        /// Получение списка деталей на складе
        /// </summary>
        /// <returns>Список деталей на складе</returns>
        public Task<List<WarehouseTableDTO>> GetWarehousesForTableAsync(bool? availability = null, bool datePurchase = false, 
            string? name = null, int? idOrder = null, CancellationToken token = default);
        

        /// <summary>
        /// Получение списка деталей на складе
        /// </summary>
        /// <returns>Список деталей на складе</returns>
        public Task<List<WarehouseDTO>> GetWarehousesAsync(CancellationToken token = default);

        /// <summary>
        /// Получение детали по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Деталь</returns>
        public Task<WarehouseEditDTO> GetWarehouseAsync(int id, CancellationToken token = default);

        /// <summary>
        /// Получение списка деталей заказе по номеру
        /// </summary>
        /// <param name="idOrder">Номер заказа</param>
        /// <returns>Список деталей</returns>
        public Task<List<WarehouseEditDTO>> GetDetailsInOrderAsync(int idOrder, CancellationToken token = default);

        /// <summary>
        /// Сохранение детали
        /// </summary>
        /// <param name="warehouseDTO">DTO детали</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task SaveWarehouseAsync(WarehouseEditDTO warehouseDTO, CancellationToken token = default);

        /// <summary>
        /// Удаление детали
        /// </summary>
        /// <param name="warehouseDTO">DTO детали</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task RemoveWarehouseAsync(WarehouseEditDTO warehouseDTO, CancellationToken token = default);
    }
}
