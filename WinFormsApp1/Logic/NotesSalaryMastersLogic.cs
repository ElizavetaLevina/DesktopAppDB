using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class NotesSalaryMastersLogic : INotesSalaryMastersLogic
    {
        INoteSalaryMasterRepository _noteSalaryMasterRepository;


        public NotesSalaryMastersLogic(INoteSalaryMasterRepository noteSalaryMasterRepository)
        {
            _noteSalaryMasterRepository = noteSalaryMasterRepository;
        }

        /// <inheritdoc/>
        public async Task<List<NoteSalaryMasterEditDTO>> GetNoteSalaryMastersAsync(DateTime date)
        {
            return await _noteSalaryMasterRepository.GetNoteSalaryMastersAsync(date);
        }

        /// <inheritdoc/>
        public async Task SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO)
        {
            await _noteSalaryMasterRepository.SaveNoteSalaryMasterAsync(noteSalaryMasterDTO);
        }
    }
}
