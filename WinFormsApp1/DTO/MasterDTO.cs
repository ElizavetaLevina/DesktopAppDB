﻿using System.ComponentModel;

namespace WinFormsApp1.DTO
{
    public class MasterDTO
    {
        [DisplayName("Id")]
        public int? Id { get; set; }
        [DisplayName("ФИО")]
        public string? NameMaster { get; set; }
        [DisplayName("Телефон")]
        public string? NumberPhone { get; set; }

        public MasterDTO()
        {
        }
    }
}
