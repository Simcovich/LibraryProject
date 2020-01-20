using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class Book : AbstractItem
    {
        [Required, ForeignKey("Author")]
        public int AuthorFK { get; set; }

        public Author Author { get; set; }
        public string ISBN { get; set; }
    }
}