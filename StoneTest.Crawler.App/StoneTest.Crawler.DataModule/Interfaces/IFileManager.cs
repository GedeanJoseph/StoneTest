using StoneTest.Crawler.Commom.Models;

namespace StoneTest.Crawler.DataModule.Interfaces
{
    public interface IFileManager
    {
        public void WriteContent(TextContent content);

        public string ReadContent();
    }
}
