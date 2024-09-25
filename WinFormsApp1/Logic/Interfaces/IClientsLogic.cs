using WinFormsApp1.DTO;
using WinFormsApp1.Enum;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IClientsLogic
    {
        /// <summary>
        /// Получение клиента по idClient
        /// </summary>
        /// <param name="idClient">idClient</param>
        /// <returns>Клиент</returns>
        public ClientEditDTO GetClientByIdClient(string idClient);

        /// <summary>
        /// Сохранение клиента
        /// </summary>
        /// <param name="idClient"></param>
        /// <param name="nameAdress"></param>
        /// <param name="secondPhone"></param>
        /// <returns></returns>
        public int SaveClient(ClientEditDTO clientDTO);

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <returns>Список клиентов</returns>
        public List<ClientEditDTO> GetClients();

        /// <summary>
        /// Получение списка клиентов для справочника
        /// </summary>
        /// <returns>Список клиентов</returns>
        public List<ClientDTO> GetClientsForTable();

        /// <summary>
        /// Получение списка клиентов по типу
        /// </summary>
        /// <param name="typeClient">Тип клиента</param>
        /// <returns>Спиок клиентов</returns>
        public List<ClientDTO> GetClientsByType(TypeClientEnum typeClient);

        /// <summary>
        /// Получение списка клиентов по подстроке id клиента
        /// </summary>
        /// <param name="idClient">Id клиента</param>
        /// <returns>Список клиентов</returns>
        public List<ClientDTO> GetClientsByIdClient(string idClient);

        // <summary>
        /// Получение клиента по идентификатору
        /// </summary>
        /// <param name="idClient">Идентификатор</param>
        /// <returns>Клиент</returns>
        public ClientEditDTO GetClient(string idClient);
    }
}
