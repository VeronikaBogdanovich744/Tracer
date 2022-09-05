using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
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


            MethodInfo myMethod = null;
            object obj = Tracer.Core.Plugin.getAddon("Tracer.Serialization.Xml", "Serialize",ref myMethod);
            using (FileStream fs = new FileStream("methods.xml", FileMode.Create))
            {
                 myMethod.Invoke(obj,new object[] { res, fs });
            }

            obj = Tracer.Core.Plugin.getAddon("Tracer.Serialization.Json", "Serialize", ref myMethod);
            using (FileStream fs = new FileStream("methods.json", FileMode.Create))
            {
                myMethod.Invoke(obj, new object[] { res, fs });
            }

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
