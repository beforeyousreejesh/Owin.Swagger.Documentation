using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Owin.Swagger.Documentation
{
    public class SwaggerDefinitionConfiguration
    {
        internal SwaggerDefinitionType SwaggerDefinitionType;

        internal Stream SwaggerDefinitionStream;

        internal byte[] SwaggerDefinitionBytes;

        public SwaggerDefinitionConfiguration(SwaggerDefinitionType swaggerDefinitionType, Stream swaggerDefinition)
        {
            if (swaggerDefinition == null)
            {
                throw new ArgumentNullException(nameof(swaggerDefinition));
            }

            SwaggerDefinitionType = swaggerDefinitionType;
            SwaggerDefinitionStream = swaggerDefinition;
        }

        public SwaggerDefinitionConfiguration(SwaggerDefinitionType swaggerDefinitionType, byte[] swaggerDefinition)
        {
            if (swaggerDefinition == null)
            {
                throw new ArgumentNullException(nameof(swaggerDefinition));
            }

            SwaggerDefinitionType = swaggerDefinitionType;
            SwaggerDefinitionBytes = swaggerDefinition;
        }

        internal SwaggerDefinitionFile SwaggerDefiniton
        {
            get
            {
                return SwaggerDefinitionFactory.CreateFromConfiguration(this);
            }
        }
    }
}
