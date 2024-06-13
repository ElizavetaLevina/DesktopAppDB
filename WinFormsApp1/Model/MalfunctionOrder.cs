namespace WinFormsApp1.Model
{
    public class MalfunctionOrder
    {
        public int MalfunctionId { get; set; }
        public virtual Malfunction? Malfunction { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public int Price { get; set; }
    }
}
