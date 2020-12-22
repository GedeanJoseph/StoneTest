using StoneTest.Crawler.PersistenceModule.Interfaces;
using StoneTest.Crawler.Commom.Models;

namespace StoneTest.Crawler.DataModule
{
    public class FileManagerIO : IFileManager
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        
        public int CurrentFileSizeMB { get => GetCurrentFileSize();}

        public FileManagerIO(string filePath, string fileName)
        {
            FilePath = filePath;
            FileName = fileName;
        }

        private int GetCurrentFileSize() {
            return 0;
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
