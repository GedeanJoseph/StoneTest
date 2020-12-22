using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace StoneTest.Crawler.WebModule
{
    public class WebProviderBase
    {
        private IConfiguration _configuration;
        public IWebDriver _driver;
        private string _pathDriver;

        public WebProviderBase(string pathDriver)
        {
            //_configuration = configuration;
            _pathDriver = pathDriver;
            DriverBuilder();
        }

        private void DriverBuilder()
        {
            try
            {
                ChromeOptions chromeOptions = new ChromeOptions() { };
                //chromeOptions.AddArgument("--headless");
                _driver = new ChromeDriver(_pathDriver,chromeOptions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PageLoad(string url)
        {
            _driver.LoadPage(
                TimeSpan.FromSeconds(5),
                url);
        }

        public void SetFieldTextValue(string fieldName, string valor)
        {
            _driver.SetText(
                By.Name(fieldName),
                valor.ToString());
        }

        public void PageFormSubmit(string submitButtonName,string waitForElementId)
        {
            _driver.Submit(By.Id(submitButtonName));

            WebDriverWait wait = new WebDriverWait(
                _driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id(waitForElementId)) != null);
        }

        public string GetValueFromElementById(string elementId)
        {
            try
            {
                return _driver.GetText(By.Id(elementId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public string GetValueFromElementByClass(string elementClassName)
        {
            try
            {
               return _driver.GetText(By.ClassName(elementClassName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }                     
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }


    }
}
