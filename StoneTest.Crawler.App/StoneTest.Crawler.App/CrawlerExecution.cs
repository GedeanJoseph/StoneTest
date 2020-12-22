using StoneTest.Crawler.Commom.Models;
using StoneTest.Crawler.PersistenceModule.Interfaces;
using StoneTest.Crawler.WebModule.Interfaces;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configuration;
        private double _bufferLimitB;
        private double _fileSizeLimitB;
        private double _executionCount;
        #endregion'

        #region     "Constructors"
        public CrawlerExecution(ITextContentProvider textProvider, ITextContentAnalyzer textAnalyzer, IFileManager fileManager, double bufferLimitMB, double fileSizeLimit)
        {
            _textProvider = textProvider;
            _textAnalyser = textAnalyzer;
            _fileManager = fileManager;
            _bufferLimitB = (bufferLimitMB > 0 ?bufferLimitMB:1) * 1024 * 1024; 
            _fileSizeLimitB = (fileSizeLimit > 0 ? fileSizeLimit:100) * 1024 * 1024;
        }
        #endregion

        #region " Public Methods"
        public void StartExecution()
        {
            do
            {
                _executionCount++;
                var newTextContent = _textProvider.GetTextContent();
                
                _textAnalyser.GetTextDetails(newTextContent);

                if (newTextContent.ContentInfo.ContentByteSize < _bufferLimitB)
                {
                    var initialContent = newTextContent.Content.ToString();
                    /*Gedean Note:
                     * Poderia utilizar aqui uma recursão de laço while, onde checaria a cada interação a necessidade de nova recursão.
                     * Mas, optei por uma laço mais simpes onde o target será definido por um cálculo matemático executado uma única vez
                    // */
                    var qtdIterations = CheckInteractions(newTextContent);
                    for (int i = 1; i < qtdIterations; i++)
                    {
                        newTextContent.Content.Append(initialContent);
                    }
                }

                //write do buffer atual com o maior valor possível dentro do valor limite
                _fileManager.WriteContent(newTextContent);

            } while (_fileManager.CurrentFileSizeMB < _fileSizeLimitB && _executionCount < 100);

            StopExecution();

            ReportGenerator();
        }
        #endregion

        #region " Private Methods"
        private double CheckInteractions(TextContent textContent) {
                      
            var qtdInterations = Math.Truncate(_bufferLimitB / textContent.ContentInfo.ContentByteSize);

            return qtdInterations;
        }
        private void StopExecution()
        {

        }
        private void ReportGenerator() { }

        #endregion
    }
}
