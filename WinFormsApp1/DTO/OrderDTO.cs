using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public string? MasterName { get; set; }
        public string? DateCreation { get; set; }
        public string? DateStartWork { get; set; }
        public string? DateCompleted { get; set; }
        public string? DateIssue { get; set; }
        public string? NameDevice { get; set; }
        public int TypeTechnicName { get; set; }
        public int BrandTechnicName { get; set; }
        public string? ModelTechnic { get; set; }
        public string? FactoryNumber { get; set; }
        public string? Equipment { get; set; }
        public string? Diagnosis { get; set; }
        public string? Note { get; set; }
        public bool InProgress { get; set; }
        public int Guarantee { get; set; }
        public string? DateEndGuarantee { get; set; }
        public bool Deleted { get; set; }
        public bool ReturnUnderGuarantee { get; set; }
        public string? DateReturn { get; set; }
        public string? DateCompletedReturn { get; set; }
        public string? DateIssueReturn { get; set; }
        public bool Issue { get; set; }
        public List<Malfunction>? Malfunction { get; set; }
        public List<MalfunctionOrder>? MalfunctionOrders { get; set; }
        public string ColorRow { get; set; } = Color.Black.Name;
        public string? DateLastCall { get; set; }
        public bool PriceAgreed { get; set; }
        public int? MaxPrice { get; set; }

        public OrderDTO(Order order)
        {
            Id = order.Id;
            DateCreation = order.DateCreation;
            DateStartWork = order.DateStartWork;
            DateCompleted = order.DateCompleted;
            DateIssue = order.DateIssue;
            MasterName = order.Master?.NameMaster;
            NameDevice = String.Format("{0} {1} {2}", order.TypeTechnic?.NameTypeTechnic,
                order.BrandTechnic?.NameBrandTechnic, ModelTechnic);
            ClientName = order.Client?.NameClient;
            Diagnosis = order.Diagnosis?.Name;
            Deleted = order.Deleted;
            ReturnUnderGuarantee = order.ReturnUnderGuarantee;
            Guarantee = order.Guarantee;
            DateEndGuarantee = order.DateEndGuarantee;
            ColorRow = order.ColorRow;
        }
    }
}
