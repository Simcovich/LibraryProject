using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class AbstractItemGenre
    {
        public AbstractItem Item { get; set; }

        [ForeignKey("AbstractItem")]
        public int ItemId { get; set; }

        public Genre Genre { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
    }
}