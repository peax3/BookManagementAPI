using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookManagementAPI.Entities.Dtos
{
    public class AuthorInputDto
    {
        [Required]
        public string AuthorName { get; set; }
 
    }
}
