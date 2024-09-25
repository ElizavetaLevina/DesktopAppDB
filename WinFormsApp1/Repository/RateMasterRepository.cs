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
            Context db = new Context();
            RateMaster rateMaster = new()
            {
                Id = rateMasterDTO.Id,
                MasterId = rateMasterDTO.MasterId,
                PercentProfit = rateMasterDTO.PercentProfit,
                DateStart = rateMasterDTO.DateStart,
                DateEnd = rateMasterDTO.DateEnd,
                Note = rateMasterDTO.Note
            };
            try
            {
                if (rateMaster.Id == 0)
                    db.RateMaster.Add(rateMaster);
                else
                    db.RateMaster.Update(rateMaster);

                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
