using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class TypeBrandDTO
    {
        public int BrandTechnicsId { get; set; }
        public int TypeTechnicsId { get; set; }
        public virtual BrandTechnicEditDTO? BrandTechnic { get; set; }
        public virtual TypeTechnicEditDTO? TypeTechnic { get; set; }


        public TypeBrandDTO(TypeBrand typeBrand)
        {
            BrandTechnicsId = typeBrand.BrandTechnicsId;
            TypeTechnicsId = typeBrand.TypeTechnicsId;
            BrandTechnic = new BrandTechnicEditDTO(typeBrand.BrandTechnic);
            TypeTechnic = new TypeTechnicEditDTO(typeBrand.TypeTechnic);
        }
    }
}
