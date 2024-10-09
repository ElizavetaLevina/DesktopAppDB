using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        IMapper _mapper;

        public EquipmentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<EquipmentEditDTO>> GetEquipmentsAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<EquipmentEditDTO>(context.Set<Equipment>().OrderBy(i => i.Name)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<EquipmentEditDTO> GetEquipmentAsync(int? id, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<EquipmentEditDTO>(context.Set<Equipment>().Where(i => i.Id == id))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<EquipmentEditDTO>> GetEquipmentsByNameAsync(string name, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<EquipmentEditDTO>(context.Set<Equipment>()
                .Where(i => i.Name.ToLower().Contains(name.ToLower()))).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<EquipmentEditDTO> GetEquipmentByNameAsync(string name, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<EquipmentEditDTO>(context.Set<Equipment>().Where(i => i.Name == name))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<int> SaveEquipmentAsync(EquipmentEditDTO equipmentDTO, CancellationToken token = default)
        {
            Context context = new();
            var equipment = _mapper.Map<EquipmentEditDTO, Equipment>(equipmentDTO);
            try
            {
                if (equipment.Id == 0)
                    context.Equipment.Add(equipment);
                else
                    context.Equipment.Update(equipment);

                await context.SaveChangesAsync(token);
                return equipment.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveEquipmentAsync(EquipmentEditDTO equipmentDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var equipment = _mapper.Map<EquipmentEditDTO, Equipment>(equipmentDTO);
                context.Equipment.Remove(equipment);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
