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
    }
}
