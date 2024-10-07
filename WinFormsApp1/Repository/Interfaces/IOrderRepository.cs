using WinFormsApp1.DTO;
using WinFormsApp1.Enum;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Получение списка заказов для главной таблицы
        /// </summary>
        /// <param name="statusOrder">Статус заказа</param>
        /// <param name="deleted">Удален</param>
        /// <param name="dateCreation">Дата создания заказа</param>
        /// <param name="dateCompleted">Дата выполнения заказа</param>
        /// <param name="dateIssue">Дата выдачи</param>
        /// <param name="id">Идентификатор заказа</param>
        /// <returns>Список заказов для главной таблицы</returns>
        public List<OrderTableDTO> GetOrdersForTable(StatusOrderEnum? statusOrder = null, bool? deleted = null, bool dateCreation = false,
            bool dateCompleted = false, bool dateIssue = false, bool id = false);


        /// <summary>
        /// Получение списка заказов для поиска
        /// </summary>
        /// <param name="numberOrder">Номер заказа</param>
        /// <param name="dateCreation">Дата создания</param>
        /// <param name="dateStartWork">Дата начала работы</param>
        /// <param name="masterName">Имя мастера</param>
        /// <param name="device">Тип, бренд и модель устройства</param>
        /// <param name="idClient">Id клиента</param>
        /// <param name="statusOrder">Статус заказка</param>
        /// <returns>Список заказов</returns>
        public List<OrderTableDTO> GetOrdersBySearch(string numberOrder, string dateCreation, string dateStartWork, string masterName,
            string device, string idClient, StatusOrderEnum? statusOrder);


        /// <summary>
        /// Получение списка заказов для экспорта таблицы в Excel
        /// </summary>
        /// <param name="orders">Заказы в главной таблице</param>
        /// <returns>Список заказов</returns>
        public List<OrderTableExcelDTO> GetOrdersForExcel(List<OrderTableDTO> orders);

        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Запись</returns>
        public OrderEditDTO GetOrder(int id);

        /// <summary>
        /// Получение последнего идентификатора в таблице
        /// </summary>
        /// <returns>Иднтификатор</returns>
        public OrderEditDTO GetLastNumberOrder();

        /// <summary>
        /// Получение списка заказов
        /// </summary>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrders();

        /// <summary>
        /// Получение списка заказов по диагнозу
        /// </summary>
        /// <param name="idDiagnosis">Идентификатор диагноза</param>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrdersByIdDiagnosis(int idDiagnosis);

        /// <summary>
        /// Получение списка заказов по комплектации
        /// </summary>
        /// <param name="idEquipment">Идентификатор комплектации</param>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrdersByIdEquipment(int idEquipment);

        /// <summary>
        /// Получения списка заказов для диаграммы
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="master">Указан ли мастер</param>
        /// <param name="masterId">Идентификатор мастера</param>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrdersForChart(int year, bool master = false, int? masterId = null);

        /// <summary>
        /// Получение списка заказов для расчета зарплаты
        /// </summary>
        /// <param name="dateCompleted">Дата завершения заказа</param>
        /// <param name="dateIssue">Дата выдачи заказа</param>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrdersForSalaries(DateTime? dateCompleted = null, DateTime? dateIssue = null);


        public Task<int> SaveOrderAsync(OrderEditDTO orderDTO, CancellationToken token = default);

        public Task RemoveOrder(OrderEditDTO orderDTO, CancellationToken token = default);
    }
}
