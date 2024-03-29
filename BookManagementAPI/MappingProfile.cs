﻿using AutoMapper;
using BookManagementAPI.Entities.Dtos;
using BookManagementAPI.Entities.Models;

namespace BookManagementAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookResponseDto>();
            CreateMap<BookInputDto, Book>();
            CreateMap<Author, AuthorResponseDto>();
            CreateMap<AuthorInputDto, Author>();
        }
    }
}