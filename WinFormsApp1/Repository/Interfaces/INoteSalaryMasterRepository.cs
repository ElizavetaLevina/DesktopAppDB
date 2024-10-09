using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface INoteSalaryMasterRepository
    {
        /// <summary>
        /// Получение списка примечаний по зарплате мастера по дате
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Список примечаний</returns>
        public Task<List<NoteSalaryMasterEditDTO>> GetNoteSalaryMastersAsync(DateTime date, CancellationToken token = default);

        /// <summary>
        /// Сохранение примечаний по зарплате мастера
        /// </summary>
        /// <param name="noteSalaryMasterDTO">DTO примечания</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO, CancellationToken token = default);
    }
}
