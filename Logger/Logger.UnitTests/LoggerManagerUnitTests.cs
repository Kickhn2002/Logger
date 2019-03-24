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
        public void AddLogClassPath_UnitTest() {
            loggerManager.AddLog("fooMessage", "fooPath");

            Assert.Equal("fooPath", loggerManager.GetLogList()[0].Class);
        }

        [Fact]
        public void AddLogMember_UnitTest() {
            loggerManager.AddLog("fooMessage", "fooPath", "fooMember");

            Assert.Equal("fooMember", loggerManager.GetLogList()[0].Method);
        }

        [Fact]
        public void AddLogClassLine_UnitTest() {
            loggerManager.AddLog("fooMessage", "fooPath", "fooMember", -1);

            Assert.Equal(-1, loggerManager.GetLogList()[0].Line);
        }

        [Fact]
        public void ClearLogs_UnitTest() {

            loggerManager.AddLog("fooMessage");
            loggerManager.ClearLogs();

            Assert.True(loggerManager.GetLogList().Count == 0);
        }

        [Fact]
        public void CreateLogFileText_UnitTest() {

            loggerManager.AddLog("fooMessage", "fooClass", "fooMethod", -1);
            var expectedJsonString = JsonConvert.SerializeObject(loggerManager.GetLogList(), Formatting.Indented);
            var JsonText = loggerManager.CreateLogFileText();

            Assert.Equal(expectedJsonString, JsonText);

        }

        public LoggerManagerUnitTests() {

            // member cleanup
            loggerManager = new LoggerManager();
        }
    }
}
