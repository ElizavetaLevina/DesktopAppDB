namespace WinFormsApp1.DTO
{
    public class ClientEditDTO
    {
        public int Id { get; set; }
        public string? IdClient { get; set; }
        public string? NameAndAddressClient { get; set; }
        public string? NumberSecondPhone { get; set; }
        public string TypeClient { get; set; } = "normal";

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
