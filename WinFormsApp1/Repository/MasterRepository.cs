using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<MasterEditDTO>> GetMastersAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<MasterEditDTO>(context.Set<Master>().OrderBy(i => i.Id)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<MasterDTO>> GetMastersForOutputAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<MasterDTO>(context.Set<Master>().OrderBy(i => i.NameMaster)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<MasterEditDTO> GetMasterAsync(int? id, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<MasterEditDTO>(context.Set<Master>().Where(i => i.Id == id)).FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<MasterEditDTO> GetMasterByNameAsync(string name, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<MasterEditDTO>(context.Set<Master>().Where(i => i.NameMaster == name))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task SaveMasterAsync(MasterEditDTO masterDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
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
            Context context = new();
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
