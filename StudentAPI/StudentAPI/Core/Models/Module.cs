using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StudentAPI.Core.Models
{
    public class Module : SchoolInformation
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(10)]
        public string AbvNom { get; set; }
        [Required]
        [StringLength(50)]
        public string Unite { get; set; }
        [Required]
        public int Coefficient { get; set; }
        [Required]
        public int Credit { get; set; }

        public ICollection<Seance> Seances { get; set; }
        public ICollection<Exam> Exams { get; set; }


        public string getAbvName()
        {
            return new string((this.Name).Split(' ').Select(m => char.ToUpper(m[0])).ToArray());
        }

        public Module()
        {
            Seances = new Collection<Seance>();
            Exams = new Collection<Exam>();

        }
    }
}
