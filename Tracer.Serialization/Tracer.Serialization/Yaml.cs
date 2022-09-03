using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core;

namespace Tracer.Serialization
{
    internal class Yaml : Tracer.Serialization.Abstractions.ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            throw new NotImplementedException();
        }
    }
}
