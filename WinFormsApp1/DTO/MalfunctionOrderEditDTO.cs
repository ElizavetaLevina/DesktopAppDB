using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class MalfunctionOrderEditDTO
    {
        public int MalfunctionId { get; set; }
        public virtual MalfunctionEditDTO? Malfunction { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }

        public MalfunctionOrderEditDTO(MalfunctionOrder malfunctionOrder)
        {
            MalfunctionId = malfunctionOrder.MalfunctionId;
            Malfunction = new MalfunctionEditDTO(malfunctionOrder.Malfunction);
            OrderId = malfunctionOrder.OrderId;
            Price = malfunctionOrder.Price;
        }

        public MalfunctionOrderEditDTO()
        {
        }
    }
}
