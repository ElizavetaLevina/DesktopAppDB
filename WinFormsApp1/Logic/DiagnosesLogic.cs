
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
        public int? SaveDiagnosis(string name)
        {
            var diagnosisDTO = diagnosisRepository.GetDiagnosisByName(name);
            int? diagnosisId = diagnosisDTO.Id;
            if (diagnosisId == 0)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    var task = Task.Run(async () =>
                    {
                        diagnosisId = await diagnosisRepository.SaveDiagnosisAsync(diagnosisDTO);
                    });
                    task.Wait();
                }
                else diagnosisId = null;
            }
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
        /// Получение списка диагнозов по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список диагнозов</returns>
        public List<DiagnosisEditDTO> GetDiagnosesByName(string name)
        {
            return diagnosisRepository.GetDiagnosesByName(name);
        }
    }
}
