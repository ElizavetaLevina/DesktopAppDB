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

        public async Task SaveClientAsync(ClientEditDTO clientDTO, CancellationToken token = default)
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
