using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class TypesBrandsLogic : ITypesBrandsLogic
    {
        ITypeBrandRepository _typeBrandRepository;

        public TypesBrandsLogic(ITypeBrandRepository typeBrandRepository)
        {
            _typeBrandRepository = typeBrandRepository;
        }

        /// <inheritdoc/>
        public async Task<List<TypeBrandComboBoxDTO>> GetTypeBrandByNameTypeAsync(string name)
        {
            return await _typeBrandRepository.GetTypeBrandByNameTypeAsync(name);
        }

        /// <inheritdoc/>
        public async Task<List<TypeBrandDTO>> GetTypeBrandAsync(int idBrand = 0, int idType = 0)
        {
            return await _typeBrandRepository.GetTypeBrandAsync(idBrand: idBrand, idType: idType);
        }

        /// <inheritdoc/>
        public async Task SaveTypeBrandAsync(List<int>? list, int id, NameTableToEditEnum name)
        {
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var idBrand = name == NameTableToEditEnum.TypeTechnic ? list[i] : id;
                    var idType = name == NameTableToEditEnum.TypeTechnic ? id: list[i];

                    if (!(await _typeBrandRepository.GetTypeBrandAsync(idBrand, idType)).Any())
                    {
                        var typeBrandDTO = new TypeBrandDTO()
                        {
                            BrandTechnicsId = idBrand,
                            TypeTechnicsId = idType
                        };
                        await _typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                    }
                }
            }
        }

        /// <inheritdoc/>
        public async Task RemoveTypeBrandByListAsync(List<int>? list, int id, NameTableToEditEnum name)
        {
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var idBrand = name == NameTableToEditEnum.TypeTechnic ? list[i] : id;
                    var idType = name == NameTableToEditEnum.TypeTechnic ? id: list[i];
                    var typeBrandDTO = new TypeBrandDTO()
                    {
                        BrandTechnicsId = idBrand,
                        TypeTechnicsId = idType
                    };
                    await RemoveTypeBrandAsync(typeBrandDTO);
                }
            }
        }

        /// <inheritdoc/>
        public async Task RemoveTypeBrandAsync(TypeBrandDTO typeBrandDTO)
        {
            await _typeBrandRepository.RemoveTypesBrandsAsync(typeBrandDTO);
        }
    }
}
