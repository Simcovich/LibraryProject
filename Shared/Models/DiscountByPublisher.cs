using System;

namespace Shared.Models
{
    public class DiscountByPublisher : AbstractDiscount
    {
        public int PublisherId { get; set; }

        public DiscountByPublisher(int publisherId, DateTime startDate, DateTime endDate, decimal percent) : base(startDate, endDate, percent)
        {
            PublisherId = publisherId;
        }
        private DiscountByPublisher()
        {
        }
        public override bool IsDiscountApplicable(AbstractItem item)
        {
            return item.Publisher.Id == PublisherId;
        }
    }
}