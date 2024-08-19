using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class TypesBrandsLogic
    {
        TypeBrandRepository typeBrandRepository = new();

        /// <summary>
        /// Получение списка брендов устройств для comboBox по типу устройства
        /// </summary>
        /// <param name="name">Название типа устройства</param>
        /// <returns></returns>
        public List<TypeBrandComboBoxDTO> GetTypeBrandByNameType(string name)
        {
            return typeBrandRepository.GetTypeBrandByNameType(name);
        }

        /// <summary>
        /// Получение списка тип-бренд устройства по идентификатору бренда или типа устройства
        /// </summary>
        /// <param name="idBrand">Идентификатор бренда</param>
        /// <param name="idType">Идентификатор типа устройства</param>
        /// <returns></returns>
        public List<TypeBrandDTO> GetTypeBrand(int idBrand = 0, int idType = 0)
        {
            return typeBrandRepository.GetTypeBrand(idBrand: idBrand, idType: idType);
        }

        /// <summary>
        /// Сохранение списка тип-бренд
        /// </summary>
        /// <param name="list">Список типов/брендов</param>
        /// <param name="id">Идентификатор типа/бренда</param>
        /// <param name="name">Название таблицы</param>
        public void SaveTypeBrand(List<int>? list, int id, NameTableToEditEnum name)
        {
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var idBrand = name == NameTableToEditEnum.TypeTechnic ? list[i] : id;
                    var idType = name == NameTableToEditEnum.TypeTechnic ? id: list[i];

                    if (!typeBrandRepository.GetTypeBrand(idBrand, idType).Any())
                    {
                        var task = Task.Run(async () =>
                        {
                            var typeBrandDTO = new TypeBrandDTO()
                            {
                                BrandTechnicsId = idBrand,
                                TypeTechnicsId = idType
                            };
                            await typeBrandRepository.SaveTypeBrandAsync(typeBrandDTO);
                        });
                        task.Wait();
                    }
                }
            }
        }

        /// <summary>
        /// Удаление списка тип-бренд
        /// </summary>
        /// <param name="list">Список типов/брендов</param>
        /// <param name="id">Идентификатор типа/бренда</param>
        /// <param name="name">Название таблицы</param>
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
                    typeBrandRepository.RemoveTypesBrands(typeBrandDTO);
                }
            }
        }

        public void RemoveTypeBrand(int idBrand = 0, int idType = 0)
        {
            var typesBrandsDTO = GetTypeBrand(idBrand, idType);
            foreach(var typesBrand in typesBrandsDTO)
            {
                typeBrandRepository.RemoveTypesBrands(typesBrand);
            }
        }
    }
}
