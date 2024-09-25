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
            using Context db = new();
            TypeTechnic typeTechnic = new()
            {
                Id = typeTechnicDTO.Id,
                NameTypeTechnic = typeTechnicDTO.Name
            };
            try
            {
                if (typeTechnic.Id == 0)
                    db.TypeTechnices.Add(typeTechnic);
                else
                    db.TypeTechnices.Update(typeTechnic);
                await db.SaveChangesAsync(token);
                return typeTechnic.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public void RemoveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO)
        {
            try
            {
                using Context db = new();
                var typeTechnic = db.TypeTechnices.FirstOrDefault(c => c.Id == typeTechnicDTO.Id);
                db.TypeTechnices.Remove(typeTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
