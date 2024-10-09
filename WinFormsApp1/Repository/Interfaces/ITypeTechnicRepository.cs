using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface ITypeTechnicRepository
    {
        /// <summary>
        /// Получение списка типов
        /// </summary>
        /// <returns>Список типов</returns>
        public Task<List<TypeTechnicDTO>> GetTypesTechnicAsync(CancellationToken token = default);

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Запись</returns>
        public Task<TypeTechnicDTO> GetTypeTechnicByNameAsync(string name, CancellationToken token = default);


        /// <summary>
        /// Получение типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Тип устройства</returns>
        public Task<TypeTechnicEditDTO> GetTypeTechnicAsync(int id, CancellationToken token = default);

        /// <summary>
        /// Сохранение типа устройства
        /// </summary>
        /// <param name="typeTechnicDTO">DTO типа устройства</param>
        /// <param name="token">Идентификатор типа устройства</param>
        /// <returns></returns>
        public Task<int> SaveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO, CancellationToken token = default);

        /// <summary>
        /// Удаление типа устройства
        /// </summary>
        /// <param name="typeTechnicDTO">DTO типа устройства</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task RemoveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO, CancellationToken token = default);
    }
}
