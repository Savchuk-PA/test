using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Selenium.pages;

namespace Selenium;
[TestFixture]
public class Test : TestBase
{
    private JObject testUser;
    
    [SetUp]
    public void OneSetup()
    {    
        testUser = (JObject) testData["testUser2"];
        driver.Navigate().GoToUrl("https://old.kzn.opencity.pro/");
        Authorization(testUser["login"].ToString(), testUser["password"].ToString());
    }
    
    
    [Test]
    public void ClosePushToMainPage()
    {
       
    }
    [TearDown]
    public void TearDown()
    {
        driver.Close();
    }
}