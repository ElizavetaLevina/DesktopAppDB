using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository;
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
        public List<TypeTechnicDTO> GetTypesTechnic()
        {
            return _typeTechnicRepository.GetTypesTechnic();
        }

        /// <inheritdoc/>
        public int GetIdTypeTechnic(string name)
        {
            return _typeTechnicRepository.GetTypeTechnicByName(name).Id;
        }

        /// <inheritdoc/>
        public string GetTypeTechnicName(int id)
        {
            //return _typeTechnicRepository.GetTypeTechnic(id).Name;
            var typeTechnicDTO = _typeTechnicRepository.GetTypeTechnic(id);
            if (typeTechnicDTO == null)
                return string.Empty;
            else return typeTechnicDTO.Name;
        }

        /// <inheritdoc/>
        public TypeTechnicEditDTO GetTypeTechnic(int id)
        {
            var typeTechnic = _typeTechnicRepository.GetTypeTechnic(id);
            if (typeTechnic == null)
                return new TypeTechnicEditDTO();
            else
                return typeTechnic;
        }

        /// <inheritdoc/>
        public int SaveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO)
        {
            var idTypeTechnic = 0;
            var task = Task.Run(async () =>
            {
                idTypeTechnic = await _typeTechnicRepository.SaveTypeTechnicAsync(typeTechnicDTO);
            });
            task.Wait();
            return idTypeTechnic;
        }

        /// <inheritdoc/>
        public void RemoveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO)
        {
            var task = Task.Run(async () =>
            {
                await _typeTechnicRepository.RemoveTypeTechnicAsync(typeTechnicDTO);
            });
            task.Wait();
        }
    }
}
