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
            prods.MapPost("/", PostProd);
            prods.MapGet("/",GetProds);
            prods.MapGet("/{id}", GetOneProd);
            prods.MapPut("/{id}", UpdateProd);
            prods.MapDelete("/{id}", DeleteProd);
            
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
            if (repo.GetAllProds().Contains(entity))
            {
                return TypedResults.BadRequest("Price must be an integer, something else was provided. / Product with provided name already exists");

            }
            return TypedResults.Ok(repo.AddProd(entity));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult DeleteProd(IRepository repo, int id) {
            repo.DeleteProd(id);
            return TypedResults.Ok(repo);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetOneProd(IRepository repo, int id) {

            
            var product = repo.GetProdById(id);
            if (product == null)
            {
                return TypedResults.NotFound("Product not found");

            }
            repo.GetProdById(id);
            return TypedResults.Ok(repo);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static IResult UpdateProd(IRepository repo, int id, Product prod)
        {
            if (repo.GetProdById(id) == null)
            {
                return TypedResults.NotFound("Product not found");
            }
            
            var existingProd = repo.GetAllProds().FirstOrDefault(p => p.Id == id);

            if(prod.Name == existingProd.Name || prod.Price % 1 != 0)
            {
                return TypedResults.BadRequest("Product with provided name already exists / Price must be an integer.");
            }
            existingProd.Name = prod.Name;
            existingProd.Category = prod.Category;
            existingProd.Price = prod.Price;

  

            return TypedResults.Ok(existingProd);


        }
    }
}
