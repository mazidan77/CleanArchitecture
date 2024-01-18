using AutoMapper;
using CleanArchitecture.Domain.Dtos.BookDto;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastrucure.Mapper
{
    public class BookMapper:Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookPostDto>().ReverseMap();
            CreateMap<Book, BookGetDto>()
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ReverseMap();
        }
    }
}
