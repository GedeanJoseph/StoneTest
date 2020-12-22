using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using StoneTest.Crawler.Commom.Models;

using StoneTest.Crawler.WebModule.Interfaces;

namespace StoneTest.Crawler.WebModule
{
    public class TextContentProvider : WebProviderBase, ITextContentProvider
    {
        public TextContentProvider(string pathDriver):base(pathDriver)
        {

        }

        public TextContent GetTextContent()
        {
            var textContent = new TextContent();

            PageLoad("https://lerolero.com/");

            var content = _driver.FindElement(By.Id("root"))
                .FindElement(By.ClassName("frase")).Text;

            textContent.Content.Append(content);

            return textContent;
        }
        public void GenerateFallBackContent()
        {
            throw new System.NotImplementedException();
        }

        public TextContent GetTextFallBack()
        {
            var textMsg = new TextContent();
            var text = GetValueFromElementByClass("sentence sentence-exited");

            Fechar();
            return textMsg;            
        }
    }
}
