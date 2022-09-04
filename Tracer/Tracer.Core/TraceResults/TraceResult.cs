using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Core.TraceResults
{
    public class TraceResult
    {

        [XmlElement("threads")]
        //list of threads
        public List<ThreadTraceResult> ThreadTraceResults { get; }

        public TraceResult()
        {
            ThreadTraceResults = new List<ThreadTraceResult>();
        }

        public void AddThread(ThreadTraceResult thread)
        {
            ThreadTraceResults.Add(thread);
        }
    }
}
