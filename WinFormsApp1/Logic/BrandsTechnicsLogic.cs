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
        public async Task<int> GetIdBrandTechnicAsync(string name)
        {
            var brandTechnicDTO = await _brandTechnicRepository.GetBrandTechnicByNameAsync(name);
            return brandTechnicDTO.Id;
        }

        /// <inheritdoc/>
        public async Task<BrandTechnicEditDTO> GetBrandTechnicAsync(int id)
        {
            var brandTechnicDTO = await _brandTechnicRepository.GetBrandTechnicAsync(id);
            if (brandTechnicDTO == null)
                return new BrandTechnicEditDTO();
            else
                return brandTechnicDTO;
        }

        /// <inheritdoc/>
        public async Task<List<BrandTechnicDTO>> GetBrandsTechnicAsync()
        {
            return await _brandTechnicRepository.GetBrandsTechnicAsync();
        }

        /// <inheritdoc/>
        public async Task<string> GetBrandTechnicNameAsync(int id) 
        {
            var brandTechnicDTO = await _brandTechnicRepository.GetBrandTechnicAsync(id);
            if (brandTechnicDTO == null)
                return string.Empty;
            else return brandTechnicDTO.Name;
        }

        /// <inheritdoc/>
        public async Task<int> SaveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO)
        {
            return await _brandTechnicRepository.SaveBrandTechnicAsync(brandTechnicDTO);
        }

        /// <inheritdoc/>
        public async Task RemoveBrandTechnicAsync(BrandTechnicEditDTO brandTechnicDTO)
        {
            await _brandTechnicRepository.RemoveBrandTechnicAsync(brandTechnicDTO);
        }
    }
}
