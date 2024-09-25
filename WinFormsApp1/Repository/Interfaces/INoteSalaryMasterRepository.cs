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
        public List<NoteSalaryMasterEditDTO> GetNoteSalaryMasters(DateTime date);

        public Task SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO, CancellationToken token = default);
    }
}
