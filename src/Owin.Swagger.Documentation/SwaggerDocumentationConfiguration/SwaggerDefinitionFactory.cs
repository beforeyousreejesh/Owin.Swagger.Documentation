using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owin.Swagger.Documentation
{
    public class SwaggerDefinitionFactory
    {
        internal static SwaggerDefinitionFile CreateFromConfiguration(SwaggerDefinitionConfiguration swaggerDefinitionCondifuration)
        {
            if (swaggerDefinitionCondifuration == null)
            {
                throw new ArgumentNullException(nameof(swaggerDefinitionCondifuration));
            }

            switch (swaggerDefinitionCondifuration.SwaggerDefinitionType)
            {
                case SwaggerDefinitionType.JSON:

                    if (swaggerDefinitionCondifuration.SwaggerDefinitionStream != null)
                    {
                        return new JsonDefinitionFile(swaggerDefinitionCondifuration.SwaggerDefinitionStream);
                    }

                    if(swaggerDefinitionCondifuration.SwaggerDefinitionBytes != null)
                    {
                        return new YamlDefinitionFile(swaggerDefinitionCondifuration.SwaggerDefinitionBytes);
                    }

                    throw new NotSupportedException();
                case SwaggerDefinitionType.YAML:
                    if (swaggerDefinitionCondifuration.SwaggerDefinitionStream != null)
                    {
                        return new YamlDefinitionFile(swaggerDefinitionCondifuration.SwaggerDefinitionStream);
                    }

                    if (swaggerDefinitionCondifuration.SwaggerDefinitionBytes != null)
                    {
                        return new YamlDefinitionFile(swaggerDefinitionCondifuration.SwaggerDefinitionBytes);
                    }

                    throw new NotSupportedException();

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
