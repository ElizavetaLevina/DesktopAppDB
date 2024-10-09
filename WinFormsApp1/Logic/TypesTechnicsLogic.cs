using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class TypesTechnicsLogic : ITypesTechnicsLogic
    {
        ITypeTechnicRepository _typeTechnicRepository; 

        public TypesTechnicsLogic(ITypeTechnicRepository typeTechnicRepository)
        {
            _typeTechnicRepository = typeTechnicRepository;
        }

        /// <inheritdoc/>
        public async Task<List<TypeTechnicDTO>> GetTypesTechnicAsync()
        {
            return await _typeTechnicRepository.GetTypesTechnicAsync();
        }

        /// <inheritdoc/>
        public async Task<int> GetIdTypeTechnicAsync(string name)
        {
            return (await _typeTechnicRepository.GetTypeTechnicByNameAsync(name)).Id;
        }

        /// <inheritdoc/>
        public async Task<string> GetTypeTechnicNameAsync(int id)
        {
            var typeTechnicDTO = await _typeTechnicRepository.GetTypeTechnicAsync(id);
            if (typeTechnicDTO == null)
                return string.Empty;
            else return typeTechnicDTO.Name;
        }

        /// <inheritdoc/>
        public async Task<TypeTechnicEditDTO> GetTypeTechnicAsync(int id)
        {
            var typeTechnic = await _typeTechnicRepository.GetTypeTechnicAsync(id);
            if (typeTechnic == null)
                return new TypeTechnicEditDTO();
            else
                return typeTechnic;
        }

        /// <inheritdoc/>
        public async Task<int> SaveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO)
        {
            return await _typeTechnicRepository.SaveTypeTechnicAsync(typeTechnicDTO);
        }

        /// <inheritdoc/>
        public async Task RemoveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO)
        {
            await _typeTechnicRepository.RemoveTypeTechnicAsync(typeTechnicDTO);
        }
    }
}
