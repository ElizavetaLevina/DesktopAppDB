using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IMalfunctionsOrdersLogic
    {
        /// <summary>
        /// Сохранение неисправности-заказа
        /// </summary>
        /// <param name="malfunctionOrderDTO">DTO неисправности-заказа</param>
        public void SaveMalfunctionOrder(MalfunctionOrderEditDTO malfunctionOrderDTO);

        /// <summary>
        /// Получение списка неисправностей в заказе
        /// </summary>
        /// <param name="idOrder">Номер заказа</param>
        /// <returns>Список неисправностей</returns>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdOrder(int idOrder);

        /// <summary>
        /// Получение списка заказов с неисправностью
        /// </summary>
        /// <param name="idMalfunction">Номер неисправности</param>
        /// <returns>Список заказов</returns>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdMalfunction(int idMalfunction);

        /// <summary>
        /// Удаление неиспрасности-заказа
        /// </summary>
        /// <param name="malfunctionOrderDTO">DTO неисправности-заказа</param>
        public void RemoveMalfunctionOrder(MalfunctionOrderEditDTO malfunctionOrderDTO);
    }
}
