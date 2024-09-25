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
        public List<TypeBrandDTO> GetTypeBrand(int idBrand = 0, int idType = 0);

        public List<TypeBrandComboBoxDTO> GetTypeBrandByNameType(string nameType);

        public Task SaveTypeBrandAsync(TypeBrandDTO typeBrandDTO, CancellationToken token = default);

        public void RemoveTypesBrands(TypeBrandDTO typeBrandDTO);
    }
}
