using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class MalfunctionsLogic : IMalfunctionsLogic
    {
        IMalfunctionRepository _malfunctionRepository;

        public MalfunctionsLogic(IMalfunctionRepository malfunctionRepository)
        {
            _malfunctionRepository = malfunctionRepository;
        }

        /// <inheritdoc/>
        public List<MalfunctionEditDTO> GetMalfunctions()
        {
            return _malfunctionRepository.GetMalfunctions();
        }

        /// <inheritdoc/>
        public MalfunctionEditDTO GetMalfunctionByName(string name)
        {
            var malfunctionDTO = _malfunctionRepository.GetMalfunctionByName(name);
            if (malfunctionDTO == null)
                return new MalfunctionEditDTO();
            else
                return malfunctionDTO;
        }

        /// <inheritdoc/>
        public int SaveMalfunction(MalfunctionEditDTO malfunctionDTO)
        {
            int idMalfunction = 0;
            var task = Task.Run(async () =>
            {
                idMalfunction = await _malfunctionRepository.SaveMalfunctionAsync(malfunctionDTO);
            });
            task.Wait();
            return idMalfunction;
        }

        /// <inheritdoc/>
        public MalfunctionEditDTO GetMalfunction(int id)
        {
            return _malfunctionRepository.GetMalfunction(id);
        }

        /// <inheritdoc/>
        public void RemoveMalfunction(MalfunctionEditDTO malfunctionDTO)
        {
            _malfunctionRepository.RemoveMalfunction(malfunctionDTO);
        }
    }
}
