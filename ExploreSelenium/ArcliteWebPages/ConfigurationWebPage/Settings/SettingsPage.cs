using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings
{
    class SettingsPage : ArcliteWebPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public SettingsXAWE pageInfo;
        IActionsVisitor _visitor;
        public SettingsPage(IActionsVisitor visitor) : base()
        {
            base.pageTitle = "Settings Page";
            _visitor = visitor;
            pageInfo = new SettingsXAWE(this);
            _pageElements = base.pageElements;
        }

        new public void runTests()
        {
        }
    }
}
