using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class BrandTechnicRepository
    {
        /// <summary>
        /// Получение списка брендов
        /// </summary>
        /// <returns>Список брендов</returns>
        public List<BrandTechnicDTO> GetBrandsTechnic()
        {
            Context context = new();
            return context.BrandTechnices.OrderBy(i => i.NameBrandTechnic).Select(a => new BrandTechnicDTO(a)).ToList();
        }

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название бренда</param>
        /// <returns>Запись</returns>
        public BrandTechnicDTO GetBrandTechnicByName(string name)
        {
            Context context = new();
            return new BrandTechnicDTO(context.BrandTechnices.First(i => i.NameBrandTechnic == name));
        }

        /// <summary>
        /// Получение бренда устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Имя</param>
        /// <returns>Бренда устройства</returns>
        public BrandTechnicEditDTO GetBrandTechnic(int id, string name)
        {
            Context context = new();
            var brandTechnic = context.BrandTechnices.FirstOrDefault(i => i.Id == id);
            if (brandTechnic == null)
                return new BrandTechnicEditDTO(name);
            else return new BrandTechnicEditDTO(brandTechnic) { Name = name };
        }

        /// <summary>
        /// Получение названия бренда по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Бренд</returns>
        public string GetBrandTechnicName(int id)
        {
            Context context = new();
            var brandTechnic = context.BrandTechnices.FirstOrDefault(i => i.Id == id);
            if (brandTechnic == null)
                return string.Empty;
            else return brandTechnic.NameBrandTechnic;
        }

        public async Task<int> SaveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO, CancellationToken token = default)
        {
            using Context db = new();
            BrandTechnic brandTechnic = new()
            {
                Id = brandTechnicDTO.Id,
                NameBrandTechnic = brandTechnicDTO.Name
            };
            try
            {
                if (brandTechnic.Id == 0)
                    db.BrandTechnices.Add(brandTechnic);
                else
                    db.BrandTechnices.Update(brandTechnic);

                await db.SaveChangesAsync(token);
                return brandTechnic.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        public void RemoveBrandTechnic(BrandTechnicEditDTO brandTechnicDTO)
        {
            try
            {
                using Context db = new();
                var brandTechnic = db.BrandTechnices.FirstOrDefault(c => c.Id == brandTechnicDTO.Id);
                db.BrandTechnices.Remove(brandTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
