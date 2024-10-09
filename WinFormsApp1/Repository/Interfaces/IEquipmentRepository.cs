using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IEquipmentRepository
    {
        /// <summary>
        /// Получение списка комплектации
        /// </summary>
        /// <returns>Список комплектации</returns>
        public Task<List<EquipmentEditDTO>> GetEquipmentsAsync(CancellationToken token = default);

        /// <summary>
        /// Получение комплектации по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Комплектация</returns>
        public Task<EquipmentEditDTO> GetEquipmentAsync(int? id, CancellationToken token = default);

        /// <summary>
        /// Получение списка комплектаций по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список комплектаций</returns>
        public Task<List<EquipmentEditDTO>> GetEquipmentsByNameAsync(string name, CancellationToken token = default);

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Названию</param>
        /// <returns>Запись</returns>
        public Task<EquipmentEditDTO> GetEquipmentByNameAsync(string name, CancellationToken token = default);

        public Task<int> SaveEquipmentAsync(EquipmentEditDTO equipmentDTO, CancellationToken token = default);

        public Task RemoveEquipmentAsync(EquipmentEditDTO equipmentDTO, CancellationToken token = default);
    }
}
