using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public abstract class AbstractItem : DbEntity
    {
        [Required, MinLength(2)]
        public string Title { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [NotMapped]
        public double Discount { get; set; }

        public ICollection<AbstractItemGenre> ItemGenres { get; set; }
        public Publisher Publisher { get; set; }

        [DataType(DataType.Date)]
        public DateTime PrintDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int Stock { get; set; }
    }
}