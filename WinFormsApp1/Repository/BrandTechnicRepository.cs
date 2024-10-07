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
        public async Task<int> SaveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO, CancellationToken token = default)
        {
            using Context context = new();
            /*BrandTechnic brandTechnic = new()
            {
                Id = brandTechnicDTO.Id,
                NameBrandTechnic = brandTechnicDTO.Name
            };*/
            var brandTechnic = _mapper.Map<BrandTechnicEditDTO, BrandTechnic>(brandTechnicDTO);
            try
            {
                if (brandTechnic.Id == 0)
                    context.BrandTechnices.Add(brandTechnic);
                else
                    context.BrandTechnices.Update(brandTechnic);

                await context.SaveChangesAsync(token);
                return brandTechnic.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO, CancellationToken token = default)
        {
            try
            {
                using Context context = new();
                var brandTechnic = _mapper.Map<BrandTechnicEditDTO, BrandTechnic>(brandTechnicDTO);
                //var brandTechnic = context.BrandTechnices.FirstOrDefault(c => c.Id == brandTechnicDTO.Id);
                context.BrandTechnices.Remove(brandTechnic);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
