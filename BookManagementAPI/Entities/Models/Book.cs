using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementAPI.Entities.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Publisher { get; set; }

        //relationship
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

    }
}