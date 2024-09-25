using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class MalfunctionOrderEditDTO
    {
        public int MalfunctionId { get; set; }
        public virtual MalfunctionEditDTO? Malfunction { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }

        public MalfunctionOrderEditDTO()
        {
        }
    }
}
