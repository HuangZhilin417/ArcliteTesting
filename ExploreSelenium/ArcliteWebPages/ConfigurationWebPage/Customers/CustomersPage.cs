using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Customers
{
    public class CustomersPage : ConfigurationsPage, IArclitePage
    {
        new public string _pageTitle;
        new public Dictionary<string, IArcliteWebElement> _pageElements;
        new public CustomersXAWE pageInfo;
        IActionsVisitor _visitor;
        public CustomersPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Customers Page";
            _visitor = visitor;
            pageInfo = new CustomersXAWE(this);
            _pageElements = base.pageElements;
        }

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true);
            switch (action)
            {
                case ArcliteTestAction.add:
                    addingCustomer();
                    break;
                case ArcliteTestAction.delete:
                    deletingCustmer();
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

