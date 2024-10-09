using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class RateMasterRepository : IRateMasterRepository
    {
        IMapper _mapper;

        public RateMasterRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<RateMasterDTO>> GetRateMasterByIdMasterAsync(int id, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<RateMasterDTO>(context.Set<RateMaster>()
                .Where(i => i.MasterId == id).OrderBy(i => i.DateStart)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<RateMasterEditDTO> GetRateMasterByDateAsync(int masterId, DateTime date, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<RateMasterEditDTO>(context.Set<RateMaster>().Where(i => i.MasterId == masterId && 
            i.DateStart == date.ToUniversalTime())).FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task SaveRateMasterAsync(RateMasterEditDTO rateMasterDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var rateMaster = _mapper.Map<RateMasterEditDTO, RateMaster>(rateMasterDTO);
            
                if (rateMaster.Id == 0)
                    context.RateMaster.Add(rateMaster);
                else
                    context.RateMaster.Update(rateMaster);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
