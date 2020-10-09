using ExploreSelenium.ArcliteWebElements;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    class ArcliteWebPage : IArclitePage
    {
        private string _pageTitle;
        private Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        public ArcliteWebPage(WebDriverWait driverWait)
        {
            _wait = driverWait;
            _pageTitle = "defaultPage";
            _pageElements = new Dictionary<string, IArcliteWebElement>();
            this.setElements();
        }

        public ArcliteWebPage()
        {
            _pageTitle = "defaultPage";
            _pageElements = new Dictionary<string, IArcliteWebElement>();
        }

        public string pageTitle { get => _pageTitle; set => _pageTitle = value; }


        public Dictionary<string, IArcliteWebElement> pageElements { get => _pageElements; }
        public WebDriverWait wait { get => _wait; set => _wait = value; }

        public void setElements()
        {
            Console.WriteLine("old");
            IArcliteWebElement home = new ArcliteWebElement("Home", "//a/i[@class='fa fa-home arc-fa-2x']", ArcliteWebElementType.Button, _wait);
            IArcliteWebElement orderTracking = new ArcliteWebElement("Order Tracking & Manangement", "//a[@id='arc-scheduler-sales']", ArcliteWebElementType.Button, _wait);
            IArcliteWebElement scheduler = new ArcliteWebElement("Scheduler", "//a[@id='arc-scheduler-jobs']", ArcliteWebElementType.Button, _wait);
            IArcliteWebElement workstation = new ArcliteWebElement("Workstation", "//a[@id='arc-workstation']", ArcliteWebElementType.Button, _wait);
            IArcliteWebElement dashboard = new ArcliteWebElement("Dashboard", "//a[@id='arc-dashboard']", ArcliteWebElementType.Button, _wait);
            IArcliteWebElement workflowBuilder = new ArcliteWebElement("Workflow Builder", "//a[@id='arc-workflow-builder']", ArcliteWebElementType.Button, _wait);
            IArcliteWebElement settings = new ArcliteWebElement("Configuration", "//a[@id='arc-config']", ArcliteWebElementType.Button, _wait);
            IArcliteWebElement user = new ArcliteWebElement("User Information", "//li[@class='nav-item dropdown']/a", ArcliteWebElementType.Button, _wait);
            this._pageElements.Add(home.elementName, home);
            this._pageElements.Add(orderTracking.elementName, orderTracking);
            this._pageElements.Add(scheduler.elementName, scheduler);
            this._pageElements.Add(workstation.elementName, workstation);
            this._pageElements.Add(dashboard.elementName, dashboard);
            this._pageElements.Add(workflowBuilder.elementName, workflowBuilder);
            this._pageElements.Add(settings.elementName, settings);
            this._pageElements.Add(user.elementName, user);

        }
    }



}
