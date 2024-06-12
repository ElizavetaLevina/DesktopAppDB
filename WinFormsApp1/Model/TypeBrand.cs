namespace WinFormsApp1.Model
{
    public class TypeBrand
    {
        public int BrandTechnicsId { get; set; }
        public virtual BrandTechnic? BrandTechnic { get; set; }
        public int TypeTechnicsId { get; set; }
        public virtual TypeTechnic? TypeTechnic { get; set; }

    }
}
