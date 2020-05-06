using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Core.Models
{
    public class SchoolInformation
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string SchoolYear { get; set; }
        [Required]
        [StringLength(20)]
        public string Cycle { get; set; }
        [Required]
        [StringLength(2)]
        public string Semester { get; set; }
        [Required]
        [StringLength(50)]
        public string Speciality { get; set; }
        [StringLength(2)]
        public string ClassNbr { get; set; }

        public DateTime LastUpdate { get; set; }

    }
}
