using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Author : DbEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PenName { get; set; }
    }
}