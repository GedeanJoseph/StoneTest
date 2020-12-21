using StoneTest.Crawler.Commom.Models;

namespace StoneTest.Crawler.WebModule.Interfaces
{
    public interface ITextContentProvider
    {        
        public TextContent GetTextContent();

        public TextContent GetTextFallBack();

        void GenerateFallBackContent();
    }
}
