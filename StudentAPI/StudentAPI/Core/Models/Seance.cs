using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAPI.Core.Models
{
    public class Seance
    {
        public int Id { get; set; }
        [ForeignKey("Module")]
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        [StringLength(5)]
        public string Type { get; set; }
        [StringLength(50)]
        public string Lieu { get; set; }
        [Required]
        [StringLength(5)]
        public string Heure { get; set; }
        [Required]
        [StringLength(15)]
        public string Jour { get; set; }
        public TimeTable TimeTable { get; set; }
        public int TimeTableId { get; set; }
    }
}
