using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Logger {

    /// <summary>
    /// Manages the logs.
    /// </summary>
    public class LoggerManager : ILoggerManager {

        // List of logs
        public List<Log> logList { get; private set; }

        public LoggerManager() {

            logList = new List<Log>();
        }

        /// <summary>
        /// Add a log with a message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="path">Path of the class where the log was created. DO NOT INSERT ANYTHING</param>
        /// <param name="memberName">Method of the class where the log was created. DO NOT INSERT ANYTHING</param>
        /// <param name="sourceLineNumber">Line of the class where the log was created. DO NOT INSERT ANYTHING</param>
        public void AddLog(string message, [CallerFilePath] string path = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int sourceLineNumber = 0) {

            logList.Add(new Log(message, path, memberName, sourceLineNumber));

        }

        /// <summary>
        /// Add a log with a message and an exeption message
        /// </summary>
        /// <param name="message">The message</param>
        /// /// <param name="exception">The exception</param>
        /// <param name="path">Path of the class where the log was created. DO NOT INSERT ANYTHING</param>
        /// <param name="memberName">Method of the class where the log was created. DO NOT INSERT ANYTHING</param>
        /// <param name="sourceLineNumber">Line of the class where the log was created. DO NOT INSERT ANYTHING</param>
        public void AddLog(string message, Exception exception, [CallerFilePath] string path = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int sourceLineNumber = 0) {

            logList.Add(new Log(message, path, memberName, sourceLineNumber, exception.Message));

        }

        /// <summary>
        /// Clear the log list
        /// </summary>
        public void ClearLogs() {
            logList.Clear();
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <returns>The list of logs</returns>
        public List<Log> GetLogList() {

            return logList;
        }

        /// <summary>
        /// Get the logs in a Json format
        /// </summary>
        /// <returns> The logs in a Json format</returns>
        public string CreateLogFileText() {

            return JsonConvert.SerializeObject(logList, Formatting.Indented);

        }
    }
}
