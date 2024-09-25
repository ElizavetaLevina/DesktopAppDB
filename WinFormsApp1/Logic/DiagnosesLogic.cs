using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class DiagnosesLogic : IDiagnosesLogic
    {
        IDiagnosisRepository _diagnosisRepository;

        public DiagnosesLogic(IDiagnosisRepository diagnosisRepository)
        {
            _diagnosisRepository = diagnosisRepository;
        }

        /// <inheritdoc/>
        public int SaveDiagnosis(DiagnosisEditDTO diagnosisDTO)
        {
            int diagnosisId = 0;
            var task = Task.Run(async () =>
            {
                diagnosisId = await _diagnosisRepository.SaveDiagnosisAsync(diagnosisDTO);
            });
            task.Wait();
            return diagnosisId;
        }

        /// <inheritdoc/>
        public List<DiagnosisEditDTO> GetDiagnoses()
        {
            return _diagnosisRepository.GetDiagnoses();
        }

        /// <inheritdoc/>
        public DiagnosisEditDTO GetDiagnosisByName(string name)
        {
            var diagnosisDTO = _diagnosisRepository.GetDiagnosisByName(name);
            if (diagnosisDTO == null)
                return new DiagnosisEditDTO();
            else 
                return diagnosisDTO;
        }

        /// <inheritdoc/>
        public DiagnosisEditDTO GetDiagnosis(int? id)
        {
            var diagnosisDTO = _diagnosisRepository.GetDiagnosis(id);
            if (diagnosisDTO == null)
                return new DiagnosisEditDTO();
            else 
                return diagnosisDTO;
        }

        /// <inheritdoc/>
        public void RemoveDiagnosis(DiagnosisEditDTO diagnosisDTO)
        {
            _diagnosisRepository.RemoveDiagnosis(diagnosisDTO);
        }

        /// <inheritdoc/>
        public List<DiagnosisEditDTO> GetDiagnosesByName(string name)
        {
            return _diagnosisRepository.GetDiagnosesByName(name);
        }
    }

}
