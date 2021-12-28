using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;



namespace Selenium.FileUpload
{
    [TestClass]
    public class FileUpload
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

        public void UploadPhoto()

        {

            driver.Navigate().GoToUrl("https://twitter.com/");
            driver.FindElement(By.XPath("//div//a[@href='/login']")).Click();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            IWebElement emailAddress = driver.FindElement(By.XPath("//div//input[@autocomplete='username']"));
            emailAddress.SendKeys("");

            IWebElement nextBtn = driver.FindElement(By.XPath("//div[@class='css-18t94o4 css-1dbjc4n r-sdzlij r-1phboty r-rs99b7 r-ywje51 r-usiww2 r-2yi16 r-1qi8awa r-1ny4l3l r-ymttw5 r-o7ynqc r-6416eg r-lrvibr r-13qz1uu']"));
            nextBtn.Click();

            IWebElement password = driver.FindElement(By.XPath("//div//input[@autocomplete='current-password']"));
            password.SendKeys("");

            driver.FindElement(By.XPath("//div[@data-testid='LoginForm_Login_Button']")).Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement home = wait2.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath("//a[@aria-label='Profile']"));
            });


            driver.FindElement(By.XPath("//a[@aria-label='Profile']")).Click();
            driver.FindElement(By.XPath("//a[@href='/settings/profile']")).Click();

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElement(By.CssSelector("input[data-testid='fileInput']")).SendKeys(@"C:\...\Desktop\puppy.jpg");

            driver.FindElement(By.CssSelector("div[class='css-18t94o4 css-1dbjc4n r-42olwf r-sdzlij r-1phboty r-rs99b7 r-15ysp7h r-4wgw6l r-1ny4l3l r-ymttw5 r-o7ynqc r-6416eg r-lrvibr']")).Click();
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElement(By.XPath("//div[@data-testid='Profile_Save_Button']")).Click();
            
            driver.FindElement(By.XPath("//div[@aria-label='Account menu']")).Click();
            driver.FindElement(By.XPath("//div//a[@href='/logout']")).Click();
            driver.FindElement(By.XPath("//div[@data-testid='confirmationSheetConfirm']")).Click();

            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }
    }
}

