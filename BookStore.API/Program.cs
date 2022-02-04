﻿using BookStore.API.Data;
using BookStore.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddDbContext<BookStoreContext>(
    optionsBuilder => optionsBuilder.UseSqlServer(
        builder.Configuration.GetConnectionString("BookStoreDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();