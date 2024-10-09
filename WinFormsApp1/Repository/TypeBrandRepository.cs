using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class TypeBrandRepository : ITypeBrandRepository
    {
        IMapper _mapper;

        public TypeBrandRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<TypeBrandDTO>> GetTypeBrandAsync(int idBrand = 0, int idType = 0, CancellationToken token = default)
        {
            Context context = new();

            var set = context.TypeBrands.Where(c => true);

            if (idBrand != 0 && idType != 0)
                set = set.Where(i => i.TypeTechnicsId == idType && i.BrandTechnicsId == idBrand);
            else if (idBrand == 0 && idType != 0)
                set = set.Where(i => i.TypeTechnicsId == idType);
            else if (idBrand != 0 && idType == 0)
                set = set.Where(i => i.BrandTechnicsId == idBrand);

            return await _mapper.ProjectTo<TypeBrandDTO>(set).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<TypeBrandComboBoxDTO>> GetTypeBrandByNameTypeAsync(string nameType, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<TypeBrandComboBoxDTO>(context.Set<TypeBrand>()
                .Where(i => i.TypeTechnic.NameTypeTechnic == nameType)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task SaveTypeBrandAsync(TypeBrandDTO typeBrandDTO, CancellationToken token = default)
        {
            Context context = new();
            var typeBrand = _mapper.Map<TypeBrandDTO, TypeBrand>(typeBrandDTO);
            try
            {
                context.TypeBrands.Add(typeBrand);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveTypesBrandsAsync(TypeBrandDTO typeBrandDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var typeBrand = _mapper.Map<TypeBrandDTO, TypeBrand>(typeBrandDTO);
                context.TypeBrands.Remove(typeBrand);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

    }
}
