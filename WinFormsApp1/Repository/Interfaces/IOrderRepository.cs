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
        public Task<List<OrderTableDTO>> GetOrdersForTableAsync(StatusOrderEnum? statusOrder = null, bool? deleted = null, bool dateCreation = false,
            bool dateCompleted = false, bool dateIssue = false, bool id = false, CancellationToken token = default);


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
        public Task<List<OrderTableDTO>> GetOrdersBySearchAsync(string numberOrder, string dateCreation, string dateStartWork, string masterName,
            string device, string idClient, StatusOrderEnum? statusOrder, CancellationToken token = default);


        /// <summary>
        /// Получение списка заказов для экспорта таблицы в Excel
        /// </summary>
        /// <param name="orders">Заказы в главной таблице</param>
        /// <returns>Список заказов</returns>
        public Task<List<OrderTableExcelDTO>> GetOrdersForExcelAsync(List<OrderTableDTO> orders, CancellationToken token = default);

        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Запись</returns>
        public Task<OrderEditDTO> GetOrderAsync(int id, CancellationToken token = default);

        /// <summary>
        /// Получение последнего идентификатора в таблице
        /// </summary>
        /// <returns>Иднтификатор</returns>
        public Task<OrderEditDTO> GetLastNumberOrderAsync(CancellationToken token = default);

        /// <summary>
        /// Получение списка заказов
        /// </summary>
        /// <returns>Список заказов</returns>
        public Task<List<OrderEditDTO>> GetOrdersAsync(CancellationToken token = default);

        /// <summary>
        /// Получение списка заказов по диагнозу
        /// </summary>
        /// <param name="idDiagnosis">Идентификатор диагноза</param>
        /// <returns>Список заказов</returns>
        public Task<List<OrderEditDTO>> GetOrdersByIdDiagnosisAsync(int idDiagnosis, CancellationToken token = default);

        /// <summary>
        /// Получение списка заказов по комплектации
        /// </summary>
        /// <param name="idEquipment">Идентификатор комплектации</param>
        /// <returns>Список заказов</returns>
        public Task<List<OrderEditDTO>> GetOrdersByIdEquipmentAsync(int idEquipment, CancellationToken token = default);

        /// <summary>
        /// Получения списка заказов для диаграммы
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="master">Указан ли мастер</param>
        /// <param name="masterId">Идентификатор мастера</param>
        /// <returns>Список заказов</returns>
        public Task<List<OrderEditDTO>> GetOrdersForChartAsync(int year, bool master = false, int? masterId = null, 
            CancellationToken token = default);

        /// <summary>
        /// Получение списка заказов для расчета зарплаты
        /// </summary>
        /// <param name="dateCompleted">Дата завершения заказа</param>
        /// <param name="dateIssue">Дата выдачи заказа</param>
        /// <returns>Список заказов</returns>
        public Task<List<OrderEditDTO>> GetOrdersForSalariesAsync(DateTime? dateCompleted = null, DateTime? dateIssue = null,
             CancellationToken token = default);


        public Task<int> SaveOrderAsync(OrderEditDTO orderDTO, CancellationToken token = default);

        public Task RemoveOrderAsync(OrderEditDTO orderDTO, CancellationToken token = default);
    }
}
