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
            return _mapper.ProjectTo<MasterDTO>(context.Set<Master>().OrderBy(i => i.NameMaster)).ToList();
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
            try
            {
                using Context context = new();
                var master = _mapper.Map<MasterEditDTO, Master>(masterDTO);
            
                if (master.Id == 0)
                    context.Masters.Add(master);
                else
                    context.Masters.Update(master);

                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveMasterAsync(MasterEditDTO masterDTO, CancellationToken token = default)
        {
            using Context context = new();
            try
            {
                var master = _mapper.Map<MasterEditDTO, Master>(masterDTO);
                context.Masters.Remove(master);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
