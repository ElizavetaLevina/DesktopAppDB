using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ClientEditDTO> GetClientAsync(string idClient, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<ClientEditDTO>(context.Set<Client>().Where(i => i.IdClient == idClient))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<ClientEditDTO>> GetClientsAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<ClientEditDTO>(context.Set<Client>()).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<ClientDTO>> GetClientsForTableAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<ClientDTO>(context.Set<Client>()).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<ClientDTO>> GetClientsByTypeAsync(TypeClientEnum typeClient, CancellationToken token = default) 
        {
            Context context = new();
            return await _mapper.ProjectTo<ClientDTO>(context.Set<Client>().Where(i => i.TypeClient == typeClient)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<ClientDTO>> GetClientsByIdClientAsync(string idClient, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<ClientDTO>(context.Set<Client>().Where(i => i.IdClient.Contains(idClient))).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<ClientEditDTO> GetClientByIdClientAsync(string idClient, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<ClientEditDTO>(context.Set<Client>().Where(i => i.IdClient == idClient))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<int> SaveClientAsync(ClientEditDTO clientDTO, CancellationToken token = default)
        {
            Context context = new();
            var client = _mapper.Map<ClientEditDTO, Client>(clientDTO);
            try
            {
                if (client.Id == 0)
                    context.Clients.Add(client);
                else
                    context.Clients.Update(client);

                await context.SaveChangesAsync(token);
                return client.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
