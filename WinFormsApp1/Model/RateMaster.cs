namespace WinFormsApp1.Model
{
    public class RateMaster
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public virtual Master? Master { get; set; }
        public int PercentProfit { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? Note { get; set; }
    }
}
