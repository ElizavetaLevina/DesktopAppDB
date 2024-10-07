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
                Context context = new();
                //var malfunctionOrder = _mapper.Map<MalfunctionOrderEditDTO, MalfunctionOrder>(malfunctionOrderDTO);
                MalfunctionOrder? malfunctionOrder = await context.MalfunctionOrders.FirstOrDefaultAsync(c => c.OrderId == malfunctionOrderDTO.OrderId &&
                c.MalfunctionId == malfunctionOrderDTO.MalfunctionId, token);
                //if (malfunctionOrder == null)
                //{
                //    malfunctionOrder = new()
                //    {
                //        MalfunctionId = malfunctionOrderDTO.MalfunctionId,
                //        OrderId = malfunctionOrderDTO.OrderId,
                //        Price = malfunctionOrderDTO.Price
                //    };
                //    await context.MalfunctionOrders.AddAsync(malfunctionOrder, token);
                //}
                //else 
                //{ 
                //    malfunctionOrder.Price = malfunctionOrderDTO.Price;
                //    context.MalfunctionOrders.Update(malfunctionOrder);
                //}

                if (malfunctionOrder == null)
                    context.MalfunctionOrders.Add(_mapper.Map<MalfunctionOrderEditDTO, MalfunctionOrder>(malfunctionOrderDTO));
                else
                    context.MalfunctionOrders.Update(malfunctionOrder);

                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                /*var malfunctionOrder = context.MalfunctionOrders.FirstOrDefault(c => c.MalfunctionId == malfunctionOrderDTO.MalfunctionId &&
                    c.OrderId == malfunctionOrderDTO.OrderId);*/
                var malfunctionOrder = _mapper.Map<MalfunctionOrderEditDTO, MalfunctionOrder>(malfunctionOrderDTO);
                context.MalfunctionOrders.Remove(malfunctionOrder);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
