using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class BrandsTechnicsLogic
    {
        BrandTechnicRepository brandTechnicRepository = new();

        /// <summary>
        /// Получение идентификатора бренда устройства по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Идентификатор</returns>
        public int GetBrandTechnic(string name)
        {
            return brandTechnicRepository.GetBrandTechnicByName(name).Id;
        }

        /// <summary>
        /// Получение списка брендов
        /// </summary>
        /// <returns>Список брендов</returns>
        public List<BrandTechnicDTO> GetBrandsTechnic()
        {
            return brandTechnicRepository.GetBrandsTechnic();
        }

        /// <summary>
        /// Получение названия бренда по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Бренд</returns>
        public string GetBrandTechnicName(int id) 
        {
            return brandTechnicRepository.GetBrandTechnicName(id);
        }

        /// <summary>
        /// Сохранение бренда устройтсва
        /// </summary>
        /// <param name="name">Название бренда</param>
        public int SaveBrandTechnic(int idBrand, string name)
        {
            var idBrandTechnic = 0;
            var brandTechnicDTO = brandTechnicRepository.GetBrandTechnic(idBrand, name);
            var task = Task.Run(async () =>
            {
                idBrandTechnic = await brandTechnicRepository.SaveBrandTechnicAsync(brandTechnicDTO);
            });
            task.Wait();
            return idBrandTechnic;
        }

        /// <summary>
        /// Удаление бренда устройства
        /// </summary>
        /// <param name="brandTechnicDTO">DTO бренда</param>
        public void RemoveBrandTechnic(BrandTechnicEditDTO brandTechnicDTO)
        {
            brandTechnicRepository.RemoveBrandTechnic(brandTechnicDTO);
        }
    }
}
