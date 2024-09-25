using AutoMapper;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class ClientRepository : IClientRepository
    {
        IMapper _mapper;

        public ClientRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public ClientEditDTO GetClient(string idClient)
        {
            Context context = new();
            return _mapper.ProjectTo<ClientEditDTO>(context.Set<Client>().Where(i => i.IdClient == idClient)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public List<ClientEditDTO> GetClients()
        {
            Context context = new();
            return _mapper.ProjectTo<ClientEditDTO>(context.Set<Client>()).ToList();
            //context.Clients.Select(a => new ClientEditDTO(a)).ToList();
        }

        /// <inheritdoc/>
        public List<ClientDTO> GetClientsForTable()
        {
            Context context = new();
            return _mapper.ProjectTo<ClientDTO>(context.Set<Client>()).ToList();
        }

        /// <inheritdoc/>
        public List<ClientDTO> GetClientsByType(TypeClientEnum typeClient) 
        {
            Context context = new();
            return _mapper.ProjectTo<ClientDTO>(context.Set<Client>().Where(i => i.TypeClient == typeClient)).ToList();
        }

        /// <inheritdoc/>
        public List<ClientDTO> GetClientsByIdClient(string idClient)
        {
            Context context = new();
            return _mapper.ProjectTo<ClientDTO>(context.Set<Client>().Where(i => i.IdClient.Contains(idClient))).ToList();
        }

        /// <inheritdoc/>
        public ClientEditDTO GetClientByIdClient(string idClient)
        {
            Context context = new();
            return _mapper.ProjectTo<ClientEditDTO>(context.Set<Client>().Where(i => i.IdClient == idClient)).FirstOrDefault();
        }

        /// <inheritdoc/>
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
