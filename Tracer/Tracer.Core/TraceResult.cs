using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public class TraceResult
    {
        public MethodBase? MethodName { get; set; }
        public string? ClassName { get; set; }
        public TimeSpan? Time { get; set; }
    }
}
