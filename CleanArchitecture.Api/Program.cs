
using CleanArchitecture.Application.Managers;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Domain.IUnitOfWork;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastrucure;
using CleanArchitecture.Infrastrucure.Repositories;
using CleanArchitecture.Infrastrucure.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CleanArchitecture.Domain.IManagers;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicatinDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies(true));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IBaseManager<Book>, BaseManager<Book>>();
            builder.Services.AddScoped<IBookManager, BookManagers>();
            builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();
            builder.Services.AddAutoMapper(typeof(ApplicatinDbContext));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}