using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IMalfunctionOrderRepository
    {
        /// <summary>
        /// Получение списка неисправностей в заказе
        /// </summary>
        /// <param name="idOrder">Номер заказа</param>
        /// <returns>Список неисправностей</returns>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdOrder(int idOrder);

        /// <summary>
        /// Получение списка заказов с неисправностью
        /// </summary>
        /// <param name="idMalfunction">Номер неисправности</param>
        /// <returns>Список заказов</returns>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdMalfunction(int idMalfunction);

        public Task SaveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO, CancellationToken token = default);

        public Task RemoveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO, CancellationToken token = default);
    }
}
