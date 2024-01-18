using CleanArchitecture.Domain.IManagers;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Domain.IUnitOfWork;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Managers
{
    public class BookManagers : BaseManager<Book>,IBookManager
    {
        protected readonly IUnitOfWork _unitOfWork;
        // protected readonly IMapper _mapper;
        private readonly IRepository<Book> _bookRepository;
        public BookManagers(IUnitOfWork unitOfWork, IRepository<Book> bookRepository) : base(unitOfWork, bookRepository)
        {
            _bookRepository = bookRepository;
        }


      

    }
}
