using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.SalesOrderPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace ExploreSelenium.ArcliteWebPages
{
    class OrderTrackingAndManagementPage : ArcliteWebPage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        public OrderTrackingAndManagementXAWE pageInfo;
        IWebDriver _driver;
        IActionsVisitor _visitor;
        public OrderTrackingAndManagementPage(WebDriverWait driverWait, IWebDriver driver, IActionsVisitor visitor) : base()
        {
            _wait = driverWait;
            _pageElements = base.pageElements;
            pageInfo = new OrderTrackingAndManagementXAWE(this);
            base.pageTitle = "Order Tracking & Manangement";
            _driver = driver;
            _visitor = visitor;

        }
        new public void runTests()
        {
        }
    }
}
