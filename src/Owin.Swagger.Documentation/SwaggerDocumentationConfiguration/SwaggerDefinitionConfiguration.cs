using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Owin.Swagger.Documentation
{
    /// <summary>
    /// Configuration for documenation.
    /// </summary>
    public class SwaggerDefinitionConfiguration
    {
        internal SwaggerDefinitionType SwaggerDefinitionType;

        internal Stream SwaggerDefinitionStream;

        internal byte[] SwaggerDefinitionBytes;

        /// <summary>
        /// Configuration for documenation.
        /// </summary>
        /// <param name="swaggerDefinitionType">Type of definition</param>
        /// <param name="swaggerDefinition"></param>
        public SwaggerDefinitionConfiguration(SwaggerDefinitionType swaggerDefinitionType, Stream swaggerDefinition)
        {
            if (swaggerDefinition == null)
            {
                throw new ArgumentNullException(nameof(swaggerDefinition));
            }

            SwaggerDefinitionType = swaggerDefinitionType;
            SwaggerDefinitionStream = swaggerDefinition;
        }

        /// <summary>
        /// Configuration for documenation.
        /// </summary>
        /// <param name="swaggerDefinitionType">Type of definition</param>
        /// <param name="swaggerDefinition"></param>
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
