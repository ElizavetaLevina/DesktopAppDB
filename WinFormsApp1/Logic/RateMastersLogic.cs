using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class RateMastersLogic : IRateMastersLogic
    {
        IRateMasterRepository _rateMasterRepository;

        public RateMastersLogic(IRateMasterRepository rateMasterRepository)
        {
            _rateMasterRepository = rateMasterRepository;
        }

        /// <inheritdoc/>
        public RateMasterEditDTO GetRateMasterByDate(int masterId, DateTime date)
        {
            var rateMasterDTO = _rateMasterRepository.GetRateMasterByDate(masterId, date);
            if (rateMasterDTO == null)
                return new RateMasterEditDTO();
            else return rateMasterDTO;
        }

        /// <inheritdoc/>
        public List<RateMasterDTO> GetRateMasterByIdMaster(int id)
        {
            return _rateMasterRepository.GetRateMasterByIdMaster(id);
        }

        /// <inheritdoc/>
        public void SaveRateMaster(RateMasterEditDTO rateMasterDTO)
        {
            var task = Task.Run(async () =>
            {
                await _rateMasterRepository.SaveRateMasterAsync(rateMasterDTO);
            });
            task.Wait();
        }
    }
}
