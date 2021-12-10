using BookManagementAPI.Contracts;
using BookManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<Book> GetBook(Guid id, bool trcakChanges)
        {
            return await FindByCondition(b => b.BookId == id, trcakChanges).SingleOrDefaultAsync();
        }

        public void CreateBook(Book bookToAdd)
        {
            Create(bookToAdd);
        }

        public void DeleteBook(Book bookToDelete)
        {
            Delete(bookToDelete);
        }

        public void UpdateBook(Book bookToUpdate)
        {
            Update(bookToUpdate);
        }
    }
}