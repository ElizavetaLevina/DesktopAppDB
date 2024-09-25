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

        /// <inheritdoc/>
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
