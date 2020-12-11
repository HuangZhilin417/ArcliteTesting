using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebPages;
using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ExploreSelenium.BaseCkass
{
    /*
     * Settings of running selenium tests
     */

    public class BaseTest
    {
        public const int order = 2;
        public IWebDriver driver;
        private String ArcliteUsername = "admin";
        public IActionsVisitor visitor;
        private String ArclitePassword = "admin";
        public WebDriverWait wait;
        public IArcliteInputs inputs = new ArcliteInputValues();
        public const int first = 1;
        public const int second = 1 + first;
        public const int thrid = 1 + second;
        public const int fourth = 1 + thrid;
        public const int afterAdd = 1 + fourth;
        public const int beforeDelete = 1 + afterAdd;
        public const int fifth = 1 + beforeDelete;
        public const int sixth = 1 + fifth;
        private String webAddress = "http://182.77.61.134/arclite.uat";
        public int longSleepTime = 4000;
        public int shortSleepTime = 2000;
        public int count = 0;

        /*
         * setting up the web browser after starting test
         */

        [SetUp]
        public void Open()
        {
            if (count == 0)
            {
                webAddress = Interaction.InputBox("Please Eneter URL for Arclite:", "Arclite URL", "http://182.77.61.134/arclite.uat", -1, -1);
            }
            count++;
            //Setting the way to load elements on chrome, so it has less timeout errors
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Default;
            chromeOptions.AddArgument("no-sandbox");
            driver = new ChromeDriver(chromeOptions)
            {
                Url = webAddress
            };

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            visitor = new ArcliteActionVisitor(wait, driver);

            //Login to ArcLite
            IArclitePage login = new LoginPage(visitor, inputs);
            login.runTests(ArcliteTestAction.login);
        }

        /*
         * close web browser after testing complete
         */

        [TearDown]
        public void Close()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}