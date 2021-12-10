using BookManagementAPI.Entities.Models;
using BookManagementAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementAPI.SeedData
{
    public static class Seeder
    {
        public static async Task AddPendingMigrations(RepositoryDbContext dbContext)
        {
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                await dbContext.Database.MigrateAsync();
            }
        }

        public static async Task SeedData(RepositoryDbContext dbContext)
        {
            if (dbContext.Books.Any() && dbContext.Authors.Any()) return;

            var authors = new List<Author>
            {
                new Author
                {
                    AuthorId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    AuthorName = "Mikasa Ackerman",
                },

                new Author
                {
                    AuthorId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    AuthorName = "Eren Yeager",
                }
            };

            var books = new List<Book>
            {
                new Book
                {
                    BookId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Title = "The Great Despair",
                    Description = "A book about the despair faced by millenials",
                    PublishedOn = DateTime.Parse("Dec 25, 2015"),
                    Publisher = "Best Books Ltd",
                    Author =  authors[0]
                },

                new Book
                {
                    BookId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Title = "Inroduction to programming",
                    Description = "A book to get you started on programming",
                    PublishedOn = DateTime.Parse("Oct 30, 2020"),
                    Publisher = "Oliver Books",
                    Author = authors[1]
                },

                new Book
                {
                    BookId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Title = "Thomas the Doubtful",
                    Description = "Book about love and denial",
                    PublishedOn = DateTime.Parse("Feb 15, 2017"),
                    Publisher = "Best Books Ltd",
                    Author = authors[1]
                }
            };

            await dbContext.Books.AddRangeAsync(books);
            await dbContext.SaveChangesAsync();
        }
    }
}