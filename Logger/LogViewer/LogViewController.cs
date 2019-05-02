using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using Newtonsoft.Json;

namespace LogViewer
{
   public class LogViewController
    {

        private ILoggerManager loggerManager;
        private LogModel model;

        public LogViewController (ILoggerManager loggerManager, LogModel model)
        {
            this.loggerManager = loggerManager;
            this.model = model;
        }


        public void setLogFile(string filePath)
        {
            try
            {

                string logText = File.ReadAllText(filePath);
                List<Log> logs = JsonConvert.DeserializeObject<List<Log>>(logText);
                model.addLog(logs);
            }

            catch (Exception ex)
            {

                loggerManager.AddLog("failed to deserialise file to logs", ex);

            }

        }


    }
}
