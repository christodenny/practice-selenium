using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
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
            String browser = Environment.GetEnvironmentVariable("Browser");
            switch (browser)
            {
                case "CHROME":
                    driver = new ChromeDriver();
                    break;
                case "FIREFOX":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
            }
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(20));
            ngDriver = new NgWebDriver(driver);
        }

        [TestMethod]
        public void TestMethod1()
        {

            System.Diagnostics.Debug.Write("path "+System.IO.Directory.GetCurrentDirectory());

            ngDriver.Url = URL; // navigate to URL

            ngDriver.FindElement(NgBy.Input("first")).SendKeys("1");
            ngDriver.FindElement(NgBy.Input("second")).SendKeys("2");
            ngDriver.FindElement(By.Id("gobutton")).Click();


            var latestResult = ngDriver.FindElement(NgBy.Binding("latest")).Text;
            Assert.AreEqual(latestResult, "3");

            /*ngDriver.FindElement(By.Name("q")).SendKeys("Google");
            ngDriver.FindElement(By.Name("q")).SendKeys(Keys.Enter);*/
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Environment.SetEnvironmentVariable("Browser", "FIREFOX");
            String var = Environment.GetEnvironmentVariable("Browser");
            Console.Write(var);
            if (!(var.Equals("FIREFOX") || var.Equals("IE") || var.Equals("CHROME")))
            {
                Assert.AreEqual(3, 4);
            }
            else
            {
                Assert.AreEqual(3, 3);
            }
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
