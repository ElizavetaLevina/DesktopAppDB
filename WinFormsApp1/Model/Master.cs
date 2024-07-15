using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public class Master
    {
        public int Id { get; set; }
        public string? NameMaster { get; set; }
        public string? Address {  get; set; }
        public string? NumberPhone { get; set; }
        public string TypeSalary { get; set; } = "rate";
        public int Rate { get; set; }

        public virtual ICollection<Order>? MainOrder { get; set; }
        public virtual ICollection<Order>? AdditionalOrder { get; set; }
    }
}
