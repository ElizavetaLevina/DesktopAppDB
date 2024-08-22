using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class RateMasterRepository
    {
        /// <summary>
        /// Получение списка ставок мастера по идентификатору мастера
        /// </summary>
        /// <param name="id">Идентификатор мастера</param>
        /// <returns>Список ставок</returns>
        public List<RateMasterDTO> GetRateMasterByIdMaster(int id)
        {
            Context context = new();
            return context.RateMaster
                .Where(i => i.MasterId == id).OrderBy(i => i.DateStart)
                .Select(a => new RateMasterDTO(a))
                .ToList();
        }

        /// <summary>
        /// Получение ставки мастера по идентификатору мастера и по дате
        /// </summary>
        /// <param name="masterId">Идентификатор мастера</param>
        /// <param name="date">Дата</param>
        /// <returns>Ставка мастера</returns>
        public RateMasterEditDTO GetRateMasterByDate(int masterId, DateTime date)
        {
            Context context = new();
            var rateMaster = context.RateMaster.FirstOrDefault(i => i.MasterId == masterId && i.DateStart == date);
            if (rateMaster != null)
                return new RateMasterEditDTO(rateMaster);
            else
                return new RateMasterEditDTO();
        }

        public async Task SaveRateMasterAsync(RateMasterEditDTO rateMasterDTO, CancellationToken token = default)
        {
            Context db = new Context();
            RateMaster rateMaster = new()
            {
                Id = rateMasterDTO.Id,
                MasterId = rateMasterDTO.MasterId,
                PercentProfit = rateMasterDTO.PercentProfit,
                DateStart = rateMasterDTO.DateStart,
                DateEnd = rateMasterDTO.DateEnd,
                Note = rateMasterDTO.Note
            };
            try
            {
                if (rateMaster.Id == 0)
                    db.RateMaster.Add(rateMaster);
                else
                    db.RateMaster.Update(rateMaster);

                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
