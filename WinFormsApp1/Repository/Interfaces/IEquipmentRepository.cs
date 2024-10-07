using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IEquipmentRepository
    {
        /// <summary>
        /// Получение списка комплектации
        /// </summary>
        /// <returns>Список комплектации</returns>
        public List<EquipmentEditDTO> GetEquipments();

        /// <summary>
        /// Получение комплектации по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Комплектация</returns>
        public EquipmentEditDTO GetEquipment(int? id);

        /// <summary>
        /// Получение списка комплектаций по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список комплектаций</returns>
        public List<EquipmentEditDTO> GetEquipmentsByName(string name);

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Названию</param>
        /// <returns>Запись</returns>
        public EquipmentEditDTO GetEquipmentByName(string name);

        public Task<int> SaveEquipmentAsync(EquipmentEditDTO equipmentDTO, CancellationToken token = default);

        public Task RemoveEquipmentAsync(EquipmentEditDTO equipmentDTO, CancellationToken token = default);
    }
}
