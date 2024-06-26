using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class EquipmentRepository
    {
        /// <summary>
        /// Получение списка комплектации
        /// </summary>
        /// <returns>Список комплектации</returns>
        public List<EquipmentEditDTO> GetEquipments()
        {
            Context context = new();
            return context.Equipment.Select(a => new EquipmentEditDTO(a)).ToList();
        }

        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Запись</returns>
        public EquipmentEditDTO GetEquipment(int? id)
        {
            Context context = new();
            var equipment = context.Equipment.FirstOrDefault(i => i.Id == id);
            if(equipment == null)
                return new EquipmentEditDTO();
            else 
                return new EquipmentEditDTO(equipment);
        }

        /// <summary>
        /// Получение списка комплектаций по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Список комплектаций</returns>
        public List<EquipmentEditDTO> GetEquipmentsByName(string name)
        {
            Context context = new();
            return context.Equipment.Where(i => i.Name.ToLower().Contains(name.ToLower())).Select(a => new EquipmentEditDTO(a)).ToList();
        }

        /// <summary>
        /// Получение записи по названию
        /// </summary>
        /// <param name="name">Названию</param>
        /// <returns>Запись</returns>
        public EquipmentEditDTO GetEquipmentByName(string name)
        {
            Context context = new();
            var equipment = context.Equipment.FirstOrDefault(i => i.Name == name);
            if (equipment != null)
            {
                return new EquipmentEditDTO(equipment);
            }
            else
                return  new EquipmentEditDTO(name);
        }

        public async Task<int> SaveEquipmentAsync(EquipmentEditDTO equipmentDTO, CancellationToken token = default)
        {
            Context db = new();
            Equipment equipment = new()
            {
                Id = equipmentDTO.Id,
                Name = equipmentDTO.Name
            };
            try
            {
                if (equipment.Id == 0)
                    db.Equipment.Add(equipment);
                else
                    db.Equipment.Update(equipment);

                await db.SaveChangesAsync(token);
                return equipment.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        public void RemoveEquipment(EquipmentEditDTO equipmentDTO)
        {
            try
            {
                Context db = new();
                var equipment = db.Equipment.FirstOrDefault(c => c.Id == equipmentDTO.Id);
                db.Equipment.Remove(equipment);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
