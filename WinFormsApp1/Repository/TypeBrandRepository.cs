using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class TypeBrandRepository
    {
        /// <summary>
        /// Получение списка тип-бренд устройства по идентификатору бренда или типа устройства
        /// </summary>
        /// <param name="idBrand">Идентификатор бренда</param>
        /// <param name="idType">Идентификатор типа устройства</param>
        /// <returns>Список бренд-тип</returns>
        public List<TypeBrandDTO> GetTypeBrand(int idBrand = 0, int idType = 0)
        {
            Context context = new();

            var set = context.TypeBrands.Where(c => true);

            if (idBrand != 0 && idType != 0)
                set = set.Where(i => i.TypeTechnicsId == idType && i.BrandTechnicsId == idBrand);
            else if (idBrand == 0 && idType != 0)
                set = set.Where(i => i.TypeTechnicsId == idType);
            else if (idBrand != 0 && idType == 0)
                set = set.Where(i => i.BrandTechnicsId == idBrand);

            return set.Select(a => new TypeBrandDTO(a)).ToList();
        }

        public List<TypeBrandComboBoxDTO> GetTypeBrandByNameType(string nameType)
        {
            Context context = new();
            return context.TypeBrands.Where(i => i.TypeTechnic.NameTypeTechnic == nameType).Select(a => new TypeBrandComboBoxDTO(a)).ToList();
        }

        public async Task SaveTypeBrandAsync(TypeBrandDTO typeBrandDTO, CancellationToken token = default)
        {
            using Context db = new();
            TypeBrand typeBrand = new()
            {
                BrandTechnicsId = typeBrandDTO.BrandTechnicsId,
                TypeTechnicsId = typeBrandDTO.TypeTechnicsId
            };
            try
            {
                db.TypeBrands.Add(typeBrand);
                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        public void RemoveTypesBrands(TypeBrandDTO typeBrandDTO)
        {
            try
            {
                using Context db = new();
                var typeBrand = db.TypeBrands.FirstOrDefault(c => c.BrandTechnicsId == typeBrandDTO.BrandTechnicsId &&
                    c.TypeTechnicsId == typeBrandDTO.TypeTechnicsId);
                db.TypeBrands.Remove(typeBrand);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /*public void RemoveTypeBrand(TypeBrandEditDTO typeBrandEditDTO)
        {
            try
            {
                Context db = new();
                var typeBrand = db.TypeBrands.FirstOrDefault(i => i.)
            }
        }*/
    }
}
