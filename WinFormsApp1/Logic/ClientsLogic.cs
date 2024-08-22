using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class ClientsLogic
    {
        ClientRepository clientRepository = new();

        /// <summary>
        /// Получение клиента по idClient
        /// </summary>
        /// <param name="idClient">idClient</param>
        /// <returns>Клиент</returns>
        public ClientEditDTO GetClientByIdClient(string idClient)
        {
            return clientRepository.GetClientByIdClient(idClient);
        }

        /// <summary>
        /// Сохранение клиента
        /// </summary>
        /// <param name="idClient"></param>
        /// <param name="nameAdress"></param>
        /// <param name="secondPhone"></param>
        /// <returns></returns>
        public int SaveClient(ClientEditDTO clientDTO)
        {
            int id = 0;
            var task = Task.Run(async () =>
            {
                id = await clientRepository.SaveClientAsync(clientDTO);
            });
            task.Wait();
            return id;
        }

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <returns>Список клиентов</returns>
        public List<ClientEditDTO> GetClients()
        {
            return clientRepository.GetClients();
        }

        /// <summary>
        /// Получение списка клиентов для справочника
        /// </summary>
        /// <returns>Список клиентов</returns>
        public List<ClientDTO> GetClientsForTable()
        {
            return clientRepository.GetClientsForTable();
        }

        /// <summary>
        /// Получение списка клиентов по типу
        /// </summary>
        /// <param name="typeClient">Тип клиента</param>
        /// <returns>Спиок клиентов</returns>
        public List<ClientDTO> GetClientsByType(TypeClientEnum typeClient)
        {
            return clientRepository.GetClientsByType(typeClient);
        }

        /// <summary>
        /// Получение списка клиентов по подстроке id клиента
        /// </summary>
        /// <param name="idClient">Id клиента</param>
        /// <returns>Список клиентов</returns>
        public List<ClientDTO> GetClientsByIdClient(string idClient)
        {
            return clientRepository.GetClientsByIdClient(idClient);
        }

        // <summary>
        /// Получение клиента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Клиент</returns>
        public ClientEditDTO GetClient(string idClient)
        {
            return clientRepository.GetClient(idClient);
        }
    }
}
