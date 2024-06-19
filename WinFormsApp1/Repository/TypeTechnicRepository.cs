using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class TypeTechnicRepository
    {
        /// <summary>
        /// Получение списка типов
        /// </summary>
        /// <returns>Список типов</returns>
        public List<TypeTechnicDTO> GetTypesTechnic()
        {
            Context context = new();
            return context.TypeTechnices.Select(a => new TypeTechnicDTO(a)).ToList();
        }

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Запись</returns>
        public TypeTechnicDTO GetTypeTechnic(string name)
        {
            Context context = new();
            return new TypeTechnicDTO(context.TypeTechnices.First(i => i.NameTypeTechnic == name));
        }

        public async Task<int> SaveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO, CancellationToken token = default)
        {
            using Context db = new();
            TypeTechnic typeTechnic = new()
            {
                Id = typeTechnicDTO.Id,
                NameTypeTechnic = typeTechnicDTO.Name
            };
            try
            {
                if (typeTechnic.Id == 0)
                    db.TypeTechnices.Add(typeTechnic);
                else
                    db.TypeTechnices.Update(typeTechnic);
                await db.SaveChangesAsync(token);
                return typeTechnic.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        public void RemoveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO)
        {
            try
            {
                using Context db = new();
                var typeTechnic = db.TypeTechnices.FirstOrDefault(c => c.Id == typeTechnicDTO.Id);
                db.TypeTechnices.Remove(typeTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
