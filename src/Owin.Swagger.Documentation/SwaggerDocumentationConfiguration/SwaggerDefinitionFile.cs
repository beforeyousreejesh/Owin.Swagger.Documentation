using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Owin.Swagger.Documentation
{
    internal abstract class SwaggerDefinitionFile
    {
        protected internal Stream SwaggerDefinitionStream;

        protected internal byte[] SwaggerDefinitionBytes;

        protected internal bool IsStream = false;

        protected internal SwaggerDefinitionFile(Stream swaggerDefinitionStream)
        {
            if (swaggerDefinitionStream == null)
            {
                throw new ArgumentNullException(nameof(swaggerDefinitionStream));
            }

            SwaggerDefinitionStream = swaggerDefinitionStream;
            IsStream = true;
        }
        protected internal SwaggerDefinitionFile(byte[] swaggerDefinitionBytes)
        {
            if (swaggerDefinitionBytes == null)
            {
                throw new ArgumentNullException(nameof(swaggerDefinitionBytes));
            }

            SwaggerDefinitionBytes = swaggerDefinitionBytes;
        }

        internal async virtual Task<Stream> GetJsonStreamAsync()
        {
            return SwaggerDefinitionStream;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        protected internal async Task<Stream> GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            await writer.WriteAsync(s).ConfigureAwait(false);
            await writer.FlushAsync().ConfigureAwait(false);
            stream.Position = 0;
            return stream;
        }
    }
}
