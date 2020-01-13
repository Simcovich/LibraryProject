using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models
{
    public abstract class DbEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
