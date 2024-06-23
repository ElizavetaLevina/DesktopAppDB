using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class MalfunctionEditDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }

        public MalfunctionEditDTO(Malfunction malfunction)
        {
            Id = malfunction.Id;
            Name = malfunction.Name;
            Price = malfunction.Price;
        }

        public MalfunctionEditDTO(string name)
        {
            Name = name;
        }

        public MalfunctionEditDTO()
        {
        }
    }
}
