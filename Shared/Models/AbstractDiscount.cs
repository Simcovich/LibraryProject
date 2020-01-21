using System;

namespace Shared.Models
{
    public abstract class AbstractDiscount : DbEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Percent { get; set; }

        public abstract bool IsDiscountApplicable(AbstractItem item);

        protected AbstractDiscount(DateTime startDate, DateTime endDate, decimal percent)
        {
            StartDate = startDate;
            EndDate = endDate;
            Percent = percent;
        }

        protected AbstractDiscount()
        {
        }
    }
}