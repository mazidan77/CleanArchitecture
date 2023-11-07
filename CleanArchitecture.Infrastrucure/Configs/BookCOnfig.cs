using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastrucure.Configs
{
    public class BookConfig: IEntityTypeConfiguration<Book>

    { 

        public void Configure(EntityTypeBuilder<Book>builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);

        }
    }
}
