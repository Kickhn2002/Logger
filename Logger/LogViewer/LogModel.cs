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
   public class LogModel
    {
        public List<Log> logs;



        public void readFile(string jsonString)
        {
            logs = JsonConvert.DeserializeObject<List<Log>>(jsonString);

        }
    }
}
