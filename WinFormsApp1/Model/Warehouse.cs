namespace WinFormsApp1.Model
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string NameDetail { get; set; } = string.Empty;
        public int PricePurchase { get; set; }
        public int PriceSale { get; set; }
        public DateTime DatePurchase { get; set; } = DateTime.Now;
        public bool Availability { get; set; }
        public int? IdOrder {  get; set; }
        public virtual Details? Details { get; set; }
    }
}
