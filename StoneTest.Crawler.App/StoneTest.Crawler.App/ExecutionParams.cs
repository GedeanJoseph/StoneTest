using System;
using System.Collections.Generic;
using System.Text;

namespace StoneTest.Crawler.App
{
    public class ExecutionParams
    {        
        public string DestinyFileName { get { return $"{DateTime.Now:yyyy-MMdd-HHmmss}-arquivo-gerado.txt"; } set { } }
        public string DestinyFilePath { get; set; }
        public int BufferLimit { get; set; }
        public int FileSizeLimit { get; set; }
    }
}
