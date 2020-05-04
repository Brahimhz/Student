﻿using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Core.Models
{
    public class Seance
    {
        public int Id { get; set; }
        [Required]
        public string Module { get; set; }
        public string Type { get; set; }
        public string Lieu { get; set; }
        [Required]
        public string Heure { get; set; }
        [Required]
        public string Jour { get; set; }
        public TimeTable TimeTable { get; set; }
        public int TimeTableId { get; set; }
    }
}
