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

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody]AuthorInputDto authorInput)
        {
            if (authorInput == null) return BadRequest();

            var authorToAdd = _Mapper.Map<Author>(authorInput);
            _RepositoryManager.Author.CreateAuthor(authorToAdd);

            var isSuccessful = await _RepositoryManager.SaveChangesToDbAsync();

            if (!isSuccessful) return BadRequest("failed to save author");
            return new StatusCodeResult(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody]AuthorInputDto authorInput)
        {
            var authorToUpdate = await _RepositoryManager.Author.GetAuthor(id, true);
            if (authorToUpdate == null) return NotFound();

            _Mapper.Map(authorInput, authorToUpdate);

            _RepositoryManager.Author.UpdateAuthor(authorToUpdate);
            var isSuccessful = await _RepositoryManager.SaveChangesToDbAsync();

            if (!isSuccessful) return BadRequest("failed to Update author");
            return new StatusCodeResult(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var authorToDelete = await _RepositoryManager.Author.GetAuthor(id, true);
            if (authorToDelete == null) return NotFound();

            _RepositoryManager.Author.DeleteAuthor(authorToDelete);

            var isSuccessful = await _RepositoryManager.SaveChangesToDbAsync();
            if (!isSuccessful) return BadRequest("failed to delete author");
            return new StatusCodeResult(201);
        }
    }
}