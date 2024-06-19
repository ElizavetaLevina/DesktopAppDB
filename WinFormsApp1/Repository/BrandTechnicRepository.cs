using DocumentFormat.OpenXml.Drawing.Diagrams;
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
            return context.BrandTechnices.Select(a => new BrandTechnicDTO(a)).ToList();
        }

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название бренда</param>
        /// <returns>Запись</returns>
        public BrandTechnicDTO GetBrandTechnic(string name)
        {
            Context context = new();
            return new BrandTechnicDTO(context.BrandTechnices.First(i => i.NameBrandTechnic == name));
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
