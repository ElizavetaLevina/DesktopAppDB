using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface ITypesTechnicsLogic
    {
        /// <summary>
        /// Получение списка типов устройств
        /// </summary>
        /// <returns>Список типов устройств</returns>
        public Task<List<TypeTechnicDTO>> GetTypesTechnicAsync();

        /// <summary>
        /// Получение идентификатора типа устройства по названию 
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Идентификатор</returns>
        public Task<int> GetIdTypeTechnicAsync(string name);

        /// <summary>
        /// Получение названия типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Тип устройства</returns>
        public Task<string> GetTypeTechnicNameAsync(int id);

        /// <summary>
        /// Получение типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Тип устройства</returns>
        public Task<TypeTechnicEditDTO> GetTypeTechnicAsync(int id);

        /// <summary>
        /// Сохранение типа устройства
        /// </summary>
        /// <param name="typeTechnicDTO">DTO типа устройства</param>
        public Task<int> SaveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO);

        /// <summary>
        /// Удаление типа устройства
        /// </summary>
        /// <param name="typeTechnicDTO">DTO типа устройства</param>
        public Task RemoveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO);
    }
}
