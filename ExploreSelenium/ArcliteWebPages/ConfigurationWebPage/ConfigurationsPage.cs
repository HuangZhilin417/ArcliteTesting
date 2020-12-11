using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.ConfigurationPage;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages
{
    /*
     * Repersents the Configurations Page on ArcLite
     */

    public class ConfigurationsPage : ArcliteWebPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public ConfigurationXAWE pageInfo;
        private IActionsVisitor _visitor;
        public IArcliteInputs inputs;

        /*
         * Creates a Configuration page and initializes page title and all of this page's Xpath and with specific inputs
         */

        public ConfigurationsPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            this.inputs = base.inputs;
            base.pageTitle = "Configuration";
            _visitor = visitor;
            pageInfo = new ConfigurationXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * Creates a Configuration page and initializes page title and all of this page's Xpath without specific inputs
         */

        public ConfigurationsPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Configuration";
            _visitor = visitor;
            pageInfo = new ConfigurationXAWE(this);
            _pageElements = base.pageElements;
        }
    }
}