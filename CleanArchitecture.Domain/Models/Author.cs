using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Models
{
    public class Author :BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Book> Book { get; set; }
    }
}
