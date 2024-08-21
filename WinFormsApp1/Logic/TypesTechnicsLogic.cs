using DocumentFormat.OpenXml.Office2010.Excel;
using WinFormsApp1.DTO;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Logic
{
    public class TypesTechnicsLogic
    {
        TypeTechnicRepository typeTechnicRepository = new(); 

        /// <summary>
        /// Получение списка типов устройств
        /// </summary>
        /// <returns>Список типов устройств</returns>
        public List<TypeTechnicDTO> GetTypesTechnic()
        {
            return typeTechnicRepository.GetTypesTechnic();
        }
    
        /// <summary>
        /// Получение идентификатора типа устройства по названию 
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Идентификатор</returns>
        public int GetIdTypeTechnic(string name)
        {
            return typeTechnicRepository.GetTypeTechnicByName(name).Id;
        }

        /// <summary>
        /// Получение названия типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Тип устройства</returns>
        public string GetTypeTechnicName(int id)
        {
            return typeTechnicRepository.GetTypeTechnicName(id);
        }

        /// <summary>
        /// Получение типа устройства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        /// <returns>Тип устройства</returns>
        public TypeTechnicEditDTO GetTypeTechnic(int id, string name)
        {
            return typeTechnicRepository.GetTypeTechnic(id, name);
        }

        /// <summary>
        /// Сохранение типа устройства
        /// </summary>
        /// <param name="typeTechnicDTO">DTO типа устройства</param>
        public int SaveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO)
        {
            var idTypeTechnic = 0;
            var task = Task.Run(async () =>
            {
                idTypeTechnic = await typeTechnicRepository.SaveTypeTechnicAsync(typeTechnicDTO);
            });
            task.Wait();
            return idTypeTechnic;
        }

        /// <summary>
        /// Удаление типа устройства
        /// </summary>
        /// <param name="typeTechnicDTO">DTO типа устройства</param>
        public void RemoveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO)
        {
            typeTechnicRepository.RemoveTypeTechnic(typeTechnicDTO);
        }
    }
}
