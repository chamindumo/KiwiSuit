using Microsoft.EntityFrameworkCore;
using KiwiSuit.Data;
using KiwiSuit.Models;
using Serilog;
using KiwiSuit;
using KiwiSuit.Middelware;
using KiwiSuit.Repositery;
using KiwiSuit.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using KiwiSuit.Service;
using ikvm.runtime;
using KiwiSuit.Profiles;
using sun.awt;
using System.Configuration;
using KiwiSuit.Endpoints_Routs_Api;
using FluentValidation;
using KiwiSuit.Validator;
using javax.swing.plaf;
using KiwiSuit.Data;
using KiwiSuit.DTO;
using KiwiSuit.Endpoints_Routs_Api;
using KiwiSuit.Models;
using KiwiSuit.Repositery;
using KiwiSuit.Service;
using KiwiSuit.Validator;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
//builder.Services.AddTransient<BasicAuthHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Books), typeof(Product));

builder.Services.AddScoped<IValidator<BookDTO>, BookDTOValidator>();
builder.Services.AddScoped<IValidator<ProductDTO>, ProductDTOValidator>();
builder.Services.AddScoped<IProductRepositery, ProductRepositery>();
builder.Services.AddScoped<IBookRepositery, BookRepository>();
builder.Services.AddScoped<IBookService, BookServices>();
builder.Services.AddScoped<IProductService, ProductService>();

//builder.Services.AddTransient<GlobaleExceptionHandlingMiddelware>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<BasicAuthHandler>("Test");
//app.UseMiddleware<GlobaleExceptionHandlingMiddelware>();

app.UseHttpsRedirection();

app.Books();

app.Product();

app.Run();
