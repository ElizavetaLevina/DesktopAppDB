using System.ComponentModel;

namespace WinFormsApp1.DTO
{
    public class ClientDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("ID клиента")]
        public string? IdClient { get; set; }
        [DisplayName("ФИО, адрес")]
        public string? NameAndAddressClient { get; set; }
        [DisplayName("Дополнительный телефон")]
        public string? NumberSecondPhone { get; set; }

        public ClientDTO(Client client)
        {
            Id = client.Id;
            IdClient = client.IdClient;
            NameAndAddressClient = client.NameAndAddressClient;
            NumberSecondPhone = client.NumberSecondPhone;
        }

        public ClientDTO()
        {
        }
    }
}
