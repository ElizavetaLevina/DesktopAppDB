
using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class WarehouseLogic
    {
        WarehouseRepository warehouseRepository = new();

        public int GetCountDetailsInOrder(int idOrder) 
        {
            return warehouseRepository.GetDetailsInOrder(idOrder).Count();
        }
    }
}
