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
        public List<WarehouseEditDTO> GetDetailsInOrder(int idOrder);

        /// <summary>
        /// Получение количества деталей в заказе
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Количество деталей</returns>
        public int GetCountDetailsInOrder(int idOrder);

        /// <summary>
        /// Получение суммы деталей в заказе
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Сумма деталей</returns>
        public int GetPriceDetailsInOrder(int idOrder);

        /// <summary>
        /// Получение списка деталей на складе
        /// </summary>
        /// <returns>Список деталей на складе</returns>
        public List<WarehouseDTO> GetWarehouses();

        /// <summary>
        /// Сохранение детали
        /// </summary>
        /// <param name="warehouseDTO">DTO детали</param>
        public void SaveDetail(WarehouseEditDTO warehouseDTO);

        /// <summary>
        /// Получение детали по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Деталь</returns>
        public WarehouseEditDTO GetWarehouse(int id);

        /// <summary>
        /// Получение списка деталей на складе для таблицы
        /// </summary>
        /// <param name="availability">Доступность для добавления в заказ</param>
        /// <param name="datePurchase">Дата покупки</param>
        /// <param name="name">Название</param>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Список деталей на складе</returns>
        public List<WarehouseTableDTO> GetWarehousesForTable(bool? availability = null, bool datePurchase = false,
            string? name = null, int? idOrder = null);

        /// <summary>
        /// Удаление детали
        /// </summary>
        /// <param name="warehouseDTO">DTO детали</param>
        public void RemoveWarehouse(WarehouseEditDTO warehouseDTO);
    }
}
