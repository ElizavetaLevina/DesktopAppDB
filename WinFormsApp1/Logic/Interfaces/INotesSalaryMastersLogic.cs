using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface INotesSalaryMastersLogic
    {
        /// <summary>
        /// Получение списка примечаний по зарплате мастера по дате
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Список примечаний</returns>
        public Task<List<NoteSalaryMasterEditDTO>> GetNoteSalaryMastersAsync(DateTime date);

        /// <summary>
        /// Сохранение примечаний по зарплате мастера
        /// </summary>
        /// <param name="noteSalaryMasterDTO">Примечания по зарплате мастера</param>
        public Task SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO);
    }
}
