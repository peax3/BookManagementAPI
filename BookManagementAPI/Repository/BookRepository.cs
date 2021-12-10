using BookManagementAPI.Contracts;
using BookManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementAPI.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryDbContext repositoryDbContext)
            : base(repositoryDbContext)
        {
        }

        public async Task<IEnumerable<Book>> GetAllBooks(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public Task<Book> GetBook(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}