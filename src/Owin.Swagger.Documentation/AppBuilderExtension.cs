using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owin.Swagger.Documentation
{
    public static class AppBuilderExtension
    {
        public static void UseSwaggerDocumentation(this IAppBuilder appBuilder, SwaggerDefinitionConfiguration swaggerDefinitionConfiguration)
        {
            appBuilder.Use<SwaggerDocumentionMiddleware>(swaggerDefinitionConfiguration);

            var embeddedFileSystem = new SwaggerDocumentationEmbeddedResourceHandler((typeof(AppBuilderExtension)).Assembly, "Owin.Swagger.Documentation.Swagger");

            var fileServerOption = new FileServerOptions
            {
                EnableDefaultFiles = true,
                RequestPath = PathString.Empty,
                FileSystem = embeddedFileSystem
            };

            appBuilder.UseFileServer(fileServerOption);
        }
    }
}
