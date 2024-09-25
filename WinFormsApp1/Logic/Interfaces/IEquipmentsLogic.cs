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
        public int SaveEquipment(EquipmentEditDTO equipmentDTO);

        /// <summary>
        /// Получение списка комплектаций
        /// </summary>
        /// <returns>Список комплектаций</returns>
        public List<EquipmentEditDTO> GetEquipments();

        /// <summary>
        /// Получение списка комплектаций по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список комплектаций</returns>
        public List<EquipmentEditDTO> GetEquipmentsByName(string name);

        /// <summary>
        /// Получение комплектации по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Комплектация</returns>
        public EquipmentEditDTO GetEquipmentByName(string name);

        /// <summary>
        /// Получение комплектации по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Комплектация</returns>
        public EquipmentEditDTO GetEquipment(int? id);

        /// <summary>
        /// Удаление комплектации
        /// </summary>
        /// <param name="equipmentDTO">DTO комплектации</param>
        public void RemoveEquipment(EquipmentEditDTO equipmentDTO);
    }
}
