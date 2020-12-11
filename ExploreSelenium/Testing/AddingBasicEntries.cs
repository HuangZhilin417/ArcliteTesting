// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using ExploreSelenium.ArcliteWebPages;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Assets;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Checklists;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Customers;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Personnel;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.AssetTypeManager;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Currency;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.InventoryItemType;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.LocationManager;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Qualification;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Unit;
using ExploreSelenium.ArcliteWebPages.Workflow_Builder;
using ExploreSelenium.BaseCkass;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ExploreSelenium
{
    [TestFixture]
    public class AddingBasicEntries : BaseTest
    {
        private static readonly int x = 5;

        [Test, Category("AddFirst"), OrderAttribute(first)]
        public void addingInventoryType()
        {
            IArclitePage unit = new UnitPage(visitor, inputs);
            unit.runTests(ArcliteTestAction.add);
            Thread.Sleep(longSleepTime);
            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);
            IArclitePage inventory = new InventoryItemTypePage(visitor, inputs);
            inventory.runTests(ArcliteTestAction.add);
        }

        [Test, Category("AddFirst"), OrderAttribute(first)]
        public void addingQualification()
        {
            IArclitePage qualificationPage = new QualificationPage(visitor, inputs);
            qualificationPage.runTests(ArcliteTestAction.add);
        }

        [Test, Category("AddFirst"), OrderAttribute(first)]
        public void addingAsset()
        {
            IArclitePage assetType = new AssetTypeManagerPage(visitor, inputs);
            assetType.runTests(ArcliteTestAction.add);
            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);
            IArclitePage asset = new AssetsPage(visitor, inputs);
            asset.runTests(ArcliteTestAction.add);
        }

        [Test, Category("AddFirst"), OrderAttribute(first)]
        public void addingLocation()
        {
            IArclitePage location = new LocationManagerPage(visitor, inputs);
            location.runTests(ArcliteTestAction.add);
        }

        [Test, Category("AddFirst"), OrderAttribute(first)]
        public void addingCurrency()
        {
            IArclitePage currency = new CurrencyPage(visitor, inputs);
            currency.runTests(ArcliteTestAction.add);
        }

        [Test, Category("AddSecond"), OrderAttribute(second)]
        public void addWorkFlow()
        {
            IArclitePage personnel = new PersonnelPage(visitor, inputs);
            personnel.runTests(ArcliteTestAction.add);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage customer = new CustomersPage(visitor, inputs);
            customer.runTests(ArcliteTestAction.add);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage supplier = new SuppliersPage(visitor, inputs);
            supplier.runTests(ArcliteTestAction.add);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage inventory = new InventoryPage(visitor, inputs);
            inventory.runTests(ArcliteTestAction.add);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage workflow = new WorkflowBuilderPage(visitor, inputs);
            workflow.runTests(ArcliteTestAction.add);
        }

        [Test, Category("AddThird"), OrderAttribute(thrid)]
        public void pushSalesOrder()
        {
            IArclitePage checklist = new ChecklistsPage(visitor, inputs);
            checklist.runTests(ArcliteTestAction.add);
            checklist.runTests(ArcliteTestAction.approve);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage addSalesOrder = new OrderTrackingAndManagementPage(visitor, inputs);
            addSalesOrder.runTests(ArcliteTestAction.add);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            //clicks the sales order
            IWebElement salesOrder = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='arc-scheduler-jobs']")));
            salesOrder.Click();

            Thread.Sleep(longSleepTime);

            //clicks the jobs to schedule
            IWebElement jobsToSchedule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='jobs-to-schedule']")));
            jobsToSchedule.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //search for customer
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblJobsGrid_length']/input")));
            searchInput.SendKeys("BCisaFB");

            //div[@id='tblJobsGrid_length']/button[@id='btnSearch']
            //clicks the search button
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblJobsGrid_length']/button[@id='btnSearch']")));
            search.Click();

            //clicks the check button
            IWebElement checkJobBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='BCisaFB']/parent::tr/td/div/label")));
            checkJobBox.Click();

            //clicks the gear button
            IWebElement schedule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblJobsGrid_filter']/button[@id='btnSchedule']")));
            schedule.Click();
        }

        [Test, Category("AddFourth"), OrderAttribute(fourth)]
        public void completeWorkStation()
        {
            IArclitePage workstation = new WorkstationsPage(visitor, inputs);
            workstation.runTests(ArcliteTestAction.add);
        }

        [Test, Category("deleteFirst"), OrderAttribute(fifth)]
        public void deleteChecklist()
        {
            IArclitePage sales = new OrderTrackingAndManagementPage(visitor, inputs);
            sales.runTests(ArcliteTestAction.delete);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage checklist = new ChecklistsPage(visitor, inputs);
            checklist.runTests(ArcliteTestAction.delete);
        }

        [Test, Category("deleteFirst"), OrderAttribute(fifth)]
        public void deleteWorkflow()
        {
            IArclitePage workflow = new WorkflowBuilderPage(visitor, inputs);
            workflow.runTests(ArcliteTestAction.delete);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage supplier = new SuppliersPage(visitor, inputs);
            supplier.runTests(ArcliteTestAction.delete);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage customer = new CustomersPage(visitor, inputs);
            customer.runTests(ArcliteTestAction.delete);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage asset = new AssetsPage(visitor, inputs);
            asset.runTests(ArcliteTestAction.delete);
        }

        [Test, Category("deleteSecond"), OrderAttribute(sixth)]
        public void disablePersonnel()
        {
            IArclitePage personnelPage = new PersonnelPage(visitor, inputs);
            personnelPage.runTests(ArcliteTestAction.delete);
        }

        [Test, Category("deleteSecond"), OrderAttribute(sixth)]
        public void deleteBaseSettings()
        {
            IArclitePage assetType = new AssetTypeManagerPage(visitor, inputs);
            assetType.runTests(ArcliteTestAction.delete);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage qualification = new QualificationPage(visitor, inputs);
            qualification.runTests(ArcliteTestAction.delete);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage currency = new CurrencyPage(visitor, inputs);
            currency.runTests(ArcliteTestAction.delete);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage location = new LocationManagerPage(visitor, inputs);
            location.runTests(ArcliteTestAction.delete);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage inventoyType = new InventoryItemTypePage(visitor, inputs);
            inventoyType.runTests(ArcliteTestAction.delete);

            visitor.switchToParentFrame();
            Thread.Sleep(longSleepTime);

            IArclitePage unit = new UnitPage(visitor, inputs);
            unit.runTests(ArcliteTestAction.delete);
        }
    }
}