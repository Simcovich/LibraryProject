using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public abstract class AbstractDiscount : DbEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Percent { get; set; }
        public abstract bool IsDiscountApplicable(AbstractItem item);
        protected AbstractDiscount(DateTime startDate, DateTime endDate, float percent)
        {
            StartDate = startDate;
            EndDate = endDate;
            Percent = percent;
        }
    }
}
