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
        public List<DiagnosisEditDTO> GetDiagnosis()
        {
            Context context = new();
            return context.Diagnosis.Select(a => new DiagnosisEditDTO(a)).ToList();
        }

        public List<DiagnosisEditDTO> GetDiagnosesByName(string name)
        {
            Context context = new();
            return context.Diagnosis.Where(i => i.Name.ToLower().Contains(name.ToLower())).Select(a => new DiagnosisEditDTO(a)).ToList();
        }

        public DiagnosisEditDTO GetDiagnosisByName(string name)
        {
            Context context = new();
            var diagnosis = context.Diagnosis.FirstOrDefault(i => i.Name == name);
            if (diagnosis != null)
            {
                return new DiagnosisEditDTO(diagnosis);
            }
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
                return diagnosisDTO.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
