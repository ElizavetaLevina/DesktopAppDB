using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class MalfunctionsLogic : IMalfunctionsLogic
    {
        IMalfunctionRepository _malfunctionRepository;

        public MalfunctionsLogic(IMalfunctionRepository malfunctionRepository)
        {
            _malfunctionRepository = malfunctionRepository;
        }

        /// <inheritdoc/>
        public async Task<List<MalfunctionEditDTO>> GetMalfunctionsAsync()
        {
            return await _malfunctionRepository.GetMalfunctionsAsync();
        }

        /// <inheritdoc/>
        public async Task<MalfunctionEditDTO> GetMalfunctionByNameAsync(string name)
        {
            var malfunctionDTO = await _malfunctionRepository.GetMalfunctionByNameAsync(name);
            if (malfunctionDTO == null)
                return new MalfunctionEditDTO();
            else
                return malfunctionDTO;
        }

        /// <inheritdoc/>
        public async Task<string> GetPriceMalfunctionByNameAsync(string name)
        {
            var malfunctionDTO = await _malfunctionRepository.GetMalfunctionByNameAsync(name);
            return malfunctionDTO.Price.ToString();
        }

        /// <inheritdoc/>
        public async Task<int> SaveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO)
        {
            return await _malfunctionRepository.SaveMalfunctionAsync(malfunctionDTO);
        }

        /// <inheritdoc/>
        public async Task<MalfunctionEditDTO> GetMalfunctionAsync(int id)
        {
            return await _malfunctionRepository.GetMalfunctionAsync(id);
        }

        /// <inheritdoc/>
        public async Task RemoveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO)
        {
            await _malfunctionRepository.RemoveMalfunctionAsync(malfunctionDTO);
        }
    }
}
