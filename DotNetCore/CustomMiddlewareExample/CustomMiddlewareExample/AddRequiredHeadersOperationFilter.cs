using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CustomMiddlewareExample
{
    public class AddRequiredHeadersOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "username",
                In = ParameterLocation.Header,
                Required = true,
                Description = "Username for authentication",
                Schema = new OpenApiSchema { Type = "string" }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "password",
                In = ParameterLocation.Header,
                Required = true,
                Description = "Password for authentication",
                Schema = new OpenApiSchema { Type = "string" }
            });
        }
    }

}
