namespace Catalog.API.Products.GetProductByID
{
    // public record GetProductByIDRequest();
    public record GetProductByIDResponse(Product Product);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIDQuery(id));

                var response = result.Adapt<GetProductByIDResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProductByID")
            .Produces<GetProductByIDResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("GET Product By ID Summary.")
            .WithDescription("GET Product By ID Description.");
        }
    }
}
