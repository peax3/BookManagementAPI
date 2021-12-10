using System;
using System.Collections.Generic;

namespace BookManagementAPI.Entities.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }

        //relationship
        public ICollection<Book> Books { get; set; }
    }
}