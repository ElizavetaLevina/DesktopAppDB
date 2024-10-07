using AutoMapper;
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
        public List<RateMasterDTO> GetRateMasterByIdMaster(int id)
        {
            Context context = new();
            return _mapper.ProjectTo<RateMasterDTO>(context.Set<RateMaster>()
                .Where(i => i.MasterId == id).OrderBy(i => i.DateStart)).ToList();
        }

        /// <inheritdoc/>
        public RateMasterEditDTO GetRateMasterByDate(int masterId, DateTime date)
        {
            Context context = new();
            return _mapper.ProjectTo<RateMasterEditDTO>(context.Set<RateMaster>().Where(i => i.MasterId == masterId && 
            i.DateStart == date.ToUniversalTime())).FirstOrDefault();
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
