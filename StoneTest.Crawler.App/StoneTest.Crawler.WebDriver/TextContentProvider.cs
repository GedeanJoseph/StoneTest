using StoneTest.Crawler.Commom.Models;
using StoneTest.Crawler.WebModule.Interfaces;

namespace StoneTest.Crawler.WebDriver
{
    public class TextContentProvider : ITextContentProvider
    {
        public void GenerateFallBackContent()
        {
            throw new System.NotImplementedException();
        }

        public TextContent GetTextContent()
        {
            throw new System.NotImplementedException();
        }

        public TextContent GetTextFallBack()
        {
            throw new System.NotImplementedException();
        }
    }
}
