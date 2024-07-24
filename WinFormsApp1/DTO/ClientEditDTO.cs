using WinFormsApp1.Enum;

namespace WinFormsApp1.DTO
{
    public class ClientEditDTO
    {
        /// <summary>
        /// Редатикрование клиента
        /// </summary>
        public int Id { get; set; }
        public string? IdClient { get; set; }
        public string? NameAndAddressClient { get; set; }
        public string? NumberSecondPhone { get; set; }
        public TypeClientEnum TypeClient { get; set; }

        public ClientEditDTO(Client client)
        {
            Id = client.Id;
            IdClient = client.IdClient;
            NameAndAddressClient = client.NameAndAddressClient;
            NumberSecondPhone = client.NumberSecondPhone;
            TypeClient = client.TypeClient;
        }

        public ClientEditDTO()
        {
        }
    }
}
