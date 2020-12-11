using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Suppliers;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage
{
    /*
     * Repersents the Suppliers Page on ArcLite
     */

    public class SuppliersPage : ConfigurationsPage, IArclitePage
    {
        new public string _pageTitle;
        new public Dictionary<string, IArcliteWebElement> _pageElements;
        new public SuppliersXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Suppliers page and initializes page title and all of this page's Xpath
         */

        public SuppliersPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Suppliers Page";
            _visitor = visitor;
            pageInfo = new SuppliersXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Suppliers
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Supplier");
                    addingSupplier();
                    System.Console.WriteLine("Finished Adding Supplier");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Supplier");
                    deletingSupplier();
                    System.Console.WriteLine("Finished Deleting Supplier");
                    break;

                default:
                    break;
            }
        }

        private void addingSupplier()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());

            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.suppliersCode.Key].accept(_visitor, inputs.getInput(pageInfo.suppliersCode.Key));
            _pageElements[pageInfo.contactName.Key].accept(_visitor, inputs.getInput(pageInfo.contactName.Key));
            _pageElements[pageInfo.secondaryNumber.Key].accept(_visitor, inputs.getInput(pageInfo.secondaryNumber.Key));
            _pageElements[pageInfo.email.Key].accept(_visitor, inputs.getInput(pageInfo.email.Key));

            _pageElements[pageInfo.address.Key].accept(_visitor, inputs.getInput(pageInfo.address.Key));
            _pageElements[pageInfo.notes.Key].accept(_visitor, inputs.getInput(pageInfo.notes.Key));
            _pageElements[pageInfo.personInCharge.Key].accept(_visitor, inputs.getInput(pageInfo.personInCharge.Key));
            _pageElements[pageInfo.description.Key].accept(_visitor, inputs.getInput(pageInfo.description.Key));

            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deletingSupplier()
        {
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}