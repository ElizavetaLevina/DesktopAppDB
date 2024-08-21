using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class NoteSalaryMasterRepository
    {
        /// <summary>
        /// Получение списка примечаний по зарплате мастера по дате
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Список примечаний</returns>
        public List<NoteSalaryMasterEditDTO> GetNoteSalaryMasters(DateTime date)
        {
            Context context = new();
            return context.NoteSalaryMasters.Where(i => i.Date == date).Select(a => new NoteSalaryMasterEditDTO(a)).ToList();
        } 

        public async Task SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO, CancellationToken token = default)
        {
            Context context = new();
            NoteSalaryMaster noteSalaryMaster = new()
            {
                Id = noteSalaryMasterDTO.Id,
                MasterId = noteSalaryMasterDTO.MasterId,
                Note = noteSalaryMasterDTO.Note,
                Date = noteSalaryMasterDTO.Date
            };

            try
            {
                if (noteSalaryMaster.Id == 0)
                    context.NoteSalaryMasters.Add(noteSalaryMaster);
                else
                    context.NoteSalaryMasters.Update(noteSalaryMaster);

                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
