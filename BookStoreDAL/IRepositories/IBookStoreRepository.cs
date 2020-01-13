using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IBookStoreRepository
    {
        IAbstractItemRepository GetAbstractItemRepository { get; }
        IAuthorRepository GetAuthorRepository { get; }
        IBookRepository GetBookRepository { get; }
        IDiscountRepository GetDiscountRepository { get; }
        IGenreRepository GetGenreRepository { get; }
        IJournalRepository GetJournalRepository { get; }
        IPublisherRepository GetPublisherReposiory { get; }
    }
}
