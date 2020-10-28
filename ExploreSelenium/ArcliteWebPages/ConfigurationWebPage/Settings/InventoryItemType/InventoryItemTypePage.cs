using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.InventoryItemType
{
    public class InventoryItemTypePage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public InventoryItemTypeXAWE pageInfo;
        IActionsVisitor _visitor;
        public InventoryItemTypePage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Setting Inventory Item Type";
            _visitor = visitor;
            pageInfo = new InventoryItemTypeXAWE(this);
            _pageElements = base.pageElements;


        }

        new public void runTests()
        {

        }
    }
}
