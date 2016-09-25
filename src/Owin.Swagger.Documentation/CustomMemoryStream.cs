using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Owin.Swagger.Documentation
{
    internal class CustomMemoryStream : MemoryStream
    {
        protected override void Dispose(bool disposing)
        {
            //// getting rid of disposing after usage
        }
    }
}
