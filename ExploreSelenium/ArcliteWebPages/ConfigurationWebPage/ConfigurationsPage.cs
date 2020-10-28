using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.ConfigurationPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    public class ConfigurationsPage : ArcliteWebPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public ConfigurationXAWE pageInfo;
        IActionsVisitor _visitor;
        public IArcliteInputs inputs;
        public ConfigurationsPage(IActionsVisitor visitor) : base(visitor)
        {
            inputs = base.inputs;
            base.pageTitle = "Configuration";
            _visitor = visitor;
            pageInfo = new ConfigurationXAWE(this);
            _pageElements = base.pageElements;


        }

        new public void runTests()
        {
        }
    }
}
