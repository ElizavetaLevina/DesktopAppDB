using WinFormsApp1.Enum;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public class Master
    {
        public int Id { get; set; }
        public string? NameMaster { get; set; }
        public string? Address {  get; set; }
        public string? NumberPhone { get; set; }
        public TypeSalaryEnum TypeSalary { get; set; }
        public int Rate { get; set; }

        public virtual List<Order>? MainOrder { get; set; }
        public virtual List<Order>? AdditionalOrder { get; set; }
        public virtual List<RateMaster>? RateMasters { get; set; }
        public virtual List<NoteSalaryMaster>? NoteMasters { get; set; }
    }
}
