using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface ITypesTechnicsLogic
    {
        /// <summary>
        /// Получение списка типов устройств
        /// </summary>
        /// <returns>Список типов устройств</returns>
        public List<TypeTechnicDTO> GetTypesTechnic();

        /// <summary>
        /// Получение идентификатора типа устройства по названию 
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Идентификатор</returns>
        public int GetIdTypeTechnic(string name);

        /// <summary>
        /// Получение названия типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Тип устройства</returns>
        public string GetTypeTechnicName(int id);

        /// <summary>
        /// Получение типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Тип устройства</returns>
        public TypeTechnicEditDTO GetTypeTechnic(int id);

        /// <summary>
        /// Сохранение типа устройства
        /// </summary>
        /// <param name="typeTechnicDTO">DTO типа устройства</param>
        public int SaveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO);

        /// <summary>
        /// Удаление типа устройства
        /// </summary>
        /// <param name="typeTechnicDTO">DTO типа устройства</param>
        public void RemoveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO);
    }
}
