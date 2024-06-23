namespace WinFormsApp1.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int NumberOrder { get; set; }
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }
        public int? MasterId { get; set; }
        public virtual Master? Master { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateStartWork { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? DateIssue {  get; set; } 
        public int TypeTechnicId { get; set; }
        public virtual TypeTechnic? TypeTechnic { get; set; }
        public int BrandTechnicId { get; set; }
        public virtual BrandTechnic? BrandTechnic { get; set; }
        public string? ModelTechnic { get; set; }
        public string? FactoryNumber { get; set; }
        public int? EquipmentId { get; set; }
        public virtual Equipment? Equipment { get; set; }
        public int? DiagnosisId { get; set; }
        public virtual Diagnosis? Diagnosis { get; set; }
        public string? Note { get; set; }
        public bool InProgress { get; set; }
        public int Guarantee { get; set; }
        public DateTime? DateEndGuarantee { get; set; }
        public bool Deleted { get; set; }
        public bool ReturnUnderGuarantee { get; set; }
        public DateTime? DateReturn { get; set; }
        public DateTime? DateCompletedReturn { get; set; }
        public DateTime? DateIssueReturn { get; set; }
        public bool Issue { get; set; }
        public virtual List<Malfunction>? Malfunction { get; set; }
        public virtual List<MalfunctionOrder>? MalfunctionOrders { get; set; }
        public virtual List<Warehouse>? Details { get; set; }
        public string ColorRow { get; set; } = Color.Black.Name;
        public string? DateLastCall { get; set; }
        public bool PriceAgreed { get; set; }
        public int? MaxPrice { get; set; }
    }
}
