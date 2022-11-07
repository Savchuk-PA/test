using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Selenium.pages;

public class HelpPage : TestBase
{
    private WebDriver _driver;
    private WebDriverWait _wait;
    
    
    public HelpPage(WebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
    [FindsBy(How = How.XPath, Using = "//div[@class = 'answer_accordion background_active']")]
    public IWebElement AnswerText { get; set; }
    
    private List<IWebElement> Answer => _driver.FindElements(By.XPath("//div[@class = 'btn_answer']")).ToList();

    
    public void AnswerClick(int num)
    {
        Answer[num].Click();
        Thread.Sleep(5000);
    }
    
    public void GetHelpPage()
    {
        _driver.Navigate().GoToUrl("https://old.kzn.opencity.pro/cabinet/help");
    }

    public bool AnswerIsVisible()
    {
        return AnswerText.Displayed;
    }


}
