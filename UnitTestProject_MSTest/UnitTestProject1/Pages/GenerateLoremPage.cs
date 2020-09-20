using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace UnitTestProject1.Pages
{
    public class GenerateLoremPage : BasePage
    {


        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']")]
        public IWebElement ParagraphFirst { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='generated']//a[contains(@href,'lipsum.com')]")]
        public IWebElement ReturnToHomePageButton { get; set; }

        public GenerateLoremPage(IWebDriver driver) : base(driver)
        { }
        public IWebElement GetParagraphFirst() => ParagraphFirst;

        public IWebElement GetReturnToHomePageButton() => ReturnToHomePageButton;

        public List<string> ParagraphsList1() => ParagraphFirst.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

    }

}


