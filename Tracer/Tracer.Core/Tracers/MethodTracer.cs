using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.TraceResults;

namespace Tracer.Core.Tracers
{
    public class MethodTracer
    {
        private Stopwatch stopWatch;
        private MethodTraceResult result;
        MethodTracer InnerMethod;

     //   private bool isNestedMethod = false;

        bool isActive; //contains value, that indicates whether an outer method is the previous method is active
        public Stack<MethodTracer>? NestedMethod { get; }
        public MethodTracer()
        {
            stopWatch = new Stopwatch();
          //  result = new MethodTraceResult();
            //NestedMethod = new Stack<MethodTracer>();
            InnerMethod = null;
            bool isActive = false;
        }
        public MethodTraceResult GetTraceResult()
        {
            StackTrace stackTrace = new StackTrace();
            return result;
        }

        public void StartTrace(string className, string methodName)
        {
            if (isActive == false) //является ли метод вложенным: нет - true, да - false
            {
                isActive = true; //make a method an outer method for someone
                stopWatch.Start();
                result = new MethodTraceResult(className, methodName);
            }
            else
            {
                if (InnerMethod == null)
                {
                    InnerMethod = new MethodTracer();
                }
                InnerMethod.StartTrace(className, methodName);
            }
        }

        public void StopTrace()
        {
            if (isActive==true)
            {
                if (InnerMethod != null) // если вложенный метод есть
                {
                    InnerMethod.StopTrace();
                    if (InnerMethod.IsActive()==false)
                    {
                        var innerMethodTraceResult = InnerMethod.GetTraceResult();
                        InnerMethod = null;
                        result.AddNestedMethodTraceResult(innerMethodTraceResult);
                    }
                }
                else
                {
                    stopWatch.Stop();
                    result.Time = getTime();
                    isActive = false;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool IsActive()
        {
            return isActive;
        }

        private double getTime()
        {
            var time = stopWatch.Elapsed.TotalMilliseconds;
            return time;
        }

    }
}
