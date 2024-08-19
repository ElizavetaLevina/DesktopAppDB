using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class ClientsLogic
    {
        ClientRepository clientRepository = new();
        public void SetTypeClient(string idClient, TypeClientEnum typeClient)
        {
            var clientDTO = clientRepository.GetClient(idClient);
            clientDTO.TypeClient = typeClient;
            var task = Task.Run(async () =>
            {
                await clientRepository.SaveClientAsync(clientDTO);
            });
            task.Wait();
        }

        public int SaveClient(string idClient, string nameAdress, string secondPhone)
        {
            var clientDTO = clientRepository.GetClientByIdClient(idClient);
            int id = clientDTO.Id;
            if (id == 0)
            {
                clientDTO.IdClient = idClient;
                clientDTO.NameAndAddressClient = nameAdress;
                clientDTO.NumberSecondPhone = secondPhone;

                var task = Task.Run(async () =>
                {
                    id = await clientRepository.SaveClientAsync(clientDTO);
                });
                task.Wait();
            }
            return id;
        }

        public List<ClientEditDTO> GetClients()
        {
            return clientRepository.GetClients();
        }
    }
}
