using StoneTest.Crawler.DataModule;
using StoneTest.Crawler.PersistenceModule.Interfaces;
using StoneTest.Crawler.WebModule;
using StoneTest.Crawler.WebModule.Interfaces;
using System;

namespace StoneTest.Crawler.App
{
    class Program
    {      

        static void Main(string[] args)
        {
            Console.WriteLine("Stone Test - WebCrowler says: \"-Hello world\"!");
            Console.WriteLine("Let's Works Hard, and Play Hard!");
            Console.WriteLine("____________________________________________________________");

            var parameters = GetExecutionParams(args);

            #region " Initialyzing essentials components "            
            ITextContentProvider textProvider = new TextContentProvider(@"C:\Selenium\ChromeDriver2\") { };
            ITextContentAnalyzer textAnalyzer = new TextContentAnalyze() { };
            IFileManager fileManager = new FileManagerIO(parameters.DestinyFilePath,parameters.DestinyFileName) { };
            #endregion

            var crawlerExecution = new CrawlerExecution(textProvider, textAnalyzer, fileManager, parameters.BufferLimit, parameters.FileSizeLimit);
            crawlerExecution.StartExecution();


            Console.ReadKey();
        }

        private static ExecutionParams GetExecutionParams(string[] args)
        {
            return new ExecutionParams();
        }
    }
}
