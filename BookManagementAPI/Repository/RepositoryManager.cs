using BookManagementAPI.Contracts;
using System.Threading.Tasks;

namespace BookManagementAPI.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryDbContext _RepositoryDbContext;
        private IBookRepository _BookRepository;
        private IAuthorRepository _AuthorRepository;

        public RepositoryManager(RepositoryDbContext repositoryDbContext)
        {
            _RepositoryDbContext = repositoryDbContext;
        }

        public IBookRepository Book
        {
            get
            {
                if (_BookRepository == null)
                {
                    _BookRepository = new BookRepository(_RepositoryDbContext);
                }

                return _BookRepository;
            }
        }

        public IAuthorRepository Author
        {
            get
            {
                if (_AuthorRepository == null)
                {
                    _AuthorRepository = new AuthorRepository(_RepositoryDbContext);
                }

                return _AuthorRepository;
            }
        }

        public async Task SaveChangesToDbAsync()
        {
            await _RepositoryDbContext.SaveChangesAsync();
        }
    }
}