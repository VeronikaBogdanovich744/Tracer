using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Core.TraceResults
{
    [Serializable]
    public class ThreadTraceResult
    {
        [XmlAttribute]
        public int ThreadId { get; set; }

        [XmlElement("method")]
        public List<MethodTraceResult>? Methods { get; }

        [XmlAttribute]
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
            set
            {

            }
        }

        public ThreadTraceResult()
        {
            ThreadId = Thread.CurrentThread.ManagedThreadId;
            Methods = new List<MethodTraceResult>();
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
