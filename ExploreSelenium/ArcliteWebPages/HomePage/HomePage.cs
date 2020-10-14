using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    class HomePage : ArcliteWebPage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        public HomePageXAWE pageInfo;
        IWebDriver _driver;
        public HomePage(WebDriverWait driverWait, IWebDriver driver) : base()
        {
            pageInfo = new HomePageXAWE(this);
            _pageTitle = "Home";
            _driver = driver;
        }
        new public void setElements()
        {

        }


        new public void runTests()
        {

        }

    }
}
