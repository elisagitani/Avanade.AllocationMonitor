namespace Avanade.AllocationMonitor.Core.Tracers.Common
{
    /// <summary>
    /// Interface for custom tracer
    /// </summary>
    public interface ITracer
    {
        /// <summary>
        /// Traces information log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="formatParams">Format params</param>
        void Info(string message, params object[] formatParams);

        /// <summary>
        /// Traces debug log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="formatParams">Format params</param>
        void Debug(string message, params object[] formatParams);

        /// <summary>
        /// Traces warning log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="formatParams">Format params</param>
        void Warn(string message, params object[] formatParams);

        /// <summary>
        /// Traces error log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="formatParams">Format params</param>
        void Error(string message, params object[] formatParams);
    }
}
