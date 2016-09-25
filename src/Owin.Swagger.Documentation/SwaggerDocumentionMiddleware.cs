using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owin.Swagger.Documentation
{
    public class SwaggerDocumentionMiddleware : OwinMiddleware
    {
        private SwaggerDefinitionConfiguration _swaggerDefinitionConfiguration;

        public SwaggerDocumentionMiddleware(OwinMiddleware next, SwaggerDefinitionConfiguration swaggerDefinitionConfiguration) : base(next)
        {
            if (swaggerDefinitionConfiguration == null)
            {
                throw new ArgumentNullException(nameof(swaggerDefinitionConfiguration));
            }

            _swaggerDefinitionConfiguration = swaggerDefinitionConfiguration;
        }

        public async override Task Invoke(IOwinContext context)
        {
            if (context.Request.Path.StartsWithSegments(new PathString("/definition/swagger.json")))
            {
                var jsonStream = await _swaggerDefinitionConfiguration.
                                            SwaggerDefiniton
                                            .GetJsonStreamAsync()
                                            .ConfigureAwait(false); ;

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 200;
                context.Response.ContentLength = jsonStream.Length;
                await jsonStream.CopyToAsync(context.Response.Body).ConfigureAwait(false);

                return;
            }

            await Next.Invoke(context);
        }
    }
}
