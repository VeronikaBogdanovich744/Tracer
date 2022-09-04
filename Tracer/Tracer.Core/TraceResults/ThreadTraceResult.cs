using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Core.TraceResults
{
    public class ThreadTraceResult
    {
        [XmlElement("id")]
        public int ThreadId { get; }

        [XmlElement("methods")]
        public List<MethodTraceResult>? Methods { get; }

        public double Time
        {
            get
            {
                double time = 0;
                foreach (var methodTraceResult in Methods)
                {
                    time += methodTraceResult.Time;
                }
                return time;
            }
        }

        public ThreadTraceResult(int threadId)
        {
            ThreadId = threadId;
            Methods = new List<MethodTraceResult>();
        }

        public void AddMethod(MethodTraceResult method)
        {
            Methods.Add(method);
        }
    }
}
