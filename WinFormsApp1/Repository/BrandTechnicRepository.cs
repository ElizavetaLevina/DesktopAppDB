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
        public async Task<List<BrandTechnicDTO>> GetBrandsTechnicAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<BrandTechnicDTO>(context.Set<BrandTechnic>().OrderBy(i => i.NameBrandTechnic))
                .ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<BrandTechnicDTO> GetBrandTechnicByNameAsync(string name, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<BrandTechnicDTO>(context.Set<BrandTechnic>()
                .Where(i => EF.Functions.ILike(i.NameBrandTechnic, name))).FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<BrandTechnicEditDTO> GetBrandTechnicAsync(int id, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<BrandTechnicEditDTO>(context.Set<BrandTechnic>().Where(i => i.Id == id))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<int> SaveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO, CancellationToken token = default)
        {
            Context context = new();
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
                Context context = new();
                var brandTechnic = _mapper.Map<BrandTechnicEditDTO, BrandTechnic>(brandTechnicDTO);
                context.BrandTechnices.Remove(brandTechnic);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
