using System;
using Xunit;
using Newtonsoft.Json;

namespace Logger.UnitTests {


    public class LoggerManagerUnitTests {

        [Fact]
        public void AddLog_UnitTest() {
            LoggerManager.AddLog("fooMessage");

            Assert.Equal("fooMessage", LoggerManager.getLogList()[0].message);
        }

        [Fact]
        public void AddLogWithException_UnitTest() {

            Exception ex = new Exception("fooExceptionMessage");
            LoggerManager.AddLog("fooMessage", ex);

            Assert.Equal("fooExceptionMessage", LoggerManager.getLogList()[0].exceptionMessage);

        }

        [Fact]
        public void ClearLogs_UnitTest() {

            LoggerManager.AddLog("fooMessage");
            LoggerManager.ClearLogs();

            Assert.True(LoggerManager.getLogList().Count == 0);
        }
    }
}
