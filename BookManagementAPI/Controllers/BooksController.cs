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
    }
}