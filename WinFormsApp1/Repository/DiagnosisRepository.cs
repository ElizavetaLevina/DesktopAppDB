using AutoMapper;
using MoreLinq.Extensions;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<DiagnosisEditDTO>> GetDiagnosesAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<DiagnosisEditDTO>(context.Set<Diagnosis>().OrderBy(i => i.Name)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<DiagnosisEditDTO> GetDiagnosisAsync(int? id, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<DiagnosisEditDTO>(context.Set<Diagnosis>().Where(i => i.Id == id))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<DiagnosisEditDTO>> GetDiagnosesByNameAsync(string name, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<DiagnosisEditDTO>(context.Set<Diagnosis>()
                .Where(i => i.Name.ToLower().Contains(name.ToLower()))).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<DiagnosisEditDTO> GetDiagnosisByNameAsync(string name, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<DiagnosisEditDTO>(context.Set<Diagnosis>().Where(i => i.Name == name))
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<int> SaveDiagnosisAsync(DiagnosisEditDTO diagnosisDTO, CancellationToken token = default)
        {
            Context context = new();
            var diagnosis = _mapper.Map<DiagnosisEditDTO, Diagnosis>(diagnosisDTO);
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
                context.Diagnosis.Remove(diagnosis);
                await context.SaveChangesAsync(token);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
