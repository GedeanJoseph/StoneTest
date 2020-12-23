using Microsoft.Extensions.Configuration;
using StoneTest.Crawler.DataModule;
using StoneTest.Crawler.PersistenceModule.Interfaces;
using StoneTest.Crawler.WebModule;
using StoneTest.Crawler.WebModule.Interfaces;
using System;
using System.IO;

namespace StoneTest.Crawler.App
{
    class Program
    {      
        static void Main(string[] args)
        {
            #region " Verbose section"
            Console.WriteLine("Stone Test - WebCrowler says: \"-Hello world\"!");
            Console.WriteLine("Let's Go!!!");
            #endregion

            #region " Configuration settings "
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.json");

            var configuration = builder.Build();

            #endregion

            var parameters = GetExecutionParams(args);

            #region " Initialyzing essentials components "
            var chromeDriverPath = configuration.GetSection("Selenium:DriverChromeFilePath").Value.ToString();
            ITextContentProvider textProvider = new TextContentProvider(parameters.HeadLessModeActivated); { };
            ITextContentAnalyzer textAnalyzer = new TextContentAnalyze(parameters.HeadLessModeActivated) { };
            IFileManager fileManager = new FileManagerIO(parameters.DestinyFilePath) { };
            #endregion


            Console.WriteLine($"Starting execution with {parameters.BufferLimit}MB of buffer limit and {parameters.FileSizeLimit}MB of file size limit. The file is at {parameters.DestinyFilePath}");            
            (new CrawlerExecution(textProvider, textAnalyzer, fileManager, parameters.BufferLimit, parameters.FileSizeLimit))
            .StartExecution();

            Console.ReadKey();
        }

        private static ExecutionParams GetExecutionParams(string[] args)
        {
            var parameters = new ExecutionParams();

            try
            {
                try { parameters.DestinyFilePath = args[0].ToString(); } catch { Console.WriteLine($"The mandatory parameter: \"File path\" has missed.");Console.ReadKey();throw; }
                try { parameters.BufferLimit = Convert.ToInt32(args[1]);}catch { return parameters; }
                try { parameters.FileSizeLimit = Convert.ToInt32(args[2]); } catch { return parameters; }
                try { parameters.HeadLessModeActivated = Convert.ToInt32(args[3]) ==0?false:true; } catch { return parameters; }

                return parameters;
            }
            catch (Exception)
            {
                Console.WriteLine("The mandatory file path parameter not specified. Example: \"C:\\temp\"");
                Console.ReadKey();
                throw;
            }            
        }
    }
}
