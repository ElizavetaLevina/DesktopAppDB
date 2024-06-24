using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class MalfunctionOrderEditDTO
    {
        public int MalfunctionId { get; set; }
        public virtual Malfunction? Malfunction { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public int Price { get; set; }

        public MalfunctionOrderEditDTO(MalfunctionOrder malfunctionOrder)
        {
            MalfunctionId = malfunctionOrder.MalfunctionId;
            OrderId = malfunctionOrder.OrderId;
            Price = malfunctionOrder.Price;
        }

        public MalfunctionOrderEditDTO()
        {
        }
    }
}
