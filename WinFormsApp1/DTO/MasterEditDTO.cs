using WinFormsApp1.Enum;

namespace WinFormsApp1.DTO
{
    public class MasterEditDTO
    {
        /// <summary>
        /// Редактирование мастера
        /// </summary>
        public int Id { get; set; }
        public string? NameMaster { get; set; }
        public string? Address { get; set; }
        public string? NumberPhone { get; set; }
        public TypeSalaryEnum TypeSalary { get; set; }
        public int Rate { get; set; }

        public MasterEditDTO()
        {
        }
    }
}
