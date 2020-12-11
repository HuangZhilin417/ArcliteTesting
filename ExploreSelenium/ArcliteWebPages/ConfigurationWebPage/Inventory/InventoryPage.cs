using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.Inventory;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages
{
    /*
     * Repersents the Inventory Page on ArcLite
     */

    public class InventoryPage : ConfigurationsPage, IArclitePage
    {
        new public string _pageTitle;
        new public Dictionary<string, IArcliteWebElement> _pageElements;
        new public InventoryXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Inventory page and initializes page title and all of this page's Xpath
         */

        public InventoryPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Inventory Page";
            _visitor = visitor;

            pageInfo = new InventoryXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Inventory
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);

            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Inventory");
                    addingInventory();
                    System.Console.WriteLine("Finished Adding Inventory");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Inventory");
                    deletingInventory();
                    System.Console.WriteLine("Finished Deleting Inventory");
                    break;
            }
        }

        private void addingInventory()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());

            string randomName = Util.randomString();
            string currentBarCode = inputs.getInput(pageInfo.barcode.Key).valOne;
            inputs.setInput(pageInfo.barcode.Key, new InputVal(currentBarCode + randomName));
            _pageElements[pageInfo.barcode.Key].accept(_visitor, inputs.getInput(pageInfo.barcode.Key));

            _pageElements[pageInfo.inventoryItemType.Key].accept(_visitor, inputs.getInput(pageInfo.inventoryItemType.Key));

            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));

            _pageElements[pageInfo.supplier.Key].accept(_visitor, inputs.getInput(pageInfo.supplier.Key));

            _pageElements[pageInfo.unitCost.Key].accept(_visitor, inputs.getInput(pageInfo.unitCost.Key));

            _pageElements[pageInfo.heldQuantity.Key].accept(_visitor, inputs.getInput(pageInfo.heldQuantity.Key));

            _pageElements[pageInfo.currency.Key].accept(_visitor, inputs.getInput(pageInfo.currency.Key));

            _pageElements[pageInfo.purchaseReceivedDate.Key].accept(_visitor, inputs.getInput(pageInfo.purchaseReceivedDate.Key));

            _pageElements[pageInfo.notes.Key].accept(_visitor, inputs.getInput(pageInfo.notes.Key));

            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deletingInventory()
        {
            string value = inputs.getInput(pageInfo.barcode.Key).valOne;
            string valueTwo = inputs.getInput(pageInfo.inventoryItemType.Key).valOne;
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, new InputVal(value, valueTwo));
        }
    }
}