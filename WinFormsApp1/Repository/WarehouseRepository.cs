using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        IMapper _mapper;

        public WarehouseRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<WarehouseTableDTO>> GetWarehousesForTableAsync(bool? availability = null, bool datePurchase = false, 
            string? name = null, int? idOrder = null, CancellationToken token = default)
        {
            Context context = new();
            var set = context.Warehouse.Where(c => true);
            if (availability != null)
                set = set.Where(i => i.Availability == availability);
            if (idOrder != null)
                set = set.Where(i => i.IdOrder == idOrder);
            if (name != null)
                set = set.Where(i => i.NameDetail.ToLower().Contains(name.ToLower()));
            if(datePurchase)
                set = set.OrderByDescending(i => i.DatePurchase);

            return await _mapper.ProjectTo<WarehouseTableDTO>(set).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<WarehouseDTO>> GetWarehousesAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<WarehouseDTO>(context.Set<Warehouse>()).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<WarehouseEditDTO> GetWarehouseAsync(int id, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<WarehouseEditDTO>(context.Set<Warehouse>().Where(i => i.Id == id))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<WarehouseEditDTO>> GetDetailsInOrderAsync(int idOrder, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<WarehouseEditDTO>(context.Set<Warehouse>().Where(i => i.IdOrder == idOrder))
                .ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task SaveWarehouseAsync(WarehouseEditDTO warehouseDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var warehouse = _mapper.Map<WarehouseEditDTO, Warehouse>(warehouseDTO);
                if(warehouse.Id == 0)
                    context.Warehouse.Add(warehouse);
                else
                    context.Warehouse.Update(warehouse);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveWarehouseAsync(WarehouseEditDTO warehouseDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var warehouse = _mapper.Map<WarehouseEditDTO, Warehouse>(warehouseDTO);
                context.Warehouse.Remove(warehouse);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
