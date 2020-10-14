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
using ExploreSelenium.ArcliteWebPages;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.BaseCkass
{
    public class BaseTest 
    {
        public CurrentPage currentPage;
        public IWebDriver driver;
        private String ArcliteUsername = "admin";
        public IActionsVisitor visitor;
        private String ArclitePassword = "admin";
        public WebDriverWait wait;

        private String webAddress = "http://182.77.61.134/arclite.uat";

        //setting up the driver and the wait driver
        [SetUp]
        public void Open()
        {
            
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Default;
            driver = new ChromeDriver(chromeOptions)
            {
                Url = webAddress
            };

            driver.Manage().Window.Maximize();
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IArclitePage login = new LoginPage(wait, driver);
            login.runTests();
            currentPage = new CurrentPage(login, wait, visitor);

            currentPage.pageElements["Username"].accept(visitor, ArcliteUsername);
            currentPage.pageElements["Password"].accept(visitor, ArclitePassword);
            currentPage.pageElements["Sign In"].accept(visitor, "");
            /*      IWebElement Username = currentPage.pageElements["Username"].webElement;
                  Username.SendKeys(ArcliteUsername);
                  IWebElement Password = currentPage.pageElements["Password"].webElement;
                  Password.SendKeys(ArclitePassword);
                  IWebElement loginBtn = currentPage.pageElements["Sign In"].webElement;
                  loginBtn.Click();*/
        }

        [TearDown]
        public void Close()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
