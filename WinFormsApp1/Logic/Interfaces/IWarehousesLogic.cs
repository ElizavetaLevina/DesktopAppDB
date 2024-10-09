using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IWarehousesLogic
    {
        /// <summary>
        /// Получение списка деталей в заказе
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Список деталей</returns>
        public Task<List<WarehouseEditDTO>> GetDetailsInOrderAsync(int idOrder);

        /// <summary>
        /// Получение количества деталей в заказе
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Количество деталей</returns>
        public Task<int> GetCountDetailsInOrderAsync(int idOrder);

        /// <summary>
        /// Получение суммы деталей в заказе
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Сумма деталей</returns>
        public Task<int> GetPriceDetailsInOrderAsync(int idOrder);

        /// <summary>
        /// Получение списка деталей на складе
        /// </summary>
        /// <returns>Список деталей на складе</returns>
        public Task<List<WarehouseDTO>> GetWarehousesAsync();

        /// <summary>
        /// Сохранение детали
        /// </summary>
        /// <param name="warehouseDTO">DTO детали</param>
        public Task SaveDetailAsync(WarehouseEditDTO warehouseDTO);

        /// <summary>
        /// Получение детали по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Деталь</returns>
        public Task<WarehouseEditDTO> GetWarehouseAsync(int id);

        /// <summary>
        /// Получение списка деталей на складе для таблицы
        /// </summary>
        /// <param name="availability">Доступность для добавления в заказ</param>
        /// <param name="datePurchase">Дата покупки</param>
        /// <param name="name">Название</param>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Список деталей на складе</returns>
        public Task<List<WarehouseTableDTO>> GetWarehousesForTableAsync(bool? availability = null, bool datePurchase = false,
            string? name = null, int? idOrder = null);

        /// <summary>
        /// Удаление детали
        /// </summary>
        /// <param name="warehouseDTO">DTO детали</param>
        public Task RemoveWarehouseAsync(WarehouseEditDTO warehouseDTO);
    }
}
