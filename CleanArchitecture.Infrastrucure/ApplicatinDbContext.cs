using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastrucure
{
    public class ApplicatinDbContext:DbContext
    {
        public ApplicatinDbContext(DbContextOptions<ApplicatinDbContext> options):base(options) 
        {

        }


        public virtual DbSet<Book>Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }


    }
}
