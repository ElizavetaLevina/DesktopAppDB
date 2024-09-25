using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class TypeBrandDTO
    {
        public int BrandTechnicsId { get; set; }
        public int TypeTechnicsId { get; set; }
        public virtual BrandTechnicEditDTO? BrandTechnic { get; set; }
        public virtual TypeTechnicEditDTO? TypeTechnic { get; set; }

        public TypeBrandDTO()
        {
        }
    }
}
