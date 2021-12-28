using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium.Support.UI;



namespace Selenium.ExcelSignIn
{
	[TestClass]
	public class ExcelSignIn
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

		public void Excel_MultiCell()

		{
			Excel.Application xlApp;
			Excel.Workbook xlWorkBook;
			Excel.Worksheet xlWorkSheet;
			Excel.Range range;

            string email;
            string passw;
            int rCnt, cCnt;

            xlApp = new Excel.Application();
			xlWorkBook = xlApp.Workbooks.Open(@"C:\....xlsx");
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;


            driver.Navigate().GoToUrl("https://hlrbo.com/");

            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    //Get the string from the sheet
                    for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
                    {
                        for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                        {
                           //login
                            driver.FindElement(By.XPath("//*[@id='fat-menu']")).Click();

                            email = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            IWebElement emailAddress = driver.FindElement(By.Id("emailAddressTextBox"));
                            string lowerstr2 = email.ToLower();
                            emailAddress.SendKeys(lowerstr2);

                            passw = (string)(range.Cells[rCnt, cCnt + 1] as Excel.Range).Value2;
                            IWebElement password = driver.FindElement(By.Id("passwordTextBox"));
                            password.SendKeys(passw);
                            driver.FindElement(By.XPath("//*[@id='signInButton']")).Click();
                            break;
                        }

                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        IWebElement home = wait.Until<IWebElement>((d) =>
                        {
                            return d.FindElement(By.ClassName("standardHeader"));
                        });

                        //myaccount
                        driver.FindElement(By.XPath("//*[@id='controlPanelSection']/ul/li[3]/a")).Click();
                        driver.FindElement(By.XPath("//ul//li[3]//a[@id='lnkLogout']")).Click();
                        WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                    }
                    break;
                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
        }
	}
}
