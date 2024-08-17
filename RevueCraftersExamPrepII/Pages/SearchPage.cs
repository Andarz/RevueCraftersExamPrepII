using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevueCraftersExamPrepII.Pages
{
	public class SearchPage : BasePage
	{
        public SearchPage(IWebDriver driver) : base(driver)
        {
            
        }

		public string Url = BaseUrl + "/Revue/MyRevues";

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(Url);
		}

		public IWebElement searchField => driver.FindElement(By.CssSelector(".input-group.mb-xl-5"));

		public IWebElement searchInput => driver.FindElement(By.Name("keyword"));

		public IWebElement searchButton => driver.FindElement(By.Id("search-button"));
	}
}
