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


        public LogModelUnitTests()
        {

            // reset before each test
            logmodel = new LogModel();

        }
    }
}
