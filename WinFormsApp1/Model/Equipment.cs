namespace WinFormsApp1.Model
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual List<Order>? Order { get; set; }
    }
}
