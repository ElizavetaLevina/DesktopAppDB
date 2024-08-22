using WinFormsApp1.Enum;

namespace WinFormsApp1.Helpers
{
    public class ColorsRowsHelper
    {
        public static Color ColorDefinition(string mainMaster, DateTime dateStartWork, DateTime dateCompleted, 
            StatusOrderEnum status)
        {
            Color color;
            int countDay;
            if (status == StatusOrderEnum.InRepair)
            {
                if (mainMaster != "-")
                    countDay = (DateTime.Now - dateStartWork).Days;
                else return Color.DimGray;
            }
            else if (status == StatusOrderEnum.Completed)
                countDay = (DateTime.Now - dateCompleted).Days;
            else return Color.Black;
            if (countDay < Convert.ToInt32(Properties.Settings.Default.FirstLevelText))
                color = Properties.Settings.Default.FirstLevelColor;
            else if (countDay > Convert.ToInt32(Properties.Settings.Default.SecondLevelText))
                color = Properties.Settings.Default.ThirdLevelColor;
            else
                color = Properties.Settings.Default.SecondLevelColor;


            return color;

        }
    }
}
