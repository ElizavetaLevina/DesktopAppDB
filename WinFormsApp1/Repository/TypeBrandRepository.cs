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
            using Context db = new();
            TypeBrand typeBrand = new()
            {
                BrandTechnicsId = typeBrandDTO.BrandTechnicsId,
                TypeTechnicsId = typeBrandDTO.TypeTechnicsId
            };
            try
            {
                db.TypeBrands.Add(typeBrand);
                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public void RemoveTypesBrands(TypeBrandDTO typeBrandDTO)
        {
            try
            {
                using Context db = new();
                var typeBrand = db.TypeBrands.FirstOrDefault(c => c.BrandTechnicsId == typeBrandDTO.BrandTechnicsId &&
                    c.TypeTechnicsId == typeBrandDTO.TypeTechnicsId);
                db.TypeBrands.Remove(typeBrand);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

    }
}
