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
        public string TypeSalary { get; set; } = "rate";
        public int Rate { get; set; }

        public MasterEditDTO(Master master)
        {
            Id = master.Id;
            NameMaster = master.NameMaster;
            Address = master.Address;
            NumberPhone = master.NumberPhone;
            TypeSalary = master.TypeSalary;
            Rate = master.Rate;
        }

        public MasterEditDTO()
        {
        }
    }
}
