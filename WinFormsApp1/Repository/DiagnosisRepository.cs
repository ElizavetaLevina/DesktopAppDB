using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class DiagnosisRepository
    {
        /// <summary>
        /// Получение списка неисправностей со слов клиента
        /// </summary>
        /// <returns>Список неипсравностей</returns>
        public List<DiagnosisEditDTO> GetDiagnoses()
        {
            Context context = new();
            return context.Diagnosis.Select(a => new DiagnosisEditDTO(a)).ToList();
        }

        /// <summary>
        /// Получение диагноза по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Диагноз</returns>
        public DiagnosisEditDTO GetDiagnosis(int? id)
        {
            Context context = new();
            var diagnosis = context.Diagnosis.FirstOrDefault(i => i.Id == id);
            if (diagnosis == null)
                return new DiagnosisEditDTO();
            else
                return new DiagnosisEditDTO(diagnosis);
        }

        /// <summary>
        /// Получение списка неисправностей по подстроке названия
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список неисправностей</returns>
        public List<DiagnosisEditDTO> GetDiagnosesByName(string name)
        {
            Context context = new();
            return context.Diagnosis.Where(i => i.Name.ToLower().Contains(name.ToLower())).Select(a => new DiagnosisEditDTO(a)).ToList();
        }

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Запись</returns>
        public DiagnosisEditDTO GetDiagnosisByName(string name)
        {
            Context context = new();
            var diagnosis = context.Diagnosis.FirstOrDefault(i => i.Name == name);
            if (diagnosis != null)
                return new DiagnosisEditDTO(diagnosis);
            else
                return new DiagnosisEditDTO(name);
        }


        public async Task<int> SaveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO, CancellationToken token = default)
        {
            Context db = new();
            Diagnosis diagnosis = new()
            {
                Id = diagnosisDTO.Id,
                Name = diagnosisDTO.Name
            };
            try
            {
                if (diagnosis.Id == 0)
                    db.Diagnosis.Add(diagnosis);
                else
                    db.Diagnosis.Update(diagnosis);
                await db.SaveChangesAsync(token);
                return diagnosis.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        public void RemoveDiagnosis(DiagnosisEditDTO diagnosisDTO)
        {
            try
            {
                Context db = new();
                var diagnosis = db.Diagnosis.FirstOrDefault(c => c.Id == diagnosisDTO.Id);
                db.Diagnosis.Remove(diagnosis);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
