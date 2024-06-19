using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public class Client
    {
        public int Id { get; set; }
        public string? IdClient {  get; set; }
        public string? NameAndAddressClient { get; set; }
        public string? NumberSecondPhone {  get; set; }
        public string TypeClient { get; set; } = "normal";
        public virtual List<Order>? Order { get; set; }
    }
}
