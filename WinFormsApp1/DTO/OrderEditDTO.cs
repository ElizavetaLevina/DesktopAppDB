using WinFormsApp1.Enum;
using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    /// <summary>
    /// Редактирование заказа
    /// </summary>
    public class OrderEditDTO
    {
        public int Id { get; set; }
        public int NumberOrder { get; set; }
        public int ClientId { get; set; }
        public virtual ClientEditDTO? Client { get; set; }
        public int? MainMasterId { get; set; }
        public int PercentWorkMainMaster { get; set; } = 0;
        public virtual MasterEditDTO? MainMaster { get; set; }
        public int? AdditionalMasterId { get; set; }
        public int PercentWorkAdditionalMaster { get; set; } = 0;
        public virtual MasterEditDTO? AdditionalMaster { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateStartWork { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? DateIssue { get; set; }
        public int TypeTechnicId { get; set; }
        public virtual TypeTechnicEditDTO? TypeTechnic { get; set; }
        public int BrandTechnicId { get; set; }
        public virtual BrandTechnicEditDTO? BrandTechnic { get; set; }
        public string? ModelTechnic { get; set; }
        public string? FactoryNumber { get; set; }
        public int? EquipmentId { get; set; }
        public virtual EquipmentEditDTO? Equipment { get; set; }
        public int? DiagnosisId { get; set; }
        public virtual DiagnosisEditDTO? Diagnosis { get; set; }
        public string? Note { get; set; }
        public StatusOrderEnum StatusOrder { get; set; }
        //public bool InProgress { get; set; } = true;
        public int Guarantee { get; set; } = 0;
        public DateTime? DateEndGuarantee { get; set; }
        public bool Deleted { get; set; } = false;
        public bool ReturnUnderGuarantee { get; set; } = false;
        public DateTime? DateReturn { get; set; }
        public DateTime? DateCompletedReturn { get; set; }
        public DateTime? DateIssueReturn { get; set; }
        //public bool Issue { get; set; } = false;
        public virtual List<MalfunctionOrder>? MalfunctionOrders { get; set; }
        public virtual List<Warehouse>? Details { get; set; }
        public string ColorRow { get; set; } = Color.Black.Name;
        public string? DateLastCall { get; set; }
        public bool PriceAgreed { get; set; } = false;
        public int? MaxPrice { get; set; }

        public OrderEditDTO()
        {
        }
    }
}
