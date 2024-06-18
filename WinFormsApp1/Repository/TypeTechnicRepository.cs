using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class TypeTechnicRepository
    {
        public List<TypeTechnicDTO> GetTypeTechnics(bool whole = true, string name = "")
        {
            Context context = new();
            var set = context.TypeTechnices.Where(c => true);
            if (!whole)
                set = set.Where(c => c.NameTypeTechnic == name);
            return set
                .Select(a => new TypeTechnicDTO(a))
                .ToList();
        }

        public async Task<int> SaveTypeTechnicAsync(TypeTechnicEditDTO typeTechnicDTO, CancellationToken token = default)
        {
            using Context db = new();
            TypeTechnic typeTechnic = new()
            {
                Id = typeTechnicDTO.Id,
                NameTypeTechnic = typeTechnicDTO.Name
            };
            try
            {
                if (typeTechnic.Id == 0)
                    db.TypeTechnices.Add(typeTechnic);
                else
                    db.TypeTechnices.Update(typeTechnic);
                await db.SaveChangesAsync(token);
                return typeTechnic.Id;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); throw; }
        }

        public void RemoveTypeTechnic(TypeTechnicEditDTO typeTechnicDTO)
        {
            try
            {
                using Context db = new();
                var typeTechnic = db.TypeTechnices.FirstOrDefault(c => c.Id == typeTechnicDTO.Id);
                db.TypeTechnices.Remove(typeTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); throw; }
        }
    }
}
