using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevueCraftersExamPrepII.Pages
{
	public class LoginPage : BasePage
	{
		
        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "/Users/Login";

        public IWebElement EmailField => driver.FindElement(By.Id("form3Example3"));
        public IWebElement PasswordField => driver.FindElement(By.Id("form3Example4"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block mb-4']"));

		public void LogIn(string email, string password)
		{
			EmailField.SendKeys(email);
			PasswordField.SendKeys(password);

			actions.ScrollToElement(LoginButton).Perform();

			LoginButton.Click();
		}

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(Url);
		}
	}
}
