using System;

namespace Raster.IO
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void LogMessage(string message);
    }
}
