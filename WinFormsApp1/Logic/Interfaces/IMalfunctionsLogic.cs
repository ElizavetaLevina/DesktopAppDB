using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IMalfunctionsLogic
    {
        /// <summary>
        /// Получение списка неисправностей
        /// </summary>
        /// <returns>Список неисправностей</returns>
        public List<MalfunctionEditDTO> GetMalfunctions();

        /// <summary>
        /// Получение неисправности по названию
        /// </summary>
        /// <param name="name">Название неисправности</param>
        /// <returns>Неисправность</returns>
        public MalfunctionEditDTO GetMalfunctionByName(string name);

        /// <summary>
        /// Сохранение неисправности
        /// </summary>
        /// <param name="malfunctionDTO">DTO неисправности</param>
        /// <returns>Идентификатор неисправности</returns>
        public int SaveMalfunction(MalfunctionEditDTO malfunctionDTO);

        /// <summary>
        /// Получение неисправности по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Неисправность</returns>
        public MalfunctionEditDTO GetMalfunction(int id);

        /// <summary>
        /// Удаление неисправности
        /// </summary>
        /// <param name="malfunctionDTO"></param>
        public void RemoveMalfunction(MalfunctionEditDTO malfunctionDTO);
    }
}
