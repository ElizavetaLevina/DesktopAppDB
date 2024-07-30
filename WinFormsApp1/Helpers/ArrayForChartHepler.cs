using WinFormsApp1.DTO;
using WinFormsApp1.Enum;

namespace WinFormsApp1.Helpers
{
    public static class ArrayForChartHepler
    {
        /// <summary>
        /// Получение массива с прибылью для диаграммы 
        /// </summary>
        /// <param name="ordersDTO">Список заказов</param>
        /// <param name="master">Указан ли мастер</param>
        /// <param name="masterId">Идентификатор мастера</param>
        /// <returns>Массив</returns>
        public static int[] GetArrayTotalProfit(List<OrderEditDTO> ordersDTO, bool master = false, int? masterId = null)
        {
            int[] pointsArray = new int[12];

            foreach (var order in ordersDTO)
            {
                var month = (MonthEnum)order.DateCompleted.Value.Month;
                var sumPrice = order.MalfunctionOrders.Sum(m => m.Price);

                switch (month)
                {
                    case MonthEnum.Январь:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Январь - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Январь - 1] += sumPrice;
                        break;
                    case MonthEnum.Ферваль:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Ферваль - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Ферваль - 1] += sumPrice;
                        break;
                    case MonthEnum.Март:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Март - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Март - 1] += sumPrice;
                        break;
                    case MonthEnum.Апрель:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Апрель - 1] += order.MainMasterId == masterId     ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Апрель - 1] += sumPrice;
                        break;
                    case MonthEnum.Май:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Май - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Май - 1] += sumPrice;
                        break;
                    case MonthEnum.Июнь:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Июнь - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Июнь - 1] += sumPrice;
                        break;
                    case MonthEnum.Июль:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Июль - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Июль - 1] += sumPrice;
                        break;
                    case MonthEnum.Август:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Август - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Август - 1] += sumPrice;
                        break;
                    case MonthEnum.Сентябрь:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Сентябрь - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Сентябрь - 1] += sumPrice;
                        break;
                    case MonthEnum.Октябрь:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Октябрь - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Октябрь - 1] += sumPrice;
                        break;
                    case MonthEnum.Ноябрь:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Ноябрь - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Ноябрь - 1] += sumPrice;
                        break;
                    case MonthEnum.Декабрь:
                        if (master)
                        {
                            pointsArray[(int)MonthEnum.Декабрь - 1] += order.MainMasterId == masterId ?
                            (int)(sumPrice * (order.PercentWorkMainMaster / 100.0)) :
                            (int)(sumPrice * (order.PercentWorkAdditionalMaster / 100.0));
                        }
                        else pointsArray[(int)MonthEnum.Декабрь - 1] += sumPrice;
                        break;
                }
            }
            return pointsArray;
        }

        /// <summary>
        /// Получение массива с количеством заказов для диаграммы
        /// </summary>
        /// <param name="ordersDTO">Список заказов</param>
        /// <returns>Массив</returns>
        public static int[] GetArrayCountOrders(List<OrderEditDTO> ordersDTO)
        {
            int[] pointsArray = new int[12];

            foreach (var order in ordersDTO)
            {
                var month = (MonthEnum)order.DateCompleted.Value.Month;
                switch (month)
                {
                    case MonthEnum.Январь:
                        pointsArray[(int)MonthEnum.Январь - 1] += 1;
                        break;
                    case MonthEnum.Ферваль:
                        pointsArray[(int)MonthEnum.Ферваль - 1] += 1;
                        break;
                    case MonthEnum.Март:
                        pointsArray[(int)MonthEnum.Март - 1] += 1;
                        break;
                    case MonthEnum.Апрель:
                        pointsArray[(int)MonthEnum.Апрель - 1] += 1;
                        break;
                    case MonthEnum.Май:
                        pointsArray[(int)MonthEnum.Май - 1] += 1;
                        break;
                    case MonthEnum.Июнь:
                        pointsArray[(int)MonthEnum.Июнь - 1] += 1;
                        break;
                    case MonthEnum.Июль:
                        pointsArray[(int)MonthEnum.Июль - 1] += 1;
                        break;
                    case MonthEnum.Август:
                        pointsArray[(int)MonthEnum.Август - 1] += 1;
                        break;
                    case MonthEnum.Сентябрь:
                        pointsArray[(int)MonthEnum.Сентябрь - 1] += 1;
                        break;
                    case MonthEnum.Октябрь:
                        pointsArray[(int)MonthEnum.Октябрь - 1] += 1;
                        break;
                    case MonthEnum.Ноябрь:
                        pointsArray[(int)MonthEnum.Ноябрь - 1] += 1;
                        break;
                    case MonthEnum.Декабрь:
                        pointsArray[(int)MonthEnum.Декабрь - 1] += 1;
                        break;
                }
            }
            return pointsArray;
        }


        /// <summary>
        /// Получение массива с затратамы на детали для диаграммы
        /// </summary>
        /// <param name="ordersDTO">Список заказов</param>
        /// <returns>Массив</returns>
        public static int[] GetArrayExpensesForDetails(List<OrderEditDTO> ordersDTO)
        {
            int[] pointsArray = new int[12];

            foreach (var order in ordersDTO)
            {
                var month = (MonthEnum)order.DateCompleted.Value.Month;
                switch (month)
                {
                    case MonthEnum.Январь:
                        pointsArray[(int)MonthEnum.Январь - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Ферваль:
                        pointsArray[(int)MonthEnum.Ферваль - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Март:
                        pointsArray[(int)MonthEnum.Март - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Апрель:
                        pointsArray[(int)MonthEnum.Апрель - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Май:
                        pointsArray[(int)MonthEnum.Май - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Июнь:
                        pointsArray[(int)MonthEnum.Июнь - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Июль:
                        pointsArray[(int)MonthEnum.Июль - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Август:
                        pointsArray[(int)MonthEnum.Август - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Сентябрь:
                        pointsArray[(int)MonthEnum.Сентябрь - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Октябрь:
                        pointsArray[(int)MonthEnum.Октябрь - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Ноябрь:
                        pointsArray[(int)MonthEnum.Ноябрь - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                    case MonthEnum.Декабрь:
                        pointsArray[(int)MonthEnum.Декабрь - 1] += order.Details.Sum(m => m.PriceSale);
                        break;
                }
            }
            return pointsArray;
        }
    }
}
