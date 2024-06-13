namespace WinFormsApp1.Model
{
    public class Malfunction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public virtual List<Order>? Orders { get; set; }
        public virtual List<MalfunctionOrder>? MalfunctionOrders { get; set; }
    }
}
