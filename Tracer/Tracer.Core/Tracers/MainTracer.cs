using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.TraceResults;

namespace Tracer.Core.Tracers
{
    public class MainTracer : ITracer
    {
        private TraceResult result { get; }
        object locker = new();  // объект-заглушка
        private Dictionary<int, ThreadTracer> ThreadTracers { get; }
        public MainTracer()
        {
            result = new TraceResult();
            ThreadTracers = new Dictionary<int, ThreadTracer>();
        }
        public TraceResult GetTraceResult()
        {
            foreach (var thread in ThreadTracers)
            {
                var threadTracer = thread.Value;
                var threadTraceResult = threadTracer.ThreadTraceResult;
                result.AddThread(threadTraceResult);
            }
            return result;
        }

        public void StartTrace()
        {
            lock (locker)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId; //get id of thread
                ThreadTracer threadTracer;
                //check if the thread is already in dictionary ???
                if (ThreadTracers.ContainsKey(threadId))
                {
                    threadTracer = ThreadTracers[threadId];
                }
                else
                {
                    threadTracer = new ThreadTracer(threadId);
                    ThreadTracers.Add(threadId, threadTracer);
                }
                //
                threadTracer.StartTrace();
            }
        }

        public void StopTrace()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            ThreadTracer threadTracer = ThreadTracers[threadId]; 
            /*lock (Lock)
            {
                var threadId = GetCurrentThreadId();
                if (ThreadTracers.ContainsKey(threadId))
                {
                    var threadTracer = ThreadTracers[threadId];
                    threadTracer.StopTrace();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }*/
            threadTracer.StopTrace();
        }
    }
}
