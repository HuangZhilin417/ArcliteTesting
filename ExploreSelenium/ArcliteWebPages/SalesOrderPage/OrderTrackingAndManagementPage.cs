using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.SalesOrderPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;

namespace ExploreSelenium.ArcliteWebPages
{
    /*
     * Repersents the Order Tracking And Management Page on ArcLite
     */

    public class OrderTrackingAndManagementPage : ArcliteWebPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        public OrderTrackingAndManagementXAWE pageInfo;
        private IWebDriver _driver;
        private IActionsVisitor _visitor;

        /*
         * Creates a Order Tracking And Management page and initializes page title and all of this page's Xpath
         */

        public OrderTrackingAndManagementPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            _pageElements = base.pageElements;
            pageInfo = new OrderTrackingAndManagementXAWE(this);
            base.pageTitle = "Order Tracking & Manangement";
            _visitor = visitor;
        }

        /*
         * runs the test for Order Tracking And Management page
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Sales Order");
                    addingSalesOrder();
                    System.Console.WriteLine("Finished Adding Sales Order");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Sales Order");
                    deleteSalesOrder();
                    System.Console.WriteLine("Finished Deleting Sales Order");
                    break;

                default:
                    break;
            }
        }

        private void addingSalesOrder()
        {
            _pageElements[pageInfo.addSalesOrder.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.quotation.Key].accept(_visitor, inputs.getInput(pageInfo.quotation.Key));
            _pageElements[pageInfo.customer.Key].accept(_visitor, inputs.getInput(pageInfo.customer.Key));
            _pageElements[pageInfo.order.Key].accept(_visitor, inputs.getInput(pageInfo.order.Key));
            _pageElements[pageInfo.details.Key].accept(_visitor, inputs.getInput(pageInfo.details.Key));
            Thread.Sleep(shortSleepTime);
            _pageElements[pageInfo.requestedEndDate.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.saveDraft.Key].accept(_visitor, new InputVal());
            getSalesOrderId();
            addJobInAddSalesOder();
            addCheckListInJob();
            _pageElements[pageInfo.submit.Key].accept(_visitor, new InputVal());
        }

        private void getSalesOrderId()
        {
            Thread.Sleep(6000);
            string id = _pageElements[pageInfo.id.Key].getValue(_visitor);
            inputs.setInput(pageInfo.dataTable.Key, new InputVal(id));
        }

        private void addJobInAddSalesOder()
        {
            _pageElements[pageInfo.addJobs.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.jobNotes.Key].accept(_visitor, inputs.getInput(pageInfo.quotation.Key));
            _pageElements[pageInfo.jobFinishedGoodItemType.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.jobFinishedGoodItemOther.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.jobFinishedGoodItemTable.Key].accept(_visitor, inputs.getInput(pageInfo.jobFinishedGoodItemTable.Key));
            _pageElements[pageInfo.jobFinishedGoodItemQuantity.Key].accept(_visitor, inputs.getInput(pageInfo.jobFinishedGoodItemQuantity.Key));
            Thread.Sleep(shortSleepTime);
            _pageElements[pageInfo.jobFinishedGoodItemConfirm.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.jobSelectWorkflow.Key].accept(_visitor, inputs.getInput(pageInfo.jobSelectWorkflow.Key));
            _pageElements[pageInfo.jobDone.Key].accept(_visitor, new InputVal());
        }

        private void addCheckListInJob()
        {
            _pageElements[pageInfo.addChecklist.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.checkListTable.Key].accept(_visitor, inputs.getInput(pageInfo.checkListTable.Key));
            _pageElements[pageInfo.checkListDone.Key].accept(_visitor, new InputVal());
        }

        private void deleteSalesOrder()
        {
            System.Diagnostics.Debug.WriteLine("in delete");
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.dataTable.Key));
        }
    }
}