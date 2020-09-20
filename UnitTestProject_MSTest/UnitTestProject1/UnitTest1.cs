using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest


    {
        private IWebDriver driver;
        private readonly string expectedText = "ðûáà";
        private readonly string startExpectedText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
        private readonly string containsWord = "lorem";
        private readonly int numberWords = 10;
        private readonly int numberBytes = 40;

        [TestInitialize]
        public void Setup()
        {


            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://lipsum.com/");
        }




        public void WaitForPageLoadComplete(int timeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait)).Until(
                    a => ((IJavaScriptExecutor)a).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForVisibilityOfElement(int timeToWait, By Xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Xpath));
        }

        [TestMethod]
        public void SwitchToRussianLanguage()
        {


            IWebElement lanSwitch = driver.FindElement(By.XPath("//a[contains(@href,'ru.lipsum')]"));
            lanSwitch.Click();
            WaitForPageLoadComplete(30);
            IWebElement firstParagraph = driver.FindElement(By.XPath("//*[@id='Panes']//div[1]//p"));
            string elementText = firstParagraph.Text;
            Assert.IsTrue(elementText.Contains(expectedText));


        }

        [TestMethod]
        public void GenerateParagraphStartWithIpsum()
        {
            IWebElement GenerateLoremIpsum = driver.FindElement(By.XPath("//input[@id='generate']"));
            GenerateLoremIpsum.Click();
            WaitForPageLoadComplete(30);
            IWebElement GeneratedParagraph = driver.FindElement(By.XPath("//div[@id='lipsum']"));
            string GeneratedParagraphText = GeneratedParagraph.Text;
            Assert.IsTrue(GeneratedParagraphText.StartsWith(startExpectedText));
        }

        [TestMethod]
        public void CountTheWords()
        {
            WaitForPageLoadComplete(30);

            IWebElement RadioButtonWords = driver.FindElement(By.XPath("//input[@id='words']"));
            RadioButtonWords.Click();
            IWebElement InputNumberField = driver.FindElement(By.XPath("//input[@id='amount']"));
            InputNumberField.Clear();
            InputNumberField.SendKeys(numberWords.ToString());
            InputNumberField.Submit();
            WaitForPageLoadComplete(30);
            IWebElement GeneratedParagraph = driver.FindElement(By.XPath("//div[@id='lipsum']"));
            string generatedParagraphText = GeneratedParagraph.Text;
            int countWords = generatedParagraphText.Split(' ').Length;

            Assert.AreEqual(countWords, numberWords);


        }
        [TestMethod]
        public void CountTheBytes()
        {
            WaitForPageLoadComplete(30);

            IWebElement RadioButtonBytes = driver.FindElement(By.XPath("//input[@id='bytes']"));
            RadioButtonBytes.Click();
            IWebElement InputNumberField = driver.FindElement(By.XPath("//input[@id='amount']"));
            InputNumberField.Clear();
            InputNumberField.SendKeys(numberBytes.ToString());
            InputNumberField.Submit();
            WaitForPageLoadComplete(60);
            IWebElement GeneratedParagraph = driver.FindElement(By.XPath("//div[@id='lipsum']"));
            string generatedParagraphText = GeneratedParagraph.Text;
            int countBytes = generatedParagraphText.Length;
            Assert.AreEqual(countBytes, numberBytes);


        }
        [TestMethod]
        public void GenerateParagraphStartWithNotIpsum()
        {

            IWebElement GenerateLoremIpsumStartWord = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            GenerateLoremIpsumStartWord.Click();
            IWebElement GenerateLoremIpsum = driver.FindElement(By.XPath("//input[@id='generate']"));
            GenerateLoremIpsum.Click();
            WaitForVisibilityOfElement(90, By.XPath("//div[@id='lipsum']"));
            IWebElement GeneratedParagraph = driver.FindElement(By.XPath("//div[@id='lipsum']"));
            string GeneratedParagraphText = GeneratedParagraph.Text;
            Assert.IsFalse(GeneratedParagraphText.StartsWith(startExpectedText));


        }
        [TestMethod]
        public void CheckContainsLoremInParagraph()
        {

            decimal countWord = 0;
            int n = 3;

            for (int i = 1; i <= n; i++)
            {
                IWebElement GenerateLoremIpsum = driver.FindElement(By.XPath("//input[@id='generate']"));
                GenerateLoremIpsum.Click();
                WaitForVisibilityOfElement(20, By.XPath("//div[@id='lipsum']"));
                IWebElement GeneratedParagraph = driver.FindElement(By.XPath("//div[@id='lipsum']"));
                List<string> paragraphsList = GeneratedParagraph.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                decimal temp = paragraphsList.Count(s => s.ToLowerInvariant().Contains(containsWord));
                countWord += temp;
                driver.Navigate().GoToUrl("https://lipsum.com/");
                WaitForPageLoadComplete(60);
            }
            decimal avgContainWord = countWord / n;
            if (avgContainWord >= 3)
            {
                Assert.IsTrue(true, "Avarage containing the word “lorem” in paragraph is greater than" + avgContainWord.ToString());
            }
            else Assert.Fail("Avarage containing the word “lorem” in paragraph is less than" + avgContainWord.ToString());
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
