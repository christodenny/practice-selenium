using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Protractor;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        NgWebDriver ngDriver;
        const string URL = "http://juliemr.github.io/protractor-demo/";
        ChromeDriver chrome;
        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\Users\U6031204\Documents\chromedriver_win32\");
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            ngDriver = new NgWebDriver(driver);
        }

        [TestMethod]
        public void TestMethod1()
        {

            ngDriver.Url = URL; // navigate to URL

            ngDriver.FindElement(NgBy.Input("first")).SendKeys("1");
            ngDriver.FindElement(NgBy.Input("second")).SendKeys("2");
            ngDriver.FindElement(By.Id("gobutton")).Click();


            var latestResult = ngDriver.FindElement(NgBy.Binding("latest")).Text;
            Assert.AreEqual(latestResult, "3");
            //latestResult.Should().Be("3");

            //firefox = new FirefoxDriver();
            /*chrome = new ChromeDriver(@"C:\Users\U6031204\Documents\chromedriver_win32\");
            chrome.Navigate().GoToUrl("http://www.google.com/");
            chrome.FindElement(By.Id("lst-ib")).SendKeys("Google");
            chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);*/
        }

        // This closes the driver down after the test has finished.
        [TestCleanup]
        public void TearDown()
        {
            //chrome.Quit();
            ngDriver.Quit();
        }
    }
}
