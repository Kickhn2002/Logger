using System;
using Xunit;
using LogViewer;
using Logger;
using Newtonsoft.Json;

namespace LogViewerUnitTests
{
    public class LogModelUnitTests
    {
        public LogModel logmodel;
        public ILoggerManager loggerManager;

        [Fact]
        public void ReadFiles_UnitTest()
        {
            //arrange

            loggerManager.AddLog("fooMessage", "fooPath", "fooMethod", -1);
            string addedjsonString = "[\r\n  {\r\n    \"Message\": \"fooMessage\",\r\n    \"Class\": \"fooPath\",\r\n    \"Method\": \"fooMethod\",\r\n    \"Line\": -1,\r\n    \"Exception\": \"\"\r\n  }]";
            string expectedJsonString = loggerManager.CreateLogFileText();

            //act
            logmodel.readFile(addedjsonString);
           string jsonString = JsonConvert.SerializeObject(logmodel.logs, Formatting.Indented);

            //assert
            Assert.Equal(expectedJsonString, jsonString);


        }


        public LogModelUnitTests()
        {

            // reset before each test
            logmodel = new LogModel();
            loggerManager = new LoggerManager();


        }
    }
}
