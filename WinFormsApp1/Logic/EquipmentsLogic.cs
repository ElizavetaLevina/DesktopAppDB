using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class EquipmentsLogic
    {
        EquipmentRepository equipmentRepository = new();
        /// <summary>
        /// Сохранение комплектации
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Идентификатор комплектации</returns>
        public int SaveEquipment(EquipmentEditDTO equipmentDTO)
        {
            int equipmentId = 0;
            var task = Task.Run(async () =>
            {
                equipmentId = await equipmentRepository.SaveEquipmentAsync(equipmentDTO);
            });
            task.Wait();
            return equipmentId;
        }

        /// <summary>
        /// Получение списка комплектаций
        /// </summary>
        /// <returns>Список комплектаций</returns>
        public List<EquipmentEditDTO> GetEquipments()
        {
            return equipmentRepository.GetEquipments();
        }

        /// <summary>
        /// Получение списка комплектаций по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список комплектаций</returns>
        public List<EquipmentEditDTO> GetEquipmentsByName(string name)
        {
            return equipmentRepository.GetEquipmentsByName(name);
        }

        /// <summary>
        /// Получение комплектации по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Комплектация</returns>
        public EquipmentEditDTO GetEquipmentByName(string name)
        {
            return equipmentRepository.GetEquipmentByName(name);
        }
    }
}
