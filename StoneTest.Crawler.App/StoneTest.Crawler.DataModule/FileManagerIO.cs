﻿using StoneTest.Crawler.PersistenceModule.Interfaces;
using StoneTest.Crawler.Commom.Models;
using System.IO;
using System.Text;
using System;

namespace StoneTest.Crawler.DataModule
{
    public class FileManagerIO : IFileManager
    {
        public FileManagerIO(string filePath)
        {
            FilePath = filePath;
            FileName = $"{DateTime.Now:yyyy-MM-dd-HHmmss}-arquivogerado.txt";
            CreateFile();
        }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        
        public string CurrentFileName { get { return GetCurrentFileName(); } }

        public decimal CurrentFileSizeMB { get { return GetCurrentFileSize(); } }

        public FileManagerIO(string filePath, string fileName)
        {
            FilePath = filePath;
            FileName = fileName;
        }

        private string GetCurrentFileName()
        {
            return Path.Combine(FilePath, FileName);
        }

        private decimal GetCurrentFileSize() {
            FileInfo fileInfo = new FileInfo(Path.Combine(FilePath, FileName));
            return fileInfo.Length > 0? Math.Round(((decimal)fileInfo.Length / 1024 / 1024)):0;
        }    

        private void CreateFile()
        {            
            if (!File.Exists(Path.Combine(FilePath, FileName)))
            {
                // Create a file to write to.
                using StreamWriter sw = File.CreateText(Path.Combine(FilePath, FileName));
                sw.Close();
            }
        }

        public string ReadContent()
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = File.OpenText(Path.Combine(FilePath, FileName)))
            {
                
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    sb.AppendLine(s);
                }
            }

            return sb.ToString();
        }

        public decimal WriteContent(TextContent content)
        {
            if (!File.Exists(Path.Combine(FilePath, FileName)))        
            CreateFile();
        
            using (StreamWriter sw = new StreamWriter(Path.Combine(FilePath, FileName),true))
            {
                sw.WriteLine(content.Content.ToString());
            }
            
            content.Content.Clear();
            content.ContentInfo = new ContentInfo();

            return CurrentFileSizeMB;
        }
    }
}
