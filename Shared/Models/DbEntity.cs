using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public abstract class DbEntity
    {
        [Key]
        public int Id { get; set; }
    }
}