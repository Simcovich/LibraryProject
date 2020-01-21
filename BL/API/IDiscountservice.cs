using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.API
{
    public interface IDiscountService
    {
        Task<List<AbstractDiscount>> GetDiscountsAsync();

        Task AddDiscountAsync(AbstractDiscount discount);

        void ApplyDiscount(ICollection<AbstractItem> items);
    }
}