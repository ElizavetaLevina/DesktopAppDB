using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class WarehousesLogic : IWarehousesLogic
    {
        IWarehouseRepository _warehouseRepository;

        public WarehousesLogic(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        /// <inheritdoc/>
        public List<WarehouseEditDTO> GetDetailsInOrder(int idOrder)
        {
            return _warehouseRepository.GetDetailsInOrder(idOrder);
        }

        /// <inheritdoc/>
        public int GetCountDetailsInOrder(int idOrder)
        {
            return GetDetailsInOrder(idOrder).Count;
        }

        /// <inheritdoc/>
        public int GetPriceDetailsInOrder(int idOrder)
        {
            return GetDetailsInOrder(idOrder).Sum(i => i.PriceSale);
        }

        /// <inheritdoc/>
        public List<WarehouseDTO> GetWarehouses()
        {
            return _warehouseRepository.GetWarehouses();
        }

        /// <inheritdoc/>
        public void SaveDetail(WarehouseEditDTO warehouseDTO) 
        {
            var task = Task.Run(async () =>
            {
                await _warehouseRepository.SaveWarehouseAsync(warehouseDTO);
            });
            task.Wait();
        }

        /// <inheritdoc/>
        public WarehouseEditDTO GetWarehouse(int id)
        {
            return _warehouseRepository.GetWarehouse(id);
        }

        /// <inheritdoc/>
        public List<WarehouseTableDTO> GetWarehousesForTable(bool? availability = null, bool datePurchase = false, 
            string? name = null, int? idOrder = null)
        {
            return _warehouseRepository.GetWarehousesForTable(availability, datePurchase, name, idOrder);
        }

        /// <inheritdoc/>
        public void RemoveWarehouse(WarehouseEditDTO warehouseDTO)
        {
            _warehouseRepository.RemoveWarehouse(warehouseDTO);
        }
    }
}
