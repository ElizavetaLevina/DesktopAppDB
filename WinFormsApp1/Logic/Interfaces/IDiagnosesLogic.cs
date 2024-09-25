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
        public int SaveDiagnosis(DiagnosisEditDTO diagnosisDTO);

        /// <summary>
        /// Получение списка диагнозов
        /// </summary>
        /// <returns>Список диагнозов</returns>
        public List<DiagnosisEditDTO> GetDiagnoses();

        /// <summary>
        /// Получение диагноза по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Диагноз</returns>
        public DiagnosisEditDTO GetDiagnosisByName(string name);

        /// <summary>
        /// Получение диагноза по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Диагноз</returns>
        public DiagnosisEditDTO GetDiagnosis(int? id);

        /// <summary>
        /// Удаление диагноза
        /// </summary>
        /// <param name="diagnosisDTO">DTO диагноза</param>
        public void RemoveDiagnosis(DiagnosisEditDTO diagnosisDTO);

        /// <summary>
        /// Получение списка неисправностей по подстроке названия
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список неисправностей</returns>
        public List<DiagnosisEditDTO> GetDiagnosesByName(string name);
    }
}
