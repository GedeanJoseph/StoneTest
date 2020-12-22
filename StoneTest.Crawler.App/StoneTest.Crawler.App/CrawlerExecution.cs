using StoneTest.Crawler.Commom.Models;
using StoneTest.Crawler.PersistenceModule.Interfaces;
using StoneTest.Crawler.WebModule.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;
using System;

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
        private double _executionCount;
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
            _fileSizeLimitMB = fileSizeLimit > 0 ? fileSizeLimit : 100;
            swTotal = new Stopwatch();
            swStep = new Stopwatch();

        }
        #endregion

        #region " Public Methods"
        public void StartExecution()
        {
            Console.WriteLine("_______________________________________________________________________________________");
            Console.WriteLine("===========================Starting Execution!===========================");
            Console.WriteLine("_______________________________________________________________________________________");
            swTotal.Start();
            var bufferLimitB = (_bufferLimitMB * 1024 * 1024);

            do
            {
                _executionCount++;
                swStep.Start();
                Console.WriteLine("_______________________________________________________________________________________");
                Console.WriteLine($"Starting Crawler step '{_executionCount}' ");
                Console.WriteLine("_______________________________________________________________________________________");
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
                }

                //write do buffer atual com o maior valor possível dentro do valor limite                
                _fileManager.WriteContent(newTextContent);
                swStep.Stop();

            } while (_fileManager.CurrentFileSizeMB < _fileSizeLimitMB && _executionCount < 300);

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
            Console.WriteLine("_______________________________________________________________________________________");
            Console.WriteLine($"================ Execution completed total time - {swTotal.Elapsed.ToString()} ans steps time is {swStep.Elapsed.ToString()} ===============");
            Console.WriteLine("_______________________________________________________________________________________");
        }
        private void ReportGenerator() { }

        #endregion
    }
}
