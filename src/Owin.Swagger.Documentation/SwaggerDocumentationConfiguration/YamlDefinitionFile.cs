using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Owin.Swagger.Documentation
{
    internal class YamlDefinitionFile : SwaggerDefinitionFile
    {
        internal YamlDefinitionFile(Stream swaggerDefinition)
            : base(swaggerDefinition)
        {

        }

        internal YamlDefinitionFile(byte[] swaggerDefinition)
            : base(swaggerDefinition)
        {

        }

        internal async override Task<Stream> GetJsonStreamAsync()
        {
           return await GenerateStreamFromString(ToString()).ConfigureAwait(false);           
        }

        public override string ToString()
        {
            try
            {
                object yamlObject = null;

                using (StreamReader yamlReader = IsStream ?
                    new StreamReader(SwaggerDefinition)
                    : new StreamReader(new MemoryStream(SwaggerDefinitionBytes)))
                {
                    Deserializer yamlSerializer = new Deserializer();
                    yamlObject = yamlSerializer.Deserialize(yamlReader);
                }

                if (yamlObject != null)
                {
                    SerializerBuilder yamlSerializerBuilder = new SerializerBuilder();
                    Serializer yamlSerializer = yamlSerializerBuilder.JsonCompatible().Build();
                    string jsonObject = yamlSerializer.Serialize(yamlObject);

                    if (!string.IsNullOrEmpty(jsonObject))
                    {
                        return jsonObject;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new FormatException("Error occured while processing YAML", exception);
            }

            return base.ToString();
        }
    }
}
