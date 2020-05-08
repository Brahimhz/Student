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
        public string Location { get; set; }
        [Required]
        [StringLength(5)]
        public string Time { get; set; }
        [Required]
        [StringLength(15)]
        public string Day { get; set; }
        public TimeTable TimeTable { get; set; }
        public int TimeTableId { get; set; }
    }
}
