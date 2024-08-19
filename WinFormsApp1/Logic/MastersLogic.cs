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
    }
}
