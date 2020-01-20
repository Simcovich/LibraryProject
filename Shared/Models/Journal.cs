using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Journal : AbstractItem
    {
        [Required]
        public int CopyNum { get; set; }

        [Required]
        public string ISSN { get; set; }
    }
}