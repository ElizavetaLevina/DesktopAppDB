using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class BrandTechnicRepository
    {
        /// <summary>
        /// Получение списка брендов
        /// </summary>
        /// <param name="whole">Весь список</param>
        /// <param name="name">Название бренда</param>
        /// <returns>Список брендов</returns>
        public List<BrandTechnicDTO> GetBrandTechnics(bool whole = true, string name = "")
        {
            Context context = new();
            var set = context.BrandTechnices.Where(c => true);
            if (!whole)
                set = set.Where(c => c.NameBrandTechnic == name);
            return set
                .Select(a => new BrandTechnicDTO(a))
                .ToList();
        }

        public async Task SaveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO, CancellationToken token = default)
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
                {
                    db.BrandTechnices.Update(brandTechnic);
                }

                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); throw; }
        }

        public void RemoveBrandTechnic(BrandTechnicEditDTO brandTechnicDTO)
        {
            using Context db = new();
            BrandTechnic brandTechnic = new() { Id = brandTechnicDTO.Id };
            try
            {
                db.BrandTechnices.Remove(brandTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); throw; }
        }
    }
}
