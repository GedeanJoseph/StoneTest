using StoneTest.Crawler.DataModule.Interfaces;
using StoneTest.Crawler.Commom.Models;

namespace StoneTest.Crawler.DataModule
{
    public class FileManagerIO : IFileManager
    {
        private string FileName { get; set; }
        private string FilePath { get; set; }

        public FileManagerIO(string filePath, string fileName)
        {
            FilePath = filePath;
            FileName = fileName;
        }

        public string ReadContent()
        {
            throw new System.NotImplementedException();
        }

        public void WriteContent(TextContent content)
        {
            throw new System.NotImplementedException();
        }
    }
}
