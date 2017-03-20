using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace ContosoUniversity.Logging
{
    public class Logger : ILogger
    {
        public void Error(string message)
        {
            //throw new NotImplementedException();
            Trace.TraceError(message);
        }

        public void Error(string fmt, params object[] vars)
        {
            //throw new NotImplementedException();
            Trace.TraceError(fmt, vars);
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            //throw new NotImplementedException();
            Trace.TraceError(FormatExceptionMessage(exception, fmt, vars));
        }

        public void Information(string message)
        {
            //throw new NotImplementedException();
            Trace.TraceInformation(message);
        }

        public void Information(string fmt, params object[] vars)
        {
            //throw new NotImplementedException();
            Trace.TraceInformation(fmt, vars);
        }

        public void Information(Exception exception, string fmt, params object[] vars)
        {
            //throw new NotImplementedException();
            Trace.TraceInformation(FormatExceptionMessage(exception, fmt, vars));
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan)
        {
            //throw new NotImplementedException();
            TraceApi(componentName, method, timespan, "");
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string properties)
        {
            //throw new NotImplementedException();
            string message = String.Concat("Component:", componentName, ";Method:", method, ";Timespan:", timespan.ToString(), ";Properties:", properties);
            Trace.TraceInformation(message);
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars)
        {
            //throw new NotImplementedException();
            TraceApi(componentName, method, timespan, string.Format(fmt, vars));
        }

        public void Warning(string message)
        {
            throw new NotImplementedException();
        }

        public void Warning(string fmt, params object[] vars)
        {
            throw new NotImplementedException();
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            throw new NotImplementedException();
        }

        private static string FormatExceptionMessage(Exception exception, string fmt, object[] vars)
        {
            // Simple exception formatting: for a more comprehensive version see 
            // http://code.msdn.microsoft.com/windowsazure/Fix-It-app-for-Building-cdd80df4
            var sb = new StringBuilder();
            sb.Append(string.Format(fmt, vars));
            sb.Append(" Exception: ");
            sb.Append(exception.ToString());
            return sb.ToString();
        }
    }
}