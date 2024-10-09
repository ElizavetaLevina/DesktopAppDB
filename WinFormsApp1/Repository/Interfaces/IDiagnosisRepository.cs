using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IDiagnosisRepository
    {

        /// <summary>
        /// Получение списка неисправностей со слов клиента
        /// </summary>
        /// <returns>Список неипсравностей</returns>
        public Task<List<DiagnosisEditDTO>> GetDiagnosesAsync(CancellationToken token = default);

        /// <summary>
        /// Получение диагноза по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Диагноз</returns>
        public Task<DiagnosisEditDTO> GetDiagnosisAsync(int? id, CancellationToken token = default);

        /// <summary>
        /// Получение списка неисправностей по подстроке названия
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список неисправностей</returns>
        public Task<List<DiagnosisEditDTO>> GetDiagnosesByNameAsync(string name, CancellationToken token = default);

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Запись</returns>
        public Task<DiagnosisEditDTO> GetDiagnosisByNameAsync(string name, CancellationToken token = default);

        /// <summary>
        /// Сохранение диагноза
        /// </summary>
        /// <param name="diagnosisDTO">DTO диагноза</param>
        /// <param name="token"></param>
        /// <returns>Идентификатор даигноза</returns>
        public Task<int> SaveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO, CancellationToken token = default);

        /// <summary>
        /// Удаление диагноза
        /// </summary>
        /// <param name="diagnosisDTO">DTO диагноза</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task RemoveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO, CancellationToken token = default);
    }
}
