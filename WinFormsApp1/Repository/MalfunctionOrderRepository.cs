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
        public async Task<List<MalfunctionOrderEditDTO>> GetMalfunctionOrdersByIdOrderAsync(int idOrder, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<MalfunctionOrderEditDTO>(context.Set<MalfunctionOrder>().Where(i => i.OrderId == idOrder))
                .ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<MalfunctionOrderEditDTO>> GetMalfunctionOrdersByIdMalfunctionAsync(int idMalfunction, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<MalfunctionOrderEditDTO>(context.Set<MalfunctionOrder>()
                .Where(i => i.MalfunctionId == idMalfunction)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task SaveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                MalfunctionOrder? malfunctionOrder = await context.MalfunctionOrders.FirstOrDefaultAsync(c => c.OrderId == malfunctionOrderDTO.OrderId &&
                c.MalfunctionId == malfunctionOrderDTO.MalfunctionId, token);
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
                var malfunctionOrder = _mapper.Map<MalfunctionOrderEditDTO, MalfunctionOrder>(malfunctionOrderDTO);
                context.MalfunctionOrders.Remove(malfunctionOrder);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
