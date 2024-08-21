using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class MalfunctionsLogic
    {
        MalfunctionRepository malfunctionRepository = new();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetMalfunctions()
        {
            var malfunctionDTO = malfunctionRepository.GetMalfunctions();
            List<string> malfunctions = [];
            foreach (var item in malfunctionDTO)
            {
                malfunctions.Add(item.Name);
            }
            return malfunctions;
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
    }
}
