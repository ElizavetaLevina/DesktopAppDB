using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IMalfunctionsOrdersLogic
    {
        /// <summary>
        /// Сохранение неисправности-заказа
        /// </summary>
        /// <param name="malfunctionOrderDTO">DTO неисправности-заказа</param>
        public Task SaveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO);

        /// <summary>
        /// Получение списка неисправностей в заказе
        /// </summary>
        /// <param name="idOrder">Номер заказа</param>
        /// <returns>Список неисправностей</returns>
        public Task<List<MalfunctionOrderEditDTO>> GetMalfunctionOrdersByIdOrderAsync(int idOrder);

        /// <summary>
        /// Получение списка заказов с неисправностью
        /// </summary>
        /// <param name="idMalfunction">Номер неисправности</param>
        /// <returns>Список заказов</returns>
        public Task<List<MalfunctionOrderEditDTO>> GetMalfunctionOrdersByIdMalfunctionAsync(int idMalfunction);

        /// <summary>
        /// Удаление неиспрасности-заказа
        /// </summary>
        /// <param name="malfunctionOrderDTO">DTO неисправности-заказа</param>
        public Task RemoveMalfunctionOrderAsync(MalfunctionOrderEditDTO malfunctionOrderDTO);
    }
}
