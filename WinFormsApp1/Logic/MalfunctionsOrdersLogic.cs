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
        public void SaveMalfunctionOrder(MalfunctionOrderEditDTO malfunctionOrderDTO)
        {
            var task = Task.Run(async () =>
            {
                await _malfunctionOrderRepository.SaveMalfunctionOrderAsync(malfunctionOrderDTO);
            });
            task.Wait();
        }

        /// <inheritdoc/>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdOrder(int idOrder)
        {
            return _malfunctionOrderRepository.GetMalfunctionOrdersByIdOrder(idOrder);
        }

        /// <inheritdoc/>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdMalfunction(int idMalfunction)
        {
            return _malfunctionOrderRepository.GetMalfunctionOrdersByIdMalfunction(idMalfunction);
        }

        /// <inheritdoc/>
        public void RemoveMalfunctionOrder(MalfunctionOrderEditDTO malfunctionOrderDTO)
        {
            _malfunctionOrderRepository.RemoveMalfunctionOrder(malfunctionOrderDTO);
        }
    }
}
