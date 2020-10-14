using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.DashBoardPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    class DashboardPage : ArcliteWebPage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        public DashboardPageXAWE pageInfo;
        IWebDriver _driver;
        public DashboardPage(WebDriverWait driverWait, IWebDriver driver)
        {
            pageInfo = new DashboardPageXAWE(this);
            _pageTitle = "Dashboards";
            _driver = driver;
        }

        new public void runTests()
        {
        }

    }
}
