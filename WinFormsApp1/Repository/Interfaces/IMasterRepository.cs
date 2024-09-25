using WinFormsApp1.DTO;

namespace WinFormsApp1.Repository.Interfaces
{
    public interface IMasterRepository
    {
        /// <summary>
        /// Получение списка мастеров
        /// </summary>
        /// <returns>Список мастеров</returns>
        public List<MasterEditDTO> GetMasters();

        /// <summary>
        /// Получение списка мастеров для отображения в теблице/comboBox
        /// </summary>
        /// <returns>Список мастеров</returns>
        public List<MasterDTO> GetMastersForOutput();

        /// <summary>
        /// Получение мастера по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Мастер</returns>
        public MasterEditDTO GetMaster(int? id);

        public MasterEditDTO GetMasterByName(string name);

        public Task SaveMasterAsync(MasterEditDTO masterDTO, CancellationToken token = default);

        public Task RemoveMasterAsync(MasterEditDTO masterDTO, CancellationToken token = default);
    }
}
