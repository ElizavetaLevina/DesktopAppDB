using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class MalfunctionRepository : IMalfunctionRepository
    {
        IMapper _mapper;

        public MalfunctionRepository(IMapper mapper)
        {
            _mapper = mapper;
        } 
        /// <inheritdoc/>
        public async Task<List<MalfunctionEditDTO>> GetMalfunctionsAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<MalfunctionEditDTO>(context.Set<Malfunction>().OrderBy(i => i.Name)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<MalfunctionEditDTO> GetMalfunctionAsync(int id, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<MalfunctionEditDTO>(context.Set<Malfunction>().Where(i => i.Id == id))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<MalfunctionEditDTO> GetMalfunctionByNameAsync(string name, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<MalfunctionEditDTO>(context.Set<Malfunction>().Where(i => i.Name == name))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<int> SaveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var malfunction = _mapper.Map<MalfunctionEditDTO, Malfunction>(malfunctionDTO);
            
                if (malfunction.Id == 0)
                    context.Malfunctions.Add(malfunction);
                else
                    context.Malfunctions.Update(malfunction);
                await context.SaveChangesAsync(token);
                return malfunction.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var malfunction = _mapper.Map<MalfunctionEditDTO, Malfunction>(malfunctionDTO);
                context.Malfunctions.Remove(malfunction);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }

        }
    }
}
