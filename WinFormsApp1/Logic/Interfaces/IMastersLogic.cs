using WinFormsApp1.DTO;

namespace WinFormsApp1.Logic.Interfaces
{
    public interface IMastersLogic
    {
        /// <summary>
        /// Получение списка мастеров для отображения в теблице/comboBox
        /// </summary>
        /// <returns>Список мастеров</returns>
        public List<MasterDTO> GetMastersForOutput();

        /// <summary>
        /// Получение списка мастеров
        /// </summary>
        /// <returns>Список мастеров</returns>
        public List<MasterEditDTO> GetMasters();

        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Запись</returns>
        public MasterEditDTO GetMaster(int? id);

        /// <summary>
        /// Сохранение мастера
        /// </summary>
        /// <param name="masterDTO">DTO мастера</param>
        public Task SaveMasterAsync(MasterEditDTO masterDTO);

        /// <summary>
        /// Удаление мастера
        /// </summary>
        /// <param name="masterDTO">DTO мастера</param>
        public Task RemoveMasterAsync(MasterEditDTO masterDTO);
    }
}
