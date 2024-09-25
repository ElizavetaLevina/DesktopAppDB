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
        public List<NoteSalaryMasterEditDTO> GetNoteSalaryMasters(DateTime date)
        {
            return _noteSalaryMasterRepository.GetNoteSalaryMasters(date);
        }

        /// <inheritdoc/>
        public void SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO)
        {
            Task.Run(async () =>
            {
                await _noteSalaryMasterRepository.SaveNoteSalaryMasterAsync(noteSalaryMasterDTO);
            });
        }
    }
}
