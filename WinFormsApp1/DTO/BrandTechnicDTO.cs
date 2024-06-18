using System.ComponentModel;
using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class BrandTechnicDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string? NameBrandTechnic { get; set; }

        public BrandTechnicDTO(Model.BrandTechnic brandTechnic)
        {
            Id = brandTechnic.Id;
            NameBrandTechnic = brandTechnic.NameBrandTechnic;
        }
    }
}
