using AutoMapper;
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
        public List<MalfunctionEditDTO> GetMalfunctions()
        {
            Context context = new();
            return _mapper.ProjectTo<MalfunctionEditDTO>(context.Set<Malfunction>().OrderBy(i => i.Name)).ToList();
        }

        /// <inheritdoc/>
        public MalfunctionEditDTO GetMalfunction(int id)
        {
            Context context = new();
            return _mapper.ProjectTo<MalfunctionEditDTO>(context.Set<Malfunction>().Where(i => i.Id == id)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public MalfunctionEditDTO GetMalfunctionByName(string name)
        {
            Context context = new();
            return _mapper.ProjectTo<MalfunctionEditDTO>(context.Set<Malfunction>().Where(i => i.Name == name)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<int> SaveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO, CancellationToken token = default)
        {
            Context db = new();
            Malfunction malfunction = new()
            {
                Id = malfunctionDTO.Id,
                Name = malfunctionDTO.Name,
                Price = malfunctionDTO.Price
            };
            try
            {
                if (malfunction.Id == 0)
                    db.Malfunctions.Add(malfunction);
                else
                    db.Malfunctions.Update(malfunction);
                await db.SaveChangesAsync(token);
                return malfunction.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public void RemoveMalfunction(MalfunctionEditDTO malfunctionDTO)
        {
            try
            {
                Context db = new();
                var malfunction = db.Malfunctions.FirstOrDefault(c => c.Id == malfunctionDTO.Id);
                db.Malfunctions.Remove(malfunction);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
