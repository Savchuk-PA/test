using System;
using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium
{
    public class TestBase
    {
        protected WebDriver driver;
        protected WebDriverWait wait;
        protected JObject testData;
        protected IJavaScriptExecutor executor;
        
        
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var option = new ChromeOptions();

            // Отключение "Браузером управляет автоматизированное ПО"
            option.AddAdditionalChromeOption("useAutomationExtension", false);
            option.AddExcludedArgument("enable-automation"); 
            // option.AddArgument("headless"); -- браузер не открывается
            
            driver = new ChromeDriver(@"C:\Tools\", option);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            executor = driver;

            var path = Utils.GetFilePathByFileName("testData.json");
            testData = JObject.Parse(File.ReadAllText(path));

        }
        public static void WaitElementIsVisble(IWebDriver diver, By locator, int seconds = 5)
        {
            new WebDriverWait(diver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
        }
        
        public static void WaitElementIsClickable(IWebDriver diver, By locator, int seconds = 5)
        {
            new WebDriverWait(diver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        

        [OneTimeTearDown]
        public void OneTearDown()
        {
            driver.Quit();
        }
        
        protected void Authorization(string login,  string password)
        {
            driver.FindElement(By.XPath("//a[@data-ui='auth']")).Click();
            driver.FindElement(By.Name("username")).SendKeys(login);
            driver.FindElement(By.Name("password")).SendKeys(password);
            /*wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(
                By.XPath("//iframe[@title='reCAPTCHA']")));
            var check = wait.Until(e => e.FindElement(By.Id("recaptcha-anchor")));
            check.Click();

            driver.SwitchTo().ParentFrame();*/
            driver.Manage().Cookies.AddCookie(new Cookie("PHPSESSID", "62464fkn9igif7gkrfrmfkh6h0"));  
            driver.Manage().Cookies.AddCookie(new Cookie("token", "{\"expired\":\"2022-10-12+16:30:23\",\"token\":\"b2da1668a3be6aaca882948c51d60a6eb32866a5\",\"key\":\"OAuth\",\"refresh\":\"e348ccebaa31ca68ab654b44f47d1da12c4c77d1\",\"refreshExpired\":\"2022-12-10+16:30:23\"}"));
            driver.Manage().Cookies.AddCookie(new Cookie("_ym_uid", "1639659381772082907"));
            driver.Manage().Cookies.AddCookie(new Cookie("_ym_d", "1663948815"));
            driver.Manage().Cookies.AddCookie(new Cookie("slider", "6"));
            driver.Manage().Cookies.AddCookie(new Cookie("_ym_isad", "2"));
            driver.Manage().Cookies.AddCookie(new Cookie("YII_CSRF_TOKEN", "f6c3ce5ce28d64d0a9b5c95717c894a76f8dc101"));
            driver.Navigate().GoToUrl("https://old.kzn.opencity.pro/cabinet/");
            
        }

    }
}