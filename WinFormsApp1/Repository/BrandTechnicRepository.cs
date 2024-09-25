using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class BrandTechnicRepository : IBrandTechnicRepository
    {
        IMapper _mapper;

        public BrandTechnicRepository(IMapper mapper) 
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public List<BrandTechnicDTO> GetBrandsTechnic()
        {
            Context context = new();
            return _mapper.ProjectTo<BrandTechnicDTO>(context.Set<BrandTechnic>().OrderBy(i => i.NameBrandTechnic)).ToList();
        }

        /// <inheritdoc/>
        public BrandTechnicDTO GetBrandTechnicByName(string name)
        {
            Context context = new();
            return _mapper.ProjectTo<BrandTechnicDTO>(context.Set<BrandTechnic>()
                .Where(i => EF.Functions.ILike(i.NameBrandTechnic, name))).FirstOrDefault();
        }

        /// <inheritdoc/>
        public BrandTechnicEditDTO GetBrandTechnic(int id)
        {
            Context context = new();
            return _mapper.ProjectTo<BrandTechnicEditDTO>(context.Set<BrandTechnic>().Where(i => i.Id == id)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public BrandTechnicDTO GetBrandTechnicName(int id)
        {
            Context context = new();
            return _mapper.ProjectTo<BrandTechnicDTO>(context.Set<BrandTechnic>().Where(i => i.Id == id)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<int> SaveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO, CancellationToken token = default)
        {
            using Context db = new();
            BrandTechnic brandTechnic = new()
            {
                Id = brandTechnicDTO.Id,
                NameBrandTechnic = brandTechnicDTO.Name
            };
            try
            {
                if (brandTechnic.Id == 0)
                    db.BrandTechnices.Add(brandTechnic);
                else
                    db.BrandTechnices.Update(brandTechnic);

                await db.SaveChangesAsync(token);
                return brandTechnic.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public void RemoveBrandTechnic(BrandTechnicEditDTO brandTechnicDTO)
        {
            try
            {
                using Context db = new();
                var brandTechnic = db.BrandTechnices.FirstOrDefault(c => c.Id == brandTechnicDTO.Id);
                db.BrandTechnices.Remove(brandTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
