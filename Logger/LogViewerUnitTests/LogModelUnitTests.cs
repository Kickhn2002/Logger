using System;
using Xunit;
using LogViewer;
using Logger;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LogViewerUnitTests
{
    public class LogModelUnitTests
    {
        public LogModel logmodel;

        [Fact]
        public void ReadFiles_UnitTest()
        {
            //arrange

            List<Log> fooLog = new List<Log>();
            var expectedMessage = "fooMessage";
            fooLog.Add(new Log("fooMessage", "fooClass", "fooMethod", 1,"fooDate"));

            //act
            logmodel.addLog(fooLog);

            //assert
            Assert.Equal(expectedMessage, logmodel.logs[0].Message);
        }

        [Fact]
        public void getFilteredLogsMessageFilter_UnitTest()
        {

            // arrange
            logmodel.logs.Add(new Log("FooMessage", "fooClass", "fooMethod", 1, "fooDate"));
            logmodel.logs.Add(new Log("BarMessage", "BarClass", "BarMethod",1, "fooDate"));
            logmodel.addFilter(LogAttributesEnum.Message, "Foo");

            //act
            List<Log> filteredList = logmodel.getFilteredLogs();

            //assert
            Assert.True(1 == filteredList.Count);
            Assert.Equal("FooMessage", logmodel.logs[0].Message);
        }

        [Fact]
        public void getFilteredLogsClassFilter_UnitTest()
        {
            // arrange
            logmodel.logs.Add(new Log("FooMessage", "fooClass", "fooMethod", 1, "fooDate"));
            logmodel.logs.Add(new Log("BarMessage", "BarClass", "BarMethod", 2, "fooDate"));
            logmodel.addFilter(LogAttributesEnum.Class, "foo");

            //act
            List<Log> filteredList = logmodel.getFilteredLogs();

            //assert
            Assert.True(1 == filteredList.Count);
            Assert.Equal("fooClass", logmodel.logs[0].Class);

        }

        [Fact]
        public void getFilteredLogsMethodFilter_UnitTest()
        {
            // arrange
            logmodel.logs.Add(new Log("FooMessage", "fooClass", "fooMethod", 1, "fooDate"));
            logmodel.logs.Add(new Log("BarMessage", "BarClass", "BarMethod", 2, "fooDate"));
            logmodel.addFilter(LogAttributesEnum.Method, "foo");

            //act
            List<Log> filteredList = logmodel.getFilteredLogs();

            //assert
            Assert.True(1 == filteredList.Count);
            Assert.Equal("fooMethod", logmodel.logs[0].Method);

        }

        [Fact]
        public void getFilteredLogsLineFilter_UnitTest()
        {
            // arrange
            logmodel.logs.Add(new Log("FooMessage", "fooClass", "fooMethod", 1, "fooDate"));
            logmodel.logs.Add(new Log("BarMessage", "BarClass", "BarMethod", 2, "fooDate"));
            logmodel.addFilter(LogAttributesEnum.Line, "1");

            //act
            List<Log> filteredList = logmodel.getFilteredLogs();

            //assert
            Assert.True(1 == filteredList.Count);
            Assert.Equal(1, logmodel.logs[0].Line);

        }

        [Fact]
        public void getFilteredLogsExceptionFilter_UnitTest()
        {
            // arrange
            logmodel.logs.Add(new Log("FooMessage", "fooClass", "fooMethod", 1, "fooDate", "fooException"));
            logmodel.logs.Add(new Log("BarMessage", "BarClass", "BarMethod", 2, "fooDate", "BarException"));
            logmodel.addFilter(LogAttributesEnum.Exception, "foo");

            //act
            List<Log> filteredList = logmodel.getFilteredLogs();

            //assert
            Assert.True(1 == filteredList.Count);
            Assert.Equal("fooException", logmodel.logs[0].Exception);

        }

        [Fact]
        public void getFilteredLogsMultiplePassedFilter_UnitTest()
        {
            // arrange
            logmodel.logs.Add(new Log("FooMessage", "fooClass", "fooMethod", 1, "fooDate"));
            logmodel.logs.Add(new Log("BarMessage", "BarClass", "BarMethod", 2, "fooDate"));
            logmodel.addFilter(LogAttributesEnum.Method, "Method");

            //act
            List<Log> filteredList = logmodel.getFilteredLogs();

            //assert
            Assert.True(2 == filteredList.Count);

        }

        [Fact]
        public void getFilteredLogsWithEmptyFilter_UnitTest()
        {
            // arrange
            logmodel.logs.Add(new Log("FooMessage", "fooClass", "fooMethod", 1, "fooDate"));
            logmodel.logs.Add(new Log("BarMessage", "fooClass", "fooMethod", 1, "fooDate"));

            //act
            List<Log> filteredList = logmodel.getFilteredLogs();

            //assert
            Assert.True(2 == filteredList.Count);
            Assert.Equal("FooMessage", logmodel.logs[0].Message);
            Assert.Equal("BarMessage", logmodel.logs[1].Message);
        }

        public LogModelUnitTests()
        {

            // reset before each test
            logmodel = new LogModel();

        }
    }
}
