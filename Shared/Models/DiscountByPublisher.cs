using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class DiscountByPublisher : AbstractDiscount
    {
        private int _publisherId;
        public DiscountByPublisher(int publisherId, DateTime startDate, DateTime endDate, float percent) : base(startDate, endDate, percent)
        {
            _publisherId = publisherId;
        }

        public override bool IsDiscountApplicable(AbstractItem item)
        {
            return item.Publisher.Id == _publisherId;
        }
    }
}
