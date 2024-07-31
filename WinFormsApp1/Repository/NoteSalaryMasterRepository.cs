using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class NoteSalaryMasterRepository
    {

        public async Task SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO, CancellationToken token = default)
        {
            Context db = new();
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
                    db.NoteSalaryMasters.Add(noteSalaryMaster);
                else
                    db.NoteSalaryMasters.Update(noteSalaryMaster);

                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        public async Task RemoveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO, CancellationToken token = default)
        {
            Context db = new();
            try
            {
                var noteSalaryMaster = db.NoteSalaryMasters.FirstOrDefault(c => c.Id == noteSalaryMasterDTO.Id);
                db.NoteSalaryMasters.Remove(noteSalaryMaster);
                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
