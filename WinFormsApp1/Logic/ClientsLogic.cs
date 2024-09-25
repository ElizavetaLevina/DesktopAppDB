using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class ClientsLogic : IClientsLogic
    {
        IClientRepository _clientRepository;
        public ClientsLogic(IClientRepository clientRepository) {

            _clientRepository = clientRepository;
        }


        /// <inheritdoc/>
        public ClientEditDTO GetClientByIdClient(string idClient)
        {
            var clientDTO = _clientRepository.GetClientByIdClient(idClient);
            if (clientDTO == null)
                return new ClientEditDTO();
            else
                return clientDTO;
        }

        /// <inheritdoc/>
        public int SaveClient(ClientEditDTO clientDTO)
        {
            int id = 0;
            var task = Task.Run(async () =>
            {
                id = await _clientRepository.SaveClientAsync(clientDTO);
            });
            task.Wait();
            return id;
        }

        /// <inheritdoc/>
        public List<ClientEditDTO> GetClients()
        {
            return _clientRepository.GetClients();
        }

        /// <inheritdoc/>
        public List<ClientDTO> GetClientsForTable()
        {
            return _clientRepository.GetClientsForTable();
        }

        /// <inheritdoc/>
        public List<ClientDTO> GetClientsByType(TypeClientEnum typeClient)
        {
            return _clientRepository.GetClientsByType(typeClient);
        }

        /// <inheritdoc/>
        public List<ClientDTO> GetClientsByIdClient(string idClient)
        {
            return _clientRepository.GetClientsByIdClient(idClient);
        }

        /// <inheritdoc/>
        public ClientEditDTO GetClient(string idClient)
        {
            return _clientRepository.GetClient(idClient);
        }
    }
}
