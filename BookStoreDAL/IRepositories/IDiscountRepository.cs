using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IDiscountRepository
    {
        Task AddDiscountAsync(AbstractDiscount discount);

        Task<IEnumerable<AbstractDiscount>> GetAllDiscountsAsync();

        Task<IEnumerable<AbstractDiscount>> GetAllApplicableDiscountsAsync();
    }
}