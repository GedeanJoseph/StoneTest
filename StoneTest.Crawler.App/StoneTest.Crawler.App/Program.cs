using StoneTest.Crawler.DataModule;
using StoneTest.Crawler.DataModule.Interfaces;
using StoneTest.Crawler.WebDriver;
using StoneTest.Crawler.WebModule.Interfaces;
using System;
using System.IO;

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
            ITextContentProvider textProvider = new TextContentProvider() { };
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
