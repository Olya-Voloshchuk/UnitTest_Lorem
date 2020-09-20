using OpenQA.Selenium;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace UnitTestProject1.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'ru.lipsum')]")]
        public IWebElement RussianLanguage { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")]
        public IWebElement GenerateLoremIpsumButton;
        public HomePage(IWebDriver driver) : base(driver)
        { }
        public void SwitchRussianLanguageLink() => RussianLanguage.Click();
        public IWebElement GetGenerateLoremIpsumButton() => GenerateLoremIpsumButton;
    }
}
