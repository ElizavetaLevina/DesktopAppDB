using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository;
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
        public List<TypeBrandComboBoxDTO> GetTypeBrandByNameType(string name)
        {
            return _typeBrandRepository.GetTypeBrandByNameType(name);
        }

        /// <inheritdoc/>
        public List<TypeBrandDTO> GetTypeBrand(int idBrand = 0, int idType = 0)
        {
            return _typeBrandRepository.GetTypeBrand(idBrand: idBrand, idType: idType);
        }

        /// <inheritdoc/>
        public void SaveTypeBrand(List<int>? list, int id, NameTableToEditEnum name)
        {
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var idBrand = name == NameTableToEditEnum.TypeTechnic ? list[i] : id;
                    var idType = name == NameTableToEditEnum.TypeTechnic ? id: list[i];

                    if (!_typeBrandRepository.GetTypeBrand(idBrand, idType).Any())
                    {
                        var task = Task.Run(async () =>
                        {
                            var typeBrandDTO = new TypeBrandDTO()
                            {
                                BrandTechnicsId = idBrand,
                                TypeTechnicsId = idType
                            };
                            await _typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                        });
                        task.Wait();
                    }
                }
            }
        }

        /// <inheritdoc/>
        public void RemoveTypeBrandByList(List<int>? list, int id, NameTableToEditEnum name)
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
                    RemoveTypeBrand(typeBrandDTO);
                }
            }
        }

        /// <inheritdoc/>
        public void RemoveTypeBrand(TypeBrandDTO typeBrandDTO)
        {
            var task = Task.Run(async () =>
            {
                await _typeBrandRepository.RemoveTypesBrandsAsync(typeBrandDTO);
            });
            task.Wait();
        }
    }
}
