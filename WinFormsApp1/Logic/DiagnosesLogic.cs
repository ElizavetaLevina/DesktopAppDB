using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class DiagnosesLogic
    {
        DiagnosisRepository diagnosisRepository = new();
        /// <summary>
        /// Сохранение диагноза
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Идентификатор диагноза</returns>
        public int SaveDiagnosis(DiagnosisEditDTO diagnosisDTO)
        {
            int diagnosisId = 0;
            var task = Task.Run(async () =>
            {
                diagnosisId = await diagnosisRepository.SaveDiagnosisAsync(diagnosisDTO);
            });
            task.Wait();
            return diagnosisId;
        }

        /// <summary>
        /// Получение списка диагнозов
        /// </summary>
        /// <returns>Список диагнозов</returns>
        public List<DiagnosisEditDTO> GetDiagnoses()
        {
            return diagnosisRepository.GetDiagnoses();
        }

        /// <summary>
        /// Получение диагноза по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Диагноз</returns>
        public DiagnosisEditDTO GetDiagnosisByName (string name)
        {
            return diagnosisRepository.GetDiagnosisByName(name);
        }

        /// <summary>
        /// Получение диагноза по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Диагноз</returns>
        public DiagnosisEditDTO GetDiagnosis(int? id)
        {
            return diagnosisRepository.GetDiagnosis(id);
        }

        /// <summary>
        /// Удаление диагноза
        /// </summary>
        /// <param name="diagnosisDTO">DTO диагноза</param>
        public void RemoveDiagnosis(DiagnosisEditDTO diagnosisDTO)
        {
            diagnosisRepository.RemoveDiagnosis(diagnosisDTO);
        }

        /// <summary>
        /// Получение списка неисправностей по подстроке названия
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список неисправностей</returns>
        public List<DiagnosisEditDTO> GetDiagnosesByName(string name)
        {
            return diagnosisRepository.GetDiagnosesByName(name);
        }
    }

}
