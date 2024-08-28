﻿using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class TypeBrandComboBoxDTO
    {
        public int IdBrand {  get; set; }
        public string? NameBrandTechnic {  get; set; }

        public TypeBrandComboBoxDTO(TypeBrand typeBrand)
        {
            IdBrand = typeBrand.BrandTechnicsId;
            NameBrandTechnic = typeBrand.BrandTechnic?.NameBrandTechnic;
        }
    }
}
