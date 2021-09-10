using System;
using System.Collections.Generic;

namespace Avanade.AllocationMonitor.Core.Tracers.Common
{
    /// <summary>
    /// Tracer
    /// </summary>
    /// <summary>
    /// Agnostic helper for tracer log on application
    /// </summary>
    public static class Tracer
    {
        #region Private fields
        private static IList<ITracer> _Tracers = new List<ITracer>();
        #endregion

        /// <summary>
        /// Appends provided tracer implementation to tracers list
        /// </summary>
        /// <param name="tracerImplementation">Implementation</param>
        public static void Append(ITracer tracerImplementation)
        {
            //Validazione argomenti
            if (tracerImplementation == null) throw new ArgumentNullException(nameof(tracerImplementation));

            //Append sulla lista dei tracers
            _Tracers.Add(tracerImplementation);
        }

        /// <summary>
        /// Traces information log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="formatParams">Format params</param>
        public static void Info(string message, params object[] formatParams)
        {
            foreach (var current in _Tracers)
                current.Info(message, formatParams);
        }

        /// <summary>
        /// Traces debug log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="formatParams">Format params</param>
        public static void Debug(string message, params object[] formatParams)
        {
            foreach (var current in _Tracers)
                current.Debug(message, formatParams);
        }

        /// <summary>
        /// Traces warning log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="formatParams">Format params</param>
        public static void Warn(string message, params object[] formatParams)
        {
            foreach (var current in _Tracers)
                current.Warn(message, formatParams);
        }

        /// <summary>
        /// Traces error log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="formatParams">Format params</param>
        public static void Error(string message, params object[] formatParams)
        {
            foreach (var current in _Tracers)
                current.Error(message, formatParams);
        }
    }
}
