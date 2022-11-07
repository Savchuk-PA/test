using OpenQA.Selenium;

namespace Selenium.pages
{
    public class Menu
    {
        private IWebElement menuItem;
        
        public Menu(WebDriver driver, string url)
        {
            this.menuItem = driver.FindElement(By.XPath($"//ul[@id='topItemsMenu']//li/a[@href='/{url}']"));
        }

        public void onClick()
        {
            this.menuItem.Click();
        }

        public string getText()
        {
            return menuItem.Text;
        }
    }
}