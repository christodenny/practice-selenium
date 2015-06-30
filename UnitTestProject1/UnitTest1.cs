using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
        //const string URL = "https://www.google.com";
        [TestInitialize]
        public void Initialize()
        {
            //driver = new ChromeDriver(@"C:\Users\U6031204\Documents\chromedriver_win32\");
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(20));
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
            Assert.AreEqual(latestResult, "6");

            /*ngDriver.FindElement(By.Name("q")).SendKeys("Google");
            ngDriver.FindElement(By.Name("q")).SendKeys(Keys.Enter);*/
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
