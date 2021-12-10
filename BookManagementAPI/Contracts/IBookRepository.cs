using BookManagementAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementAPI.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks(bool trackChanges);

        Task<Book> GetBook(Guid id, bool trackChanges);

        void CreateBook(Book booToAdd);

        void DeleteBook(Book bookToDelete);

        void UpdateBook(Book bookToUpdate);
    }
}