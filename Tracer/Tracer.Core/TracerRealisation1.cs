using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class TracerRealisation1 : ITracer
    {
        private Stopwatch stopWatch = new Stopwatch();

        public TracerRealisation1()
        {
           // this.stopWatch.Start();
        }
        public TraceResult GetTraceResult()
        {
            TraceResult result = new TraceResult();
            //get method name
            StackTrace stackTrace = new StackTrace();
            result.MethodName = stackTrace.GetFrame(1).GetMethod();

/*
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            
            result.Time = ts;
*/

            return result;
        }

        public void StartTrace()
        {
            stopWatch.Start();
        }

        public void StopTrace()
        {
            stopWatch.Stop();
        }
    }
}
