﻿using WinFormsApp1.DTO;
using WinFormsApp1.Enum;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IClientRepository
    {
        /// <summary>
        /// Получение клиента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Клиент</returns>
        public ClientEditDTO GetClient(string idClient);

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <returns>Список клиентов</returns>
        public List<ClientEditDTO> GetClients();

        /// <summary>
        /// Получение списка клиентов для справочника
        /// </summary>
        /// <returns>Список клиентов</returns>
        public Task<List<ClientDTO>> GetClientsForTableAsync(CancellationToken token = default);

        /// <summary>
        /// Получение списка клиентов по типу
        /// </summary>
        /// <param name="typeClient">Тип клиента</param>
        /// <returns>Спиок клиентов</returns>
        public Task<List<ClientDTO>> GetClientsByTypeAsync(TypeClientEnum typeClient, CancellationToken token = default);

        /// <summary>
        /// Получение списка клиентов по подстроке id клиента
        /// </summary>
        /// <param name="idClient">Id клиента</param>
        /// <returns>Список клиентов</returns>
        public Task<List<ClientDTO>> GetClientsByIdClientAsync (string idClient, CancellationToken token = default);

        /// <summary>
        /// Получение клиента по idClient
        /// </summary>
        /// <param name="idClient">idClient</param>
        /// <returns>Клиент</returns>
        public ClientEditDTO GetClientByIdClient(string idClient);

        public Task<int> SaveClientAsync(ClientEditDTO clientDTO, CancellationToken token = default);
    }
}