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
    public class SchedulerPage : ArcliteWebPage
    {
        private string _pageTitle;
        private Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        IActionsVisitor _visitor;
        public SchedulerPage(WebDriverWait driverWait, IActionsVisitor visitor)
        {
            _wait = base.wait;
            _pageTitle = "Scheduler";
            _pageElements = base.pageElements;
            _visitor = visitor;
            setElements();
        }

        new public void setElements()
        {


        }

    }
}
