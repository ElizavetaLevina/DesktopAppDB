using System.ComponentModel;
using WinFormsApp1.Model;
using WinFormsApp1.Enum;

namespace WinFormsApp1.DTO
{
    public class RateMasterDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Мастер")]
        public string? MasterName { get; set; }
        [DisplayName("Месяц | Год")]
        public string MonthYear { get; set; }
        [DisplayName("Процет прибыли")]
        public int PercentProfit {  get; set; }

        public RateMasterDTO() { }
    }
}
