using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core;
using Tracer.Core.TraceResults;
using Tracer.Core.Tracers;

namespace Tracer.Example
{
    internal class Program
    {
        private static ITracer tracer = new MainTracer();
        static void Main(string[] args)
        {
            TraceResult traceResult = new TraceResult();
           // tracer = new MainTracer();

            Thread thread = new Thread(new ThreadStart(AnotherThreadMethod));
            thread.Start();

            Method1();
            Method2();

            while (thread.IsAlive)
            {

            }

            var res = tracer.GetTraceResult();
            Console.Read();
        }

        private static void Method1()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }

        private static void Method2()
        {
            tracer.StartTrace();
            Method1();
            Thread.Sleep(100);
            tracer.StopTrace();
        }

        private static void AnotherThreadMethod()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}
