using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Customers
{
    /*
     * Repersents the Customers Page on ArcLite
     */

    public class CustomersPage : ConfigurationsPage, IArclitePage
    {
        new public string _pageTitle;
        new public Dictionary<string, IArcliteWebElement> _pageElements;
        new public CustomersXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Customers page and initializes page title and all of this page's Xpath
         */

        public CustomersPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Customers Page";
            _visitor = visitor;
            pageInfo = new CustomersXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Customer
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Customer");
                    addingCustomer();
                    System.Console.WriteLine("Finished Adding Customer");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("deleting Customer");
                    deletingCustmer();
                    System.Console.WriteLine("Finished deleting Customer");
                    break;

                default:
                    break;
            }
        }

        private void addingCustomer()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());

            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.customerCode.Key].accept(_visitor, inputs.getInput(pageInfo.customerCode.Key));
            _pageElements[pageInfo.contactName.Key].accept(_visitor, inputs.getInput(pageInfo.contactName.Key));
            _pageElements[pageInfo.secondaryNumber.Key].accept(_visitor, inputs.getInput(pageInfo.secondaryNumber.Key));
            _pageElements[pageInfo.email.Key].accept(_visitor, inputs.getInput(pageInfo.email.Key));

            _pageElements[pageInfo.deliveryAddress.Key].accept(_visitor, inputs.getInput(pageInfo.deliveryAddress.Key));
            _pageElements[pageInfo.notes.Key].accept(_visitor, inputs.getInput(pageInfo.notes.Key));
            _pageElements[pageInfo.personInCharge.Key].accept(_visitor, inputs.getInput(pageInfo.personInCharge.Key));

            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deletingCustmer()
        {
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}