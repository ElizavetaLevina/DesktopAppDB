using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class BrandTechnicEditDTO
    {
        /// <summary>
        /// Редактирование брендов
        /// </summary>
        public int Id { get; set; }
        public string? Name { get; set; }

        public BrandTechnicEditDTO(BrandTechnic brandTechnic)
        {
            Id = brandTechnic.Id;
            Name = brandTechnic.NameBrandTechnic;
        }

        public BrandTechnicEditDTO(string name)
        {
            Name = name;
        }

        public BrandTechnicEditDTO()
        {
        }
    }
}
