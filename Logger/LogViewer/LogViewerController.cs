using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogViewer
{
   public class LogViewerController
    {


        public void openFile()
        {
            Stream logText = null;
            var opendialog = new OpenFileDialog();
            opendialog.ShowDialog();

          

        }
    }
}
