using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class MalfunctionOrderRepository
    {
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdOrder(int idOrder)
        {
            Context context = new();
            return context.MalfunctionOrders.Where(i => i.OrderId == idOrder).Select(a => new MalfunctionOrderEditDTO(a)).ToList();
        }

        public async Task SaveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO, CancellationToken token = default)
        {
            Context db = new();
            MalfunctionOrder malfunctionOrder = new()
            {
                MalfunctionId = malfunctionOrderDTO.MalfunctionId,
                OrderId = malfunctionOrderDTO.OrderId,
                Price = malfunctionOrderDTO.Price
            };
            try
            {
                db.MalfunctionOrders.Add(malfunctionOrder);
                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
