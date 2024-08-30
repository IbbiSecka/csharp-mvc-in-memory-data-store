using exercise.wwwapi.Model;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoint
{
    public static class ProductEndpoint
    {
        public static void ConfigureProductEndpoint(this WebApplication app)
        {
            var prods = app.MapGroup("products");
            prods.MapGet("/",GetProds);
            prods.MapPost("/", PostProd);
            prods.MapDelete("/{id}", DeleteProd);
            prods.MapPut("/{id}", GetOneProd);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetProds(IRepository repo, string category)
        {
            if (repo.GetProducts(category).Count == 0)

            {
                return TypedResults.NotFound("No products of the provided category were found.");
            }
            return TypedResults.Ok(repo.GetProducts(category));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public static IResult PostProd(IRepository repo, Product entity) {
            if ()
            {
                return TypedResults.BadRequest("Price must be an integer, something else was provided. / Product with provided name already exists");

            }
            return TypedResults.Ok(repo.AddProd(entity));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult DeleteProd(IRepository repo, Guid id) {
            repo.DeleteProd(id);
            return TypedResults.Ok(repo);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult GetOneProd(IRepository repo, Guid id) {
            repo.GetProdById(id);
            return TypedResults.Ok(repo);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult UpdateProd(IRepository repo, Guid id, Product prod)
        {
            

        }
    }
}
