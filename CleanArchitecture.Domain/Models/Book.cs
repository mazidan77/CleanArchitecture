using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Models
{
    public class Book :BaseEntity
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

    }
}
