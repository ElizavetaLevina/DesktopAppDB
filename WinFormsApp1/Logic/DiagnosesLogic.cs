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
        public async Task<int> SaveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO)
        {
            return await _diagnosisRepository.SaveDiagnosisAsync(diagnosisDTO);
        }

        /// <inheritdoc/>
        public async Task<List<DiagnosisEditDTO>> GetDiagnosesAsync()
        {
            return await _diagnosisRepository.GetDiagnosesAsync();
        }

        /// <inheritdoc/>
        public async Task<DiagnosisEditDTO> GetDiagnosisByNameAsync(string name)
        {
            var diagnosisDTO = await _diagnosisRepository.GetDiagnosisByNameAsync(name);
            if (diagnosisDTO == null)
                return new DiagnosisEditDTO();
            else 
                return diagnosisDTO;
        }

        /// <inheritdoc/>
        public async Task<DiagnosisEditDTO> GetDiagnosisAsync(int? id)
        {
            var diagnosisDTO = await _diagnosisRepository.GetDiagnosisAsync(id);
            if (diagnosisDTO == null)
                return new DiagnosisEditDTO();
            else 
                return diagnosisDTO;
        }

        /// <inheritdoc/>
        public async Task RemoveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO)
        {
            await _diagnosisRepository.RemoveDiagnosisAsync(diagnosisDTO);
        }

        /// <inheritdoc/>
        public async Task<List<DiagnosisEditDTO>> GetDiagnosesByNameAsync(string name)
        {
            return await _diagnosisRepository.GetDiagnosesByNameAsync(name);
        }
    }

}
