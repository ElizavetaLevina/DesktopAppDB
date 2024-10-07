using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class EquipmentsLogic : IEquipmentsLogic
    {
        IEquipmentRepository _equipmentRepository;

        public EquipmentsLogic(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }


        /// <inheritdoc/>
        public int SaveEquipment(EquipmentEditDTO equipmentDTO)
        {
            int equipmentId = 0;
            var task = Task.Run(async () =>
            {
                equipmentId = await _equipmentRepository.SaveEquipmentAsync(equipmentDTO);
            });
            task.Wait();
            return equipmentId;
        }

        /// <inheritdoc/>
        public List<EquipmentEditDTO> GetEquipments()
        {
            return _equipmentRepository.GetEquipments();
        }

        /// <inheritdoc/>
        public List<EquipmentEditDTO> GetEquipmentsByName(string name)
        {
            return _equipmentRepository.GetEquipmentsByName(name);
        }

        /// <inheritdoc/>
        public EquipmentEditDTO GetEquipmentByName(string name)
        {
            var equipmentDTO = _equipmentRepository.GetEquipmentByName(name);
            if (equipmentDTO == null)
                return new EquipmentEditDTO();
            else
                return equipmentDTO;
        }

        /// <inheritdoc/>
        public EquipmentEditDTO GetEquipment(int? id)
        {
            var equipmentDTO = _equipmentRepository.GetEquipment(id);
            if (equipmentDTO == null)
                return new EquipmentEditDTO();
            else
                return equipmentDTO;
        }

        /// <inheritdoc/>
        public void RemoveEquipment(EquipmentEditDTO equipmentDTO)
        {
            var task = Task.Run(async () =>
            {
                await _equipmentRepository.RemoveEquipmentAsync(equipmentDTO);
            });
            task.Wait();
        }
    }
}
