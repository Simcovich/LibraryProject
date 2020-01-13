using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Genre : DbEntity
    {
        [DataType(DataType.Text),Required]
        public string Name { get; set; }
        public ICollection<AbstractItemGenre> AbstractItemGenres { get; set; }
    }
}