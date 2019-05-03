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
            fooLog.Add(new Log("fooMessage", "fooClass", "fooMethod", 1));
            
            //act
            logmodel.addLog(fooLog);

            //assert
            Assert.Equal(expectedMessage,logmodel.logs[0].Message);
        }

        [Fact]
        public void getFilteredLogs_UnitTest()
        {

            // arrange
            logmodel.logs.Add(new Log("FooMessage","fooClass","fooMethod",1));
            logmodel.logs.Add(new Log("BarMessage", "fooClass", "fooMethod", 1));
            logmodel.addFilter(LogAttributesEnum.Message,"Foo");

            //act
            List<Log> filteredList = logmodel.getFilteredLogs();

            //assert
            Assert.True(1== filteredList.Count);
            Assert.Equal("FooMessage",logmodel.logs[0].Message);
        }

        [Fact]
        public void getFilteredLogsWithEmptyFilter_UnitTest()
        {
            // arrange
            logmodel.logs.Add(new Log("FooMessage", "fooClass", "fooMethod", 1));
            logmodel.logs.Add(new Log("BarMessage", "fooClass", "fooMethod", 1));

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
