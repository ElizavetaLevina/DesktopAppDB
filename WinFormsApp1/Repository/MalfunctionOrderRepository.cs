using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class MalfunctionOrderRepository
    {
        /// <summary>
        /// Получение списка неисправностей в заказе
        /// </summary>
        /// <param name="idOrder">Номер заказа</param>
        /// <returns>Список неисправностей</returns>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdOrder(int idOrder)
        {
            Context context = new();
            var some = context.MalfunctionOrders
                .Where(i => i.OrderId == idOrder);
            var list = some.Include(i => i.Malfunction).ToList();
            return list
                .Select(a => new MalfunctionOrderEditDTO(a))
                .ToList();
        }

        /// <summary>
        /// Получение списка заказов с неисправностью
        /// </summary>
        /// <param name="idMalfunction">Номер неисправности</param>
        /// <returns>Список заказов</returns>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdMalfunction(int idMalfunction)
        {
            Context context = new();
            return context.MalfunctionOrders
                .Where(i => i.MalfunctionId == idMalfunction)
                .Select(a => new MalfunctionOrderEditDTO(a))
                .ToList();
        }

        public async Task SaveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO, CancellationToken token = default)
        {
            try
            {
                Context db = new();
                MalfunctionOrder? malfunctionOrder = await db.MalfunctionOrders.FirstOrDefaultAsync(c => c.OrderId == malfunctionOrderDTO.OrderId &&
                c.MalfunctionId == malfunctionOrderDTO.MalfunctionId, token);
                if (malfunctionOrder == null)
                {
                    malfunctionOrder = new()
                    {
                        MalfunctionId = malfunctionOrderDTO.MalfunctionId,
                        OrderId = malfunctionOrderDTO.OrderId,
                        Price = malfunctionOrderDTO.Price
                    };
                    await db.MalfunctionOrders.AddAsync(malfunctionOrder, token);
                }
                else 
                { 
                    malfunctionOrder.Price = malfunctionOrderDTO.Price;
                    db.MalfunctionOrders.Update(malfunctionOrder);
                }
                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message); throw; }
        }

        public void RemoveMalfunctionOrder(MalfunctionOrderEditDTO malfunctionOrderDTO)
        {
            try
            {
                Context db = new();
                var malfunctionOrder = db.MalfunctionOrders.FirstOrDefault(c => c.MalfunctionId == malfunctionOrderDTO.MalfunctionId &&
                    c.OrderId == malfunctionOrderDTO.OrderId);
                db.MalfunctionOrders.Remove(malfunctionOrder);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
