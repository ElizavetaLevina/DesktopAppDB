using WinFormsApp1.Repository;

namespace WinFormsApp1.Helpers
{
    public static class FoundProblemTextChangeHelper
    {
        /// <summary>
        /// Получение списка неисправностей по строке 
        /// </summary>
        /// <param name="textBoxProblem1">Первая неисправность</param>
        /// <param name="textBoxProblem2">Вторая неисправность</param>
        /// <param name="textBoxProblem3">Третья неисправность</param>
        /// <returns>Список неисправностей для ListBox</returns>
        public static List<string> GetItemsListBox(/*string? textBoxProblem1 = null, string? textBoxProblem2 = null, string? textBoxProblem3 = null*/string text)
        {
            MalfunctionRepository malfunctionRepository = new();
            //string text = string.Empty;
            List<string> finalListProblem = [];
            var malfunctionList = malfunctionRepository.GetMalfunctions();

            /*if (textBoxProblem1 != null)
                text = textBoxProblem1;
            else if (textBoxProblem2 != null)
                text = textBoxProblem2;
            else if (textBoxProblem3 != null)
                text = textBoxProblem3;*/

            foreach (var problem in malfunctionList)
            {
                if (problem.Name.ToLower().StartsWith(text.ToLower()))
                {
                    finalListProblem.Add(problem.Name);
                }
            }
            return finalListProblem;
        }

        /// <summary>
        /// Получение списка неисправностей по количеству
        /// </summary>
        /// <param name="countProblem">Количество неисправностей</param>
        /// <param name="textBoxProblem1">Первая неисправность</param>
        /// <param name="textBoxProblem2">ВТроая неисправность</param>
        /// <param name="textBoxProblem3">Третья неисправность</param>
        /// <returns>Список неисправностей</returns>
        public static List<string> GetFoundProblem(int countProblem, string textBoxProblem1 = "", string textBoxProblem2 = "", string textBoxProblem3 = "")
        {
            List<string> foundProblem = [];
            switch (countProblem)
            {
                case 1:
                    foundProblem.Add(textBoxProblem1);
                    break;
                case 2: 
                    foundProblem.Add(textBoxProblem1);
                    foundProblem.Add(textBoxProblem2);
                    break;
                case 3:
                    foundProblem.Add(textBoxProblem1);
                    foundProblem.Add(textBoxProblem2);
                    foundProblem.Add(textBoxProblem3);
                    break;
            }
            return foundProblem;
        }

        /// <summary>
        /// Получение списка цен неисправностей по количеству
        /// </summary>
        /// <param name="countProblem">Количество неисправностей</param>
        /// <param name="textBoxPrice1">Первая неисправность</param>
        /// <param name="textBoxPrice2">Вторая неисправность</param>
        /// <param name="textBoxPrice3">Третья неисправность</param>
        /// <returns>Список цен</returns>
        public static List<int> GetPriceProblem(int countProblem, string textBoxPrice1 = "", string textBoxPrice2 = "", string textBoxPrice3 = "")
        {
            List<int> priceProblem = [];
            switch (countProblem)
            {
                case 1:
                    priceProblem.Add(Convert.ToInt32(textBoxPrice1));
                    break;
                case 2:
                    priceProblem.Add(Convert.ToInt32(textBoxPrice1));
                    priceProblem.Add(Convert.ToInt32(textBoxPrice2));
                    break;
                case 3:
                    priceProblem.Add(Convert.ToInt32(textBoxPrice1));
                    priceProblem.Add(Convert.ToInt32(textBoxPrice2));
                    priceProblem.Add(Convert.ToInt32(textBoxPrice3));
                    break;
            }
            return priceProblem;
        }
    }
}
