using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IMalfunctionsLogic
    {
        /// <summary>
        /// Получение списка неисправностей
        /// </summary>
        /// <returns>Список неисправностей</returns>
        public Task<List<MalfunctionEditDTO>> GetMalfunctionsAsync();

        /// <summary>
        /// Получение неисправности по названию
        /// </summary>
        /// <param name="name">Название неисправности</param>
        /// <returns>Неисправность</returns>
        public Task<MalfunctionEditDTO> GetMalfunctionByNameAsync(string name);

        /// <summary>
        /// Получение цены неисправности по названию
        /// </summary>
        /// <param name="name">Название неисправности</param>
        /// <returns>Цена</returns>
        public Task<string> GetPriceMalfunctionByNameAsync(string name);
        /// <summary>
        /// Сохранение неисправности
        /// </summary>
        /// <param name="malfunctionDTO">DTO неисправности</param>
        /// <returns>Идентификатор неисправности</returns>
        public Task<int> SaveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO);

        /// <summary>
        /// Получение неисправности по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Неисправность</returns>
        public Task<MalfunctionEditDTO> GetMalfunctionAsync(int id);

        /// <summary>
        /// Удаление неисправности
        /// </summary>
        /// <param name="malfunctionDTO"></param>
        public Task RemoveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO);
    }
}
