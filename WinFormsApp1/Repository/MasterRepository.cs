using DocumentFormat.OpenXml.Drawing.Charts;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class MasterRepository
    {
        /// <summary>
        /// Получение списка мастеров
        /// </summary>
        /// <returns>Список мастеров</returns>
        public List<MasterDTO> GetMasters()
        {
            Context context = new();
            return context.Masters.Select(c => new MasterDTO(c)).ToList();
        }

        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Запись</returns>
        public MasterEditDTO GetMaster(int id)
        {
            Context context = new();
            return new MasterEditDTO(context.Masters.First(i => i.Id == id));
        }

        public async Task SaveMasterAsync(MasterEditDTO masterDTO, CancellationToken token = default)
        {
            using Context db = new();
            Master master = new()
            {
                Id = masterDTO.Id,
                NameMaster = masterDTO.NameMaster,
                Address = masterDTO.Address,
                NumberPhone = masterDTO.NumberPhone,
                TypeSalary = masterDTO.TypeSalary,
                Rate = masterDTO.Rate
            };
            try
            {
                if (master.Id == 0)
                    db.Masters.Add(master);
                else
                {
                    db.Masters.Update(master);
                }

                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        public void RemoveMaster(MasterEditDTO masterDTO)
        {
            try
            {
                using Context db = new();
                var master = db.Masters.FirstOrDefault(c => c.Id == masterDTO.Id);
                db.Masters.Remove(master);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
