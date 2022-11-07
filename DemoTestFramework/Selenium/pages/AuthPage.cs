using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.pages;

public class AuthPage : TestBase
{
    private WebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement _authBtn => _driver.FindElement(By.XPath("//a[@data-ui='auth']"));
    private IWebElement _inputUserName => _driver.FindElement(By.Name("username"));
    private IWebElement _inputPasswor => _driver.FindElement(By.Name("password"));

    public AuthPage(WebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public MainPage Authorization2(string login, string password)
    {
        _wait.Until(e => e.FindElement(By.XPath("//a[@data-ui='auth']")).Displayed);
        _authBtn.Click();
        _inputUserName.SendKeys(login);
        _inputPasswor.SendKeys(password);
        Thread.Sleep(5000);
        _driver.Navigate().GoToUrl("https://old.kzn.opencity.pro/information");
        Thread.Sleep(5000);
        
        _driver.Manage().Cookies.AddCookie(new Cookie("PHPSESSID", "62464fkn9igif7gkrfrmfkh6h0"));
        _driver.Manage().Cookies.AddCookie(new Cookie("token",
            "{\"expired\":\"2022-10-12+16:30:23\",\"token\":\"b2da1668a3be6aaca882948c51d60a6eb32866a5\",\"key\":\"OAuth\",\"refresh\":\"e348ccebaa31ca68ab654b44f47d1da12c4c77d1\",\"refreshExpired\":\"2022-12-10+16:30:23\"}"));
        _driver.Manage().Cookies.AddCookie(new Cookie("_ym_uid", "1639659381772082907"));
        _driver.Manage().Cookies.AddCookie(new Cookie("_ym_d", "1663948815"));
        _driver.Manage().Cookies.AddCookie(new Cookie("slider", "6"));
        _driver.Manage().Cookies.AddCookie(new Cookie("_ym_isad", "2"));
        _driver.Manage().Cookies.AddCookie(new Cookie("YII_CSRF_TOKEN", "f6c3ce5ce28d64d0a9b5c95717c894a76f8dc101"));
        _driver.Navigate().GoToUrl("https://old.kzn.opencity.pro/cabinet/");

        return new MainPage(_driver, _wait);
    }

}