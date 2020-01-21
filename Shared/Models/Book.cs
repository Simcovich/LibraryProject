using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Book : AbstractItem
    {
        public int AuthorFK { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required, DataType(DataType.Text)]
        public string ISBN { get; set; }
    }
}