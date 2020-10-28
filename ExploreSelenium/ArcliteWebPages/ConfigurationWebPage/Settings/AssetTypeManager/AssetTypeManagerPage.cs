using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.AssetTypeManager
{
    public class AssetTypeManagerPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public AssetTypeManagerXAWE pageInfo;
        IActionsVisitor _visitor;
        public AssetTypeManagerPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Setting Asset Type";
            _visitor = visitor;
            pageInfo = new AssetTypeManagerXAWE(this);
            _pageElements = base.pageElements;


        }

        new public void runTests()
        {
        }
    }
}
