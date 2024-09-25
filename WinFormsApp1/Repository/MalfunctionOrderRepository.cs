using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class MalfunctionOrderRepository : IMalfunctionOrderRepository
    {
        IMapper _mapper;

        public MalfunctionOrderRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdOrder(int idOrder)
        {
            Context context = new();
            return _mapper.ProjectTo<MalfunctionOrderEditDTO>(context.Set<MalfunctionOrder>().Where(i => i.OrderId == idOrder)).ToList();
        }

        /// <inheritdoc/>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdMalfunction(int idMalfunction)
        {
            Context context = new();
            return _mapper.ProjectTo<MalfunctionOrderEditDTO>(context.Set<MalfunctionOrder>()
                .Where(i => i.MalfunctionId == idMalfunction)).ToList();
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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
