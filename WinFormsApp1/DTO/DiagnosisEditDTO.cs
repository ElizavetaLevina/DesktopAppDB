using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class DiagnosisEditDTO
    {
        /// <summary>
        /// Редактирование диагноза
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DiagnosisEditDTO()
        {
        }
    }
}
