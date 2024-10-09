using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
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
        public async Task<RateMasterEditDTO> GetRateMasterByDateAsync(int masterId, DateTime date)
        {
            var rateMasterDTO = await _rateMasterRepository.GetRateMasterByDateAsync(masterId, date);
            if (rateMasterDTO == null)
                return new RateMasterEditDTO();
            else return rateMasterDTO;
        }

        /// <inheritdoc/>
        public async Task<List<RateMasterDTO>> GetRateMasterByIdMasterAsync(int id)
        {
            return await _rateMasterRepository.GetRateMasterByIdMasterAsync(id);
        }

        /// <inheritdoc/>
        public async Task SaveRateMasterAsync(RateMasterEditDTO rateMasterDTO)
        {
            await _rateMasterRepository.SaveRateMasterAsync(rateMasterDTO);
        }
    }
}
