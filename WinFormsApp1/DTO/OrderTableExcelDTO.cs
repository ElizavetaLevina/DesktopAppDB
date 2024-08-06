using System.ComponentModel;

namespace WinFormsApp1.DTO
{
    public class OrderTableExcelDTO
    {
        [DisplayName("№")]
        public int NumberOrder { get; set; }
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

        public OrderTableExcelDTO(OrderTableDTO order)
        {
            NumberOrder = order.NumberOrder;
            DateCreation = order.DateCreation;
            DateStartWork = order.DateStartWork;
            DateCompleted = order.DateCompleted;
            DateIssue = order.DateIssue;
            MasterName = order.MasterName;
            NameDevice = order.NameDevice;
            IdClient = order.IdClient;
            Diagnosis = order.Diagnosis;
        }
    }
}
