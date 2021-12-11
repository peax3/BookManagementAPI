using System;

namespace BookManagementAPI.Entities.Dtos
{
    public class AuthorResponseDto
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }

    }
}
