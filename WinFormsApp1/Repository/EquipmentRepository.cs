using AutoMapper;
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
        public List<EquipmentEditDTO> GetEquipments()
        {
            Context context = new();
            return _mapper.ProjectTo<EquipmentEditDTO>(context.Set<Equipment>().OrderBy(i => i.Name)).ToList();
        }

        /// <inheritdoc/>
        public EquipmentEditDTO GetEquipment(int? id)
        {
            Context context = new();
            return _mapper.ProjectTo<EquipmentEditDTO>(context.Set<Equipment>().Where(i => i.Id == id)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public List<EquipmentEditDTO> GetEquipmentsByName(string name)
        {
            Context context = new();
            return _mapper.ProjectTo<EquipmentEditDTO>(context.Set<Equipment>()
                .Where(i => i.Name.ToLower().Contains(name.ToLower()))).ToList();
        }

        /// <inheritdoc/>
        public EquipmentEditDTO GetEquipmentByName(string name)
        {
            Context context = new();
            return _mapper.ProjectTo<EquipmentEditDTO>(context.Set<Equipment>().Where(i => i.Name == name)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<int> SaveEquipmentAsync(EquipmentEditDTO equipmentDTO, CancellationToken token = default)
        {
            Context context = new();
            var equipment = _mapper.Map<EquipmentEditDTO, Equipment>(equipmentDTO);
            /*Equipment equipment = new()
            {
                Id = equipmentDTO.Id,
                Name = equipmentDTO.Name
            };*/
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
                //var equipment = context.Equipment.FirstOrDefault(c => c.Id == equipmentDTO.Id);
                var equipment = _mapper.Map<EquipmentEditDTO, Equipment>(equipmentDTO);
                context.Equipment.Remove(equipment);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
