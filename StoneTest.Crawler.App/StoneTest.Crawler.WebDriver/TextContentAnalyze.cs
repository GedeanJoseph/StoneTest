using System;
using StoneTest.Crawler.WebModule.Interfaces;
using StoneTest.Crawler.Commom.Models;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace StoneTest.Crawler.WebModule
{
    public class TextContentAnalyze : WebProviderBase, ITextContentAnalyzer
    {
        public TextContentAnalyze(string pathDriver) : base(pathDriver)
        {
        }

        public TextContent GetTextDetails(TextContent textContent)
        {
            try
            {
                PageLoad($"https://mothereff.in/byte-counter#{textContent.Content}");

                //_driver.SetText(
                //    By.CssSelector("body textarea"),
                //    textContent.Content.ToString());

                var charCount = GetValueFromElementById("characters");

                var byteCountResult = GetValueFromElementById("bytes");

                var byteCountValue = Regex.Match(byteCountResult, "[0-9]*").Value;

                textContent.ContentInfo.ContentByteSize = Convert.ToDouble(byteCountValue);
                Fechar();
            }
            catch (Exception ex)
            {
                Fechar();
                throw ex;
            }

            return textContent;
        }
    }
}
