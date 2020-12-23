using System;
using System.Collections.Generic;
using System.Text;

namespace StoneTest.Crawler.App
{
    public class ExecutionParams
    {
        public ExecutionParams()
        {
            BufferLimit = 1;
            FileSizeLimit = 100;
            HeadLessModeActivated = true;

        }
        public string DestinyFilePath { get; set; }
        public int BufferLimit { get; set; }
        public int FileSizeLimit { get; set; }
        public bool HeadLessModeActivated { get; set; }

    }
}
