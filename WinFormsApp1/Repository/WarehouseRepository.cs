using DocumentFormat.OpenXml.Office2010.Excel;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class WarehouseRepository
    {
        /// <summary>
        /// Получение списка деталей на складе
        /// </summary>
        /// <returns>Список деталей на складе</returns>
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

            return set
                .Select(a => new WarehouseTableDTO(a))
                .ToList();
        }

        public List<WarehouseDTO> GetWarehouses()
        {
            Context context = new();
            return context.Warehouse.Select(c => new WarehouseDTO(c)).ToList();
        }


        public WarehouseEditDTO GetWarehouse(int id)
        {
            Context context = new();
            return new WarehouseEditDTO(context.Warehouse.First(i => i.Id == id));
        }

        public async Task SaveWarehouseAsync(WarehouseEditDTO warehouseDTO, CancellationToken token = default)
        {
            try
            {
                Context db = new();
                Warehouse warehouse = new()
                {
                    Id = warehouseDTO.Id,
                    NameDetail = warehouseDTO.NameDetail,
                    PricePurchase = warehouseDTO.PricePurchase,
                    PriceSale = warehouseDTO.PriceSale,
                    DatePurchase = warehouseDTO.DatePurchase,
                    Availability = warehouseDTO.Availability,
                    IdOrder = warehouseDTO.IdOrder
                };
                if(warehouse.Id == 0)
                    db.Warehouse.Add(warehouse);
                else
                    db.Warehouse.Update(warehouse);
                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        public void RemoveWarehouse(WarehouseEditDTO warehouseDTO)
        {
            try
            {
                Context db = new();
                var warehouse = db.Warehouse.FirstOrDefault(c => c.Id == warehouseDTO.Id);
                db.Warehouse.Remove(warehouse);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
