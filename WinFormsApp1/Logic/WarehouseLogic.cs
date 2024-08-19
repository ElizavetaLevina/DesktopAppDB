
using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class WarehouseLogic
    {
        WarehouseRepository warehouseRepository = new();

        /// <summary>
        /// Получение списка деталей в заказе
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns></returns>
        public int GetCountDetailsInOrder(int idOrder) 
        {
            return warehouseRepository.GetDetailsInOrder(idOrder).Count();
        }
    }
}
