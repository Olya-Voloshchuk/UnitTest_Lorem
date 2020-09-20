using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.Pages;

namespace UnitTestProject1.Test
{
    public class BaseTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://lipsum.com/");
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
        public BasePage GetBasePage() => new BasePage(GetDriver());

        public HomePage GetHomePage() => new HomePage(GetDriver());

        public RussianHomePage GetRussianHomePage() => new RussianHomePage(GetDriver());

        public GenerateLoremPage GetGenerateLoremPage() => new GenerateLoremPage(GetDriver());
        // public Waiters GetWaiters() => new Waiters(GetDriver());
    }
}
