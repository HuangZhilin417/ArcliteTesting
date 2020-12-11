using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings
{
    /*
     * Repersents the Settings Page on ArcLite
     */

    public class SettingsPage : ArcliteWebPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public SettingsXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Settings page and initializes page title and all of this page's Xpath
         */

        public SettingsPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Settings Page";
            _visitor = visitor;
            pageInfo = new SettingsXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Settings
         */

        new public void runTests()
        {
        }
    }
}