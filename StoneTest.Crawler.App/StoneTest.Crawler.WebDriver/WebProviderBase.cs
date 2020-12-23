using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace StoneTest.Crawler.WebModule
{
    public class WebProviderBase:IDisposable
    {
        public IWebDriver _driver;
        private string _pathDriver;
        private bool _headLessModeActivated;

        public WebProviderBase(bool headLessModeActivated)
        {
            _pathDriver = Path.Combine(Directory.GetCurrentDirectory(), "Driver"); ;
            _headLessModeActivated = headLessModeActivated;
        }

        private void DriverBuilder()
        {
            if (_driver == null)
            {
                try
                {

                    ChromeOptions chromeOptions = new ChromeOptions() { };

                    //this not throw browser to load de pages
                    if (_headLessModeActivated)
                        chromeOptions.AddArgument("--headless");

                    //to execute in silent mode
                    ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService(_pathDriver);
                    chromeService.SuppressInitialDiagnosticInformation = true;
                    chromeOptions.AddArgument("--silent");
                    chromeOptions.AddArgument("--log-level=3");
                    chromeOptions.AddArgument("--disable-logging");

                    _driver = new ChromeDriver(chromeService, chromeOptions);
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
        }

        public void PageLoad(string url)
        {
            DriverBuilder();

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
            if(_driver!= null)
                _driver.Quit();
            
            _driver = null;
        }

        public void Dispose()
        {
            Fechar();
        }
    }
}
