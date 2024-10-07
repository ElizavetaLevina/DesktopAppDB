using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IBrandTechnicRepository
    {
        /// <summary>
        /// Получение списка брендов
        /// </summary>
        /// <returns>Список брендов</returns>
        public List<BrandTechnicDTO> GetBrandsTechnic();

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Название бренда</param>
        /// <returns>Запись</returns>
        public BrandTechnicDTO GetBrandTechnicByName(string name);

        /// <summary>
        /// Получение бренда устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Имя</param>
        /// <returns>Бренда устройства</returns>
        public BrandTechnicEditDTO GetBrandTechnic(int id);

        public Task<int> SaveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO, CancellationToken token = default);

        public Task RemoveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO, CancellationToken token = default);
    }
}
