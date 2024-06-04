

namespace WinFormsApp1.Model
{
    public class TypeTechnic
    {
        public int Id { get; set; }
        public string? NameTypeTechnic { get; set; }
        public List<BrandTechnic>? BrandTechnics { get; set; }
        public List<TypeBrand>? TypeBrands { get; set; }
        public List<Order>? Order { get; set; }
    }
}
