using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class EquipmentEditDTO
    {
        /// <summary>
        /// Редактирование комплектации
        /// </summary>
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;

        public EquipmentEditDTO()
        {
        }
    }
}
