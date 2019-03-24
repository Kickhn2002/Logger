using System;
using Xunit;
using Newtonsoft.Json;

namespace Logger.UnitTests {


    public class LoggerManagerUnitTests {

        private ILoggerManager loggerManager;

        [Fact]
        public void AddLog_UnitTest() {
            loggerManager.AddLog("fooMessage");

            Assert.Equal("fooMessage", loggerManager.GetLogList()[0].Message);
        }

        [Fact]
        public void AddLogWithException_UnitTest() {

            Exception ex = new Exception("fooExceptionMessage");
            loggerManager.AddLog("fooMessage", ex);

            Assert.Equal("fooExceptionMessage", loggerManager.GetLogList()[0].Exception);

        }

        [Fact]
        public void ClearLogs_UnitTest() {

            loggerManager.AddLog("fooMessage");
            loggerManager.ClearLogs();

            Assert.True(loggerManager.GetLogList().Count == 0);
        }

        public LoggerManagerUnitTests() {

            loggerManager = new LoggerManager();
        }
    }
}
