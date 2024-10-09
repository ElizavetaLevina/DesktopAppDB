using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class MastersLogic : IMastersLogic
    {
        IMasterRepository _masterRepository;
        public MastersLogic(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        /// <inheritdoc/>
        public async Task<List<MasterDTO>> GetMastersForOutputAsync()
        {
            return await _masterRepository.GetMastersForOutputAsync();
        }

        /// <inheritdoc/>
        public async Task<List<MasterEditDTO>> GetMastersAsync()
        {
            return await _masterRepository.GetMastersAsync();
        }

        /// <inheritdoc/>
        public async Task<MasterEditDTO> GetMasterAsync(int? id)
        {
            var masterDTO = await _masterRepository.GetMasterAsync(id);
            if (masterDTO == null)
                return new MasterEditDTO();
            else 
                return masterDTO;
        }

        /// <inheritdoc/>
        public async Task SaveMasterAsync(MasterEditDTO masterDTO)
        {
            await _masterRepository.SaveMasterAsync(masterDTO);
        }

        /// <inheritdoc/>
        public async Task RemoveMasterAsync(MasterEditDTO masterDTO)
        {
            await _masterRepository.RemoveMasterAsync(masterDTO);
        }

    }
}
