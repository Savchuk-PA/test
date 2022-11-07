using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Selenium.pages
{
    public class MainPage : TestBase
    {
        private WebDriver _driver;
        private WebDriverWait _wait;

        [FindsBy(How = How.XPath, Using = "//ul[@id='topItemsMenu']//li/a[@href='/information']")]
        public IWebElement Information { get; set; }

        [FindsBy(How = How.CssSelector)] public IWebElement About { get; set; }
        
        public Menu InformationMenu;
        public Menu AboutMenu;

        public MainPage(WebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            InformationMenu = new Menu(driver, "information");
            AboutMenu = new Menu(driver, "aboutproject");
            //PageFactory.InitElements(_driver, this);
        }



        public RegistrationPage GetRegistrationPage()
        {
            IWebElement registration = _wait.Until(e => e.FindElement(By.XPath("//a[@data-ui='registration']")));
            registration.Click();
            return new RegistrationPage(_driver, _wait);
        }
    }
}