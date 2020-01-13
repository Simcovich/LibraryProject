using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Models
{
    public class AbstractItemGenre
    {
        public AbstractItem Item { get; set; }
        [ForeignKey("AbstractItem")]
        public int ItemId { get; set; }
        public Genre Id { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
    }
}
