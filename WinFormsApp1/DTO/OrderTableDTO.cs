﻿using System.ComponentModel;
using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class OrderTableDTO
    {
        [DisplayName("")]
        public int Id { get; set; }
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
        [DisplayName("")]
        public bool Deleted { get; set; }
        [DisplayName("")]
        public bool ReturnUnderGuarantee { get; set; }
        [DisplayName("")]
        public int Guarantee { get; set; }
        [DisplayName("")]
        public DateTime? DateEndGuarantee { get; set; }
        [DisplayName("")]
        public string ColorRow { get; set; } = Color.Black.Name;

        public OrderTableDTO()
        {

        }
    }
}
