using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages
{
    /*
    * Repersents the Dashboard Page on ArcLite
    */

    public class DashboardPage : ArcliteWebPage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        public DashboardPageXAWE pageInfo;

        /*
        * Creates a Dashboard page and initializes page title and all of this page's Xpath
        */

        public DashboardPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            pageInfo = new DashboardPageXAWE(this);
            base.pageTitle = "Dashboard";
        }

        /*
         * runs the test for Dashboard
         */

        new public void runTests()
        {
        }
    }
}