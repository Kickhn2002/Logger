using System;
using System.Collections.Generic;
using System.Text;

namespace Logger {
   public interface ILoggerManager {

        void AddLog(string message, string path = "", string memberName = "", int sourceLineNumber = 0);

        void AddLog(string message, Exception exception, string path = "", string memberName = "", int sourceLineNumber = 0);

        void ClearLogs();

        List<Log> GetLogList();
    }
}
