using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IEquipmentsLogic
    {
        /// <summary>
        /// Сохранение комплектации
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Идентификатор комплектации</returns>
        public Task<int> SaveEquipmentAsync(EquipmentEditDTO equipmentDTO);

        /// <summary>
        /// Получение списка комплектаций
        /// </summary>
        /// <returns>Список комплектаций</returns>
        public Task<List<EquipmentEditDTO>> GetEquipmentsAsync();

        /// <summary>
        /// Получение списка комплектаций по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список комплектаций</returns>
        public Task<List<EquipmentEditDTO>> GetEquipmentsByNameAsync(string name);

        /// <summary>
        /// Получение комплектации по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Комплектация</returns>
        public Task<EquipmentEditDTO> GetEquipmentByNameAsync(string name);

        /// <summary>
        /// Получение комплектации по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Комплектация</returns>
        public Task<EquipmentEditDTO> GetEquipmentAsync(int? id);

        /// <summary>
        /// Удаление комплектации
        /// </summary>
        /// <param name="equipmentDTO">DTO комплектации</param>
        public Task RemoveEquipmentAsync(EquipmentEditDTO equipmentDTO);
    }
}
