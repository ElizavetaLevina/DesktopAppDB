using AutoMapper;
using MoreLinq.Extensions;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        IMapper _mapper;
        public DiagnosisRepository(IMapper mapper) 
        { 
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public List<DiagnosisEditDTO> GetDiagnoses()
        {
            Context context = new();
            return _mapper.ProjectTo<DiagnosisEditDTO>(context.Set<Diagnosis>().OrderBy(i => i.Name)).ToList();
        }

        /// <inheritdoc/>
        public DiagnosisEditDTO GetDiagnosis(int? id)
        {
            Context context = new();
            return _mapper.ProjectTo<DiagnosisEditDTO>(context.Set<Diagnosis>().Where(i => i.Id == id)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public List<DiagnosisEditDTO> GetDiagnosesByName(string name)
        {
            Context context = new();
            return _mapper.ProjectTo<DiagnosisEditDTO>(context.Set<Diagnosis>()
                .Where(i => i.Name.ToLower().Contains(name.ToLower()))).ToList();
        }

        /// <inheritdoc/>
        public DiagnosisEditDTO GetDiagnosisByName(string name)
        {
            Context context = new();
            return _mapper.ProjectTo<DiagnosisEditDTO>(context.Set<Diagnosis>().Where(i => i.Name == name)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<int> SaveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO, CancellationToken token = default)
        {
            Context context = new();
            var diagnosis = _mapper.Map<DiagnosisEditDTO, Diagnosis>(diagnosisDTO);
            /*Diagnosis diagnosis = new()
            {
                Id = diagnosisDTO.Id,
                Name = diagnosisDTO.Name
            };*/
            try
            {
                if (diagnosis.Id == 0)
                    context.Diagnosis.Add(diagnosis);
                else
                    context.Diagnosis.Update(diagnosis);
                await context.SaveChangesAsync(token);
                return diagnosis.Id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var diagnosis = _mapper.Map<DiagnosisEditDTO, Diagnosis>(diagnosisDTO);
                //var diagnosis = context.Diagnosis.FirstOrDefault(c => c.Id == diagnosisDTO.Id);
                context.Diagnosis.Remove(diagnosis);
                await context.SaveChangesAsync(token);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
