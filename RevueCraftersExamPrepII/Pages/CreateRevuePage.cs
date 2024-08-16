using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevueCraftersExamPrepII.Pages
{
	public class CreateRevuePage : BasePage
	{
        public CreateRevuePage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "/Revue/Create#createRevue";

		public IWebElement TitleField => driver.FindElement(By.Id("form3Example1c"));
		public IWebElement ImageUrlField => driver.FindElement(By.Id("form3Example3c"));
		public IWebElement DescriptionField => driver.FindElement(By.Id("form3Example4cd"));
		public IWebElement CreateButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));
		public IWebElement MainMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));

		public void CreateRevue(string title, string imgUrl, string description)
		{
			TitleField.Clear();
			TitleField.SendKeys(title);

			ImageUrlField.Clear();
			ImageUrlField.SendKeys(imgUrl);

			DescriptionField.Clear();
			DescriptionField.SendKeys(description);

			actions.ScrollToElement(CreateButton).Perform();
			CreateButton.Click();
		}

		public void AssertMainErrorMessage()
		{
			Assert.True(MainMessage.Text.Equals("Unable to create new Revue!"), "Non-correct main message");
		}

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(Url);
		}
	}
}
