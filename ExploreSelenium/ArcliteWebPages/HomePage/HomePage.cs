using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages
{
    /*
    * Repersents the Home Page on ArcLite, which is simply the page after users login
    */

    public class HomePage : ArcliteWebPage, IArclitePage
    {
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public HomePageXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Home page and initializes page title and all of this page's Xpath
         */

        public HomePage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Home";
            _visitor = visitor;
            pageInfo = new HomePageXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs test for home page, which is currently empty
         */

        new public void runTests()
        {
        }
    }
}