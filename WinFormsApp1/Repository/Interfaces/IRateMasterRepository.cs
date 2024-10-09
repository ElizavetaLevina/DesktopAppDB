using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IRateMasterRepository
    {
        /// <summary>
        /// Получение списка ставок мастера по идентификатору мастера
        /// </summary>
        /// <param name="id">Идентификатор мастера</param>
        /// <returns>Список ставок</returns>
        public Task<List<RateMasterDTO>> GetRateMasterByIdMasterAsync(int id, CancellationToken token = default);

        /// <summary>
        /// Получение ставки мастера по идентификатору мастера и по дате
        /// </summary>
        /// <param name="masterId">Идентификатор мастера</param>
        /// <param name="date">Дата</param>
        /// <returns>Ставка мастера</returns>
        public Task<RateMasterEditDTO> GetRateMasterByDateAsync(int masterId, DateTime date, CancellationToken token = default);

        public Task SaveRateMasterAsync(RateMasterEditDTO rateMasterDTO, CancellationToken token = default);
    }
}
