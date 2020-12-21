using StoneTest.Crawler.Commom.Models;

namespace StoneTest.Crawler.WebModule.Interfaces
{
    public interface ITextContentAnalyzer
    {
        public  TextContent GetTextDetails(TextContent textContent);
    }
}
