using BookManagementAPI.Contracts;
using System.Threading.Tasks;

namespace BookManagementAPI.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryDbContext _RepositoryDbContext;
        private readonly IBookRepository _BookRepository;
        private readonly IAuthorRepository _AuthorRepository;

        public RepositoryManager(RepositoryDbContext repositoryDbContext)
        {
            _RepositoryDbContext = repositoryDbContext;
        }

        public IBookRepository Book => _BookRepository == null ? new BookRepository(_RepositoryDbContext) : _BookRepository;

        public IAuthorRepository Author => _AuthorRepository == null ? new AuthorRepository(_RepositoryDbContext) : _AuthorRepository;

        public async Task SaveChangesToDbAsync()
        {
            await _RepositoryDbContext.SaveChangesAsync();
        }
    }
}