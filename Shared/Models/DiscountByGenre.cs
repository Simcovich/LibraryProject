using System;
using System.Linq;

namespace Shared.Models
{
    public class DiscountByGenre : AbstractDiscount
    {
        public int GenreId { get; set; }

        public DiscountByGenre(int genreId, DateTime startDate, DateTime endDate, decimal percent) : base(startDate, endDate, percent)
        {
            GenreId = genreId;
        }

        public DiscountByGenre()
        {
        }

        public override bool IsDiscountApplicable(AbstractItem item)
        {
            return item.ItemGenres.Any(ig => ig.GenreId == GenreId);
        }
    }
}