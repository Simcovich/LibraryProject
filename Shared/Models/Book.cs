using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Models
{
    public class Book: AbstractItem
    {
        [Required,ForeignKey("Author")]
        public int AuthorFK { get; set; }
        public Author Author { get; set; }
        public ICollection<AbstractItemGenre> AbstractItemGenres { get; set; }
    }
}
