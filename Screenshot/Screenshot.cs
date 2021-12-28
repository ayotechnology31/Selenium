using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Screenshot
{
    [TestClass]
    public class Screenshot
    {
        IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]

        public void TakeScreenshot()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            //identify dropdown
            IWebElement i = driver.FindElement(By.CssSelector("input[name='q']"));
            //scroll to dropdown
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", i);
            i.Click();
            //capture screenshot along file name
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm");
            string localFolder = @"C:\...\Desktop\";
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(localFolder + timestamp + " .png", ScreenshotImageFormat.Png);

        }
    }
}