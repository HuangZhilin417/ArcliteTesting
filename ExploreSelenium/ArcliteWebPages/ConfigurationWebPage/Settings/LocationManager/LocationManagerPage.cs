using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.LocationManager
{
    public class LocationManagerPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public LocationManagerXAWE pageInfo;
        IActionsVisitor _visitor;
        public LocationManagerPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Setting Location Manager";
            _visitor = visitor;
            pageInfo = new LocationManagerXAWE(this);
            _pageElements = base.pageElements;


        }

        new public void runTests()
        {
        }
    }
}
