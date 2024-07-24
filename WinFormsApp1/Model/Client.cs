using WinFormsApp1.Enum;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public class Client
    {
        public int Id { get; set; }
        public string? IdClient {  get; set; }
        public string? NameAndAddressClient { get; set; }
        public string? NumberSecondPhone {  get; set; }
        public TypeClientEnum TypeClient { get; set; }
        public virtual List<Order>? Order { get; set; }
    }
}
