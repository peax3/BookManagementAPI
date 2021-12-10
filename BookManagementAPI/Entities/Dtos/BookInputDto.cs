using System;
using System.ComponentModel.DataAnnotations;

namespace BookManagementAPI.Entities.Dtos
{
    public class BookInputDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime PublishedOn { get; set; }
        [Required]
        public string Publisher { get; set; }
    }
}
