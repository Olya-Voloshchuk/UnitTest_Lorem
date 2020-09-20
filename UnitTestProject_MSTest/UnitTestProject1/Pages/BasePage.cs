using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1.Pages
{
    public class BasePage
    {
        readonly IWebDriver driver;

        
            public BasePage(IWebDriver driver)
            {
                this.driver = driver;
           PageFactory.InitElements(driver, this);
        }
     /*   public void WaitForPageLoadComplete(int timeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait)).Until(
                    a => ((IJavaScriptExecutor)a).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForClickableOfElement(int timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        */


    }
}
