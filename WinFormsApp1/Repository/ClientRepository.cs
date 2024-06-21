using System.Net.Sockets;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class ClientRepository
    {
        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Запись</returns>
        public ClientEditDTO GetClient(int id)
        {
            Context context = new();
            return new ClientEditDTO(context.Clients.First(i => i.Id == id));
        }

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <returns>Список клиентов</returns>
        public List<ClientEditDTO> GetClients()
        {
            Context context = new();
            return context.Clients.Select(a => new ClientEditDTO(a)).ToList();
        }

        /// <summary>
        /// Получение списка клиентов для справочника
        /// </summary>
        /// <returns>Список клиентов</returns>
        public List<ClientDTO> GetClientsForTable()
        {
            Context context = new();
            return context.Clients
                .Select(a => new ClientDTO(a))
                .ToList();
        }

        /// <summary>
        /// Получение списка клиентов по типу
        /// </summary>
        /// <param name="typeClient">Тип клиента</param>
        /// <returns>Спиок клиентов</returns>
        public List<ClientDTO> GetClientsByType(string typeClient) 
        {
            Context context = new();
            return context.Clients
                .Where(i => i.TypeClient == typeClient)
                .Select(a => new ClientDTO(a))
                .ToList();
        }

        public bool CheckClientByIdClient(string idClient)
        {
            Context context = new();
            return context.Clients.Any(a => a.IdClient == idClient);
        }

        public List<ClientDTO> GetClientsByIdClient(string idClient)
        {
            Context context = new();
            return context.Clients
                .Where(i => i.IdClient.Contains(idClient))
                .Select(a => new ClientDTO(a))
                .ToList();
        }

        public async Task<int> SaveClientAsync(ClientEditDTO clientDTO, CancellationToken token = default)
        {
            Context db = new();
            Client client = new()
            {
                Id = clientDTO.Id,
                IdClient = clientDTO.IdClient,
                NameAndAddressClient = clientDTO.NameAndAddressClient,
                NumberSecondPhone = clientDTO.NumberSecondPhone,
                TypeClient = clientDTO.TypeClient
            };
            try
            {
                if (client.Id == 0)
                    db.Clients.Add(client);
                else
                    db.Clients.Update(client);

                await db.SaveChangesAsync(token);
                return client.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
