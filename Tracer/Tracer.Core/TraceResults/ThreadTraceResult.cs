using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Core.TraceResults
{
    [Serializable]
    public class ThreadTraceResult
    {
        [XmlAttribute]
        [JsonPropertyName("Id")]
        [YamlDotNet.Serialization.YamlMember(Alias = "Id")]
        public int ThreadId { get; set; }

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

        [XmlElement("method")]
        public List<MethodTraceResult>? Methods { get; }

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
