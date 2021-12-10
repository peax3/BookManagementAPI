using AutoMapper;
using BookManagementAPI.Contracts;
using BookManagementAPI.Entities.Dtos;
using BookManagementAPI.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IRepositoryManager _RepositoryManager;
        private readonly IMapper _Mapper;

        public AuthorsController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _RepositoryManager = repositoryManager;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorResponseDto>>> GetAllAuthors()
        {
            var authors = await _RepositoryManager.Author.GetAllAuthors(false);
            var authorsResponseDto = _Mapper.Map<IEnumerable<AuthorResponseDto>>(authors);
            return Ok(authorsResponseDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponseDto>> GetAuthorById(Guid id)
        {
            var author = await _RepositoryManager.Author.GetAuthor(id, false);

            if (author == null) return NotFound();

            var authorResponseDto = _Mapper.Map<AuthorResponseDto>(author);

            return Ok(authorResponseDto);
        }
    }
}