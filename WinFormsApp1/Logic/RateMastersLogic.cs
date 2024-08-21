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
    }
}
