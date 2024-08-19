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
        public int? SaveEquipment(string name)
        {
            var equipmentDTO = equipmentRepository.GetEquipmentByName(name);
            int? equipmentId = equipmentDTO.Id;
            if (equipmentId == 0)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    var task = Task.Run(async () =>
                    {
                        equipmentId = await equipmentRepository.SaveEquipmentAsync(equipmentDTO);
                    });
                    task.Wait();
                }
                else equipmentId = null;
            }
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
    }
}
