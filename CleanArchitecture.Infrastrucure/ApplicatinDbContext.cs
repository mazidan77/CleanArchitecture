using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicatinDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
          
          
        }
        public virtual DbSet<Book>Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }


    }
}
