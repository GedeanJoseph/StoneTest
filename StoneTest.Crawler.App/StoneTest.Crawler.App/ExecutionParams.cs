using System;
using System.Collections.Generic;
using System.Text;

namespace StoneTest.Crawler.App
{
    public class ExecutionParams
    {
        public ExecutionParams()
        {
            SetDestinyFileName();
        }
        public string DestinyFileName { get; private set; }
        public string DestinyFilePath { get; set; }
        public int BufferLimit { get; set; }
        public int FileSizeLimit { get; set; }

        private void SetDestinyFileName() { 
            DestinyFileName = $"{DateTime.Now:yyyy-MMdd-HHmmss}-arquivo-gerado.txt";
        }    
    }
}
