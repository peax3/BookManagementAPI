using BookManagementAPI.Contracts;
using BookManagementAPI.Entities.Models;

namespace BookManagementAPI.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryDbContext repositoryDbContext)
            : base(repositoryDbContext)
        {
        }
    }
}