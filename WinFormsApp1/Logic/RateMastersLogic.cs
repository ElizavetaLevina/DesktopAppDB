using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class RateMastersLogic
    {
        RateMasterRepository rateMasterRepository = new();

        /// <summary>
        /// Получение ставки мастера по идентификатору мастера и по дате
        /// </summary>
        /// <param name="masterId">Идентификатор мастера</param>
        /// <param name="date">Дата</param>
        /// <returns>Ставка мастера</returns>
        public RateMasterEditDTO GetRateMasterByDate(int masterId, DateTime date)
        {
            return rateMasterRepository.GetRateMasterByDate(masterId, date);
        }

        /// <summary>
        /// Получение списка ставок мастера по идентификатору мастера
        /// </summary>
        /// <param name="id">Идентификатор мастера</param>
        /// <returns>Список ставок</returns>
        public List<RateMasterDTO> GetRateMasterByIdMaster(int id)
        {
            return rateMasterRepository.GetRateMasterByIdMaster(id);
        }

        /// <summary>
        /// Сохранение ставки мастера
        /// </summary>
        /// <param name="rateMasterDTO">DTO ставки</param>
        public void SaveRateMaster(RateMasterEditDTO rateMasterDTO)
        {
            var task = Task.Run(async () =>
            {
                await rateMasterRepository.SaveRateMasterAsync(rateMasterDTO);
            });
            task.Wait();
        }
    }
}
