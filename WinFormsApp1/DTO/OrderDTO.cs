using System.ComponentModel;
using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class OrderDTO
    {
        [DisplayName("№")]
        public int Id { get; set; }
        [DisplayName("Дата приема")]
        public string? DateCreation { get; set; }
        [DisplayName("Дата начала ремонта")] 
        public string? DateStartWork { get; set; }
        [DisplayName("Дата окончания ремонта")]
        public string? DateCompleted { get; set; }
        [DisplayName("Дата выдачи аппарата")]
        public string? DateIssue { get; set; }
        [DisplayName("Мастер")]
        public string? MasterName { get; set; }
        [DisplayName("Тип аппарата/Производитель/Модель")]
        public string? NameDevice { get; set; }
        [DisplayName("Заказчик")]
        public string? IdClient { get; set; }
        [DisplayName("Диагноз")]
        public string? Diagnosis { get; set; }
        [DisplayName("")]
        public bool Deleted { get; set; }
        [DisplayName("")]
        public bool ReturnUnderGuarantee { get; set; }
        [DisplayName("")]
        public int Guarantee { get; set; }
        [DisplayName("")]
        public string? DateEndGuarantee { get; set; }
        //public DateTime? DateEndGuaranteeDT 
        //{
        //    get
        //    {
        //        return !string.IsNullOrEmpty(DateEndGuarantee) ? DateTime.Parse(DateEndGuarantee) : null;
        //    }
        //}
        [DisplayName("")]
        public string ColorRow { get; set; } = Color.Black.Name;

        public OrderDTO(Order order)
        {
            Id = order.Id;
            DateCreation = order.DateCreation;
            DateStartWork = order.DateStartWork;
            DateCompleted = order.DateCompleted;
            DateIssue = order.DateIssue;
            MasterName = order.Master?.NameMaster;
            NameDevice = String.Format("{0} {1} {2}", order.TypeTechnic?.NameTypeTechnic,
                order.BrandTechnic?.NameBrandTechnic, order.ModelTechnic);
            IdClient = order.Client?.IdClient;
            Diagnosis = order.Diagnosis?.Name;
            Deleted = order.Deleted;
            ReturnUnderGuarantee = order.ReturnUnderGuarantee;
            Guarantee = order.Guarantee;
            DateEndGuarantee = order.DateEndGuarantee;
            ColorRow = order.ColorRow;
        }
    }
}
