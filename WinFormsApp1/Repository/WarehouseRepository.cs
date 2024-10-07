using AutoMapper;
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
        public List<WarehouseTableDTO> GetWarehousesForTable(bool? availability = null, bool datePurchase = false, string? name = null, int? idOrder = null)
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

            return _mapper.ProjectTo<WarehouseTableDTO>(set).ToList();
        }

        /// <inheritdoc/>
        public List<WarehouseDTO> GetWarehouses()
        {
            Context context = new();
            return _mapper.ProjectTo<WarehouseDTO>(context.Set<Warehouse>()).ToList();
        }

        /// <inheritdoc/>
        public WarehouseEditDTO GetWarehouse(int id)
        {
            Context context = new();
            return _mapper.ProjectTo<WarehouseEditDTO>(context.Set<Warehouse>().Where(i => i.Id == id)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public List<WarehouseEditDTO> GetDetailsInOrder(int idOrder)
        {
            Context context = new();
            return _mapper.ProjectTo<WarehouseEditDTO>(context.Set<Warehouse>().Where(i => i.IdOrder == idOrder)).ToList();
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
