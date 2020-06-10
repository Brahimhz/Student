using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Core.Models
{
    public class DocumentFile
    {
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }

        public int DocumentPartageId { get; set; }
    }
}
