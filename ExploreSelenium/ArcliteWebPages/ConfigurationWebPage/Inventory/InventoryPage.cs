using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    public class InventoryPage : ConfigurationsPage, IArclitePage
    {
        new public string _pageTitle;
        new public Dictionary<string, IArcliteWebElement> _pageElements;
        new public InventoryXAWE pageInfo;
        IActionsVisitor _visitor;
        public InventoryPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Inventory Page";
            _visitor = visitor;
            pageInfo = new InventoryXAWE(this);
            _pageElements = base.pageElements;
        }

        new public void runTests(ArcliteTestAction action)
        {
           Util.navigateToWeb(this, _visitor, true);
          
            switch (action)
            {
                case ArcliteTestAction.add:
                    addingInventory();
                    break;
                case ArcliteTestAction.delete:
                    deletingInventory();
                    break;
            }
        }
        private void addingInventory()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());
   
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

            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.barcode.Key));
        }
    }


}
