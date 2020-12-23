using StoneTest.Crawler.Commom.Models;
using StoneTest.Crawler.PersistenceModule.Interfaces;
using StoneTest.Crawler.WebModule.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;
using System;
using System.Globalization;

namespace StoneTest.Crawler.App
{
    public class CrawlerExecution
    {
        #region " Fields "
        private ITextContentProvider _textProvider;
        private ITextContentAnalyzer _textAnalyser;
        private IFileManager _fileManager;
        //private IConfiguration _configuration;
        private double _bufferLimitMB;
        private double _fileSizeLimitMB;
        private long _executionCount;
        private Stopwatch swTotal;
        private Stopwatch swStep;
        #endregion'

        #region     "Constructors"
        public CrawlerExecution(ITextContentProvider textProvider, ITextContentAnalyzer textAnalyzer, IFileManager fileManager, double bufferLimitMB, double fileSizeLimit)
        {
            _textProvider = textProvider;
            _textAnalyser = textAnalyzer;
            _fileManager = fileManager;            
            _bufferLimitMB = bufferLimitMB > 0 ? bufferLimitMB : 1;
            _fileSizeLimitMB = fileSizeLimit > 0 ? fileSizeLimit : 2;
            swTotal = new Stopwatch();
            swStep = new Stopwatch();

        }
        #endregion

        #region " Public Methods"
        public void StartExecution()
        {
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("===========================  Starting Execution!  ===========================");
            Console.WriteLine("=======================================================================================\n\n");
            swTotal.Start();
            var bufferLimitB = (_bufferLimitMB * 1024 * 1024);

            while (_fileManager.CurrentFileSizeMB < (decimal)_fileSizeLimitMB)
            {
                _executionCount++;
                swStep.Start();
                
                Console.WriteLine($"\n==========   Executing Crawler iteration '{_executionCount}' file size is \"{_fileManager.CurrentFileSizeMB}MB/{_fileSizeLimitMB}MB\" ==========\n");

                var newTextContent = _textProvider.GetTextContent();
                
                _textAnalyser.GetTextDetails(newTextContent);

                if (newTextContent.ContentInfo.ContentByteSize < bufferLimitB)
                {
                    var initialContent = newTextContent.Content.ToString();
                    /*Gedean Note:
                     * Poderia utilizar aqui uma recursão de laço while, onde checaria a cada interação a necessidade de nova recursão.
                     * Mas, optei por uma laço mais simpes onde o target será definido por um cálculo matemático executado uma única vez
                    // */

                    var qtdIterations = CheckInteractions(newTextContent, bufferLimitB);
                    for (int i = 1; i < qtdIterations; i++)
                    {
                        newTextContent.Content.Append(initialContent);
                    }
                    Console.WriteLine($"\nWriting a buffer of {qtdIterations * newTextContent.ContentInfo.ContentByteSize} bytes and {newTextContent.Content.Length} characteres done with {qtdIterations} perfect concatenations");
                }
                
                //write do buffer atual com o maior valor possível dentro do valor limite                
                _fileManager.WriteContent(newTextContent);
                swStep.Stop();
            } 

            StopExecution();

            ReportGenerator();
        }
        #endregion

        #region " Private Methods"
        private double CheckInteractions(TextContent textContent, double bufferLimitB) {
                      
            var qtdInterations = Math.Truncate(bufferLimitB / textContent.ContentInfo.ContentByteSize);

            return qtdInterations;
        }
        private void StopExecution()
        {
            swTotal.Stop();
            Console.WriteLine("\n\n"); 
            Console.WriteLine("=======================================================================================");
            Console.WriteLine($"================ Execution completed ===============");
            Console.WriteLine("=======================================================================================");
        }
        private void ReportGenerator() {
                Console.WriteLine("{0,35} {1,10} {2,19} {3,10} {4,16} {5,16}", "Name", "Size(MB)", "File Path", "Iterations", "Total Time", "Average Time");
                Console.WriteLine("_______________________________________________________________________________________________________________");                
                Console.WriteLine("{0,35} {1,10} {2,19} {3,10} {4,16} {5,16}\n\n", _fileManager.FileName, _fileManager.CurrentFileSizeMB, _fileManager.FilePath,_executionCount, swTotal.Elapsed.ToString(@"hh\:mm\:ss"),(new TimeSpan(swStep.Elapsed.Ticks / _executionCount)).ToString(@"hh\:mm\:ss"));                 
        }

        #endregion
    }
}
