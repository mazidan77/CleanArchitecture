using AutoMapper;
using CleanArchitecture.Application.Managers;
using CleanArchitecture.Domain.Dtos.BookDto;
using CleanArchitecture.Domain.IManagers;
using CleanArchitecture.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseManager<Book> _baseManager;
        private readonly IBookManager _bookManager;

        protected readonly IMapper _mapper;
        public BookController(IBaseManager<Book> baseManager, IBookManager bookManager,

          IMapper mapper)
        {
            _baseManager = baseManager;
            _bookManager = bookManager;

            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Post(BookPostDto bookPostDto)
        {
            Book entity = _mapper.Map<Book>(bookPostDto);
            var x = await _baseManager.AddWithComplete(entity);
            return Ok(bookPostDto);
          
        }




        [HttpGet]
        public virtual IActionResult Get()
        {
            var entities = _baseManager.GetAll();

            // Map entities to DTOs
            var dtoList = _mapper.Map<List<BookGetDto>>(entities);

            // Return the DTOs
            return Ok(dtoList);

        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Getby(int id)
        {
            var res= await _baseManager.GetById(id);
            if (res == null)
            {
                return NotFound("no");
            }
           var dtoList = _mapper.Map<BookGetDto>(res);

            return Ok(dtoList);

        }

    }
}
