﻿using System;
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
        public decimal Discount { get; set; }

        public ICollection<AbstractItemGenre> ItemGenres { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime PrintDate { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}