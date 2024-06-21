using System.ComponentModel;
using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class TypeTechnicDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string? NameTypeTechnic { get; set; }

        public TypeTechnicDTO(TypeTechnic typeTechnic)
        {
            Id = typeTechnic.Id;
            NameTypeTechnic = typeTechnic.NameTypeTechnic;
        }
    }
}
