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
    }
}
