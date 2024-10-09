using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IMalfunctionRepository
    {
         /// <summary>
         /// Получение списка неисправностей
         /// </summary>
         /// <returns>Список неисправностей</returns>
        public Task<List<MalfunctionEditDTO>> GetMalfunctionsAsync(CancellationToken token = default);

        /// <summary>
        /// Получение неисправности по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Неисправность</returns>
        public Task<MalfunctionEditDTO> GetMalfunctionAsync(int id, CancellationToken token = default);

        /// <summary>
        /// Получение неисправности по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Неисправность</returns>
        public Task<MalfunctionEditDTO> GetMalfunctionByNameAsync(string name, CancellationToken token = default);

        public Task<int> SaveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO, CancellationToken token = default);

        public Task RemoveMalfunctionAsync(MalfunctionEditDTO malfunctionDTO, CancellationToken token = default);
    }
}
