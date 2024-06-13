namespace WinFormsApp1.Model
{
    public class Details
    {
        public int Id { get; set; }
        public virtual List<int>? IdWarehouse { get; set; }
        public virtual List<Warehouse>? Warehouse { get; set; }
    }
}
