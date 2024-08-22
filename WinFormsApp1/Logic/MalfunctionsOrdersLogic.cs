using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class MalfunctionsOrdersLogic
    {
        MalfunctionOrderRepository malfunctionOrderRepository = new();

        /// <summary>
        /// Сохранение неисправности-заказа
        /// </summary>
        /// <param name="malfunctionOrderDTO">DTO неисправности-заказа</param>
        public void SaveMalfunctionOrder(MalfunctionOrderEditDTO malfunctionOrderDTO)
        {
            var task = Task.Run(async () =>
            {
                await malfunctionOrderRepository.SaveMalfunctionOrderAsync(malfunctionOrderDTO);
            });
            task.Wait();
        }

        /// <summary>
        /// Получение списка неисправностей в заказе
        /// </summary>
        /// <param name="idOrder">Номер заказа</param>
        /// <returns>Список неисправностей</returns>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdOrder(int idOrder)
        {
            return malfunctionOrderRepository.GetMalfunctionOrdersByIdOrder(idOrder);
        }

        /// <summary>
        /// Получение списка заказов с неисправностью
        /// </summary>
        /// <param name="idMalfunction">Номер неисправности</param>
        /// <returns>Список заказов</returns>
        public List<MalfunctionOrderEditDTO> GetMalfunctionOrdersByIdMalfunction(int idMalfunction)
        {
            return malfunctionOrderRepository.GetMalfunctionOrdersByIdMalfunction(idMalfunction);
        }

        /// <summary>
        /// Удаление неиспрасности-заказа
        /// </summary>
        /// <param name="malfunctionOrderDTO">DTO неисправности-заказа</param>
        public void RemoveMalfunctionOrder(MalfunctionOrderEditDTO malfunctionOrderDTO)
        {
            malfunctionOrderRepository.RemoveMalfunctionOrder(malfunctionOrderDTO);
        }
    }
}
