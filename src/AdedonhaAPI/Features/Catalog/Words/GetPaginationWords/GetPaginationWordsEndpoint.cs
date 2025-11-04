using Carter;
using Carter.OpenApi;

namespace AdedonhaAPI.Features.Catalog.Words.GetPaginationWords
{
    public class GetPaginationWordsEndpoint : CarterModule
    {
        public GetPaginationWordsEndpoint() 
        {
            WithTags("Words Catalog");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", () =>
            {
                return "Hello Carter";
            })
            .WithSummary("Endpoint para recuperar palavras paginadas de uma categoria")
            .IncludeInOpenApi();
        }
    }
}
