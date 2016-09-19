using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Swagger.Documentation
{
    internal class JsonDefinitionFile : SwaggerDefinitionFile
    {
        internal JsonDefinitionFile(Stream swaggerDefinition)
            :base(swaggerDefinition)
        {

        }

        internal JsonDefinitionFile(byte[] swaggerDefinition)
            :base(swaggerDefinition)
        {

        }

        internal async override Task<Stream> GetJsonStreamAsync()
        {
            if(IsStream)
            {
                return await base.GetJsonStreamAsync().ConfigureAwait(false);
            }

            return new MemoryStream(SwaggerDefinitionBytes);
        }

        public override string ToString()
        {
            using (StreamReader jsonReader = IsStream ?
                new StreamReader(SwaggerDefinitionStream) :
                new StreamReader(new MemoryStream(SwaggerDefinitionBytes)))
            {
                return jsonReader.ReadToEnd();
            }
        }
    }
}
