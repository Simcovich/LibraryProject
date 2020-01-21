using System;

namespace Shared.Models
{
    public class DiscountByAuthor : AbstractDiscount
    {
        public int AuthorId { get; set; }

        public DiscountByAuthor(int authorId, DateTime startDate, DateTime endDate, decimal percent) : base(startDate, endDate, percent)
        {
            AuthorId = authorId;
        }

        private DiscountByAuthor()
        {
        }

        public override bool IsDiscountApplicable(AbstractItem item)
        {
            if (item is Book)
            {
                return (item as Book).Author.Id == AuthorId;
            }
            return false;
        }
    }
}