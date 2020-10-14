using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    class WorkstationPage : ArcliteWebPage
    {
        private string _pageTitle;
        private Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        IActionsVisitor _visitor;
        public WorkstationPage(WebDriverWait driverWait, IActionsVisitor visitor)
        {
            _wait = base.wait;
            _pageTitle = "Workstation";
            _pageElements = base.pageElements;
            _visitor = visitor;
            setElements();
        }

        new public void setElements()
        {


        }
    }
}
