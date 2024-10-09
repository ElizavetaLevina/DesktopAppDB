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
        public async Task<ClientEditDTO> GetClientByIdClientAsync(string idClient)
        {
            var clientDTO = await _clientRepository.GetClientByIdClientAsync(idClient);
            if (clientDTO == null)
                return new ClientEditDTO();
            else
                return clientDTO;
        }

        /// <inheritdoc/>
        public async Task<int> SaveClientAsync(ClientEditDTO clientDTO)
        {
            return await _clientRepository.SaveClientAsync(clientDTO);
        }

        /// <inheritdoc/>
        public async Task<List<ClientEditDTO>> GetClientsAsync()
        {
            return await _clientRepository.GetClientsAsync();
        }

        /// <inheritdoc/>
        public async Task<List<ClientDTO>> GetClientsForTableAsync()
        {
            return await _clientRepository.GetClientsForTableAsync();
        }

        /// <inheritdoc/>
        public async Task<List<ClientDTO>> GetClientsByTypeAsync(TypeClientEnum typeClient)
        {
            return await _clientRepository.GetClientsByTypeAsync(typeClient);
        }

        /// <inheritdoc/>
        public async Task<List<ClientDTO>> GetClientsByIdClientAsync(string idClient)
        {
            return await _clientRepository.GetClientsByIdClientAsync(idClient);
        }

        /// <inheritdoc/>
        public async Task<ClientEditDTO> GetClientAsync(string idClient)
        {
            return await _clientRepository.GetClientAsync(idClient);
        }
    }
}
