using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IMasterRepository
    {
        /// <summary>
        /// Получение списка мастеров
        /// </summary>
        /// <returns>Список мастеров</returns>
        public Task<List<MasterEditDTO>> GetMastersAsync(CancellationToken token = default);

        /// <summary>
        /// Получение списка мастеров для отображения в теблице/comboBox
        /// </summary>
        /// <returns>Список мастеров</returns>
        public Task<List<MasterDTO>> GetMastersForOutputAsync(CancellationToken token = default);

        /// <summary>
        /// Получение мастера по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Мастер</returns>
        public Task<MasterEditDTO> GetMasterAsync(int? id, CancellationToken token = default);

        /// <summary>
        /// Получение мастера по имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="token"></param>
        /// <returns>Мастер</returns>
        public Task<MasterEditDTO> GetMasterByNameAsync(string name, CancellationToken token = default);

        /// <summary>
        /// Сохранение мастера
        /// </summary>
        /// <param name="masterDTO">DTO мастера</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task SaveMasterAsync(MasterEditDTO masterDTO, CancellationToken token = default);

        /// <summary>
        /// Удаление мастера
        /// </summary>
        /// <param name="masterDTO">DTO мастера</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task RemoveMasterAsync(MasterEditDTO masterDTO, CancellationToken token = default);
    }
}
