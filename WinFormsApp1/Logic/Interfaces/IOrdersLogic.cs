using WinFormsApp1.DTO;
using WinFormsApp1.Enum;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IOrdersLogic
    {
        /// <summary>
        /// Получение списка заказов для главной таблицы
        /// </summary>
        /// <param name="statusOrder">Статус заказа</param>
        /// <param name="deleted">Удален</param>
        /// <param name="dateCreation">Дата создания заказа</param>
        /// <param name="dateCompleted">Дата завершения заказа</param>
        /// <param name="dateIssue">Дата выдачи заказа</param>
        /// <param name="id">Идентификатор заказа</param>
        /// <returns>Список заказов</returns>
        public List<OrderTableDTO> GetOrdersForTable(StatusOrderEnum? statusOrder = null, bool? deleted = null, bool dateCreation = false,
           bool dateCompleted = false, bool dateIssue = false, bool id = false);

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="orderDTO">DTO заказа</param>
        public void RemoveOrder(OrderEditDTO orderDTO);


        /// <summary>
        /// Получение заказа по идентификатору
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <returns></returns>
        public OrderEditDTO GetOrder(int idOrder);

        /// <summary>
        /// Получение списка заказов по параметрам поиска
        /// </summary>
        /// <param name="numberOrder">Номер квитанции</param>
        /// <param name="dateCreation">Дата создания заказа</param>
        /// <param name="dateStartWork">Дата начала работы над заказом</param>
        /// <param name="masterName">Имя мастера</param>
        /// <param name="device">Устройство</param>
        /// <param name="idClient">Id клиента</param>
        /// <param name="statusOrder">Статус заказа</param>
        /// <returns></returns>
        public List<OrderTableDTO> GetOrdersBySearch(string numberOrder, string dateCreation, string dateStartWork, string masterName,
            string device, string idClient, StatusOrderEnum? statusOrder);

        /// <summary>
        /// Получение списка заказов для экспорта в Excel таблицу
        /// </summary>
        /// <param name="orders">Заказы в главной таблице</param>
        /// <returns>Список заказов</returns>
        public List<OrderTableExcelDTO> GetOrdersForExcel(List<OrderTableDTO> orders);

        /// <summary>
        /// Получение последнего + 1 номера квитанции
        /// </summary>
        /// <returns>Номер квитанции</returns>
        public int GetLastIdOrder();

        /// <summary>
        /// Сохранение заказа
        /// </summary>
        /// <param name="orderDTO">DTO заказа</param>
        /// <returns>Идентификатор заказа</returns>
        public int SaveOrder(OrderEditDTO orderDTO);

        /// <summary>
        /// Получение списка заказов для расчета зарплаты
        /// </summary>
        /// <param name="dateCompleted">Дата завершения заказа</param>
        /// <param name="dateIssue">Дата выдачи заказа</param>
        /// <returns></returns>
        public List<OrderEditDTO> GetOrdersForSalaries(DateTime? dateCompleted = null,
            DateTime? dateIssue = null);

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
        /// Получение списка заказов
        /// </summary>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrders();
    }
}
