using StoneTest.Crawler.Commom.Models;
using StoneTest.Crawler.DataModule.Interfaces;
using StoneTest.Crawler.WebModule.Interfaces;


namespace StoneTest.Crawler.App
{
    public class CrawlerExecution
    {
        #region " Fields "
        private ITextContentProvider _textProvider;
        private ITextContentAnalyzer _textAnalyser;
        private IFileManager _fileManager;
        private int _bufferLimitMB { get; set; }
        private int _fileSizeLimit { get; set; }
        #endregion'

        #region     "Constructors"
        public CrawlerExecution(ITextContentProvider textProvider, ITextContentAnalyzer textAnalyzer, IFileManager fileManager, int bufferLimitMB, int fileSizeLimit)
        {
            _textProvider = textProvider;
            _textAnalyser = textAnalyzer;
            _fileManager = fileManager;
            _bufferLimitMB = bufferLimitMB;
            _fileSizeLimit = fileSizeLimit;
        }
        #endregion

        #region " Public Methods"
        public void StartExecution()
        {
            do
            {
                var newTextContent = _textProvider.GetTextContent();
                _textAnalyser.GetTextDetails(newTextContent);
                if (newTextContent.ContentInfo.ContentByteSize < _bufferLimitMB)
                {

                    var initialValue = newTextContent.Content;

                    /*Gedean Note:
                     * Poderia utilizar aqui uma recursão de laço while, onde checaria a cada interação a necessidade de nova recursão. 
                     * Mas, optei por uma laço mais simpes onde o target será definido por um cálculo matemático executado uma única vez.
                     */
                    for (int i = 0; i < CheckInteractions(newTextContent); i++)
                    {
                        newTextContent.Content.Append(initialValue);
                    }
                }
                _fileManager.WriteContent(newTextContent); 
            } while (_fileManager.CurrentFileSizeMB < _fileSizeLimit);

            StopExecution();
            ReportGenerator();
        }
        #endregion

        #region " Private Methods"
        private int CheckInteractions(TextContent textContent) {


            return 1;
        }
        private void StopExecution()
        {

        }
        private void ReportGenerator() { }

        #endregion
    }
}
