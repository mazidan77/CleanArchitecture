using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Dtos.BookDto
{
    public class BookPutDto : BookBaseDto
    {
        public int Id { get; set; }
    }
}
