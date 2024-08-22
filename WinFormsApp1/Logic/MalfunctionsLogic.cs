using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class MalfunctionsLogic
    {
        MalfunctionRepository malfunctionRepository = new();

        /// <summary>
        /// Получение списка неисправностей
        /// </summary>
        /// <returns>Список неисправностей</returns>
        public List<MalfunctionEditDTO> GetMalfunctions()
        {
            return malfunctionRepository.GetMalfunctions();
        }

        /// <summary>
        /// Получение неисправности по названию
        /// </summary>
        /// <param name="name">Название неисправности</param>
        /// <returns>Неисправность</returns>
        public MalfunctionEditDTO GetMalfunctionByName(string name)
        {
            return malfunctionRepository.GetMalfunctionByName(name);
        }

        /// <summary>
        /// Сохранение неисправности
        /// </summary>
        /// <param name="malfunctionDTO">DTO неисправности</param>
        /// <returns>Идентификатор неисправности</returns>
        public int SaveMalfunction(MalfunctionEditDTO malfunctionDTO)
        {
            int idMalfunction = 0;
            var task = Task.Run(async () =>
            {
                idMalfunction = await malfunctionRepository.SaveMalfunctionAsync(malfunctionDTO);
            });
            task.Wait();
            return idMalfunction;
        }

        /// <summary>
        /// Получение неисправности по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Неисправность</returns>
        public MalfunctionEditDTO GetMalfunction(int id)
        {
            return malfunctionRepository.GetMalfunction(id);
        }

        /// <summary>
        /// Удаление неисправности
        /// </summary>
        /// <param name="malfunctionDTO"></param>
        public void RemoveMalfunction(MalfunctionEditDTO malfunctionDTO)
        {
            malfunctionRepository.RemoveMalfunction(malfunctionDTO);
        }
    }
}
