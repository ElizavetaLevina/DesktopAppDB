using WinFormsApp1.DTO;
using WinFormsApp1.Enum;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IClientRepository
    {
        /// <summary>
        /// Получение клиента по идентификатору
        /// </summary>
        /// <param name="idClient">Идентификатор</param>
        /// <param name="token"></param>
        /// <returns>Клиент</returns>
        public Task<ClientEditDTO> GetClientAsync(string idClient, CancellationToken token = default);

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Список клиентов</returns>
        public Task<List<ClientEditDTO>> GetClientsAsync(CancellationToken token = default);

        /// <summary>
        /// Получение списка клиентов для справочника
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Список клиентов</returns>
        public Task<List<ClientDTO>> GetClientsForTableAsync(CancellationToken token = default);

        /// <summary>
        /// Получение списка клиентов по типу
        /// </summary>
        /// <param name="typeClient">Тип клиента</param>
        /// <param name="token"></param>
        /// <returns>Спиок клиентов</returns>
        public Task<List<ClientDTO>> GetClientsByTypeAsync(TypeClientEnum typeClient, CancellationToken token = default);

        /// <summary>
        /// Получение списка клиентов по подстроке id клиента
        /// </summary>
        /// <param name="idClient">Id клиента</param>
        /// <param name="token"></param>
        /// <returns>Список клиентов</returns>
        public Task<List<ClientDTO>> GetClientsByIdClientAsync (string idClient, CancellationToken token = default);

        /// <summary>
        /// Получение клиента по idClient
        /// </summary>
        /// <param name="idClient">idClient</param>
        /// <param name="token"></param>
        /// <returns>Клиент</returns>
        public Task<ClientEditDTO> GetClientByIdClientAsync(string idClient, CancellationToken token = default);

        /// <summary>
        /// Сохранение клиента
        /// </summary>
        /// <param name="clientDTO">DTO клиента</param>
        /// <param name="token"></param>
        /// <returns>Идентификатор клиента</returns>
        public Task<int> SaveClientAsync(ClientEditDTO clientDTO, CancellationToken token = default);
    }
}
