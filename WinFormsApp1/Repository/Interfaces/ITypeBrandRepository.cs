using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface ITypeBrandRepository
    {
        /// <summary>
        /// Получение списка тип-бренд устройства по идентификатору бренда или типа устройства
        /// </summary>
        /// <param name="idBrand">Идентификатор бренда</param>
        /// <param name="idType">Идентификатор типа устройства</param>
        /// <returns>Список бренд-тип</returns>
        public Task<List<TypeBrandDTO>> GetTypeBrandAsync(int idBrand = 0, int idType = 0, CancellationToken token = default);

        /// <summary>
        /// Получение списка тип-бренд устройства для comboBox по типу устройства
        /// </summary>
        /// <param name="nameType">Название типа устройства</param>
        /// <param name="token"></param>
        /// <returns>Список тип-бренд</returns>
        public Task<List<TypeBrandComboBoxDTO>> GetTypeBrandByNameTypeAsync(string nameType, CancellationToken token = default);

        /// <summary>
        /// Сохранение типа-бренда
        /// </summary>
        /// <param name="typeBrandDTO">DTO типа-бренда</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task SaveTypeBrandAsync(TypeBrandDTO typeBrandDTO, CancellationToken token = default);

        /// <summary>
        /// Удаление типа-бренда
        /// </summary>
        /// <param name="typeBrandDTO">DTO типа-бренда</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task RemoveTypesBrandsAsync(TypeBrandDTO typeBrandDTO, CancellationToken token = default);
    }
}
