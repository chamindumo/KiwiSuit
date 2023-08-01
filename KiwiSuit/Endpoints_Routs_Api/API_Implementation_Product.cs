using AutoMapper;
using com.sun.org.apache.xpath.@internal.operations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using KiwiSuit.Data;
using KiwiSuit.DTO;
using KiwiSuit.Models;
using KiwiSuit.Repositery;
using KiwiSuit.Service;
using KiwiSuit.Filter;

namespace KiwiSuit.Endpoints_Routs_Api
{
    public static class API_Implementation_Product
    {
        public static void Product(this IEndpointRouteBuilder app)
        {
            app.MapGet("/product", async (HttpContext httpContext) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IProductService>();
                var books = await repository.GetAllProductAsync();
                return Results.Ok(books);
            });


            app.MapGet("/product/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IProductService>();
                var product = await repository.GetProductById(id);
                return product is not null ? Results.Ok(product) : Results.NotFound("product Not Found");
            });
            app.MapPost("Add/product", async (HttpContext httpContext, ProductDTO inputDTO) =>
            {
                var repository1 = httpContext.RequestServices.GetRequiredService<IProductService>();


                repository1.Create(inputDTO);

                return Results.Ok(inputDTO);

            }).AddEndpointFilter<ProductValidationFilter>();

            app.MapPut("/product/{id}", async (HttpContext httpContext, ProductDTO inputDTO, int id) =>
            {

                var repository1 = httpContext.RequestServices.GetRequiredService<IProductService>();

                var existingproduct = await repository1.GetProductById(id);
                if (existingproduct == null)
                {
                    return Results.NotFound("product not found");
                }



                repository1.Update(id, inputDTO);

                return Results.Ok(inputDTO);
            }).AddEndpointFilter<ProductValidationFilter>();




            app.MapDelete("/product/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IProductService>();
                await repository.Delete(id);
                return Results.Ok(await repository.GetAllProductAsync());
            });



        }
    }
}
