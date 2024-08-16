using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace RevueCraftersExamPrepII.Pages
{
	public class BasePage
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;
        public Actions actions;

        protected static string BaseUrl = "https://d3s5nxhwblsjbi.cloudfront.net";

        
		public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            actions = new Actions(driver);
        }

        public IWebElement HomeLink => driver.FindElement(By.XPath("//a[@class='navbar-brand']"));
        public IWebElement MyRevuesLink => driver.FindElement(By.XPath("//a[@class='nav-link active']"));
        public IWebElement CreateRevueLink => driver.FindElement(By.XPath("//a[@class='nav-link']"));
        public IWebElement LogoutLink => driver.FindElement(By.XPath("//a[@class='nav-link text-dark' and text()='Logout']"));
    }
}
