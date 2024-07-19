﻿using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class RateMasterRepository
    {
        public List<RateMasterDTO> GetRateMasterByIdMaster(int id)
        {
            Context context = new();
            return context.RateMaster.Where(i => i.MasterId == id).OrderBy(i => i.DateStart).Select(a => new RateMasterDTO(a)).ToList();
        }

        public RateMasterEditDTO GetRateMaster(DateTime date)
        {
            Context context = new();
            var rateMaster = context.RateMaster.FirstOrDefault(i => i.DateStart == date);
            if (rateMaster != null)
                return new RateMasterEditDTO(rateMaster);
            else
                return new RateMasterEditDTO();
        }

        public async Task SaveRateMasterAsync(RateMasterEditDTO rateMasterDTO, CancellationToken token = default)
        {
            Context db = new Context();
            RateMaster rateMaster = new()
            {
                Id = rateMasterDTO.Id,
                MasterId = rateMasterDTO.MasterId,
                PercentProfit = rateMasterDTO.PercentProfit,
                DateStart = rateMasterDTO.DateStart,
                DateEnd = rateMasterDTO.DateEnd,
                Note = rateMasterDTO.Note
            };
            try
            {
                if (rateMaster.Id == 0)
                    db.RateMaster.Add(rateMaster);
                else
                    db.RateMaster.Update(rateMaster);

                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); throw; }
        }
    }
}
