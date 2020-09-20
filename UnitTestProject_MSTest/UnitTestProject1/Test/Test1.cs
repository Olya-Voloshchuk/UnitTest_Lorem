using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using UnitTestProject1.Test;
using UnitTestProject1.WebDriver;

namespace UnitTestProject1
{
    [TestClass]
    public class Test1 : BaseTest


    {
        //private IWebDriver driver;
        private readonly string expectedText = "ðûáà";
        private readonly string startExpectedText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
        private readonly string containsWord = "lorem";
        private readonly int numberWords = 10;
        private readonly int numberBytes = 40;




        [TestMethod]
        public void SwitchToRussianLanguage()
        {
            // GetBasePage().WaitForPageLoadComplete(30);
            Waiters waiters = new Waiters(GetDriver());
            waiters.WaitForPageLoadComplete(30);
            // GetWaiters().WaitForPageLoadComplete(30);
            GetHomePage().SwitchRussianLanguageLink();
            waiters.WaitForPageLoadComplete(30);
            // GetWaiters().WaitForPageLoadComplete(30);
            // GetBasePage().WaitForPageLoadComplete(30);
            string elementText = GetRussianHomePage().GetParagraph().Text;
            Assert.IsTrue(elementText.Contains(expectedText));
        }


        [TestMethod]
        public void GenerateParagraphStartWithIpsum()
        {
            GetHomePage().GetGenerateLoremIpsumButton().Click();
            Waiters waiters = new Waiters(GetDriver());
            waiters.WaitForPageLoadComplete(30);
            string GeneratedParagraphText = GetGenerateLoremPage().GetParagraphFirst().Text;
            Assert.IsTrue(GeneratedParagraphText.StartsWith(startExpectedText));
        }
        [TestMethod]
        public void CheckAvarageContainsWordLoremInParagraph()
        {
            decimal countWord = 0;
            int n = 10;
            for (int i = 1; i <= n; i++)
            {
                GetHomePage().GetGenerateLoremIpsumButton().Click();
                Waiters waiters = new Waiters(GetDriver());
                waiters.WaitForClickableOfElement(20, GetGenerateLoremPage().GetParagraphFirst());
                decimal temp = GetGenerateLoremPage().ParagraphsList1().Count(s => s.ToLowerInvariant().Contains(containsWord));
                countWord += temp;
                GetGenerateLoremPage().GetReturnToHomePageButton().Click();
                waiters.WaitForPageLoadComplete(30);
            }
            decimal avgContainWord = countWord / n;
            if (avgContainWord >= 3)
            {
                Assert.IsTrue(true, "Avarage containing the word “lorem” in paragraph is " + avgContainWord.ToString("0.00") + " and  is greater than 3 ");

                Console.WriteLine(countWord.ToString("0.00"));
            }
            else Assert.Fail("Avarage containing the word “lorem” in paragraph is " + avgContainWord.ToString("0.00") + " and  is less than 3 ");


        }


    }
}
