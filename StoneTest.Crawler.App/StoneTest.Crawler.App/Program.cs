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
            Console.WriteLine("Let's Works Hard, and Play Hard!");
            Console.WriteLine("____________________________________________________________");
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
            ITextContentProvider textProvider = new TextContentProvider(chromeDriverPath) { };
            ITextContentAnalyzer textAnalyzer = new TextContentAnalyze(chromeDriverPath) { };
            IFileManager fileManager = new FileManagerIO(parameters.DestinyFilePath,parameters.DestinyFileName) { };
            #endregion

            
            (new CrawlerExecution(textProvider, textAnalyzer, fileManager, parameters.BufferLimit, parameters.FileSizeLimit))
            .StartExecution();

            Console.ReadKey();
        }

        private static ExecutionParams GetExecutionParams(string[] args)
        {
            return new ExecutionParams();
        }
    }
}
