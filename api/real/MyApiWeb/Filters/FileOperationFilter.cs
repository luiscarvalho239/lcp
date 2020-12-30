using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace MyApiWeb.Filters
{
  public class FileOperationFilter : IOperationFilter
  {

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      if (operation.OperationId == "EnviaImagens" || operation.OperationId == "EnviaFicheiros" || operation.OperationId == "EnviaVideos")
      {
        operation.Parameters.Clear();
        //operation.Parameters.Add(new OpenApiParameter
        //{
        //  Name = "arquivo",
        //  In = ParameterLocation.Header,
        //  Description = "Upload File",
        //  Required = true,
        //  Schema = new OpenApiSchema
        //  {
        //    Type = "file",
        //    Format = "binary"
        //  }
        //});

        var uploadFileMediaType = new OpenApiMediaType()
        {
          Schema = new OpenApiSchema()
          {
            Type = "object",
            Properties = {
                ["arquivo"] = new OpenApiSchema() {
                    Description = "Upload File",
                    Type = "file",
                    Format = "binary"
                }
            },
            Required = new HashSet<string>() {
                "arquivo"
            }
          }
        };

        operation.RequestBody = new OpenApiRequestBody
        {
          Content =
          {
              ["multipart/form-data"] = uploadFileMediaType
          }
        };
      }
    }
  }
}
