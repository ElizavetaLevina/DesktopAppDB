namespace WinFormsApp1.Model
{
    public class NoteSalaryMaster
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public virtual Master? Master { get; set; }
        public string? Note {  get; set; }
        public DateTime Date { get; set; }
    }
}
