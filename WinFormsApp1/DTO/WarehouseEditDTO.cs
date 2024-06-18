﻿using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    /// <summary>
    /// Редактирование деталей на складе
    /// </summary>
    public class WarehouseEditDTO
    {
        public int Id { get; set; }
        public string NameDetail { get; set; }
        public int PricePurchase { get; set; }
        public int PriceSale { get; set; }
        public DateTime DatePurchase { get; set; }
        public bool Availability { get; set; }
        public int? IdOrder { get; set; }

        public WarehouseEditDTO() { }

        public WarehouseEditDTO(Warehouse warehouse)
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
