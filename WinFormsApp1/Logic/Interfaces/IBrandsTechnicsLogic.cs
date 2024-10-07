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
        public int GetIdBrandTechnic(string name);

        /// <summary>
        /// Получение бренда устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Бренд устройства</returns>
        public BrandTechnicEditDTO GetBrandTechnic(int id);

        /// <summary>
        /// Получение списка брендов
        /// </summary>
        /// <returns>Список брендов</returns>
        public List<BrandTechnicDTO> GetBrandsTechnic();

        /// <summary>
        /// Получение названия бренда по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Бренд</returns>
        public string GetBrandTechnicName(int id);

        /// <summary>
        /// Сохранение бренда устройтсва
        /// </summary>
        /// <param name="brandTechnicDTO">DTO бренда</param>
        public int SaveBrandTechnic(BrandTechnicEditDTO brandTechnicDTO);

        /// <summary>
        /// Удаление бренда устройства
        /// </summary>
        /// <param name="brandTechnicDTO">DTO бренда</param>
        public void RemoveBrandTechnic(BrandTechnicEditDTO brandTechnicDTO);
    }
}
