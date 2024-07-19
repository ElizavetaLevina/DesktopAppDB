﻿using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class RateMasterEditDTO
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int PercentProfit { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? Note { get; set; }

        public RateMasterEditDTO(RateMaster rateMaster)
        {
            Id = rateMaster.Id;
            MasterId = rateMaster.MasterId;
            PercentProfit = rateMaster.PercentProfit;
            DateStart = rateMaster.DateStart;
            DateEnd = rateMaster.DateEnd;
            Note = rateMaster.Note;
        }

        public RateMasterEditDTO()
        {
        }
    }
}
