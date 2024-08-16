using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevueCraftersExamPrepII.Pages
{
	public class MyRevuesPage : BasePage
	{
        public MyRevuesPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "/MyRevues#createRevue";

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public IReadOnlyCollection<IWebElement> AllRevues => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        public IWebElement LastRevueEditButton => AllRevues.Last().FindElement(By.XPath("//a[@class='btn btn-sm btn-outline-secondary' and text()='Edit']"));
        public IWebElement LastRevueDeleteButton => AllRevues.Last().FindElement(By.XPath("//a[@class='btn btn-sm btn-outline-secondary' and text()='Delete']"));
		public IWebElement lastRevueTitle => AllRevues.Last().FindElement(By.CssSelector(".text-muted"));
        public IWebElement searchField => driver.FindElement(By.XPath("//input[@type='search']"));
        public IWebElement searchButton => driver.FindElement(By.Id("search-button"));
	}
}
