using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Selenium
{
    public class  RemoteExample
    {

        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            TimeSpan timeSpan = new TimeSpan(0, 3, 0);
            string urlGrid = "http://localhost:4444/wd/hub";

            ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments();
            _driver = new RemoteWebDriver(new Uri(urlGrid), chromeOptions.ToCapabilities(), timeSpan);
        }

        [TearDown]
        public void After()
        {
            _driver.Quit();
        }

        [Test]
        public void GoogleExampleTesting()
        {
            _driver.Navigate().GoToUrl("https://google.com");
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Name("q")).SendKeys("SELENIUM Grid example");
            
            string actualPathFile = Utils.GetFilePathByFileName(@"screens/remote/google.png");
            
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenshot.SaveAsFile(actualPathFile);
            Assert.True(File.Exists(actualPathFile));
        }
    }
}