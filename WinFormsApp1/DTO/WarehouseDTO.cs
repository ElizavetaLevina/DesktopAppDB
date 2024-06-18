using System.ComponentModel;
using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class WarehouseDTO
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
        public DateTime DatePurchase { get; set; }
        public bool Availability { get; set; }
        public int? IdOrder { get; set; }

        public WarehouseDTO(Warehouse warehouse) 
        {
            Id = warehouse.Id;
            NameDetail = warehouse.NameDetail;
            PricePurchase = warehouse.PricePurchase;
            PriceSale = warehouse.PriceSale;
            DatePurchase = warehouse.DatePurchase;
            Availability = warehouse.Availability;
            IdOrder = warehouse.IdOrder;
        }
    }
}
