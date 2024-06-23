using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class MalfunctionRepository
    {
        /// <summary>
        /// Получение списка неисправностей
        /// </summary>
        /// <returns>Список неисправностей</returns>
        public List<MalfunctionEditDTO> GetMalfunctions()
        {
            Context context = new();
            return context.Malfunctions.Select(a => new MalfunctionEditDTO(a)).ToList();
        }

        /// <summary>
        /// Получение неисправности по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Неисправность</returns>
        public MalfunctionEditDTO GetMalfunctionByName(string name)
        {
            Context context = new();
            //return new MalfunctionEditDTO(context.Malfunctions.First(i => i.Name == name));


            var malfunction = context.Malfunctions.FirstOrDefault(i => i.Name == name);
            if (malfunction != null)
            {
                return new MalfunctionEditDTO(malfunction);
            }
            else
                return new MalfunctionEditDTO(name);
        }

        public async Task<int> SaveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO, CancellationToken token = default)
        {
            Context db = new();
            Malfunction malfunction = new()
            {
                Id = malfunctionDTO.Id,
                Name = malfunctionDTO.Name,
                Price = malfunctionDTO.Price
            };
            try
            {
                if (malfunction.Id == 0)
                    db.Malfunctions.Add(malfunction);
                else
                    db.Malfunctions.Update(malfunction);
                await db.SaveChangesAsync(token);
                return malfunction.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
