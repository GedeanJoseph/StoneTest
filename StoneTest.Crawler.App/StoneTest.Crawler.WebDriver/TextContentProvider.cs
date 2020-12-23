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

        public TextContentProvider(bool headLessModeActivated) :base(headLessModeActivated)
        {
            _fallbackMsgs = new List<string>();
            LoadFallBackFile();
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
                Fechar();
                return textContent;
            }
            catch (Exception){
               Fechar();
                return GetTextFallBack();
            }
        }        
        public TextContent GetTextFallBack()
        {
            var textContent = new TextContent();
            var rdn = new Random();
            var idx = rdn.Next(0, _fallbackMsgs.Count());

            textContent.Content.Append(_fallbackMsgs[idx]);
            return textContent;            
        }

        private void LoadFallBackFile()
        {
            _fallbackMsgs =  File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Template", "FallBackVerboseFile.txt")).ToList();
        }
    }
}
