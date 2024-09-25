using AutoMapper;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class MasterRepository : IMasterRepository
    {
        IMapper _mapper;

        public MasterRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public List<MasterEditDTO> GetMasters()
        {
            Context context = new();
            return _mapper.ProjectTo<MasterEditDTO>(context.Set<Master>().OrderBy(i => i.Id)).ToList();
        }

        /// <inheritdoc/>
        public List<MasterDTO> GetMastersForOutput()
        {
            Context context = new();
            return _mapper.ProjectTo<MasterDTO>(context.Set<Master>().OrderBy(i => i.Id)).ToList();
        }

        /// <inheritdoc/>
        public MasterEditDTO GetMaster(int? id)
        {
            Context context = new();
            return _mapper.ProjectTo<MasterEditDTO>(context.Set<Master>().Where(i => i.Id == id)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public MasterEditDTO GetMasterByName(string name)
        {
            Context context = new();
            return _mapper.ProjectTo<MasterEditDTO>(context.Set<Master>().Where(i => i.NameMaster == name)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task SaveMasterAsync(MasterEditDTO masterDTO, CancellationToken token = default)
        {
            using Context db = new();
            Master master = new()
            {
                Id = masterDTO.Id,
                NameMaster = masterDTO.NameMaster,
                Address = masterDTO.Address,
                NumberPhone = masterDTO.NumberPhone,
                TypeSalary = masterDTO.TypeSalary,
                Rate = masterDTO.Rate
            };
            try
            {
                if (master.Id == 0)
                    db.Masters.Add(master);
                else
                {
                    db.Masters.Update(master);
                }

                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveMasterAsync(MasterEditDTO masterDTO, CancellationToken token = default)
        {
            using Context db = new();
            try
            {
                var master = db.Masters.FirstOrDefault(c => c.Id == masterDTO.Id);
                db.Masters.Remove(master);
                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
