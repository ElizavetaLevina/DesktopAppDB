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
    }
}
