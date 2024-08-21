using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class WarehousesLogic
    {
        WarehouseRepository warehouseRepository = new();

        /// <summary>
        /// Получение списка деталей в заказе
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Список деталей</returns>
        public List<WarehouseEditDTO> GetDetailsInOrder(int idOrder)
        {
            return warehouseRepository.GetDetailsInOrder(idOrder);
        }

        /// <summary>
        /// Получение количества деталей в заказе
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Количество деталей</returns>
        public int GetCountDetailsInOrder(int idOrder)
        {
            return GetDetailsInOrder(idOrder).Count;
        }

        /// <summary>
        /// Получение суммы деталей в заказе
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Сумма деталей</returns>
        public int GetPriceDetailsInOrder(int idOrder)
        {
            return GetDetailsInOrder(idOrder).Sum(i => i.PriceSale);
        }

        /// <summary>
        /// Получение списка деталей на складе
        /// </summary>
        /// <returns>Список деталей на складе</returns>
        public List<WarehouseDTO> GetWarehouses()
        {
            return warehouseRepository.GetWarehouses();
        }

        /// <summary>
        /// Сохранение детали
        /// </summary>
        /// <param name="warehouseDTO">DTO детали</param>
        public void SaveDetail(WarehouseEditDTO warehouseDTO) 
        {
            var task = Task.Run(async () =>
            {
                await warehouseRepository.SaveWarehouseAsync(warehouseDTO);
            });
            task.Wait();
        }

        /// <summary>
        /// Получение детали по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Деталь</returns>
        public WarehouseEditDTO GetWarehouse(int id)
        {
            return warehouseRepository.GetWarehouse(id);
        }

        /// <summary>
        /// Получение списка деталей на складе для таблицы
        /// </summary>
        /// <param name="availability">Доступность для добавления в заказ</param>
        /// <param name="datePurchase">Дата покупки</param>
        /// <param name="name">Название</param>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns>Список деталей на складе</returns>
        public List<WarehouseTableDTO> GetWarehousesForTable(bool? availability = null, bool datePurchase = false, 
            string? name = null, int? idOrder = null)
        {
            return warehouseRepository.GetWarehousesForTable(availability, datePurchase, name, idOrder);
        }

        /// <summary>
        /// Удаление детали
        /// </summary>
        /// <param name="warehouseDTO">DTO детали</param>
        public void RemoveWarehouse(WarehouseEditDTO warehouseDTO)
        {
            warehouseRepository.RemoveWarehouse(warehouseDTO);
        }
    }
}
