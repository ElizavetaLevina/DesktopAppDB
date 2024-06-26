﻿namespace WinFormsApp1.Model
{
    public class BrandTechnic
    {
        public int Id { get; set; }
        public string? NameBrandTechnic { get; set; }
        public virtual List<TypeTechnic>? TypeTechnics { get; set; }
        public virtual List<TypeBrand>? TypeBrands { get; set; }
        public virtual List<Order>? Order { get; set; }
    }
}
