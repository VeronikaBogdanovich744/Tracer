using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core;

namespace Tracer.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StackTrace stackTrace = new StackTrace();
            // Console.WriteLine(stackTrace.GetFrame(0).GetMethod().Name);
            foo();
            Console.Read();
        }

       private static void foo()
        {
            ITracer tracer = new TracerRealisation();
            TraceResult result = tracer.GetTraceResult();
            Console.WriteLine(result.MethodName.ToString());
        }
    }
}
