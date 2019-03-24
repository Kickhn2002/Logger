using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace Logger {
    class LoggerManager {

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
    }
}
