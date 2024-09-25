using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IDiagnosisRepository
    {

        /// <summary>
        /// Получение списка неисправностей со слов клиента
        /// </summary>
        /// <returns>Список неипсравностей</returns>
        public List<DiagnosisEditDTO> GetDiagnoses();

        /// <summary>
        /// Получение диагноза по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Диагноз</returns>
        public DiagnosisEditDTO GetDiagnosis(int? id);

        /// <summary>
        /// Получение списка неисправностей по подстроке названия
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список неисправностей</returns>
        public List<DiagnosisEditDTO> GetDiagnosesByName(string name);

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Запись</returns>
        public DiagnosisEditDTO GetDiagnosisByName(string name);


        public Task<int> SaveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO, CancellationToken token = default);

        public void RemoveDiagnosis(DiagnosisEditDTO diagnosisDTO);
    }
}
