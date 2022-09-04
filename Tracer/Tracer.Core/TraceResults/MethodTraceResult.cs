using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Core.TraceResults
{
    public class MethodTraceResult
    {
        [XmlElement("time")]
        public double Time { get; set; }
        [XmlElement("name")]
        public string MethodName { get; }

        [XmlElement("class")]
        public string ClassName { get; }

        [XmlElement("methods")]
        public List<MethodTraceResult> NestedMethodTraceResults { get; }

        public MethodTraceResult(string className, string methodName)
        {
            Time = 0;
            ClassName = className;
            MethodName = methodName;
            NestedMethodTraceResults = new List<MethodTraceResult>();
        }

        public MethodTraceResult()
        {
            Time = 0;
           /* var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();
            MethodName = method.Name;*
            ClassName = method.DeclaringType.FullName;*/
            //ClassName = className;
            //  MethodName = methodName;
            NestedMethodTraceResults = new List<MethodTraceResult>();
        }


        public void AddNestedMethodTraceResult(MethodTraceResult method)
        {
            NestedMethodTraceResults.Add(method);
        }
    }
}
