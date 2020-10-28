using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Unit
{
    public class UnitPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public UnitXAWE pageInfo;
        IActionsVisitor _visitor;
        public UnitPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Setting Unit";
            _visitor = visitor;
            pageInfo = new UnitXAWE(this);
            _pageElements = base.pageElements;


        }

        new public void runTests()
        {
        }
    }
}
