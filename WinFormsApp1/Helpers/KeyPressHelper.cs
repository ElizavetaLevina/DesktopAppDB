namespace WinFormsApp1.Helpers
{
    public static class KeyPressHelper
    {
        /// <summary>
        /// Проверка нажатой клавиши
        /// </summary>
        /// <param name="checkText">Нужно ли проверять текст</param>
        /// <param name="text">Текст</param>
        /// <param name="keyChar">Код нажатой клавиши</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckKeyPress(bool checkText, string? text, int keyChar)
        {
            if ((keyChar < (int)Keys.D0 || keyChar > (int)Keys.D9) && keyChar != (int)Keys.Back)
                return false;
            if (checkText && string.IsNullOrEmpty(text))
            {
                if (keyChar == (int)Keys.D0)
                    return false;
            }
            return true;
        }
    }
}
