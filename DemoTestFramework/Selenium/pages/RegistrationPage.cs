using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.pages
{
    public class RegistrationPage
    {
        private WebDriver _driver;
        private WebDriverWait _wait;

        public RegistrationPage(WebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public RegistrationPage SetEmail(string email)
        {
            _wait.Until(e => e.FindElement(By.Name("email"))).SendKeys(email);
            return this;
        }

        public MainPage SubmitRegistration()
        {
           var element =  _driver.FindElement(By.XPath(Locators.submitButton));
           element.Click();
           return new MainPage(this._driver, _wait);
        }
    }
}