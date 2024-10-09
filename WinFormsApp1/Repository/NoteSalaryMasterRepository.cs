using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class NoteSalaryMasterRepository : INoteSalaryMasterRepository
    {
        IMapper _mapper;

        public NoteSalaryMasterRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<NoteSalaryMasterEditDTO>> GetNoteSalaryMastersAsync(DateTime date, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<NoteSalaryMasterEditDTO>(context.Set<NoteSalaryMaster>()
                .Where(i => i.Date == date.ToUniversalTime())).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var noteSalaryMaster = _mapper.Map<NoteSalaryMasterEditDTO, NoteSalaryMaster>(noteSalaryMasterDTO);

                if (noteSalaryMaster.Id == 0)
                    context.NoteSalaryMasters.Add(noteSalaryMaster);
                else
                    context.NoteSalaryMasters.Update(noteSalaryMaster);

                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
