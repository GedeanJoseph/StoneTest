using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using StoneTest.Crawler.Commom.Models;

using StoneTest.Crawler.WebModule.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StoneTest.Crawler.WebModule
{
    public class TextContentProvider : WebProviderBase, ITextContentProvider
    {
        private List<string> _fallbackMsgs;

        public TextContentProvider(string pathDriver):base(pathDriver)
        {
            _fallbackMsgs = new List<string>();
        }

        public TextContent GetTextContent()
        {
            var textContent = new TextContent();


            try
            {
                PageLoad("https://lerolero.com/");

                var content = _driver.FindElement(By.Id("root"))
                    .FindElement(By.ClassName("frase")).Text;

                textContent.Content.Append(content);
               
            }
            catch (Exception)            {
                var rdn = new Random();
                var idx = rdn.Next(0, _fallbackMsgs.Count());

                textContent.Content.Append(_fallbackMsgs[idx]);
            }
            Fechar();
            return textContent;
        }        
        public TextContent GetTextFallBack()
        {
            var textMsg = new TextContent();
            var text = GetValueFromElementByClass("sentence sentence-exited");

            Fechar();
            return textMsg;            
        }

        private void LoadFallBackFile()
        {
            _fallbackMsgs =  File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Template", "FallBackVerboseFile.txt")).ToList();
        }
    }
}
