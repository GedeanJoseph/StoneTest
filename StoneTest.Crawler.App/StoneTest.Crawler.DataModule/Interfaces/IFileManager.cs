using StoneTest.Crawler.Commom.Models;

namespace StoneTest.Crawler.PersistenceModule.Interfaces
{
    public interface IFileManager
    {
        public double CurrentFileSizeMB { get; }

        public double WriteContent(TextContent content);

        public string ReadContent();
    }
}
