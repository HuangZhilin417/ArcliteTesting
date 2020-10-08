using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace ExploreSelenium.BaseCkass
{
    public class BaseTest
    {
        public IWebDriver driver;
        private String ArcliteUsername = "admin";

        private String ArclitePassword = "admin";
        public WebDriverWait wait;
        private String webAddress = "http://182.77.61.134/arclite.uat";
        public Dictionary<String, int> order;

        //setting up the driver and the wait driver
        [SetUp]
        public void Open()
        {
            order = new Dictionary<string, int>();
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Default;
            driver = new ChromeDriver(chromeOptions)
            {
                Url = webAddress
            };
            driver.Manage().Window.Maximize();
            order.Add("Add first", 1);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));


            IWebElement Username = driver.FindElement(By.XPath(".//*[@id='UserName']"));
            Username.SendKeys(ArcliteUsername);
            IWebElement Password = driver.FindElement(By.XPath(".//*[@id='Password']"));
            Password.SendKeys(ArclitePassword);
            IWebElement loginBtn = driver.FindElement(By.XPath(".//*[@id='btnlogin']"));
            loginBtn.Click();
        }

        [TearDown]
        public void Close()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
