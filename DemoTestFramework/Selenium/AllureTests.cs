using Allure.Commons;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;


namespace Selenium
{

    //https://docs.nunit.org/articles/nunit/writing-tests/attributes/parallelizable.html
    [TestFixture]
    [AllureNUnit]
    //  [Parallelizable(scope: ParallelScope.All )]
    public class AllureTests : TestBase
    {

        private bool isNeedAuth = true;
        private JObject testUser;
        private bool isNeedScreenEtalon = false;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            //driver = new ChromeDriver();
            testUser = (JObject) testData["testUser2"];
            driver.Navigate().GoToUrl("https://old.kzn.opencity.pro/");
            Authorization(testUser["login"].ToString(), testUser["password"].ToString());
        }
        
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test(Description = "XXX")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void OpenKznAuth1Testing()
        {
            var element = driver.FindElement(By.XPath("//div[@class='username']/span"));
            Assert.AreEqual(testUser["login"].ToString(), element.Text);
        }
    }
}