using BookManagementAPI.Contracts;
using BookManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementAPI.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryDbContext repositoryDbContext)
            : base(repositoryDbContext)
        {
        }

        public async Task<IEnumerable<Author>> GetAllAuthors(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Author> GetAuthor(Guid id, bool trackChanges)
        {
            return await FindByCondition(a => a.AuthorId == id, trackChanges).SingleOrDefaultAsync();
        }
    }
}