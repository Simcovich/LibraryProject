using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Publisher : DbEntity
    {
        [Required, DataType(DataType.Text)]
        public string Name { get; set; }
    }
}