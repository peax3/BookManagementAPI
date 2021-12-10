using BookManagementAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementAPI.Contracts
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors(bool trackChanges);
        Task<Author> GetAuthor(Guid id, bool trackChanges);
    }
}