using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RevueCraftersExamPrepII.Pages;

namespace RevueCraftersExamPrepII.Tests
{
	public class BaseTest
	{
		public IWebDriver driver;
		public Actions actions;
		public WebDriverWait wait;

		public LoginPage loginPage;
		public CreateRevuePage createRevuePage;
		public MyRevuesPage myRevuesPage;
		public SearchPage searchPage;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			var chromeOptions = new ChromeOptions();
			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
			chromeOptions.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(chromeOptions);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			actions = new Actions(driver);

			loginPage = new LoginPage(driver);
			createRevuePage = new CreateRevuePage(driver);
			myRevuesPage = new MyRevuesPage(driver);
			searchPage = new SearchPage(driver);

			loginPage.OpenPage();
			loginPage.LogIn("testuser@abv.bg", "123456");
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		private const string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		public string GenerateRandomString(int length)
		{
			var random = new Random();
			return new string(Enumerable.Range(0, length)
										.Select(_ => CharSet[random.Next(CharSet.Length)])
										.ToArray());
		}
	}
}
