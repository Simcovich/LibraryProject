using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Models
{
    public class DiscountByGenre : AbstractDiscount
    {
        private int _genreId;
        public DiscountByGenre(int genreId, DateTime startDate, DateTime endDate, float percent) : base(startDate, endDate, percent)
        {
            _genreId = genreId;
        }
        public override bool IsDiscountApplicable(AbstractItem item)
        {
            return item.ItemGenres.Any(ig => ig.GenreId == _genreId);
        }
    }
}
