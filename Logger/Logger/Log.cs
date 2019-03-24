using System;
using System.Collections.Generic;
using System.Text;

namespace Logger {

    /// <summary>
    /// A log
    /// </summary>
   public class Log {

        // Message written by Dev
        public string Message { get; private set; }

        // Class in which the log was created
        public string Class { get; private set; }

        // Method in which the log was created
        public string Method { get; private set; }

        // Line where the log was created
        public int Line { get; private set; }

        // The exception message
        public string Exception { get; private set; }


        public Log(string Message, string Class, string Method, int Line, string Exception="") {

            this.Message = Message;
            this.Class = Class;
            this.Method = Method;
            this.Line = Line;
            this.Exception = Exception;

        }
    }
}
