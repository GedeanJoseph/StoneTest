using StoneTest.Crawler.Commom.Models;

namespace StoneTest.Crawler.PersistenceModule.Interfaces
{
    public interface IFileManager
    {
        public double CurrentFileSizeMB { get; }
        public string CurrentFileName { get; }

        public string FilePath { get; }
        public string FileName { get; }

        public double WriteContent(TextContent content);

        public string ReadContent();
    }
}
