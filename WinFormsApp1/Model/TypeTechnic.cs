namespace WinFormsApp1.Model
{
    public class TypeTechnic
    {
        public int Id { get; set; }
        public string? NameTypeTechnic { get; set; }
        public virtual List<BrandTechnic>? BrandTechnics { get; set; }
        public virtual List<TypeBrand>? TypeBrands { get; set; }
        public virtual List<Order>? Order { get; set; }
    }
}
