using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Currency
{
    public class CurrencyPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public CurrencyXAWE pageInfo;
        IActionsVisitor _visitor;
        public CurrencyPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Setting Currency";
            _visitor = visitor;
            pageInfo = new CurrencyXAWE(this);
            _pageElements = base.pageElements;
        }

        new public void runTests()
        {
        }
    }
}
