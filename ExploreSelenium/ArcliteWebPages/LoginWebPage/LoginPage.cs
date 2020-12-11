using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages
{
    /*
    * Repersents the Login Page on ArcLite
    */

    public class LoginPage : ArcliteWebPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public LoginPageXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Login page and initializes page title and all of this page's Xpath
         */

        public LoginPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "LoginPage";
            _visitor = visitor;
            pageInfo = new LoginPageXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Login Page, which only logs in to arclite
         */

        new public void runTests(ArcliteTestAction action)
        {
            _pageElements[pageInfo.username.Key].accept(_visitor, inputs.getInput(pageInfo.username.Key));
            _pageElements[pageInfo.password.Key].accept(_visitor, inputs.getInput(pageInfo.password.Key));
            _pageElements[pageInfo.signIn.Key].accept(_visitor, new InputVal());
        }
    }
}