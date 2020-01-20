using System;

namespace Shared.Models
{
    public class DiscountByAuthor : AbstractDiscount
    {
        private int _authorId;

        public DiscountByAuthor(int authorId, DateTime startDate, DateTime endDate, float percent) : base(startDate, endDate, percent)
        {
            _authorId = authorId;
        }
        public override bool IsDiscountApplicable(AbstractItem item)
        {
            if (item is Book)
            {
                return (item as Book).Author.Id == _authorId;
            }
            return false;
        }
    }
}
