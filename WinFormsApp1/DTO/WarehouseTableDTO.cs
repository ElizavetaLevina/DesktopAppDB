using System.ComponentModel;

namespace WinFormsApp1.DTO
{
    public class WarehouseTableDTO
    {
        [DisplayName("№")]
        public int Id { get; set; }
        [DisplayName("Название детали")]
        public string NameDetail { get; set; }
        [DisplayName("Цена покупки")]
        public int PricePurchase { get; set; }
        [DisplayName("Цена продажи")]
        public int PriceSale { get; set; }
        [DisplayName("Дата покупки")]
        public string DatePurchase { get; set; }
        public bool Availability { get; set; }
        public int? IdOrder { get; set; }

        public WarehouseTableDTO() { }
    }
}
