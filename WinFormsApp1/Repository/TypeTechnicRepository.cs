using AutoMapper;
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
        public List<TypeTechnicDTO> GetTypesTechnic()
        {
            Context context = new();
            return _mapper.ProjectTo<TypeTechnicDTO>(context.Set<TypeTechnic>().OrderBy(i => i.NameTypeTechnic)).ToList();
        }

        /// <inheritdoc/>
        public TypeTechnicDTO GetTypeTechnicByName(string name)
        {
            Context context = new();
            return _mapper.ProjectTo<TypeTechnicDTO>(context.Set<TypeTechnic>().Where(i => i.NameTypeTechnic == name)).FirstOrDefault();
        }


        /// <inheritdoc/>
        public TypeTechnicEditDTO GetTypeTechnic(int id)
        {
            Context context = new();
            return _mapper.ProjectTo<TypeTechnicEditDTO>(context.Set<TypeTechnic>().Where(i => i.Id == id)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<int> SaveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO, CancellationToken token = default)
        {
            using Context context = new();
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
                using Context context = new();
                var typeTechnic = _mapper.Map<TypeTechnicEditDTO, TypeTechnic>(typeTechnicDTO);
                context.TypeTechnices.Remove(typeTechnic);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
