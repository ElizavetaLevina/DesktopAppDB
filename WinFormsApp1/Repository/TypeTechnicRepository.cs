using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class TypeTechnicRepository : ITypeTechnicRepository
    {
        IMapper _mapper;

        public TypeTechnicRepository (IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<TypeTechnicDTO>> GetTypesTechnicAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<TypeTechnicDTO>(context.Set<TypeTechnic>().OrderBy(i => i.NameTypeTechnic))
                .ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<TypeTechnicDTO> GetTypeTechnicByNameAsync(string name, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<TypeTechnicDTO>(context.Set<TypeTechnic>().Where(i => i.NameTypeTechnic == name))
                .FirstOrDefaultAsync(token);
        }


        /// <inheritdoc/>
        public async Task<TypeTechnicEditDTO> GetTypeTechnicAsync(int id, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<TypeTechnicEditDTO>(context.Set<TypeTechnic>().Where(i => i.Id == id))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<int> SaveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO, CancellationToken token = default)
        {
            Context context = new();
            var typeTechnic = _mapper.Map<TypeTechnicEditDTO, TypeTechnic>(typeTechnicDTO);
            try
            {
                if (typeTechnic.Id == 0)
                    context.TypeTechnices.Add(typeTechnic);
                else
                    context.TypeTechnices.Update(typeTechnic);
                await context.SaveChangesAsync(token);
                return typeTechnic.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var typeTechnic = _mapper.Map<TypeTechnicEditDTO, TypeTechnic>(typeTechnicDTO);
                context.TypeTechnices.Remove(typeTechnic);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
