﻿using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Core.Models
{
    public class SchoolInformation
    {
        public int Id { get; set; }
        public string SchoolYear { get; set; }
        [Required]
        public string Cycle { get; set; }
        [Required]
        public string Semester { get; set; }
        [Required]
        public string Specility { get; set; }
        public string ClassNbr { get; set; }

        public DateTime LastUpdate { get; set; }

    }
}
