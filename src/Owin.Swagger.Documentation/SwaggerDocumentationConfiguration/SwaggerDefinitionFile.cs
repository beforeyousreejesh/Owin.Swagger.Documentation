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

        private static Stream _swaggerStream;

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

        protected internal Stream SwaggerDefinition
        {
            get
            {
                if (IsStream)
                {
                    if (_swaggerStream != null)
                    {
                        _swaggerStream.Position = 0;
                        return _swaggerStream;
                    }

                    _swaggerStream = new CustomMemoryStream();
                    SwaggerDefinitionStream.CopyTo(_swaggerStream);
                    _swaggerStream.Position = 0;
                    return _swaggerStream;
                }

                throw new NotSupportedException("Given input is not stream");
            }
        }
        internal virtual Task<Stream> GetJsonStreamAsync()
        {
            return Task.FromResult(SwaggerDefinition);
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
