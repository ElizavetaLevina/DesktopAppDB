using WinFormsApp1.DTO;
using WinFormsApp1.Enum;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface ITypesBrandsLogic
    {
        /// <summary>
        /// Получение списка брендов устройств для comboBox по типу устройства
        /// </summary>
        /// <param name="name">Название типа устройства</param>
        /// <returns></returns>
        public Task<List<TypeBrandComboBoxDTO>> GetTypeBrandByNameTypeAsync(string name);

        /// <summary>
        /// Получение списка тип-бренд устройства по идентификатору бренда или типа устройства
        /// </summary>
        /// <param name="idBrand">Идентификатор бренда</param>
        /// <param name="idType">Идентификатор типа устройства</param>
        /// <returns></returns>
        public Task<List<TypeBrandDTO>> GetTypeBrandAsync(int idBrand = 0, int idType = 0);

        /// <summary>
        /// Сохранение списка тип-бренд по списку типов/брендов
        /// </summary>
        /// <param name="list">Список типов/брендов</param>
        /// <param name="id">Идентификатор типа/бренда</param>
        /// <param name="name">Название таблицы</param>
        public Task SaveTypeBrandAsync(List<int>? list, int id, NameTableToEditEnum name);

        /// <summary>
        /// Удаление списка тип-бренд по списку типов/брендов
        /// </summary>
        /// <param name="list">Список типов/брендов</param>
        /// <param name="id">Идентификатор типа/бренда</param>
        /// <param name="name">Название таблицы</param>
        public Task RemoveTypeBrandByListAsync(List<int>? list, int id, NameTableToEditEnum name);

        /// <summary>
        /// Удаление типа-бренда устройства
        /// </summary>
        /// <param name="typeBrandDTO">DTO типа-бренда устройства</param>
        public Task RemoveTypeBrandAsync(TypeBrandDTO typeBrandDTO);
    }
}
