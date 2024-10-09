using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IDiagnosesLogic
    {
        /// <summary>
        /// Сохранение диагноза
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Идентификатор диагноза</returns>
        public Task<int> SaveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO);

        /// <summary>
        /// Получение списка диагнозов
        /// </summary>
        /// <returns>Список диагнозов</returns>
        public Task<List<DiagnosisEditDTO>> GetDiagnosesAsync();

        /// <summary>
        /// Получение диагноза по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Диагноз</returns>
        public Task<DiagnosisEditDTO> GetDiagnosisByNameAsync(string name);

        /// <summary>
        /// Получение диагноза по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Диагноз</returns>
        public Task<DiagnosisEditDTO> GetDiagnosisAsync(int? id);

        /// <summary>
        /// Удаление диагноза
        /// </summary>
        /// <param name="diagnosisDTO">DTO диагноза</param>
        public Task RemoveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO);

        /// <summary>
        /// Получение списка неисправностей по подстроке названия
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список неисправностей</returns>
        public Task<List<DiagnosisEditDTO>> GetDiagnosesByNameAsync(string name);
    }
}
