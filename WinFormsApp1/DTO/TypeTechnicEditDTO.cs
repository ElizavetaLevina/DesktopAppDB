using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class TypeTechnicEditDTO
    {
        /// <summary>
        /// Редактирование типов устройств
        /// </summary>
        public int Id { get; set; }
        public string? Name { get; set; }

        public TypeTechnicEditDTO(TypeTechnic typeTechnic)
        {
            Id = typeTechnic.Id;
            Name = typeTechnic.NameTypeTechnic;
        }

        public TypeTechnicEditDTO(string name)
        {
            Name = name;
        }

        public TypeTechnicEditDTO()
        {
        }
    }
}
