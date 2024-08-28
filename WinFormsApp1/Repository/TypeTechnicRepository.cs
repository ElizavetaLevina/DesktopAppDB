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
            return context.TypeTechnices.OrderBy(i => i.NameTypeTechnic).Select(a => new TypeTechnicDTO(a)).ToList();
        }

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Запись</returns>
        public TypeTechnicDTO GetTypeTechnicByName(string name)
        {
            Context context = new();
            return new TypeTechnicDTO(context.TypeTechnices.First(i => i.NameTypeTechnic == name));
        }


        /// <summary>
        /// Получение типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Тип устройства</returns>
        public TypeTechnicEditDTO GetTypeTechnic(int id, string name)
        {
            Context context = new();
            var typeTechnic = context.TypeTechnices.FirstOrDefault(i => i.Id == id);
            if (typeTechnic == null)
                return new TypeTechnicEditDTO(name);
            else return new TypeTechnicEditDTO(typeTechnic) { Name = name };
        }

        /// <summary>
        /// Получение названия типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Тип устройства</returns>
        public string GetTypeTechnicName(int id)
        {
            Context context = new();
            var typeTechnic = context.TypeTechnices.FirstOrDefault(i => i.Id == id);
            if (typeTechnic == null)
                return string.Empty;
            else return typeTechnic.NameTypeTechnic;
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
