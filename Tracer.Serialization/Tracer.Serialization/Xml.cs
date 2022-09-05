﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tracer.Core;
using Tracer.Core.TraceResults;

namespace Tracer.Serialization
{
    internal class Xml : Tracer.Serialization.Abstractions.ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceResult));
            xmlSerializer.Serialize(to, traceResult);
        }
    }
}
