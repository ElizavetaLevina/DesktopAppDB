using AutoMapper;
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
        public List<TypeBrandDTO> GetTypeBrand(int idBrand = 0, int idType = 0)
        {
            Context context = new();

            var set = context.TypeBrands.Where(c => true);

            if (idBrand != 0 && idType != 0)
                set = set.Where(i => i.TypeTechnicsId == idType && i.BrandTechnicsId == idBrand);
            else if (idBrand == 0 && idType != 0)
                set = set.Where(i => i.TypeTechnicsId == idType);
            else if (idBrand != 0 && idType == 0)
                set = set.Where(i => i.BrandTechnicsId == idBrand);

            return _mapper.ProjectTo<TypeBrandDTO>(set).ToList();
        }

        /// <inheritdoc/>
        public List<TypeBrandComboBoxDTO> GetTypeBrandByNameType(string nameType)
        {
            Context context = new();
            return _mapper.ProjectTo<TypeBrandComboBoxDTO>(context.Set<TypeBrand>()
                .Where(i => i.TypeTechnic.NameTypeTechnic == nameType)).ToList();
        }

        /// <inheritdoc/>
        public async Task SaveTypeBrandAsync(TypeBrandDTO typeBrandDTO, CancellationToken token = default)
        {
            using Context context = new();
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
                using Context context = new();
                var typeBrand = _mapper.Map<TypeBrandDTO, TypeBrand>(typeBrandDTO);
                context.TypeBrands.Remove(typeBrand);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

    }
}
