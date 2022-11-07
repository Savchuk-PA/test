using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Selenium.pages;

public class NotificationPage : TestBase
{
    private WebDriver _driver;
    
    public NotificationPage(WebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
    [FindsBy(How = How.XPath, Using = "//button[@class='align-right secondary slidedown-button']")]
    public IWebElement NotificationBtnNot { get; set; }

    public void NotificationClickNot()
    {
        WaitElementIsClickable(_driver, By.XPath("//button[@class='align-right secondary slidedown-button']"));
        NotificationBtnNot.Click();
    }


    
    
}