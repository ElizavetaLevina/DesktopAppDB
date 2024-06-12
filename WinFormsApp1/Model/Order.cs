using FluentFTP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }
        public int? MasterId { get; set; }
        public virtual Master? Master { get; set; }
        public string? DateCreation { get; set; }
        public string? DateStartWork { get; set; }
        public string? DateCompleted { get; set; }
        public string? DateIssue {  get; set; } 
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
        public string? DateEndGuarantee { get; set; }
        public bool Deleted { get; set; }
        public bool ReturnUnderGuarantee { get; set; }
        public string? DateReturn { get; set; }
        public string? DateCompletedReturn { get; set; }
        public string? DateIssueReturn { get; set; }
        public bool Issue { get; set; }
        public virtual List<Malfunction>? Malfunction { get; set; }
        public virtual List<MalfunctionOrder>? MalfunctionOrders { get; set; }
        public string ColorRow { get; set; } = Color.Black.Name;
        public string? DateLastCall { get; set; }
        public bool PriceAgreed { get; set; }
        public int? MaxPrice { get; set; }
    }
}
