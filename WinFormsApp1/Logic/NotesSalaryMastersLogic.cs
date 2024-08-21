using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class NotesSalaryMastersLogic
    {
        NoteSalaryMasterRepository noteSalaryMasterRepository = new();

        /// <summary>
        /// Получение списка примечаний по зарплате мастера по дате
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Список примечаний</returns>
        public List<NoteSalaryMasterEditDTO> GetNoteSalaryMasters(DateTime date)
        {
            return noteSalaryMasterRepository.GetNoteSalaryMasters(date);
        }

        /// <summary>
        /// Сохранение примечаний по зарплате мастера
        /// </summary>
        /// <param name="noteSalaryMasterDTO">Примечания по зарплате мастера</param>
        public void SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO)
        {
            Task.Run(async () =>
            {
                await noteSalaryMasterRepository.SaveNoteSalaryMasterAsync(noteSalaryMasterDTO);
            });
        }
    }
}
