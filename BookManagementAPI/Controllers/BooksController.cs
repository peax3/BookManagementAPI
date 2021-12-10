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
    public class BooksController : ControllerBase
    {
        private readonly IRepositoryManager _RepositoryManager;
        private readonly IMapper _Mapper;

        public BooksController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _RepositoryManager = repositoryManager;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _RepositoryManager.Book.GetAllBooks(false);
            var booksResponseDto = _Mapper.Map<IEnumerable<BookResponseDto>>(books);
            return Ok(booksResponseDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponseDto>> GetBookById(Guid id)
        {
            var book = await _RepositoryManager.Book.GetBook(id, false);

            if (book == null) return NotFound();

            var bookResponseDto = _Mapper.Map<BookResponseDto>(book);

            return Ok(bookResponseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookInputDto booksInput)
        {
            if (booksInput == null) return BadRequest();

            var bookToUpdate = _Mapper.Map<Book>(booksInput);
            _RepositoryManager.Book.CreateBook(bookToUpdate);

            var isSuccessful = await _RepositoryManager.SaveChangesToDbAsync();
  
            if (!isSuccessful) return BadRequest("failed to save contact");
            return new StatusCodeResult(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody]BookInputDto bookInputDto)
        {
            var bookToUpdate = await _RepositoryManager.Book.GetBook(id, true);
            if (bookToUpdate == null) return NotFound();

            _Mapper.Map(bookInputDto, bookToUpdate);

            _RepositoryManager.Book.UpdateBook(bookToUpdate);
            var isSuccessful = await _RepositoryManager.SaveChangesToDbAsync();

            if (!isSuccessful) return BadRequest("failed to Update contact");
            return new StatusCodeResult(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(Guid id)
        {
            var bookToDelete = await _RepositoryManager.Book.GetBook(id, true);
            if (bookToDelete == null) return NotFound();

            _RepositoryManager.Book.DeleteBook(bookToDelete);

            var isSuccessful = await _RepositoryManager.SaveChangesToDbAsync();
            if (!isSuccessful) return BadRequest("failed to delete contact");
            return new StatusCodeResult(201);
        }
    }
}