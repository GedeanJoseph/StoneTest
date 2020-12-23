using System;
using StoneTest.Crawler.WebModule.Interfaces;
using StoneTest.Crawler.Commom.Models;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace StoneTest.Crawler.WebModule
{
    public class TextContentAnalyze : WebProviderBase, ITextContentAnalyzer
    {
        public TextContentAnalyze(bool headLessModeActivated) : base(headLessModeActivated)
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

                var byteCountValue = Regex.Match(byteCountResult, "[0-9]*").Value;//GET ONLY NUMERIC VALUES FROM STRING ^.^

                textContent.ContentInfo.ContentByteSize = Convert.ToDouble(byteCountValue);
                Fechar();
                return textContent;
            }
            catch (Exception)
            {
                Fechar();
                return GetTextDetailsFallBack(textContent);                
            }
        }

        public TextContent GetTextDetailsFallBack(TextContent textContent)
        {
            textContent.ContentInfo = new ContentInfo() { ContentByteSize = System.Text.ASCIIEncoding.UTF8.GetByteCount(textContent.Content.ToString())};
            return textContent;
        }
    }
}
