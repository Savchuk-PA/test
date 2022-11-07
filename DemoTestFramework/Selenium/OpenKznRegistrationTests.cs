using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.pages;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;

namespace Selenium
{

    [TestFixture]
    public class OpenKznRegistrationTests : TestBase
    {

        private bool isNeedAuth = true;


        [SetUp]
        public void OneSetup()
        {    
            driver.Navigate().GoToUrl("https://old.kzn.opencity.pro/");
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        

        [Test]
        public void OpenKznRegistrationTesting()
        {
            var mainPage = new MainPage(driver, wait);
            mainPage
                .GetRegistrationPage()
                .SetEmail(Utils.GetRandomEmail())
                .SubmitRegistration();

            bool isDisplayed = wait.Until( e => e.FindElement(By.XPath("//h3[text()='Вы зарегистрированы!']"))
                .Displayed);
           // Thread.Sleep(5000);
            Assert.IsTrue(isDisplayed);
        }


        [Test]
        public void FactoryTesting()
        {
            var mainPage = new MainPage(driver, wait);
            PageFactory.InitElements(driver, mainPage);
            mainPage.Information.Click();
            Assert.AreEqual("https://old.kzn.opencity.pro/information", driver.Url);
        }


        [Test]
        public void PageElementTesting()
        {
            var mainPage = new MainPage(driver, wait);
            mainPage.InformationMenu.onClick();          
            Assert.AreEqual("https://old.kzn.opencity.pro/information", driver.Url);
            
        }
        
    

    }
}