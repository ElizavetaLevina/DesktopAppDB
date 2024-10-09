using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class MalfunctionsOrdersLogic : IMalfunctionsOrdersLogic
    {
        IMalfunctionOrderRepository _malfunctionOrderRepository;

        public MalfunctionsOrdersLogic(IMalfunctionOrderRepository malfunctionOrderRepository)
        {
            _malfunctionOrderRepository = malfunctionOrderRepository;
        }

        /// <inheritdoc/>
        public async Task SaveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO)
        {
            await _malfunctionOrderRepository.SaveMalfunctionOrderAsync(malfunctionOrderDTO);
        }

        /// <inheritdoc/>
        public async Task<List<MalfunctionOrderEditDTO>> GetMalfunctionOrdersByIdOrderAsync(int idOrder)
        {
            return await _malfunctionOrderRepository.GetMalfunctionOrdersByIdOrderAsync(idOrder);
        }

        /// <inheritdoc/>
        public async Task<List<MalfunctionOrderEditDTO>> GetMalfunctionOrdersByIdMalfunctionAsync(int idMalfunction)
        {
            return await _malfunctionOrderRepository.GetMalfunctionOrdersByIdMalfunctionAsync(idMalfunction);
        }

        /// <inheritdoc/>
        public async Task RemoveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO)
        {
            await _malfunctionOrderRepository.RemoveMalfunctionOrderAsync(malfunctionOrderDTO);
        }
    }
}
