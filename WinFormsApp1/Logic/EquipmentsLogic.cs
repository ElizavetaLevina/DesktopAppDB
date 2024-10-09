using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
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
        public async Task<int> SaveEquipmentAsync(EquipmentEditDTO equipmentDTO)
        {
            return await _equipmentRepository.SaveEquipmentAsync(equipmentDTO);
        }

        /// <inheritdoc/>
        public async Task<List<EquipmentEditDTO>> GetEquipmentsAsync()
        {
            return await _equipmentRepository.GetEquipmentsAsync();
        }

        /// <inheritdoc/>
        public async Task<List<EquipmentEditDTO>> GetEquipmentsByNameAsync(string name)
        {
            return await _equipmentRepository.GetEquipmentsByNameAsync(name);
        }

        /// <inheritdoc/>
        public async Task<EquipmentEditDTO> GetEquipmentByNameAsync(string name)
        {
            var equipmentDTO = await _equipmentRepository.GetEquipmentByNameAsync(name);
            if (equipmentDTO == null)
                return new EquipmentEditDTO();
            else
                return equipmentDTO;
        }

        /// <inheritdoc/>
        public async Task<EquipmentEditDTO> GetEquipmentAsync(int? id)
        {
            var equipmentDTO = await _equipmentRepository.GetEquipmentAsync(id);
            if (equipmentDTO == null)
                return new EquipmentEditDTO();
            else
                return equipmentDTO;
        }

        /// <inheritdoc/>
        public async Task RemoveEquipmentAsync(EquipmentEditDTO equipmentDTO)
        {
            await _equipmentRepository.RemoveEquipmentAsync(equipmentDTO);
        }
    }
}
