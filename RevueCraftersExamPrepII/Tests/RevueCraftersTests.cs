using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RevueCraftersExamPrepII.Tests
{
	public class RevueCraftersTests : BaseTest
	{
		private string? lastRevueRandomTitle;
		private string? lastRevueRandomDescription;

		[Test, Order(1)]
		public void Test_CreateRevueWithInvalidData()
		{
			createRevuePage.OpenPage();

			createRevuePage.CreateRevue("", "", "");

			createRevuePage.AssertMainErrorMessage();
		}

		[Test, Order(2)]
		public void Test_CreateRandomRevue()
		{
			lastRevueRandomTitle = "Title: " + GenerateRandomString(7);
			lastRevueRandomDescription = "Description: " + GenerateRandomString(24);

			createRevuePage.OpenPage();

			createRevuePage.CreateRevue(lastRevueRandomTitle, "", lastRevueRandomDescription);

			wait.Until(d => myRevuesPage.AllRevues.Count > 0);

			actions.ScrollToElement(myRevuesPage.AllRevues.Last());

			Console.WriteLine(myRevuesPage.lastRevueTitle.Text);

			Assert.That(myRevuesPage.lastRevueTitle.Text, Is.EqualTo(lastRevueRandomTitle), "Titles do not match!");
		}

		[Test, Order(3)]
		public void Test_SearchForRevueTitle()
		{
			searchPage.OpenPage();

			//var searchField = driver.FindElement(By.Id("keyword"));

			//actions.MoveToElement(searchPage.searchInput).Perform();

			searchPage.searchInput.Clear();

			searchPage.searchInput.SendKeys(myRevuesPage.lastRevueTitle.Text);

			//actions.MoveToElement(searchPage.searchButton).Perform();

			//wait.Until(d => searchPage.searchButton.Displayed);

			searchPage.searchButton.Click();

			Assert.That(myRevuesPage.lastRevueTitle.Text, Is.EqualTo(lastRevueRandomTitle), "Titles do not match!");
		}
	}
}
