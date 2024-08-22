using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class MastersLogic
    {
        MasterRepository masterRepository = new();
        /// <summary>
        /// Получение списка мастеров для отображения в теблице/comboBox
        /// </summary>
        /// <returns>Список мастеров</returns>
        public List<MasterDTO> GetMastersForOutput()
        {
            return masterRepository.GetMastersForOutput();
        }

        /// <summary>
        /// Получение списка мастеров
        /// </summary>
        /// <returns>Список мастеров</returns>
        public List<MasterEditDTO> GetMasters()
        {
            return masterRepository.GetMasters();
        }

        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Запись</returns>
        public MasterEditDTO GetMaster(int? id)
        {
            return masterRepository.GetMaster(id);
        }

        /// <summary>
        /// Сохранение мастера
        /// </summary>
        /// <param name="masterDTO">DTO мастера</param>
        public void SaveMaster(MasterEditDTO masterDTO)
        {
            var task = Task.Run(async () =>
            {
                await masterRepository.SaveMasterAsync(masterDTO);
            });
            task.Wait();
        }

        /// <summary>
        /// Удаление мастера
        /// </summary>
        /// <param name="masterDTO">DTO мастера</param>
        public void RemoveMaster(MasterEditDTO masterDTO)
        {
            var task = Task.Run(async () =>
            {
                await masterRepository.RemoveMasterAsync(masterDTO);
            });
            task.Wait();
        }

    }
}
