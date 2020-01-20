using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class DiscountByPublishDate : AbstractDiscount
    {
        private DateTime _publishDate;
        public DiscountByPublishDate(DateTime publishDate, DateTime startDate, DateTime endDate, float percent) : base(startDate, endDate, percent)
        {
            _publishDate = publishDate;
        }
        public override bool IsDiscountApplicable(AbstractItem item)
        {
            return item.PrintDate.CompareTo(_publishDate) <= 0;
        }
    }
}
