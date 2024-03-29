﻿using BookManagementAPI.Contracts;
using BookManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementAPI.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryDbContext repositoryDbContext)
            : base(repositoryDbContext)
        {
        }

        public void CreateAuthor(Author authorToAdd)
        {
            Create(authorToAdd);
        }

        public void DeleteAuthor(Author authorToDelete)
        {
            Delete(authorToDelete);
        }

        public async Task<IEnumerable<Author>> GetAllAuthors(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Author> GetAuthor(Guid id, bool trackChanges)
        {
            return await FindByCondition(a => a.AuthorId == id, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IList<Author>> GetAuthorsByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(a => ids.Contains(a.AuthorId), trackChanges).ToListAsync();
        }

        public void UpdateAuthor(Author authorToUpdate)
        {
            Update(authorToUpdate);
        }
    }
}