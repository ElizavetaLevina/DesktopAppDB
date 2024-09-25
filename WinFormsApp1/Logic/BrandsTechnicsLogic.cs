using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class BrandsTechnicsLogic : IBrandsTechnicsLogic
    {
        IBrandTechnicRepository _brandTechnicRepository;

        public BrandsTechnicsLogic(IBrandTechnicRepository brandTechnicRepository)
        {
            _brandTechnicRepository = brandTechnicRepository;
        }

        /// <inheritdoc/>
        public int GetIdBrandTechnic(string name)
        {
            return _brandTechnicRepository.GetBrandTechnicByName(name).Id;
        }

        /// <inheritdoc/>
        public BrandTechnicEditDTO GetBrandTechnic(int id)
        {
            var brandTechnicDTO = _brandTechnicRepository.GetBrandTechnic(id);
            if (brandTechnicDTO == null)
                return new BrandTechnicEditDTO();
            else
                return brandTechnicDTO;
        }

        /// <inheritdoc/>
        public List<BrandTechnicDTO> GetBrandsTechnic()
        {
            return _brandTechnicRepository.GetBrandsTechnic();
        }

        /// <inheritdoc/>
        public string GetBrandTechnicName(int id) 
        {
            var brandTechnicDTO = _brandTechnicRepository.GetBrandTechnicName(id);
            if (brandTechnicDTO == null)
                return string.Empty;
            else return brandTechnicDTO.NameBrandTechnic;
        }

        /// <inheritdoc/>
        public int SaveBrandTechnic(BrandTechnicEditDTO brandTechnicDTO)
        {
            var idBrandTechnic = 0;
            var task = Task.Run(async () =>
            {
                idBrandTechnic = await _brandTechnicRepository.SaveBrandTechnicAsync(brandTechnicDTO);
            });
            task.Wait();
            return idBrandTechnic;
        }

        /// <inheritdoc/>
        public void RemoveBrandTechnic(BrandTechnicEditDTO brandTechnicDTO)
        {
            _brandTechnicRepository.RemoveBrandTechnic(brandTechnicDTO);
        }
    }
}
