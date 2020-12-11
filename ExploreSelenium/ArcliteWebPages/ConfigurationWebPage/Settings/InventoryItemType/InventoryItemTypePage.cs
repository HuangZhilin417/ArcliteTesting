using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.InventoryItemType
{
    /*
     * Repersents the Inventory Item Type Page on ArcLite
     */

    public class InventoryItemTypePage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public InventoryItemTypeXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Inventory Item Type page and initializes page title and all of this page's Xpath
         */

        public InventoryItemTypePage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Setting Inventory Item Type";
            _visitor = visitor;
            pageInfo = new InventoryItemTypeXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Inventory Item Type
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Inventory Item Type");
                    addingInventoryItemType();
                    System.Console.WriteLine("Finished Adding Inventory Item Type");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Inventory Item Type");
                    deleteInventoryItemType();
                    System.Console.WriteLine("Finished Deleting Inventory Item Type");
                    break;

                default:
                    break;
            }
        }

        private void addingInventoryItemType()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());

            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.description.Key].accept(_visitor, inputs.getInput(pageInfo.description.Key));
            _pageElements[pageInfo.minimumQuantity.Key].accept(_visitor, inputs.getInput(pageInfo.minimumQuantity.Key));
            _pageElements[pageInfo.maximumQuantity.Key].accept(_visitor, inputs.getInput(pageInfo.maximumQuantity.Key));
            _pageElements[pageInfo.reorderQuantity.Key].accept(_visitor, inputs.getInput(pageInfo.reorderQuantity.Key));
            _pageElements[pageInfo.unit.Key].accept(_visitor, inputs.getInput(pageInfo.unit.Key));

            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deleteInventoryItemType()
        {
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}