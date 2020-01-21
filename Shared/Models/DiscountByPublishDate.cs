using System;

namespace Shared.Models
{
    public class DiscountByPublishDate : AbstractDiscount
    {
        public DateTime PublishedDate { get; set; }

        public DiscountByPublishDate(DateTime publishDate, DateTime startDate, DateTime endDate, decimal percent) : base(startDate, endDate, percent)
        {
            PublishedDate = publishDate;
        }

        private DiscountByPublishDate()
        { }

        public override bool IsDiscountApplicable(AbstractItem item)
        {
            return item.PrintDate.CompareTo(PublishedDate) <= 0;
        }
    }
}