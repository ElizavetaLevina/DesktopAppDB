using AutoMapper;
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
        public List<NoteSalaryMasterEditDTO> GetNoteSalaryMasters(DateTime date)
        {
            Context context = new();
            return _mapper.ProjectTo<NoteSalaryMasterEditDTO>(context.Set<NoteSalaryMaster>()
                .Where(i => i.Date == date.ToUniversalTime())).ToList();
        }

        /// <inheritdoc/>
        public async Task SaveNoteSalaryMasterAsync(NoteSalaryMasterEditDTO noteSalaryMasterDTO, CancellationToken token = default)
        {
            Context context = new();
            NoteSalaryMaster noteSalaryMaster = new()
            {
                Id = noteSalaryMasterDTO.Id,
                MasterId = noteSalaryMasterDTO.MasterId,
                Note = noteSalaryMasterDTO.Note,
                Date = noteSalaryMasterDTO.Date
            };

            try
            {
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
