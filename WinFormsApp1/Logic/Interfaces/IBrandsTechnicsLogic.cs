using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IBrandsTechnicsLogic
    {
        /// <summary>
        /// Получение идентификатора бренда устройства по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Идентификатор</returns>
        public Task<int> GetIdBrandTechnicAsync(string name);

        /// <summary>
        /// Получение бренда устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Бренд устройства</returns>
        public Task<BrandTechnicEditDTO> GetBrandTechnicAsync(int id);

        /// <summary>
        /// Получение списка брендов
        /// </summary>
        /// <returns>Список брендов</returns>
        public Task<List<BrandTechnicDTO>> GetBrandsTechnicAsync();

        /// <summary>
        /// Получение названия бренда по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Бренд</returns>
        public Task<string> GetBrandTechnicNameAsync(int id);

        /// <summary>
        /// Сохранение бренда устройтсва
        /// </summary>
        /// <param name="brandTechnicDTO">DTO бренда</param>
        public Task<int> SaveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO);

        /// <summary>
        /// Удаление бренда устройства
        /// </summary>
        /// <param name="brandTechnicDTO">DTO бренда</param>
        public Task RemoveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO);
    }
}
