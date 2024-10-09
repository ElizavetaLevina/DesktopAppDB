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
        public async Task<List<WarehouseEditDTO>> GetDetailsInOrderAsync(int idOrder)
        {
            return await _warehouseRepository.GetDetailsInOrderAsync(idOrder);
        }

        /// <inheritdoc/>
        public async Task<int> GetCountDetailsInOrderAsync(int idOrder)
        {
            return (await GetDetailsInOrderAsync(idOrder)).Count;
        }

        /// <inheritdoc/>
        public async Task<int> GetPriceDetailsInOrderAsync(int idOrder)
        {
            return (await GetDetailsInOrderAsync(idOrder)).Sum(i => i.PriceSale);
        }

        /// <inheritdoc/>
        public async Task<List<WarehouseDTO>> GetWarehousesAsync()
        {
            return await _warehouseRepository.GetWarehousesAsync();
        }

        /// <inheritdoc/>
        public async Task SaveDetailAsync(WarehouseEditDTO warehouseDTO) 
        {
            await _warehouseRepository.SaveWarehouseAsync(warehouseDTO);
        }

        /// <inheritdoc/>
        public async Task<WarehouseEditDTO> GetWarehouseAsync(int id)
        {
            return await _warehouseRepository.GetWarehouseAsync(id);
        }

        /// <inheritdoc/>
        public async Task<List<WarehouseTableDTO>> GetWarehousesForTableAsync(bool? availability = null, bool datePurchase = false, 
            string? name = null, int? idOrder = null)
        {
            return await _warehouseRepository.GetWarehousesForTableAsync(availability, datePurchase, name, idOrder);
        }

        /// <inheritdoc/>
        public async Task RemoveWarehouseAsync(WarehouseEditDTO warehouseDTO)
        {
            await _warehouseRepository.RemoveWarehouseAsync(warehouseDTO);
        }
    }
}
