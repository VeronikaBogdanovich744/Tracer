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
            StackTrace stackTrace = new StackTrace();
            Console.WriteLine(stackTrace.GetFrame(0).GetMethod().Name);
            Console.Read();
        }

       private void foo()
        {
            ITracer tracer = new TracerRealisation();
           
        }
    }
}
