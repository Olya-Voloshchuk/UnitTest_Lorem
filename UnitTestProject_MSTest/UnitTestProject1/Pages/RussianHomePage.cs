using OpenQA.Selenium;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace UnitTestProject1.Pages
{
    public class RussianHomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='Panes']//div[1]//p")]
        public IWebElement Paragraph { get; set; }
        public RussianHomePage(IWebDriver driver) : base(driver)
        { }
        public IWebElement GetParagraph() => Paragraph;
    }

}
