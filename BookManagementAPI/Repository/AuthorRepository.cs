using BookManagementAPI.Contracts;
using BookManagementAPI.Entities.Models;

namespace BookManagementAPI.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryDbContext repositoryDbContext)
            : base(repositoryDbContext)
        {
        }
    }
}