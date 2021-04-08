using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Assi1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            { 
                string url = "https://ieeexplore.ieee.org/document/4055450"; //Setting URL Of chrome Web store for Extension
                string[] Topics = new string[4] { "Internalizing Disorders", "Intelligence Tests", "Machine Learning", "Entropy of Isolated System" };
                Random rg = new Random();
                int randomNumber = rg.Next(0, 3);
                string Topic = Topics[randomNumber];

                var driverOptions = new ChromeOptions();
                driverOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                ChromeDriver driver = new ChromeDriver(driverOptions); // Creating Chrome Web Driver Object named driver

                driver.Navigate().GoToUrl(url); //Navigate to set Url.


                driver.FindElement(By.ClassName("stats-Unav_P_SignIn")).Click();
                driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("");
                driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("");
                driver.FindElement(By.TagName("Button")).Click();
                Thread.Sleep(10000);

                driver.FindElement(By.TagName("input")).SendKeys(Topic + Keys.Enter);

                Thread.Sleep(4000);

                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");

                driver.FindElementByClassName("results-actions-selectall-checkbox").Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,0)");
                driver.FindElement(By.TagName("xpl-download-pdf")).Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,100)");
                driver.FindElement(By.ClassName("downloadpdf-predl-proceed-button")).Click();
                driver.Quit();

            }
            catch
            {

            }
        }
    }
}
