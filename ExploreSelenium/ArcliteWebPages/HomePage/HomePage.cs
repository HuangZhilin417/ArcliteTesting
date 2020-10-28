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
    class HomePage : ArcliteWebPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public HomePageXAWE pageInfo;
        IActionsVisitor _visitor;
        public HomePage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Home";
            _visitor = visitor;
            pageInfo = new HomePageXAWE(this);
            _pageElements = base.pageElements;

        }


        new public void runTests()
        {

        }

    }
}
