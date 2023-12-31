using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastrucure.Configs
{
    public class AuthorConfig:IEntityTypeConfiguration<Author>
    {
        public void Configure (EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasData(
                new Author
                {
                    Id = 1,
                    Name = "test1"
                });
        }
    }
}
