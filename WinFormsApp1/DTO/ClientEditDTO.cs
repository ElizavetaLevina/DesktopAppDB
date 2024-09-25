using WinFormsApp1.Enum;

namespace WinFormsApp1.DTO
{
    /// <summary>
    /// Редатикрование клиента
    /// </summary>
    public class ClientEditDTO
    {
        public int Id { get; set; }
        public string? IdClient { get; set; }
        public string? NameAndAddressClient { get; set; }
        public string? NumberSecondPhone { get; set; }
        public TypeClientEnum TypeClient { get; set; }

        public ClientEditDTO()
        {
        }
    }
}
