﻿using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class TypeBrandDTO
    {
        public int BrandTechnicsId { get; set; }
        public int TypeTechnicsId { get; set; }
        public virtual BrandTechnic? BrandTechnic { get; set; }
        public virtual TypeTechnic? TypeTechnic { get; set; }


        public TypeBrandDTO(TypeBrand typeBrand)
        {
            BrandTechnicsId = typeBrand.BrandTechnicsId;
            TypeTechnicsId = typeBrand.TypeTechnicsId;
            BrandTechnic = typeBrand.BrandTechnic;
            TypeTechnic = typeBrand.TypeTechnic;
        }
    }
}
