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
        public int GetTypeTechnic(string name)
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
        /// Сохранение типа устройства
        /// </summary>
        /// <param name="name">Название</param>
        public int SaveTypeTechnic(int idType, string name)
        {
            var idTypeTechnic = 0;
            var typeTechnicDTO = typeTechnicRepository.GetTypeTechnic(idType, name);
            var task = Task.Run(async () =>
            {
                //var typeTechnicDTO = new TypeTechnicEditDTO() { Id = 0, Name = name };
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
