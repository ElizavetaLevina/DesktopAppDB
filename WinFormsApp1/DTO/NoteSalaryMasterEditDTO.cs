using System.ComponentModel;
using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class NoteSalaryMasterEditDTO
    {
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public int MasterId { get; set; }
        [DisplayName("Мастер")]
        public string NameMaster { get; set; }
        [DisplayName("Зарплата")]
        public int Salary { get; set; }
        [DisplayName("Примечание")]
        public string? Note { get; set; }
        [Browsable(false)]
        public DateTime Date { get; set; }

        public NoteSalaryMasterEditDTO(NoteSalaryMaster noteSalaryMaster) 
        {
            Id = noteSalaryMaster.Id;
            MasterId = noteSalaryMaster.MasterId;
            Note = noteSalaryMaster.Note;
            Date = noteSalaryMaster.Date;
        }

        public NoteSalaryMasterEditDTO()
        {
        }
    }
}
