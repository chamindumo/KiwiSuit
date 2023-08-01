using AutoMapper;
using java.awt.print;
using KiwiSuit.Filter;
using KiwiSuit.DTO;
using KiwiSuit.Models;
using KiwiSuit.Profiles;
using KiwiSuit.Repositery;
using KiwiSuit.Service;

namespace KiwiSuit.Endpoints_Routs_Api
{
    public static class API_Implimentation_Books
    {
        public static void Books(this IEndpointRouteBuilder app)
        {

            app.MapGet("/Books", async (HttpContext httpContext) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IBookService>();

                var books = await repository.GetAllBooksAsync();
                return Results.Ok(books);
            });

            app.MapGet("/Books/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IBookService>();
                var book = await repository.GetBookByIdAsync(id);

                return book is not null ? Results.Ok(book) : Results.NotFound("Book Not Found");
            });
            app.MapPost("Add/Book", async (HttpContext httpContext, BookDTO inputDTO) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IBookService>();
                repository.AddBookAsync(inputDTO);
                return Results.Ok(inputDTO);

            }).AddEndpointFilter<BookValidationFilter>();


            app.MapPut("/Book/{id}", async (HttpContext httpContext, BookDTO inputDTO, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IBookService>();
                var existingBook = await repository.GetBookByIdAsync(id);
                if (existingBook == null)
                {
                    return Results.NotFound("Book not found");
                }

                repository.UpdateBookAsync(id, inputDTO);
                return Results.Ok(inputDTO);

            }).AddEndpointFilter<BookValidationFilter>();

            app.MapDelete("/Book/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IBookService>();
                await repository.DeleteBookAsync(id);

                return Results.Ok(await repository.GetAllBooksAsync());
            });
        }

    }
}