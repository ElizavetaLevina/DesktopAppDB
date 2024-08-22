using WinFormsApp1.DTO;
using WinFormsApp1.Enum;

namespace WinFormsApp1.Helpers
{
    public class ColorsRowsHelper
    {
        /// <summary>
        /// Определение цвета строки в таблице
        /// </summary>
        /// <param name="orderDTO">DTO заказа</param>
        /// <returns>Цвет</returns>
        public static Color ColorDefinition(OrderEditDTO orderDTO)
        {
            Color newColor;
            var countDays = 0;
            switch (orderDTO.StatusOrder)
            {
                case StatusOrderEnum.InRepair:
                    if (orderDTO.MainMasterId != null)
                        countDays = (DateTime.Now - orderDTO.DateStartWork.Value).Days;
                    if (orderDTO.MainMasterId == null)
                        return Color.DimGray;
                    if (orderDTO.Deleted)
                        return Color.Black;
                    break;
                case StatusOrderEnum.Completed:
                    countDays = (DateTime.Now - orderDTO.DateCompleted.Value).Days;
                    break;
            }

            if (countDays < Convert.ToInt32(Properties.Settings.Default.FirstLevelText))
                newColor = Properties.Settings.Default.FirstLevelColor;
            else if (countDays > Convert.ToInt32(Properties.Settings.Default.SecondLevelText))
                newColor = Properties.Settings.Default.ThirdLevelColor;
            else if (orderDTO.StatusOrder == StatusOrderEnum.GuaranteeIssue || orderDTO.StatusOrder == StatusOrderEnum.Archive)
                newColor = Color.Black;
            else
                newColor = Properties.Settings.Default.SecondLevelColor;
            return newColor;
        }
    }
}
