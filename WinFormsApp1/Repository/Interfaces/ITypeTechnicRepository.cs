using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface ITypeTechnicRepository
    {
        /// <summary>
        /// Получение списка типов
        /// </summary>
        /// <returns>Список типов</returns>
        public List<TypeTechnicDTO> GetTypesTechnic();

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Запись</returns>
        public TypeTechnicDTO GetTypeTechnicByName(string name);


        /// <summary>
        /// Получение типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Тип устройства</returns>
        public TypeTechnicEditDTO GetTypeTechnic(int id);

        public Task<int> SaveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO, CancellationToken token = default);

        public void RemoveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO);
    }
}
