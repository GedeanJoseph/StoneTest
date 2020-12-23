using MatthiWare.CommandLine.Core.Attributes;
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

        [Required, Name("dp", "destinypath"),Description("Directoty to save the file with the buffer")]
        public string DestinyFilePath { get; set; }
        [Name("bl", "bufferlimit"),Description("The mega bytes limit for each buffer beffore persist in file. Default is: 1MB")]
        public int BufferLimit { get; set; }
        [Name("fsl", "filesizelimit"), Description("The mega bytes limit for file in destiny. Default is: 100MB")]
        public int FileSizeLimit { get; set; }
        [Name("hm", "headlessmodeactivated"), Description("The option to disable the headless mode in selenium webdriver to see and follow the webpage interaction")]
        public bool HeadLessModeActivated { get; set; }

    }
}
