using ExploreSelenium.ArcliteWebElements;
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
        private string _pageTitle;
        private Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        public HomePage(WebDriverWait driverWait) : base(driverWait)
        {
            _wait = driverWait;
            _pageTitle = "HomePage";
            _pageElements = base.pageElements;
        }

    }
}
