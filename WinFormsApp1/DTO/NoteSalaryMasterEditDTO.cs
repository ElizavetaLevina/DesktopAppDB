using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class NoteSalaryMasterEditDTO
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string? Note { get; set; }
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
